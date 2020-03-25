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
    public partial class Dessert : ProdPageBase
    {

        protected void Button1_Click(object sender, EventArgs e)
        {
            int nChocQty = 0;
            int nCherryQty = 0;

            if (txtChocQty.Text.Equals("0") && txtCherryQty.Text.Equals("0") )
                return;

            try
            {
                int.TryParse(txtChocQty.Text, out nChocQty);
                if (nChocQty > 0)
                    Click(nChocQty, sChocolateBDGUID, sChocolateBDGUID); 
                
                int.TryParse(txtCherryQty.Text, out nCherryQty);
                if (nCherryQty > 0)
                    Click(nCherryQty, sCherryBDGUID, sCherryBDGUID);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }
        }
    }
}
