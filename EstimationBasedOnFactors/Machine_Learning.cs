using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace EstimationBasedOnFactors
{
    public class Machine_Learning
    {
        static List<string[]> myRules = new List<string[]>();
        static Stack<string> myRule = new Stack<string>();

        public static void Rule_Generation()
        {
            myRules.Clear();
            myRule.Clear();
            List<Attribute> all_Attribute = new List<Attribute>();
            List<Factor> all_factors = Factor.ReadFromXml();
            for (int i = 0; i < all_factors.Count; i++)
            {
                string atr_name = all_factors[i].Name;
                string[] atr_values = new string[all_factors[i].MembershipFunctions.Count];
                for (int j = 0; j < atr_values.Length; j++)
                {
                    atr_values[j] = all_factors[i].MembershipFunctions[j].Name;
                }
                all_Attribute.Add(new Attribute(atr_name, atr_values));
            }

            Attribute[] attributes = all_Attribute.ToArray();
            string all_rules = "";
            int slot_num = 1;
            for (slot_num = 1; slot_num < 6; slot_num++)
            {
                myRules.Clear();
                DataTable samples = getDataTable(attributes, slot_num);

                DecisionTreeID3 id3 = new DecisionTreeID3();
                TreeNode root = id3.mountTree(samples, "result", attributes);

                GetRules(root);

                string rule = "";
                for (int i = 0; i < myRules.Count; i++)
                {
                    rule = "";
                    rule += "(defrule Slot_Num_" + slot_num.ToString() + "_" + "Rule_Num_" + (i + 1).ToString() + "\n\t";
                    rule += "(sharedfile ?path)\n\t";
                    rule += "(case\n\t\t";
                    rule += "(id ?id)\n\t\t";
                    for (int j = 0; j < myRules[i].Length; j++)
                    {
                        rule += myRules[i][j];
                        if (j == myRules[i].Length - 1)
                            rule += "\n\t";
                        else
                            rule += "\n\t\t";
                    }
                    rule += ")\n\t=>\n\t(assert(case_output (id ?id) (time slot" + slot_num.ToString() + ") ))\n\t";
                    rule += "(save-facts ?path visible case_output)\n)\n\n";
                    //(defrule test
                    //    (sharedfile ?path)
                    //    (case
                    //        (id ?id)
                    //        (height short)
                    //    )
                    //    =>
                    //    (assert(case_output (id ?id) (time slot1) ))
                    //    (save-facts ?path visible case_output)
                    //)
                    all_rules += rule;
                }
            }
            File.WriteAllText(Constants.RulesInputsClipsFile, all_rules);
        }

        static void GetRules(TreeNode root)
        {
            if (root.attribute.ToString() == true.ToString())
            {
                myRules.Add(myRule.ToArray());
            }
            else
            {

                if (root.attribute.values != null)
                {
                    for (int i = 0; i < root.attribute.values.Length; i++)
                    {
                        TreeNode childNode = root.getChildByBranchName(root.attribute.values[i]);
                        myRule.Push("(" + root.attribute.AttributeName + " " + root.attribute.values[i] + ")");
                        GetRules(childNode);
                        myRule.Pop();
                    }
                }
            }
        }

        static int GetTimeSlot(string min_s)
        {
            int min = Convert.ToInt32(min_s);
            if (min > 0 && min <= 10)
                return 1;
            else if (min > 10 && min <= 20)
                return 2;
            else if (min > 20 && min <= 30)
                return 3;
            else if (min > 30 && min <= 40)
                return 4;
            else if (min > 40 && min <= 50)
                return 5;
            else if (min > 50 && min <= 60)
                return 6;
            else
                return -1;

        }

        static DataTable getDataTable(Attribute[] attributes, int time_slot)
        {
            DataTable result = new DataTable("Time_Slot_" + time_slot.ToString());

            DataColumn column;
            for (int i = 0; i < attributes.Length; i++)
            {
                column = result.Columns.Add(attributes[i].AttributeName);
                column.DataType = typeof(string);
            }
            column = result.Columns.Add("result");
            column.DataType = typeof(bool);

            List<Case> all_Cases = Case.ReadFromXml();
            List<object[]> people = new List<object[]>(all_Cases.Count);
            for (int w = 0; w < all_Cases.Count; w++)
            {
                people.Add(new object[attributes.Length + 1]);
                for (int i = 0; i < attributes.Length; i++)
                {
                    people[w][i] = all_Cases[w].Attributes[attributes[i].AttributeName];
                }
                people[w][attributes.Length] = (time_slot == GetTimeSlot(all_Cases[w].ActualOutput));
                result.Rows.Add(people[w]);
            }

            return result;
        }
    }

    public class Attribute
    {
        ArrayList mValues;
        string mName;
        object mLabel;

        public Attribute(string name, string[] values)
        {
            mName = name;
            mValues = new ArrayList(values);
            mValues.Sort();
        }

        public Attribute(object Label)
        {
            mLabel = Label;
            mName = string.Empty;
            mValues = null;
        }

        public string AttributeName
        {
            get
            {
                return mName;
            }
        }


        public string[] values
        {
            get
            {
                if (mValues != null)
                    return (string[])mValues.ToArray(typeof(string));
                else
                    return null;
            }
        }


        public bool isValidValue(string value)
        {
            return indexValue(value) >= 0;
        }


        public int indexValue(string value)
        {
            if (mValues != null)
                return mValues.BinarySearch(value);
            else
                return -1;
        }


        public override string ToString()
        {
            if (mName != string.Empty)
            {
                return mName;
            }
            else
            {
                return mLabel.ToString();
            }
        }
    }

    public class TreeNode
    {
        private ArrayList mChilds = null;
        private Attribute mAttribute;


        public TreeNode(Attribute attribute)
        {
            if (attribute.values != null)
            {
                mChilds = new ArrayList(attribute.values.Length);
                for (int i = 0; i < attribute.values.Length; i++)
                    mChilds.Add(null);
            }
            else
            {
                mChilds = new ArrayList(1);
                mChilds.Add(null);
            }
            mAttribute = attribute;
        }


        public void AddTreeNode(TreeNode treeNode, string ValueName)
        {
            int index = mAttribute.indexValue(ValueName);
            mChilds[index] = treeNode;
        }


        public int totalChilds
        {
            get
            {
                return mChilds.Count;
            }
        }


        public TreeNode getChild(int index)
        {
            return (TreeNode)mChilds[index];
        }


        public Attribute attribute
        {
            get
            {
                return mAttribute;
            }
        }


        public TreeNode getChildByBranchName(string branchName)
        {
            int index = mAttribute.indexValue(branchName);
            return (TreeNode)mChilds[index];
        }
    }

    public class DecisionTreeID3
    {
        private DataTable mSamples;
        private int mTotalPositives = 0;
        private int mTotal = 0;
        private string mTargetAttribute = "result";
        private double mEntropySet = 0.0;

        private int countTotalPositives(DataTable samples)
        {
            int result = 0;

            foreach (DataRow aRow in samples.Rows)
            {
                if ((bool)aRow[mTargetAttribute] == true)
                    result++;
            }

            return result;
        }

        private double calcEntropy(int positives, int negatives)
        {
            int total = positives + negatives;
            if (total == 0)
                return 0;
            double ratioPositive = (double)positives / total;
            double ratioNegative = (double)negatives / total;

            if (ratioPositive != 0)
                ratioPositive = -(ratioPositive) * System.Math.Log(ratioPositive, 2);
            if (ratioNegative != 0)
                ratioNegative = -(ratioNegative) * System.Math.Log(ratioNegative, 2);

            double result = ratioPositive + ratioNegative;

            return result;
        }

        private void getValuesToAttribute(DataTable samples, Attribute attribute, string value, out int positives, out int negatives)
        {
            positives = 0;
            negatives = 0;

            foreach (DataRow aRow in samples.Rows)
            {
                if (((string)aRow[attribute.AttributeName] == value))
                    if ((bool)aRow[mTargetAttribute] == true)
                        positives++;
                    else
                        negatives++;
            }
        }

        private double gain(DataTable samples, Attribute attribute)
        {
            string[] values = attribute.values;
            double sum = 0.0;

            for (int i = 0; i < values.Length; i++)
            {
                int positives, negatives;

                positives = negatives = 0;

                getValuesToAttribute(samples, attribute, values[i], out positives, out negatives);

                double entropy = calcEntropy(positives, negatives);
                sum += -(double)(positives + negatives) / mTotal * entropy;
            }
            return mEntropySet + sum;
        }

        private Attribute getBestAttribute(DataTable samples, Attribute[] attributes)
        {
            double maxGain = 0.0;
            Attribute result = null;

            foreach (Attribute attribute in attributes)
            {
                double aux = gain(samples, attribute);
                if (aux > maxGain)
                {
                    maxGain = aux;
                    result = attribute;
                }
            }
            return result;
        }

        private bool allSamplesPositives(DataTable samples, string targetAttribute)
        {
            foreach (DataRow row in samples.Rows)
            {
                if ((bool)row[targetAttribute] == false)
                    return false;
            }

            return true;
        }

        private bool allSamplesNegatives(DataTable samples, string targetAttribute)
        {
            foreach (DataRow row in samples.Rows)
            {
                if ((bool)row[targetAttribute] == true)
                    return false;
            }

            return true;
        }

        private ArrayList getDistinctValues(DataTable samples, string targetAttribute)
        {
            ArrayList distinctValues = new ArrayList(samples.Rows.Count);

            foreach (DataRow row in samples.Rows)
            {
                if (distinctValues.IndexOf(row[targetAttribute]) == -1)
                    distinctValues.Add(row[targetAttribute]);
            }

            return distinctValues;
        }

        private object getMostCommonValue(DataTable samples, string targetAttribute)
        {
            ArrayList distinctValues = getDistinctValues(samples, targetAttribute);

            int[] count = new int[distinctValues.Count];

            foreach (DataRow row in samples.Rows)
            {
                int index = distinctValues.IndexOf(row[targetAttribute]);
                count[index]++;
            }

            int MaxIndex = 0;
            int MaxCount = 0;

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > MaxCount)
                {
                    MaxCount = count[i];
                    MaxIndex = i;
                }
            }

            return distinctValues[MaxIndex];
        }

        private TreeNode internalMountTree(DataTable samples, string targetAttribute, Attribute[] attributes)
        {
            if (allSamplesPositives(samples, targetAttribute) == true)
                return new TreeNode(new Attribute(true));

            if (allSamplesNegatives(samples, targetAttribute) == true)
                return new TreeNode(new Attribute(false));
            mTargetAttribute = targetAttribute;
            mTotalPositives = countTotalPositives(samples);
            mTotal = samples.Rows.Count;
            mEntropySet = calcEntropy(mTotalPositives, mTotal - mTotalPositives);
            Attribute bestAttribute = getBestAttribute(samples, attributes);
            ArrayList aAttributes = new ArrayList(attributes.Length - 1);
            if (bestAttribute == null)
                return new TreeNode(new Attribute(false));
            if (attributes.Length == 0)
                return new TreeNode(new Attribute(false));

            TreeNode root = new TreeNode(bestAttribute);

            DataTable aSample = samples.Clone();

            foreach (string value in bestAttribute.values)
            {
                aSample.Rows.Clear();

                DataRow[] rows = samples.Select(bestAttribute.AttributeName + " = " + "'" + value + "'");

                foreach (DataRow row in rows)
                {
                    aSample.Rows.Add(row.ItemArray);
                }

                for (int i = 0; i < attributes.Length; i++)
                {
                    if (attributes[i].AttributeName != bestAttribute.AttributeName)
                        aAttributes.Add(attributes[i]);
                }

                if (aSample.Rows.Count == 0)
                {
                    root.AddTreeNode(new TreeNode(new Attribute(false)), value);
                }
                else
                {
                    DecisionTreeID3 dc3 = new DecisionTreeID3();
                    TreeNode ChildNode = dc3.mountTree(aSample, targetAttribute, (Attribute[])aAttributes.ToArray(typeof(Attribute)));
                    root.AddTreeNode(ChildNode, value);
                }
            }

            return root;
        }

        public TreeNode mountTree(DataTable samples, string targetAttribute, Attribute[] attributes)
        {
            mSamples = samples;
            return internalMountTree(mSamples, targetAttribute, attributes);
        }
    }
}