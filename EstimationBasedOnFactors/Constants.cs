using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.IO;

namespace EstimationBasedOnFactors
{
    public class Constants
    {
        /*<add key="WorkingDirectory" value="C:\\EstimationBasedOnFactors\\Clisp\\"/>
            
		<add key="FactorsInputsXmlFile" value="input_membership_functions.xml"/>
		<add key="FactorsInputsClipsFile" value="input_membership_functions.clp"/>
            
        <add key="RulesInputsXmlFile" value="input_rules.xml"/>
        <add key="RulesInputsClipsFile" value="input_rules.clp"/>
            
		<add key="CasesInputsXmlFile" value="cases.xml"/>
		<add key="CasesInputsClipsFile" value="cases.clp"/>
        <add key="Fuzzy_Server_File" value="fzclipscmd.exe" /> */
        public static string WorkingDirectory
        {
            get { return ConfigurationManager.AppSettings["WorkingDirectory"]; }
        }

        public static string System_Output_File
        {
            get
            {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["System_Output_File"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string Fuzzy_Server_File
        {
            get
            {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["Fuzzy_Server_File"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string FactorsInputsXmlFile
        {
            get
            {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["FactorsInputsXmlFile"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string FactorsInputsClipsFile
        {
            get 
            { 
                string path = WorkingDirectory + ConfigurationManager.AppSettings["FactorsInputsClipsFile"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string SharedFile
        {
            get {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["SharedFile"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string FClips_Output_Template_File
        {
            get {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["FClips_Output_Template_File"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }
        
        public static string RulesInputsClipsFile
        {
            get {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["RulesInputsClipsFile"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string CasesInputsXmlFile
        {
            get {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["CasesInputsXmlFile"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }

        public static string CasesInputsClipsFile
        {
            get {
                string path = WorkingDirectory + ConfigurationManager.AppSettings["CasesInputsClipsFile"];
                if (File.Exists(path))
                    return path;
                else
                    throw new Exception("Can not find Database file!\n Please check the Configuration Setting in the home page.");
            }
        }
    }
}
