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

public partial class Modules_Products_ReviewDisplay : System.Web.UI.UserControl
{
    public Commerce.Common.Product product;
    protected void Page_Load(object sender, EventArgs e)
    {
        rptReviews.DataSource = product.Reviews;
        rptReviews.DataBind();

    }
    protected void PostReviewResponse(object sender, RepeaterCommandEventArgs e)
    {
        Label lblReviewID = (Label)e.Item.FindControl("lblReviewID");
        string commandName = e.CommandName;
        bool bIsHelpful = commandName == "Yes";
        if (lblReviewID != null)
        {
            Label lblThanks = (Label)e.Item.FindControl("lblThanks");

            
            ProductReviewFeedback feedback = new ProductReviewFeedback();
            feedback.ReviewID = int.Parse(lblReviewID.Text);
            feedback.UserName = Utility.GetUserName();
            feedback.IsHelpful = bIsHelpful;
            feedback.Save(Utility.GetUserName());


            if (lblThanks != null)
            {
                if (bIsHelpful)
                {
                    lblThanks.Text = "Thank you for letting us know you liked this review";
                }
                else
                {
                    lblThanks.Text = "Thank you for letting us know you did not like this review";

                }
            }

        }
    }
}
