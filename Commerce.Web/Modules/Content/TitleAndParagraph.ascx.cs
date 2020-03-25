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

public partial class Modules_Content_TitleAndParagraph : System.Web.UI.UserControl {
    public bool CanEdit = false;
    public string ContentName = "";
    public DataTable LoadTable;
    public string Title = "";
    public string ContentText;
    protected void Page_Load(object sender, EventArgs e) {
        CanEdit = Page.User.IsInRole("Administrator");
        pnlCommand.Visible = false;

        ToggleEditor(false);
        //if(!Page.IsPostBack){
        try {

            if (ContentName != string.Empty) {
                TextEntry text = new TextEntry(ContentName);
                if (text.IsLoaded) {
                    Title = text.Title;
                    ContentText = text.Content;
                    lblTitle.Text = text.Title;
                    lblContent.Text = text.Content;
                }
            } else {
                lblTitle.Text = "Set both the ContentID and PageName";
            }
        } catch {

        }
    }
    void ToggleEditor(bool show) {
        tblEdit.Visible = show;
        pnlContent.Visible = !show;

    }

    protected void btnEdit_Click(object sender, System.EventArgs e) {
        ToggleEditor(true);
        //load up the content to edit
        TextEntry text = new TextEntry(ContentName);

        txtTitle.Text = text.Title;
        txtContent.Text = text.Content;

    }

    protected void btnCancel_Click(object sender, System.EventArgs e) {
        ToggleEditor(false);
    }

    protected void btnSave_Click(object sender, System.EventArgs e) {
        //save the content up
        TextEntry text = new TextEntry(ContentName);
        //if it's loaded, it exists.
        if (!text.IsLoaded) {
            //make sure it's marked new
            text.IsNew = true;
            
        }
        text.ContentName = ContentName;
        text.Title = txtTitle.Text;
        text.Content = txtContent.Text;
        text.Save(Page.User.Identity.Name);
		Response.Redirect(Request.Url.PathAndQuery, false);

    }
}
