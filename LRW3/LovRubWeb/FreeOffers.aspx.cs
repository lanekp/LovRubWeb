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
using Commerce.Promotions;

public partial class FreeOffers : ProdPageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        if (chkStocking.Checked)
                AddToCart(sStockingGUID, 1);
            else
                AddToCart(sFreeMassageGelGUID, 1);
        

        Response.Redirect("https://www.lovrub.com/CheckoutLV3.aspx", false);
        //Response.Redirect("~/CheckoutLV3.aspx", false);
    }


    protected virtual void StockingCheckedChange(Object sender, EventArgs e)
    {
        if (chkStocking.Checked)
            chkRubLov.Checked = false;
        else
            chkRubLov.Checked = true;
    }


    protected virtual void RubLovCheckedChange(Object sender, EventArgs e)
    {
        if (chkRubLov.Checked)
            chkStocking.Checked = false;
        else
            chkStocking.Checked = true;
    }
    
}
