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


namespace LovRubWeb.Products
{
    //public partial class Hers : System.Web.UI.Page
    public partial class Hers : ProdPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           int nNewQty = 0;
           if (txtQty.Text.Equals(""))
                return;
            try
            {
                int.TryParse(txtQty.Text, out nNewQty);

                Click(nNewQty, sFemaleProductGUID, sFemaleDiscountGUID);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }

        }
    }
}
