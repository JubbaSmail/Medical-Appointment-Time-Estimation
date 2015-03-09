using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Xml.XPath;
using System.Configuration;
using System.IO;

namespace EstimationBasedOnFactors
{
    public partial class EditFactor : System.Web.UI.Page
    {
        Factor selectedFactor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["selected_factor"] == null)
            {
                if (this.selectedFactor == null)
                    this.selectedFactor = new Factor();
                this.Session.Add("selected_factor", this.selectedFactor);
            }
            else
            {
                this.selectedFactor = (Factor)this.Session["selected_factor"];
            }
                        
            if (!this.IsPostBack)
            {
                this.TextBoxName.Text = this.selectedFactor.Name;
                this.TextBoxUnit.Text = this.selectedFactor.Unit;
                this.TextBoxRangeFrom.Text = this.selectedFactor.RangeFrom.ToString();
                this.TextBoxRangeTo.Text= this.selectedFactor.RangeTo.ToString();
            }

            this.updateGridView();
        }

        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            this.selectedFactor.Name = this.TextBoxName.Text;
            this.selectedFactor.RangeFrom = double.Parse(this.TextBoxRangeFrom.Text);
            this.selectedFactor.RangeTo = double.Parse(this.TextBoxRangeTo.Text);
            this.selectedFactor.Unit = this.TextBoxUnit.Text;

            this.Session["selected_factor"] = this.selectedFactor;

            this.Response.Redirect("./Factors.aspx");
        }

        protected void ButtonAddTri_Click(object sender, EventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Add(
                new MembershipFunction(TextBox30.Text,
                string.Format("({0} 0) ({1} 1) ({2} 0)",
                this.TextBox5.Text,
                this.TextBox6.Text,
                this.TextBox7.Text)));

            this.updateGridView();
        }

        private void updateGridView()
        {
            this.Session["selected_factor"] = this.selectedFactor;

            var m = from mf in this.selectedFactor.MembershipFunctions
                    select mf;
            this.GridView1.DataSource = m;
            this.GridView1.DataBind();

            this.Validate();
        }

        protected void ButtonAddTrap_Click(object sender, EventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Add(
                new MembershipFunction(TextBox31.Text,
                string.Format("({0} 0) ({1} 1) ({2} 1) ({3} 0)",
                this.TextBox8.Text,
                this.TextBox9.Text,
                this.TextBox11.Text,
                this.TextBox10.Text)));

            this.updateGridView();

        }

        protected void ButtonAddS_Click(object sender, EventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Add(
                new MembershipFunction(TextBox28.Text,
                string.Format("(S {0} {1})",
                this.TextBox16.Text,
                this.TextBox18.Text)));

            this.updateGridView();
        }

        protected void ButtonAddZ_Click(object sender, EventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Add(
                new MembershipFunction(TextBox29.Text,
                string.Format("(Z {0} {1})",
                this.TextBox19.Text,
                this.TextBox20.Text)));

            this.updateGridView();

        }

        protected void ButtonAddPi_Click(object sender, EventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Add(
                new MembershipFunction(TextBox26.Text,
                string.Format("(PI {0} {1})",
                this.TextBox13.Text,
                this.TextBox12.Text)));

            this.updateGridView();

        }

        protected void ButtonAddLinguisticExpression_Click(object sender, EventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Add(
                new MembershipFunction(TextBox27.Text,
                this.TextBox25.Text));

            this.updateGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.selectedFactor.MembershipFunctions.Remove(
                this.selectedFactor.MembershipFunctions[e.RowIndex]);
            this.updateGridView();
        }
    }
}
