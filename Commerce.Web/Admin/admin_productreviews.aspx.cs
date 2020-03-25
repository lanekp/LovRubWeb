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

public partial class Admin_admin_productreviews : System.Web.UI.Page
{
    
    //***************************************************************
    //Many Thanks to Lucian Naie for this page :)
    //***************************************************************
    int ProductID=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ProductID = Utility.GetIntParameter("p");
            if (Request.QueryString["r"] != null)
            {
                string reviewID = Request.QueryString["r"].ToString();
                if (reviewID != "0")
                    LoadEditor(int.Parse(reviewID));
                else
                {
                    // We can't add a new review when productID is <= 0
                    if (this.ProductID <= 0)
											Response.Redirect("admin_productreviews.aspx", false);
                    else
                        LoadAddForm();
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e) 
    {
        string resultMessage = "";

        if (!Page.IsValid)
            return;
        ProductReview review = null;
        if (lblID.Text != "")
        {
            review = new ProductReview(int.Parse(lblID.Text));
        }
        else
        {
            review=new ProductReview();

        }
        // Init preview object
        review.Title = Utility.StripHTML(txtTitle.Text.Trim());
        review.Body = Utility.StripHTML(txtBody.Text.Trim());
        review.AuthorName = thxAuthor.Text.Trim();
        try {
            review.PostDate = DateTime.Parse(txtPostDate.Text.Trim());
        } catch {
            review.PostDate = DateTime.UtcNow;
        }
        review.IsApproved = ckbApproved.Checked;
        review.Rating = int.Parse(ddlRating.SelectedValue);

        bool haveError = false;
        uResult.Visible = true;

        resultMessage = "Review Updated";

        try {
            // Update review
            review.Save(Utility.GetUserName());
            uResult.ShowSuccess(resultMessage);


        }
        catch (Exception x) {
            resultMessage = "Update Failed: " + x.Message;
            uResult.ShowSuccess(resultMessage);
        }

    }

    protected void btnPerm_Click(object sender, EventArgs e)
    {
        ToggleGrid(false);
        uResult.Visible = true;
        try
        {
            ProductReview.Delete(int.Parse(lblID.Text));

            uResult.ShowSuccess("Review Permanently Deleted");

            btnSave.Enabled = false;
            btnPerm.Enabled = false;
        }
        catch (Exception x)
        {
            uResult.ShowFail("Cannot delete this review");
        }
    }

    void ToggleGrid(bool showGrid)
    {
        // Toggle the panels
        pnlEdit.Visible = !showGrid;
        pnlGrid.Visible = showGrid;
    }

    void LoadAddForm()
    {
        ToggleGrid(false);

        HttpContext context = HttpContext.Current;
        btnSave.Text = "Add";
        trID.Visible = false;
        btnPerm.Visible = false;
        txtPostDate.Text = DateTime.UtcNow.ToString();
        if (context.User != null && 
            context.User.Identity != null)
        {
            thxAuthor.Text = context.User.Identity.Name;
        }
    }

    void LoadEditor(int reviewID)
    {
        ToggleGrid(false);

        btnPerm.Attributes.Add("onclick", "CheckDelete()");

        // Load the product reader
        ProductReview review = new ProductReview(reviewID);
        // Load up the form
        lblID.Text = reviewID.ToString();
        txtTitle.Text = review.Title;
        txtBody.Text = review.Body;
        ddlRating.Items.FindByValue(review.Rating.ToString()).Selected = true;
        thxAuthor.Text = review.AuthorName;
        thxAuthor.Enabled = false;
        txtPostDate.Text = review.PostDate.ToString();
        ckbApproved.Checked = review.IsApproved;
        //lblHelpful.Text = review.IsHelpfulVotesNo.ToString() + "/" + review.TotalHelpfulVotesNo.ToString();
    }

    #region Properties

    public string ProductName
    {
        get {
            string prodName = "";

            if (!Page.IsPostBack) {
                // Get it from quesry string
                try {
                    prodName = HttpUtility.UrlDecode(HttpContext.Current.Request["pname"].Trim());
                } catch { }

                // Add it to view state
                if (ViewState != null) {
                    ViewState["ProductName"] = prodName;
                }
            }
            else {
                // Get it from view state
                if (ViewState != null && ViewState["ProductName"] != null) {
                    prodName = ViewState["ProductName"].ToString();
                }
            }

            return prodName;
        }
    }

    #endregion
}
