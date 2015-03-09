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
using System.IO;

namespace EstimationBasedOnFactors.Setup
{
    public partial class FuzzyClips_Output : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(Constants.System_Output_File);
            Label1.Text = "";
            foreach (var line in lines)
            {
                Label1.Text += line + "<br />";
            }
        }
    }
}
