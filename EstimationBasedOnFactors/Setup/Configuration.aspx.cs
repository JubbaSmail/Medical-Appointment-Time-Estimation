using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EstimationBasedOnFactors.Setup
{
    public partial class Configuration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TextBox1.Text = Constants.WorkingDirectory;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration webConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            webConfig.AppSettings.Settings["WorkingDirectory"].Value = this.TextBox1.Text;
            webConfig.Save();
            this.TextBox1.Text = Constants.WorkingDirectory;
            this.Response.Redirect("../Home_Page.aspx");
        }
    }
}
