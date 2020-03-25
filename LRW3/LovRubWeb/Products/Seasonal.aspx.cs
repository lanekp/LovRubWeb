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

namespace LovRubWeb.Products
{
    //public partial class Seasonal : System.Web.UI.Page
    public partial class Seasonal : ProdPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /******
             * determine if hh, mm, or ff
             * determine qty 
             * add them all to cart
             ******/
            int nHisHers, nGay, nLesbo = 0;
            try
            {
                nHisHers = ddlHisHer.SelectedIndex;
                nGay = ddlGay.SelectedIndex;
                nLesbo = ddlLesbo.SelectedIndex;
                
                if (nHisHers > 0)
                    AddToCart(sHisHersValentineGUID, nHisHers);

                if (nGay > 0)
                    AddToCart(sGayValentineGUID, nGay);
                
                if (nLesbo > 0)
                    AddToCart(sLesboValentineGUID, nLesbo);

                //AddKeyForOrderMotion();
                Response.Redirect("~/BasketLV3.aspx", false);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }
 
        }
    }
}
