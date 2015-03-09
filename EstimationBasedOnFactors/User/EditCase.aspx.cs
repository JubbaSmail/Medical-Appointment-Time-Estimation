using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace EstimationBasedOnFactors.User
{
    public partial class EditCase : System.Web.UI.Page
    {
        Case selectedCase;
        List<Factor> factors;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["selected_case"] == null)
            {
                if (this.selectedCase == null)
                {
                    factors = Factor.ReadFromXml();
                    this.selectedCase = new Case(factors);
                }
                this.Session.Add("selected_case", this.selectedCase);
            }
            else
            {
                this.selectedCase = (Case)this.Session["selected_case"];
            }
            if (!this.IsPostBack)
                this.updateGridView();
        }


        private void updateGridView()
        {
            this.Session["selected_case"] = this.selectedCase;

            this.LabelID.Text = this.selectedCase.ID.ToString();
            this.TextBoxName.Text = this.selectedCase.Name;
            this.GridViewCaseAttirbutes.DataSource = this.selectedCase.Attributes;
            this.GridViewCaseAttirbutes.DataBind();

            this.Validate();
        }

        private void updateSelectedCase()
        {
            this.selectedCase.Name = this.TextBoxName.Text;
            foreach (GridViewRow row in this.GridViewCaseAttirbutes.Rows)
            {
                ;
            }
            this.Session["selected_case"] = this.selectedCase;
            this.Validate();
        }

        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            this.updateSelectedCase();
            this.Response.Redirect("./Cases.aspx");
        }

        protected void GridViewCaseAttirbutes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridViewCaseAttirbutes.EditIndex = e.NewEditIndex;
            this.updateGridView();
        }

        protected void GridViewCaseAttirbutes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            factors = Factor.ReadFromXml();
            int index = this.GridViewCaseAttirbutes.EditIndex;
            string value = ((TextBox)(this.GridViewCaseAttirbutes.Rows[index].FindControl("TextBoxAttributesValue"))).Text;
            for (int i = 0; i < factors.Count; i++)
            {
                if (factors[i].Name == this.selectedCase.Attributes.Keys.ToArray()[index])
                {
                    if (factors[i].RangeFrom <= Convert.ToDouble(value) && factors[i].RangeTo >= Convert.ToDouble(value))
                    {
                        this.selectedCase.Attributes[this.selectedCase.Attributes.Keys.ToArray()[index]] = value;
                    }
                    else
                    {
                        if (factors[i].RangeFrom > Convert.ToDouble(value))
                            this.selectedCase.Attributes[this.selectedCase.Attributes.Keys.ToArray()[index]] = factors[i].RangeFrom.ToString();
                        else
                            this.selectedCase.Attributes[this.selectedCase.Attributes.Keys.ToArray()[index]] = factors[i].RangeTo.ToString();
                    }
                    this.GridViewCaseAttirbutes.EditIndex = -1;
                    this.updateGridView();
                    break;
                }
            }
            
        }

        protected void GridViewCaseAttirbutes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridViewCaseAttirbutes.EditIndex = -1;
            this.updateGridView();
        }
    }
}