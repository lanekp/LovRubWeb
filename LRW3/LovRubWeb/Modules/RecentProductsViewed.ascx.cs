#region dCPL Version 1.1.1
/*
The contents of this file are subject to the dashCommerce Public License
Version 1.1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.dashcommerce.org

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is dashCommerce.

The Initial Developer of the Original Code is Mettle Systems LLC.
Portions created by Mettle Systems LLC are Copyright (C) 2007. All Rights Reserved.
*/
#endregion
 
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
using Commerce.Common;

public partial class Modules_RecentProductsViewed : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            rptRecentProds.DataSource = SPs.StatsFavoriteProducts(Utility.GetUserName()).GetReader();
            rptRecentProds.DataBind();

            pnlProd.Visible = rptRecentProds.Items.Count > 0;

        }
    }
    public int GetCount()
    {

        return rptRecentProds.Items.Count; 
    }
    protected string GetImagePath(object img)
    {
        string sOut = string.Empty;
				if(img != null) {
					if(img.ToString().Trim().Length != 0) {
            sOut= Page.ResolveUrl("~/"+img.ToString());
					}
					else {
						sOut = Page.ResolveUrl("~/images/ProductImages/no_image_available_small.gif");
					}
				}
				else {
					sOut = Page.ResolveUrl("~/images/ProductImages/no_image_available_small.gif");
				}
        return sOut;
    }

}
