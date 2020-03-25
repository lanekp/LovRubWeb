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

public partial class Modules_Admin_ProductQtyDiscounts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddQtyDiscount(object sender, System.EventArgs e)
    {
        if (txtNewQuantity.Text != string.Empty && txtDiscount.Text != string.Empty)
        {
            SqlDataSource1.InsertParameters["ProductId"].DefaultValue = Request.QueryString["id"].ToString();
            SqlDataSource1.InsertParameters["Quantity"].DefaultValue = txtNewQuantity.Text;
            SqlDataSource1.InsertParameters["Discount"].DefaultValue = txtDiscount.Text;
            SqlDataSource1.InsertParameters["IsPercent"].DefaultValue = chkIsPercent.Checked.ToString();
            SqlDataSource1.InsertParameters["IsActive"].DefaultValue = chkIsActive.Checked.ToString();
            SqlDataSource1.Insert();
            LoadControl();

            //MessageBox.Display("Insert Successful", WebLogik.Controls.MessageType.Success);
        }
    }

    protected void removeSelection(object source, DataGridCommandEventArgs e)
    {
        Commerce.Common.QtyDiscount.Destroy(int.Parse(e.Item.Cells[2].Text));
        LoadControl();

        //MessageBox.Display("Delete Successful", WebLogik.Controls.MessageType.Success);
    }
    protected void editSelection(object source, DataGridCommandEventArgs e)
    {
        dgDiscount.EditItemIndex = e.Item.ItemIndex;
        LoadControl();
    }
    protected void cancelSelection(object source, DataGridCommandEventArgs e)
    {
        dgDiscount.EditItemIndex = -1;
        LoadControl();
    }
    protected void updateSelection(object source, DataGridCommandEventArgs e)
    {
        //create a new selection and add it
        Commerce.Common.QtyDiscount vol = new Commerce.Common.QtyDiscount(int.Parse(e.Item.Cells[2].Text));
        vol.Quantity = int.Parse(((TextBox)e.Item.Cells[3].Controls[0]).Text.Trim());
        vol.Discount = int.Parse(((TextBox)e.Item.Cells[4].Controls[0]).Text.Trim());
        vol.IsPercent = ((CheckBox)e.Item.Cells[5].FindControl("IsPercent")).Checked;
        vol.IsActive = ((CheckBox)e.Item.Cells[6].FindControl("IsActive")).Checked;
        vol.Save(Utility.GetUserName());
        dgDiscount.EditItemIndex = -1;
        LoadControl();

        //MessageBox.Display("Update Successful", WebLogik.Controls.MessageType.Success);
    }

    public void LoadControl()
    {
        dgDiscount.DataBind();
    }
}
