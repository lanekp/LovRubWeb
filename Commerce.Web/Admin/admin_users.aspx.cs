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
using System.Web.Administration;

public partial class Admin_admin_users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void EnabledChanged(object sender, EventArgs e)
    {
        string userID = null;
        CheckBox checkBox = sender as CheckBox;
        if (checkBox == null)
            return;
                
        if (!string.IsNullOrEmpty(checkBox.Attributes["Value"]))
            userID = checkBox.Attributes["Value"];

        if (userID == null)
            return;

        MembershipUser user = Membership.FindUsersByName(userID)[userID];
        user.IsApproved = checkBox.Checked;

        Membership.UpdateUser(user);
    }

    public void SearchForUsers(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            GridView1.DataSourceID = "";
            SearchForUsers(sender, e, GridView1, SearchByDropDown, TextBox1);
        }
    }

    protected void SearchForUsers(object sender, EventArgs e, GridView dataGrid, DropDownList dropDown, TextBox textBox)
    {
        ICollection coll = null;
        string text = textBox.Text;
        text = text.Replace("*", "%");
        text = text.Replace("?", "_");
        int total = 0;

        if (text.Trim().Length != 0)
        {
            if (dropDown.SelectedIndex == 0 /* userID */)
            {
                coll = Membership.FindUsersByName(text); 
            }
            else
            {
                coll = Membership.FindUsersByEmail(text);
            }
        }

        dataGrid.PageIndex = 0;
        dataGrid.DataSource = coll;
        dataGrid.DataBind();

        Pager1.TotalRecords = coll.Count;
    }

    public void LinkButtonClick(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            string userName = (string)e.CommandArgument;
            
            Membership.DeleteUser(userName);

						Response.Redirect("admin_users.aspx", false);
        }
    }

    protected void allUsersDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Pager1.TotalRecords = Convert.ToInt32(e.OutputParameters["TotalRecords"]);
    }
}
