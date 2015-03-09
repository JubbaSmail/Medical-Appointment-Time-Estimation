using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Text;
using System.Configuration;

namespace EstimationBasedOnFactors
{
    public class Case
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string computedOutput;
        public string ComputedOutput
        {
            get { return computedOutput; }
            set { computedOutput = value; }
        }

        private string actualOutput;
        public string ActualOutput
        {
            get { return actualOutput; }
            set { actualOutput = value; }
        }

        private Dictionary<string, string> attributes;        
        public Dictionary<string, string> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        public Case(List<Factor> factors)
        {
            this.Attributes = new Dictionary<string, string>();
            foreach (Factor factor in factors)
            {
                this.Attributes.Add(factor.Name,"");
            }
        }

        public static List<Case> ReadFromXml()
        {
            string xmlFileFullPath = Constants.CasesInputsXmlFile;
            List<Case> cases = new List<Case>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            XmlReader xmlReader = (XmlReader)XmlReader.Create(xmlFileFullPath, settings);


            xmlReader.ReadStartElement("cases");
            {
                while (xmlReader.Name == "case" ||
                    xmlReader.ReadToFollowing("case"))
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement)
                    {
                        xmlReader.Read();
                        continue;
                    }
                    List<Factor> factors = Factor.ReadFromXml();
                    Case temp_case = new Case(factors);
                    xmlReader.MoveToAttribute("id");
                    temp_case.ID = int.Parse(xmlReader.Value);
                    xmlReader.MoveToAttribute("name");
                    temp_case.Name = xmlReader.Value;
                    xmlReader.MoveToAttribute("computed_output");
                    temp_case.ComputedOutput = xmlReader.Value;
                    xmlReader.MoveToAttribute("actual_output");
                    temp_case.ActualOutput = xmlReader.Value;
                    {
                        xmlReader.ReadToFollowing("attributes");
                        {
                            while (xmlReader.Read() &&
                                xmlReader.Name == "attribute")
                            {
                                xmlReader.MoveToAttribute("name");
                                string name = xmlReader.Value;

                                xmlReader.MoveToAttribute("value");
                                string value = xmlReader.Value;
                                temp_case.Attributes[name] = value;
                            }
                        }
                    }
                    cases.Add(temp_case);
                }
            }

            xmlReader.Close();

            return cases;
        }

        public static void SaveToFiles(List<Case> cases)
        {
            string xmlFileFullPath = Constants.CasesInputsXmlFile;
            string clipsFileFullPath = Constants.CasesInputsClipsFile;
            StringBuilder xmlOutput = new StringBuilder();
            StringBuilder clipsOutput = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            XmlWriter xmlWriter = (XmlWriter)XmlTextWriter.Create(xmlOutput, settings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("cases");
            {
                foreach (Case temp_case in cases)
                {
                    xmlWriter.WriteStartElement("case");
                    xmlWriter.WriteAttributeString("id", temp_case.ID.ToString());
                    xmlWriter.WriteAttributeString("name", temp_case.Name);
                    xmlWriter.WriteAttributeString("computed_output", temp_case.ComputedOutput);
                    xmlWriter.WriteAttributeString("actual_output", temp_case.ActualOutput);
                    //modified 
                    clipsOutput.Append(string.Format("(assert\n\t(case \n\t\t(ID {0})\n\t\t(Name {1})",
                        temp_case.id.ToString(), temp_case.Name));

                    xmlWriter.WriteStartElement("attributes");

                    foreach (KeyValuePair<string, string> attributes in temp_case.Attributes)
                    {
                        xmlWriter.WriteStartElement("attribute");
                        xmlWriter.WriteAttributeString("name", attributes.Key);
                        xmlWriter.WriteAttributeString("value", attributes.Value);
                        clipsOutput.Append(String.Format("\n\t\t({0} ({1} 1))", attributes.Key, attributes.Value));
                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndElement();

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
            fileClipsWirter.Close();
        }

        public static int GetNextID(List<Case> cases)
        {
            if (cases.Count == 0)
                return 0;

            int newID = (from c in cases
                     where c.ID == cases.Max(ca => ca.ID)
                     select c).First().ID;
            return newID + 1;
        }

    }
}
