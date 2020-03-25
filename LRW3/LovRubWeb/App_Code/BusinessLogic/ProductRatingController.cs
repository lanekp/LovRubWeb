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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Commerce.Common;
using System.Collections.Generic;
using SubSonic;

/// <summary>
/// Controller for business logic relating to Products
/// </summary>
public static class ProductRatingController
{
    /// <summary>
    /// Adds a rating to a product for a given user and resets the product's rating stats
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="productID"></param>
    /// <param name="rating"></param>
    public static void AddUserRating(string userName, int productID, int rating)
    {

        SPs.StoreProductAddRating(productID, rating, userName).Execute();

    }

    /// <summary>
    /// Gets the user's rating for a products
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static int GetUserRating(string userName, int productID)
    {
        int iOut = -1;
        ProductRating rating = new ProductRating();
        rating.UserName = Utility.GetUserName();
        rating.ProductID = productID;
        IDataReader rdr = ProductRating.Find(rating);
        ProductRatingCollection coll = new ProductRatingCollection();
        coll.Load(rdr);
        rdr.Close();
        if (coll.Count > 0)
        {
            iOut = coll[0].Rating;
        }
        return iOut;

    }


}
