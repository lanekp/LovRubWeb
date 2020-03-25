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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SubSonic;

namespace Commerce.Common
{
    public partial class OrderItemCollection : ActiveList<OrderItem> {
        public OrderItem FindItem(OrderItem item) {
            OrderItem itemOut = null;
            foreach (OrderItem child in this) {
                if (child.ProductID == item.ProductID) {
                    itemOut = child;
                    break;
                }
            }
            return itemOut;
        }

        public new bool Contains(OrderItem item) {
            bool bOut = Find(item.ProductID) != null;
            return bOut;
        }

        public OrderItem Find(int productID) {
            OrderItem result = null;
            foreach (OrderItem child in this) {
                if (child.ProductID == productID) {
                    result = child;
                    break;
                }
            }
            return result;
        }
    }
    
    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Store_OrderItem table.
    /// </summary>
    public partial class OrderItem : ActiveRecord<OrderItem>
    {

        #region Custom - not in DB
        int currencyDecimals = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits;

        public decimal LineTotal
        {
            get
            {
                decimal dOut = Convert.ToDecimal(this.Quantity) * this.PricePaid;
                return Math.Round(dOut, currencyDecimals);
            }
        }

        private decimal _discountAmount;

        public decimal DiscountAmount
        {
            get
            {
                return _discountAmount;
            }
            set
            {
                _discountAmount = value;
            }
        }

        private DateTime _dateAdded;

        public DateTime DateAdded
        {
            get
            {
                return _dateAdded;
            }
            set
            {
                _dateAdded = value;
            }
        }
        #endregion


    }
}
