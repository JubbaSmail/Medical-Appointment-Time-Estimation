using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstimationBasedOnFactors.User
{
    public partial class ActualOutputs : System.Web.UI.Page
    {
        List<Case> cases = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.cases = Case.ReadFromXml();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("");
                for (int i = 0; i < cases.Count; i++)
                {
                    if (cases[i].ActualOutput.Length == 0)
                        DropDownList1.Items.Add(cases[i].Name);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(TextBoxActualTime.Text) > 60)
                    TextBoxActualTime.Text = "60";
            }
            catch
            { }
            if (DropDownList1.Text.Length > 0)
            {
                string patient_name = DropDownList1.Text;
                string actual_time = TextBoxActualTime.Text;
                this.cases = Case.ReadFromXml();
                for (int i = 0; i < cases.Count; i++)
                {
                    if (cases[i].Name == patient_name)
                    {
                        cases[i].ActualOutput = actual_time;
                        DropDownList1.Items.Remove(patient_name);
                        break;
                    }
                }
                Case.SaveToFiles(this.cases);
                if (cases.Count % 10 == 0)
                {
                    //Run System Machine Learning (Rule Generation)
                }
            }
            DropDownList1.Text = "";
            TextBoxActualTime.Text = "";
        }

    }
}
