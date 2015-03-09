
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;
using System;
using System.Linq;

namespace EstimationBasedOnFactors
{
    public class Factor
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string unit;
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private double rangeFrom;
        public double RangeFrom
        {
            get { return rangeFrom; }
            set { rangeFrom = value; }
        }
        private double rangeTo;
        public double RangeTo
        {
            get { return rangeTo; }
            set { rangeTo = value; }
        }

        List<MembershipFunction> membershipFunctions;
        public List<MembershipFunction> MembershipFunctions
        {
            get { return membershipFunctions; }
            set { membershipFunctions = value; }
        }

        public Factor()
        {
            this.MembershipFunctions = new List<MembershipFunction>();
        }

        public Factor(string name, string unit, double rangeFrom, double rangeTo
            , List<MembershipFunction> membershipFunctions)
        {
            this.Name = name;
            this.Unit = unit;
            this.RangeFrom = rangeFrom;
            this.RangeTo = rangeTo;
            this.MembershipFunctions = membershipFunctions;
        }

        public static void SaveToFiles(List<Factor> factors)
        {
            string xmlFileFullPath = Constants.FactorsInputsXmlFile;
            string clipsFileFullPath = Constants.FactorsInputsClipsFile;
            StringBuilder xmlOutput = new StringBuilder();
            StringBuilder clipsOutput = new StringBuilder();
            StringBuilder clipsOutputContainerTemplate = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            XmlWriter xmlWriter = (XmlWriter)XmlTextWriter.Create(xmlOutput, settings);

            xmlWriter.WriteStartDocument();
            clipsOutputContainerTemplate.Append("\n\t(slot ID)");
            clipsOutputContainerTemplate.Append("\n\t(slot Name)");
            xmlWriter.WriteStartElement("factors");
            {
                foreach (Factor factor in factors)
                {
                    xmlWriter.WriteStartElement("factor");
                    xmlWriter.WriteAttributeString("name", factor.Name);
                    xmlWriter.WriteAttributeString("range_from", factor.RangeFrom.ToString());
                    xmlWriter.WriteAttributeString("range_to", factor.RangeTo.ToString());
                    xmlWriter.WriteAttributeString("unit", factor.Unit);

                    clipsOutput.Append(String.Format("(deftemplate factor_{0}\n\t{1} {2} {3}\n\t(",
                        factor.Name, factor.RangeFrom, factor.RangeTo, factor.Unit));
                    clipsOutputContainerTemplate.Append(
                        String.Format("\n\t(slot {0} (type FUZZY-VALUE {1}))", factor.Name, "factor_" + factor.Name));

                    {
                        xmlWriter.WriteStartElement("memberships");
                        {
                            foreach (MembershipFunction memFun in factor.MembershipFunctions)
                            {
                                xmlWriter.WriteStartElement("membership");
                                xmlWriter.WriteAttributeString("name", memFun.Name);
                                xmlWriter.WriteAttributeString("value", memFun.Value);
                                xmlWriter.WriteEndElement();

                                clipsOutput.Append(String.Format("\n\t\t({0} {1})", memFun.Name, memFun.Value));
                            }
                        }

                        xmlWriter.WriteEndElement();
                    }
                    clipsOutput.Append("\n\t)\n)\n\n");

                    xmlWriter.WriteEndElement();
                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();


            string baseFolder = xmlFileFullPath.Substring(0, xmlFileFullPath.LastIndexOf('\\'));
            if (!Directory.Exists(baseFolder))
                Directory.CreateDirectory(baseFolder);

            baseFolder = xmlFileFullPath.Substring(0, clipsFileFullPath.LastIndexOf('\\'));
            if (!Directory.Exists(baseFolder))
                Directory.CreateDirectory(baseFolder);

            StreamWriter fileXmlWirter = File.CreateText(xmlFileFullPath);
            fileXmlWirter.Write(xmlOutput.ToString());
            fileXmlWirter.Close();

            StreamWriter fileClipsWirter = File.CreateText(clipsFileFullPath);
            fileClipsWirter.Write(clipsOutput.ToString());
            fileClipsWirter.Write(String.Format("(deftemplate case{0}\n)", clipsOutputContainerTemplate.ToString()));
            fileClipsWirter.Close();
        }

        public static List<Factor> ReadFromXml()
        {
            string xmlFileFullPath = Constants.FactorsInputsXmlFile;
            List<Factor> factors = new List<Factor>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            XmlReader xmlReader = (XmlReader)XmlReader.Create(xmlFileFullPath, settings);

            xmlReader.ReadStartElement("factors");
            {
                while (xmlReader.Name == "factor" ||
                    xmlReader.ReadToFollowing("factor"))
                {
                    Factor factor = new Factor();
                    xmlReader.MoveToAttribute("name");
                    factor.Name = xmlReader.Value;
                    xmlReader.MoveToAttribute("range_from");
                    factor.RangeFrom = double.Parse(xmlReader.Value);
                    xmlReader.MoveToAttribute("range_to");
                    factor.RangeTo = double.Parse(xmlReader.Value);
                    xmlReader.MoveToAttribute("unit");
                    factor.unit = xmlReader.Value;
                    {
                        xmlReader.ReadToFollowing("memberships");
                        {
                            while (xmlReader.Read() &&
                                xmlReader.Name == "membership")
                            {
                                xmlReader.MoveToAttribute("name");
                                string name = xmlReader.Value;

                                xmlReader.MoveToAttribute("value");
                                string value = xmlReader.Value;

                                MembershipFunction memFun = new MembershipFunction(name, value);
                                factor.MembershipFunctions.Add(memFun);
                            }
                        }
                    }
                    factors.Add(factor);
                }
            }

            xmlReader.Close();

            return factors;
        }
    }
}