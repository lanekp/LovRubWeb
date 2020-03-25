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
using Commerce.Stats;

public partial class _Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Button btnLogin=(Button)Login1.FindControl("LoginButton");
        Page.Form.DefaultButton = btnLogin.UniqueID;

        string redir = Utility.GetParameter("ReturnUrl");
        if(!string.IsNullOrEmpty(redir)) {
          Login1.CreateUserUrl = Login1.CreateUserUrl + "?ReturnUrl=" + redir;
        }
    }
    protected void LogInUser(object sender, EventArgs e) {
         //check to see if this person has a cookie
        if (Request.Cookies["shopperID"] != null) {
            string sAnonID = Request.Cookies["shopperID"].Value;
            //synch the tracker
            Tracker.SynchTrackingCookie(Login1.UserName, sAnonID);

            //Log it
            Tracker.Add(BehaviorType.LoggingIn);
           
            //reset the cookie so we know who this is
            Response.Cookies["shopperID"].Value = Login1.UserName;
            Response.Cookies["shopperID"].Expires = DateTime.Today.AddDays(365);
        }                       
    }
    protected void NewRegistration(object sender, EventArgs e) {
        string redir = Utility.GetParameter("ReturnUrl");
        if (redir != string.Empty) {
					Response.Redirect(redir, false);
        } else {
					Response.Redirect("default.aspx", false);
        }
    }

        protected void OnLoginError(object sender, EventArgs e)
        {
            Login1.HelpPageText = "Help with logging in...";
            Login1.CreateUserText = "Create a new user...";
            Login1.PasswordRecoveryText = "Forgot your password?";
        }


    
}
