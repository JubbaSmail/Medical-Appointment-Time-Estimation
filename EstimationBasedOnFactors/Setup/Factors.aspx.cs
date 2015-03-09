using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using System.Configuration;
using System.IO;

namespace EstimationBasedOnFactors.Setup
{
    public partial class Factors : System.Web.UI.Page
    {
        List<Factor> factors;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["factors"] == null)
            {
                if (this.factors == null)
                {
                    this.factors = Factor.ReadFromXml();
                }
                this.Session.Add("factors", this.factors);
            }
            else
            {
                this.factors = (List<Factor>)this.Session["factors"];
            }
            Factor selecteFactor = (Factor)this.Session["selected_factor"];
            if (selecteFactor != null
                && selecteFactor.Name != null)
            {
                if (!this.factors.Contains(selecteFactor))
                {
                    this.factors.Add(selecteFactor);
                }
                else
                {
                    this.factors[this.factors.IndexOf(selecteFactor)] = selecteFactor;
                }
                this.Session["selected_factor"] = null;
                this.Session["factors"] = this.factors;
            }

            this.updateGridView();
        }

        private void updateGridView()
        {
            if (this.factors.Count > 0)
            {
                this.Session["factors"] = this.factors;

                var m = from mf in this.factors
                        select mf;
                this.GridViewFactors.DataSource = m;
            }
            else
            {
                this.GridViewFactors.DataSource = null;
            }
            this.GridViewFactors.DataBind();
            this.Validate();
        }


        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Factor.SaveToFiles(this.factors);
            this.Response.Redirect("../Home_Page.aspx");
        }

        protected void GridViewFactors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.factors.RemoveAt(e.RowIndex);
            this.updateGridView();
        }

        protected void GridViewFactors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.Session["selected_factor"] = this.factors[e.NewEditIndex];

            this.Response.Redirect("./EditFactor.aspx");
        }

        protected void ButtonAddNew_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("./EditFactor.aspx");
        }

    }
}
