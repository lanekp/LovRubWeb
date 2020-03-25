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

public partial class Modules_Admin_ProductCategories : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }
    int catLevel = 0;
    private void BuildCategoryList(DataSet ds) {

        ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["categoryID"], ds.Tables[0].Columns["parentID"], false);

        foreach (DataRow dbRow in ds.Tables[0].Rows) {
					if(int.Parse(dbRow["parentID"].ToString()) == 0) {
                catLevel = 0;
                ddlCats.Items.Add(new ListItem(dbRow["categoryName"].ToString(), dbRow["categoryID"].ToString()));
                PopulateSubTree(dbRow);
            }
        }

    }
    private void PopulateSubTree(DataRow dbRow) {
        catLevel++;
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation")) {
            ddlCats.Items.Add(new ListItem("---" + childRow["categoryName"].ToString(), childRow["categoryID"].ToString()));
            PopulateSubTree(childRow);
        }
    }
    public void LoadCategories(int productID) {
        lblID.Text = productID.ToString();
        DataSet ds = CategoryController.GetDataSetList(); ;
        BuildCategoryList(ds);
        LoadCatList();

    }
    void LoadCatList() {
        dgCats.DataSource = CategoryController.GetByProductID(int.Parse(lblID.Text));
        dgCats.DataBind();
    }

    protected void DeleteCat(object source, DataGridCommandEventArgs e) {
        string sCatID = e.Item.Cells[0].Text;
        ProductController.RemoveFromCategory(int.Parse(lblID.Text),int.Parse(sCatID));
        LoadCatList();
    }
    protected void btnCats_Click(object sender, EventArgs e) {
        ProductController.AddToCategory(int.Parse(lblID.Text),int.Parse(ddlCats.SelectedValue));
        LoadCatList();

    }
}
