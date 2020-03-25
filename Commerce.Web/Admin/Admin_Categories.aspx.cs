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
using System.Data.SqlClient;
using Commerce.Common;
using System.Collections.Generic;

public partial class Admin_Admin_Categories : System.Web.UI.Page {

  CategoryCollection catList = null;

  protected void Page_Load(object sender, EventArgs e) {
    string delFlag = "";
    if (Request.QueryString["did"] != null) {
      delFlag = Request.QueryString["did"].ToString();
    }

    if (delFlag != string.Empty) {
      int delID = int.Parse(delFlag);
      Response.Redirect("admin_folders.aspx", false);
    }

    if (!Page.IsPostBack) {
      LoadCatBox();
      ddlParentID.DataSource = catList;
      ddlParentID.DataTextField = "CategoryName";
      ddlParentID.DataValueField = "categoryID";
      ddlParentID.DataBind();
      ListItem item = new ListItem("<Top Level>", "0");
      ddlParentID.Items.Insert(0, item);

      lstCats.SelectedIndex = 0;
      if (lstCats.Items.Count > 0)
        LoadCategory(int.Parse(lstCats.SelectedValue));
    }

  }

  void LoadCatBox() {

    //get all of em
    catList = new CategoryCollection().Load();

    lstCats.Items.Clear();

    //figure out the levels
    //load the top ones first
    foreach (Category thisCat in catList) {
      ListItem item = new ListItem();
      item.Text = thisCat.CategoryName;
      item.Value = thisCat.CategoryID.ToString();
      lstCats.Items.Add(item);
    }



  }
  protected void btnAdd_Click(object sender, EventArgs e) {
    Category cat = new Category();
    cat.CategoryName = txtCatNew.Text;
    cat.ListOrder = 99;
    cat.ParentID = 0;
    cat.Save(Utility.GetUserName());
    LoadCatBox();

    //reload the master list
    CategoryController.Load();

  }


  void LoadCategory(int categoryID) {
    btnDelete.Attributes.Add("onclick", "return CheckDelete();");
    Category cat = new Category(categoryID);
    txtCategoryName.Text = cat.CategoryName;
    txtLongDescription.Text = cat.LongDescription;
    txtShortDescription.Text = cat.ShortDescription;
    txtListOrder.Text = cat.ListOrder.ToString();
    lblID.Text = cat.CategoryID.ToString();
    ddlParentID.SelectedValue = cat.ParentID.ToString();

    //this is a hack - Atlas doesn't respect the ViewState for some reason
    ImagePicker1.ImageFolder = "images/pageheaders";

    ImagePicker1.SetImage(cat.ImageFile);
  }

  protected void btnDelete_Click(object sender, EventArgs e) {

    int delCatID = int.Parse(lblID.Text);
    //see if this category has children

    //get all the categories
    CategoryCollection coll = new CategoryCollection().Load();

    //find the one to be deleted
    bool hasKids = false;
    foreach (Category cat in coll) {
      if (cat.ParentID == delCatID) {
        hasKids = true;
        break;
      }
    }

    if (!hasKids) {
      Category.Delete(delCatID);
      LoadCatBox();
      if (lstCats.Items.Count > 0) {
        lstCats.SelectedIndex = 0;
        LoadCategory(int.Parse(lstCats.SelectedValue));

        //Reload the master category list
        CategoryController.Load();
      }
    }
    else {
      ResultMessage1.ShowFail("You must delete all child categories first, or reassign them by dragging and dropping to another parent category");
    }
  }

  protected void btnSave_Click(object sender, EventArgs e) {
    int parentID = 0;
    parentID = int.Parse(ddlParentID.SelectedValue);
    Category cat = new Category(int.Parse(lblID.Text));
    cat.CategoryName = txtCategoryName.Text;
    cat.ImageFile = ImagePicker1.GetSelectedImage();
    //reset the image file to use virtual root reference
    string imageFile = System.IO.Path.GetFileName(cat.ImageFile);
    cat.ImageFile = "~/images/pageheaders/" + imageFile;

    cat.ListOrder = int.Parse(txtListOrder.Text);
    cat.ShortDescription = txtShortDescription.Text;
    cat.LongDescription = txtLongDescription.Text;
    cat.ParentID = parentID;
    cat.Save(Utility.GetUserName());

    LoadCategory(cat.CategoryID);
    LoadCatBox();

    //Reload the master category list
    CategoryController.Load();

  }
  protected void lstCats_SelectedIndexChanged(object sender, EventArgs e) {
    LoadCategory(int.Parse(lstCats.SelectedValue));
  }
}
