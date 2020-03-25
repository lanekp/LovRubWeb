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
using Commerce.Providers;
using Commerce.ContentManagement;

public partial class Modules_Content_Paragraph : System.Web.UI.UserControl
{
    public bool CanEdit = false;
    public string ContentName = "";
    public string Title = "";
    protected string ContentText = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CanEdit = Page.User.IsInRole("Administrator");
        if (ContentName != string.Empty)
        {

            TextEntry text = new TextEntry(ContentName);
            if (text.IsLoaded)
            {
                ContentText = text.Content;
            }
        }
        else
        {
            ContentText = "Set both the ContentID and PageName";
        }

    }
}

