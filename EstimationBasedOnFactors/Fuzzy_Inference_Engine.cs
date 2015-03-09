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
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace EstimationBasedOnFactors
{
    public class Fuzzy_Inference_Engine
    {
        static Process myProcess = null;
        static StreamWriter myStreamWriter;
        static bool door = true;
        public static void Start()
        {
            if (door)
            {
                myProcess = new Process();
                myProcess.StartInfo.FileName = Constants.Fuzzy_Server_File;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardInput = true;
                door = false;
            }
        }
        
        public static void Reload()
        {
            myProcess.Start();
            myStreamWriter = myProcess.StandardInput;
            File.Create(Constants.System_Output_File).Close();
            File.Create(Constants.SharedFile).Close();
            myStreamWriter.WriteLine("(clear)\n");
            myStreamWriter.WriteLine("(dribble-on \"" + Constants.System_Output_File + "\")\n");
            myStreamWriter.WriteLine("(batch \"" + Constants.FactorsInputsClipsFile + "\")\n");
            myStreamWriter.WriteLine("(batch \"" + Constants.FClips_Output_Template_File + "\")\n");
            myStreamWriter.WriteLine("(batch \"" + Constants.RulesInputsClipsFile + "\")\n");
            myStreamWriter.WriteLine("(reset)\n");
            myStreamWriter.WriteLine("(assert (SharedFile \"" + Constants.SharedFile + "\"))\n");
            myStreamWriter.WriteLine("(batch \"" + Constants.CasesInputsClipsFile + "\")\n");
            myStreamWriter.WriteLine("(run)\n");
            myStreamWriter.WriteLine("(exit)\n");
            List<Case> cases = null;
            while (!myProcess.HasExited)
                System.Threading.Thread.Sleep(200);
            string[] shared_file = File.ReadAllLines(Constants.SharedFile);
            //(Patient 2 150.0) CF 1.00 
            List<string> ids = new List<string>();
            List<string> ComputedOutput = new List<string>();
            for (int i = 0; i < shared_file.Length; i++)
            {
                if(shared_file[i].Contains(')'))
                {
                    string[] temps = shared_file[i].Split(')')[0].Split(' ');
                    ids.Add(temps[1]);
                    ComputedOutput.Add(temps[2]);
                }
            }
            cases = Case.ReadFromXml();
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].ActualOutput.Length == 0 &&
                    ids.Contains(cases[i].ID.ToString()))
                    cases[i].ComputedOutput = ComputedOutput[ids.IndexOf(cases[i].ID.ToString())];
            }
            Case.SaveToFiles(cases);
        }
    }
}