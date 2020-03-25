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
using System.Collections.Generic;

public partial class Members_ProductReview : System.Web.UI.Page {
    int productID = 0;
    protected void Page_Load(object sender, EventArgs e) {
        productID = Utility.GetIntParameter("id");
        if (!Page.IsPostBack) {
            if (!ReviewExists())
                ToggleEditor(true);
        } else {

        }
    }
    bool ReviewExists() {
        string userName = Utility.GetUserName();

        //see if there is a review for this user and product
        ProductReviewCollection revs =ProductController.GetByProductAndAuthor(productID, userName);

        bool bOut = false;

        if (revs.Count>0)
        {
            pnlReview.Visible = false;
            pnlFinished.Visible = false;
            pnlReviewed.Visible = true;
            
            bOut = true;

        }
        return bOut;
    }
    void ToggleEditor(bool showReviewPanel) {
        pnlReview.Visible = showReviewPanel;
        pnlFinished.Visible = !showReviewPanel;

    }
    protected void btnSave_Click(object sender, EventArgs e) {
        string sRating = ddlRating.SelectedValue;
        if (!String.IsNullOrEmpty(sRating)) {
            
            //if the selection is null for some reason
            //default it.
            int rating = int.Parse(sRating);

            //add the review
            string review = Utility.StripHTML(txtReview.Text);
            string title = Utility.StripHTML(txtTitle.Text);
            try {
                string thisUser=Utility.GetUserName();
                
                ProductReview rev = new ProductReview();
                rev.ProductID = productID;
                rev.AuthorName = thisUser;
                rev.Body = review;
                rev.IsApproved = false;
                rev.PostDate = DateTime.UtcNow;
                rev.Rating = rating;
                rev.Title = title;

                rev.Save(thisUser);
                
                ResultMessage1.ShowSuccess("Review Saved!");
            } catch (Exception x) {
                ResultMessage1.ShowFail("Oops! There was an error and your review was not saved: " + x.Message);
            }
        }
        ToggleEditor(false);

    }
}
