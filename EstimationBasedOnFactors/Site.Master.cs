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

namespace WorkFlowSite
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.TitleLable != null)
                this.TitleLable.Text = SiteMap.CurrentNode.Title;
            if (this.DescriptionLabel != null)
                this.DescriptionLabel.Text = SiteMap.CurrentNode.Description;
        }
    }
}
