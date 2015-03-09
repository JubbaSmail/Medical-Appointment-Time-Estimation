using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace EstimationBasedOnFactors.User
{
    public partial class Cases : System.Web.UI.Page
    {
        List<Case> cases = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cases = Case.ReadFromXml();
            Case c = (Case)this.Session["selected_case"];
            if (c != null)
            {
                for (int i = 0; i < cases.Count; i++)
                {
                    if (cases[i].ID == c.ID)
                    {
                        cases[i] = c;
                        c = null;
                        break;
                    }
                }
                if (c != null && c.Name!= null)
                    this.cases.Add(c);
                //Run System Estemation for Case 'c'....
                Case.SaveToFiles(this.cases);
                Fuzzy_Inference_Engine.Reload();
                this.cases = Case.ReadFromXml();
                this.Session["selected_case"] = null;
            }
            this.updateGridView();
        }

        private void updateGridView()
        {
            if (this.cases.Count > 0)
            {
                this.Session["cases"] = this.cases;

                var m = from mf in this.cases
                        select mf;
                this.GridViewCases.DataSource = m;
            }
            else
            {
                this.GridViewCases.DataSource = null;
            }
            this.GridViewCases.DataBind();
            this.Validate();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            List<Factor> factors = Factor.ReadFromXml();
            
            Case c = new Case(factors);
            c.ID = Case.GetNextID(this.cases);
            this.Session["selected_case"] = c;
            this.Response.Redirect("./EditCase.aspx");
        }

        protected void GridViewCases_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.Session["selected_case"] = null;
            //To be changed!!!
            this.cases.RemoveAt(e.RowIndex);
            Case.SaveToFiles(this.cases);
            updateGridView();
        }

        protected void GridViewCases_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //To be changed!!!
            this.Session["selected_case"] = this.cases[e.NewEditIndex];
            this.Response.Redirect("./EditCase.aspx");
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Case.SaveToFiles(this.cases);
            this.Response.Redirect("../Home_Page.aspx");
        }
    }
}