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
    public partial class Valentines2010 : ProdPageBase
    {
        string sLoveDepotID = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                sLoveDepotID = null;
                sLoveDepotID = HttpContext.Current.Request.QueryString["ID"];
                if (null != sLoveDepotID)
                {
                    HttpContext.Current.Response.Cookies["ID"].Value = sLoveDepotID;
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            int nHisQty = 0;
            int nHersQty = 0;
            int nHisHersQty = 0;

            if (txtHisQty.Text.Equals("0") && txtHersQty.Text.Equals("0") && txtHisHersQty.Text.Equals("0"))
                return;

            try
            {
                int.TryParse(txtHisQty.Text, out nHisQty);
                if (nHisQty > 0)
                    Click(nHisQty, sHisChocDelightGUID, sHisChocDelightGUID); 
                
                int.TryParse(txtHersQty.Text, out nHersQty);
                if (nHersQty > 0)
                    Click(nHersQty, sHersChocDelightGUID, sHersChocDelightGUID);

                int.TryParse(txtHisHersQty.Text, out nHisHersQty);
                if (nHisHersQty > 0)
                    Click(nHisHersQty, sHisHersChocDelightGUID, sHisHersChocDelightGUID); 

            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }
        }
             
    }
}
