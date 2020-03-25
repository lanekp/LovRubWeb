using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CCMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnSearch.Attributes.Add("onclick", "location.href="+Page.ResolveUrl("~/search.aspx")+"?q='+txtSearch.value");
        if (!Page.IsPostBack)
        {
            Head1.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("~/js/modal/common.js") + "'></script>"));
            Head1.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("~/js/modal/subModal.js") + "'></script>"));
        }

    }
}
