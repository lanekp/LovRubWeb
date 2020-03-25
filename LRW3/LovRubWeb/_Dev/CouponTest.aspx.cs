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
using Commerce.Promotions;

public partial class _Dev_CouponTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Collections.Generic.Dictionary<int, CouponType> couponTypes 
            = CouponType.GetAllCouponTypes();
        GridView1.DataSource = couponTypes.Values; 
        GridView1.DataBind();

        PercentOffCoupon pctCoupon = new PercentOffCoupon("AAAA", couponTypes[1]); 
        pctCoupon.PercentOff = 10;
        pctCoupon.SaveCoupon();

        PercentOffCoupon savedCoupon = (PercentOffCoupon) Coupon.GetCoupon("AAAA");
        this.DetailsView1.DataSource = new object[] { savedCoupon };
        this.DetailsView1.DataBind(); 

        
    }
}
