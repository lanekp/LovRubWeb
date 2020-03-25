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

namespace Commerce.Stats
{
    public enum BehaviorType : int
    {
        BrowsingCategory = 1,
        BrowsingProduct = 2,
        ClickingOnAd = 3,
        ClickingOnPromo = 4,
        ClickingOnUpsell = 5,
        ClickingOnCrosssell = 6,
        ClickingOnBundle = 7,
        RunningSearch = 8,
        AddingItemToBasket = 9,
        CheckingOut = 10,
        Paying = 11,
        ViewingReceipt = 12,
        RemovingItemFromBasket = 13,
        AdjustingQuantity = 14,
        LoggingIn = 15,
        LoggingOut = 16
    }
}
