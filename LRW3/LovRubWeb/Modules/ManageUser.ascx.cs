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

public partial class Modules_ManageUser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadUser();

    }

    protected void LoadUser()
    {
        MembershipUser mu = Membership.GetUser(Utility.GetUserName());
        lblUserName.Text = mu.UserName.ToString();
        lblEmailAddr.Text = mu.Email.ToString();
        lblQuestion.Text = mu.PasswordQuestion.ToString();
        txtSecQuest.Text = mu.PasswordQuestion.ToString();
    }

    protected void HidePassPanel(object sender, EventArgs e)
    {
        pnlUserOV.Visible = true;
        pnlChangePassword.Visible = false;
        
    }
    protected void lnkPasswordChange_Click(object sender, EventArgs e)
    {
        pnlChangePassword.Visible = true;
        pnlUserOV.Visible = false;
    }
    protected void btnSaveSQ_Click(object sender, EventArgs e)
    {
        MembershipUser mu = Membership.GetUser(Utility.GetUserName());
        if (mu.ChangePasswordQuestionAndAnswer(txtCurPass.Text, txtSecQuest.Text, txtSecAnswer.Text))
            lblSQresult.Text = "Security Question Saved!";
        else
            lblSQresult.Text = "Error: Question could not be saved! Check Password";

        btnContinueSQ.Visible = true;
        btnSaveSQ.Visible = false;
        btnCancelSQ.Visible = false;
        LoadUser();
    }
    protected void lnkChangeQuestion_Click(object sender, EventArgs e)
    {
        pnlChangePassword.Visible = false;
        pnlUserOV.Visible = false;

        pnlSecQuestion.Visible = true;
        btnContinueSQ.Visible = false;
        lblSQresult.Text = "";
        btnSaveSQ.Visible = true;
        btnCancelSQ.Visible = true;
        

    }
    protected void btnCancelSQ_Click(object sender, EventArgs e)
    {
        pnlSecQuestion.Visible = false;
        btnContinueSQ.Visible = false;
        pnlEmailEdit.Visible = false;
        lblSQresult.Text = "";
        btnSaveSQ.Visible = true;
        btnCancelSQ.Visible = true;
        
        pnlChangePassword.Visible = false;
        pnlUserOV.Visible = true;


    }
    protected void btnSaveE_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(Utility.GetUserName(), txtEmailPass.Text))
        {
            MembershipUser mu = Membership.GetUser(Utility.GetUserName());
            mu.Email = txtEmailAddr.Text;
            Membership.UpdateUser(mu);
            Response.Redirect("~/myaccount.aspx");
        }
        else
        {
            lblEmailResult.Text = "Invalid Password!";
        }
    }
    protected void lnkUpdateEmail_Click(object sender, EventArgs e)
    {
        pnlEmailEdit.Visible = true;
        pnlSecQuestion.Visible = false;
        pnlChangePassword.Visible = false;
        pnlUserOV.Visible = false;
        lblEmailResult.Text = "";
    }
}
