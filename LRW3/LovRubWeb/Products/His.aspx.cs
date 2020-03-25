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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Commerce.Common;
using Commerce.Promotions;


namespace LovRubWeb.Products
{
    //public partial class His : System.Web.UI.Page
    public partial class His : ProdPageBase
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

                Click(nNewQty, sMaleProductGUID, sMaleDiscountGUID);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }

        }

   }
}