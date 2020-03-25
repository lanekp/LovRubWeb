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
using System.Collections.Generic;
using System.Text;
using Commerce.Common;

namespace Commerce.Promotions
{
    public class PercentOffCoupon:Coupon
    {
        public PercentOffCoupon():base()
        {

        }

        public PercentOffCoupon(string couponCode, CouponType couponType)
            : base(couponCode, couponType)
        {
        }
        private int _percentOff;

        public int PercentOff
        {
            get { return _percentOff; }
            set { _percentOff = value; }
        }



        decimal CalculateDiscountAmount(decimal itemAmount) {
            
            decimal result = 0;
            decimal dPercent = Convert.ToDecimal(PercentOff);
            if (PercentOff > 0) {
                decimal dRate = dPercent / 100.00M;
                result = dRate * itemAmount;
                result = Math.Round(result, 2);
            }

            return result;
        }
        public override void ApplyCouponToOrder(Commerce.Common.Order order)
        {
            //Validate the order to make sure it's good.  
            CouponValidationResponse validationResponse =
                ValidateCouponForOrder(order);
            if (!validationResponse.IsValid)
            {
                throw new ArgumentException("Coupon is not valid for order: " + validationResponse, "order"); 
            }

            //updated by Spook, 11-5-2006
           

            //The logic for this coupon is to apply a Percent off to the order items
            //this does not include shipping/tax since those items are not 
            
            //first, make sure this coupon hasn't been used
            if (!order.CouponCodes.Contains(CouponCode)) {

                //calculate the discount
                order.DiscountAmount = CalculateDiscountAmount(order.CalculateSubTotal());

                //add a comment to the order
                order.CouponCodes += CouponCode;

                //save the order
                order.Save("Coupon System");
            }

        }

    }
}
