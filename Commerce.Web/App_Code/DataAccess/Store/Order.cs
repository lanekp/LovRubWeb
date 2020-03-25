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
    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Store_Order table.
    /// </summary>
    public partial class Order : ActiveRecord<Order>
    {

        #region custom .ctors
        /// <summary>
        /// Sets the static Table property from our Base class. This property tells
        /// the base class how to create the CRUD queries, etc.
        /// </summary>

        public Order(string orderID)
        {
            SetSQLProps();
            //override the default implementation since orderID is a GUID
            Query q = new Query(Schema);
            q.AddWhere("orderID", orderID);
            IDataReader rdr = q.ExecuteReader();
            Load(rdr);
        }

        #endregion

        #region Custom - not in DB

        private OrderItem _lastAdded;

        public OrderItem LastAdded
        {
            get { return _lastAdded; }
            set { _lastAdded = value; }
        }

        int currencyDecimals = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits;


        /// <summary>
        /// This is a calculated field that's also stored in the DB for
        /// Reporting purposes.
        /// </summary>
        public decimal CalculateSubTotal()
        {

            decimal dOut = 0;
            if (this.Items != null)
            {

                foreach (OrderItem item in this.Items)
                {
                    dOut += item.LineTotal;
                }

                dOut = Math.Round(dOut, currencyDecimals);
                
                //apply any discounts
                dOut -= this.DiscountAmount;
            }
            else
            {
                dOut = 0;
            }

            

            //using this for the save method
            return dOut;


        }
        /// <summary>
        /// Delete's a pending order from the system. This will not work
        /// for orders that have already been paid/cancelled/refunded
        /// </summary>
        public void DeletePermanent()
        {
            QueryCommandCollection coll = new QueryCommandCollection();
            if (this.OrderStatus == OrderStatus.NotProcessed)
            {
                //in order - notes, transactions, items, order
                //notes
                Query q = new Query(OrderNote.GetTableSchema());
                q.AddWhere("orderID", OrderID);
                coll.Add(q.BuildDeleteCommand());

                //transactions
                q = new Query(Transaction.GetTableSchema());
                q.AddWhere("orderID", OrderID);
                coll.Add(q.BuildDeleteCommand());
                
                //items
                q = new Query(OrderItem.GetTableSchema());
                q.AddWhere("orderID", OrderID);
                coll.Add(q.BuildDeleteCommand());

                q = new Query(Schema);
                q.AddWhere("orderID", OrderID);
                coll.Add(q.BuildDeleteCommand());

                DataService.ExecuteTransaction(coll);

            }
        }
        public void SaveItems(){

            //queue up a SQL batch of the existing items
            //and save them all at once
            QueryCommandCollection coll = new QueryCommandCollection();

            //first, delete out all the existing items
            Query qry = new Query(OrderItem.GetTableSchema());
            qry.AddWhere("orderID", this.OrderID);
            qry.QueryType = QueryType.Delete;
            coll.Add(qry.BuildCommand());
            QueryCommand insertItemCommand = null;
            
            foreach (OrderItem item in this.Items)
            {
                insertItemCommand = item.GetInsertCommand(Utility.GetUserName());
                coll.Add(insertItemCommand);

            }

            DataService.ExecuteTransaction(coll);



        }
        public decimal GetItemsWeight()
        {
            decimal dOut = 0;
            decimal dQty = 0;
            decimal dWeight = 0;

            foreach (OrderItem item in this.Items)
            {
                dQty = Convert.ToDecimal(item.Quantity);
                dWeight = item.Weight;
                dOut += dQty * dWeight;
            }
            return dOut;
        }
        public decimal GetTotalWidth()
        {
            decimal dOut = 0;
            decimal dQty = 0;
            decimal dWidth = 0;

            foreach (OrderItem item in this.Items)
            {
                dQty = Convert.ToDecimal(item.Quantity);
                dWidth = item.Width;
                dOut += dQty * dWidth;
            }
            return dOut;
        }
        public decimal GetTotalHeight()
        {
            decimal dOut = 0;
            decimal dQty = 0;
            decimal dHeight = 0;

            foreach (OrderItem item in this.Items)
            {
                dQty = Convert.ToDecimal(item.Quantity);
                dHeight = item.Height;
                dOut += dQty * dHeight;
            }
            return dOut;
        }
        public decimal GetMaxLength()
        {
            decimal dOut = 0;
            decimal dQty = 0;
            decimal dLength = 0;

            foreach (OrderItem item in this.Items)
            {
                dQty = Convert.ToDecimal(item.Quantity);
                dLength = item.Length;
                dOut += dQty * dLength;
            }
            return dOut;
        }

        public decimal OrderTotal
        {
            get
            {
                decimal dSub = this.CalculateSubTotal();
                if (dSub == 0)
                    dSub = this.SubTotalAmount;

                return dSub + this.TaxAmount + this.ShippingAmount;
            }
        }

        #region "Credit Card Information"
        [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
        private string _CreditCardNumber;
        [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
        private int _CrediCartExpYear;
        [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
        private int _CreditCardExpireMonth;
        [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
        private string _CreditCardSecurityNumber;
        [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
        private CreditCardType _CreditCardType;

        //[NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public string CreditCardNumber
        {
            get
            {
                return _CreditCardNumber;
            }
            set
            {
                _CreditCardNumber = value;
            }
        }

        //[NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public int CreditCardExpireYear
        {
            get
            {
                return _CrediCartExpYear;
            }
            set
            {
                _CrediCartExpYear = value;
            }
        }

        //[NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public int CreditCardExpireMonth
        {
            get
            {
                return _CreditCardExpireMonth;
            }
            set
            {
                _CreditCardExpireMonth = value;
            }
        }

        //[NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public string CreditCardSecurityNumber
        {
            get
            {
                return _CreditCardSecurityNumber;
            }
            set
            {
                _CreditCardSecurityNumber = value;
            }
        }


        //[NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public CreditCardType CreditCardType
        {
            get
            {
                return _CreditCardType;
            }
            set
            {
                _CreditCardType = value;
            }
        }


        #endregion


        public string PONumber
        {
            get
            {
                return _PONumber;
            }
            set
            {
                _PONumber = value;
            }
        }

        //Not currently implemented. Stubbed 
        //for future use.
        public string TaxExemptionCode
        {
            get
            {
                return _TaxExemptionCode;
            }
            set
            {
                _TaxExemptionCode = value;
            }
        }
        [XmlIgnore]
        public OrderItemCollection Items;
        public Address ShippingAddress;
        public Address BillingAddress;
        [XmlIgnore]
        public TransactionCollection Transactions;
        [XmlIgnore]
        public OrderNoteCollection Notes;


        private string _PONumber;
        private string _TaxExemptionCode;
        #endregion

        #region ToString() Override
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //override the base class to output a nice text rendering
            sb.Append("********* ORDER " + this.OrderNumber + " ************************");
            sb.Append("Bill To:\r\n" + this.BillToAddress + "\r\n\r\n");
            sb.Append("Ship To:\r\n" + this.ShipToAddress + "\r\n\r\n");

            if (this.Transactions.Count > 0)
            {
                sb.Append("Payment Method: " + this.Transactions[0].TransactionType.ToString() + "\r\n\r\n");
            }
            sb.Append(ItemsToString(false) + "\r\n\r\n");
            sb.Append("More Info: " + Utility.GetSiteRoot() + "/admin/admin_orders_details.aspx?id=" + this.OrderID);
            return sb.ToString();
        }
        public string ToHtml()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("<table width=600 cellpadding=0 cellspacing=0 >");
            sb.Append("<tr><td colspan=2 style='height:20;background-color:whitesmoke;border:1px solid #cccccc;font-size:14px;padding:10px'><b>Order Number " + this.OrderNumber + "</b></td></tr>");
            sb.Append("<tr><td colspan=2 style='padding:10px'><font color=#990000><b>Status:</b> " + Utility.ParseCamelToProper(Enum.GetName(typeof(OrderStatus), this.OrderStatus)) + "</font><br>");
            sb.Append("<b>Date:</b> " + this.OrderDate.ToShortDateString() + "<br><br></td></tr>");
            if (this.Transactions.Count > 0)
            {
                sb.Append("<tr><td colspan=2><font size=2>&nbsp;&nbsp;<b>Payment Information</b></font></td></tr>");
                sb.Append("<tr><td colspan=2 style='border-top:1px solid #cccccc'>&nbsp;</td></tr>");
                sb.Append("<tr><td colspan=2 style='padding:10px'><b>Transaction Number:</b> " + this.Transactions[0].AuthorizationCode + "<br>");
                sb.Append("<b>Payment Method:</b> " + this.Transactions[0].TransactionType.ToString() + "<br><br><br><br></td></tr>");
            }
            sb.Append("<tr><td colspan=2>&nbsp;&nbsp;<font size=2><b>Shipping And Billing</b></font></td></tr>");
            sb.Append("<tr><td colspan=2 style='border-top:1px solid #cccccc'>&nbsp;</td></tr>");
            sb.Append("<tr><td width=50% style='padding:10px' valign=top><b>Bill To:</b><br>" + this.BillToAddress + "</td><td style='padding:10px' valign=top><b>Ship To:</b><br>" + this.ShipToAddress.ToString() + "<br><br><br><br></td></tr>");
            sb.Append("<tr><td colspan=2>&nbsp;&nbsp;<font size=2><b>Order Items</b></font></td></tr>");
            sb.Append("<tr><td colspan=2 style='border-top:1px solid #cccccc'>&nbsp;</td></tr>");
            sb.Append("<tr><td colspan=2 style='padding:10px'>" + this.ItemsToString(true) + "</td></tr>");
            sb.Append("</table>");

            return sb.ToString();


        }
        public string ItemsToString(bool UseHtml)
        {

            string sOut = "";
            if (UseHtml)
            {
                sOut = "";
                StringBuilder sb = new StringBuilder();
/*
                sb.Append("<table width=100% cellpadding=4 cellspacing=0>");
                sb.Append("<tr style='border:1px solid #cccccc; background-color:whitesmoke'><td><b>Item Number</b></td><td><b>Item</b></td><td><b>Quantity</b></td><td><b>Price</b></td><td><b>Total<b></td></tr>");

                string appendFormat = "<tr bgcolor=#ffffff><Td>{0}</td><td>{1}</td><td>{2}</td><td align=right>{3}</td><td align=right>{4}</td></tr>";
                string appendAltFormat = "<tr bgcolor=#f5f5f5><Td>{0}</td><td>{1}</td><td>{2}</td><td align=right>{3}</td><Td align=right>{4}</td></tr>";
 */
                sb.Append("<table width=733 cellpadding=4 cellspacing=0>");
                sb.Append("<tr style='border:1px solid #cccccc; background-color:#3A3A3C'><td><b>Item Number</b></td><td><b>Item</b></td><td><b>Quantity</b></td><td><b>Price</b></td><td><b>Total<b></td></tr>");

                string appendFormat = "<tr bgcolor=#3A3A3C><Td>{0}</td><td>{1}</td><td>{2}</td><td align=right>{3}</td><td align=right>{4}</td></tr>";
                string appendAltFormat = "<tr bgcolor=#3A3A3C><Td>{0}</td><td>{1}</td><td>{2}</td><td align=right>{3}</td><Td align=right>{4}</td></tr>";
 
                string formatToUse = appendFormat;

                bool isEven = true;

                foreach (OrderItem item in this.Items)
                {

                    if (isEven)
                    {
                        formatToUse = appendFormat;
                    }
                    else
                    {
                        formatToUse = appendAltFormat;
                    }
                    string attSelections = "";
                    if (item.Attributes != string.Empty)
                    {
                        attSelections = "<br>" + item.Attributes;
                    }

                    sb.AppendFormat(formatToUse,item.Sku, item.ProductName+" "+attSelections,
                        item.Quantity.ToString(), item.PricePaid.ToString("C"),
                        item.LineTotal.ToString("C"));
                    isEven = !isEven;


                }
                //append the totals
                decimal subTotal = this.CalculateSubTotal();

                if (this.DiscountAmount > 0) {
                    decimal originalAmount = subTotal+this.DiscountAmount;
                    sb.Append("<tr><td colspan=4 align=right><b>Item Total:</td><td align=right>" + originalAmount.ToString("c") + "</td></tr>");
                    sb.Append("<tr><td colspan=4 align=right><b>Discount:</td><td align=right style='color:#990000'>(" + this.DiscountAmount.ToString("c") + ")</td></tr>");
                    sb.Append("<tr><td colspan=4 align=right><b>Subtotal:</td><td align=right>" + subTotal.ToString("c") + "</td></tr>");

                } else {
                    sb.Append("<tr><td colspan=4 align=right><b>Subtotal:</td><td align=right>" + subTotal.ToString("c") + "</td></tr>");

                }


                sb.Append("<tr><td colspan=4 align=right><b>Tax:</td><td align=right>" + this.TaxAmount.ToString("c") + "</td></tr>");
                sb.Append("<tr><td colspan=4 align=right><b>Shipping:</td><td align=right>" + this.ShippingAmount.ToString("c") + "</td></tr>");
                sb.Append("<tr><td colspan=4 align=right><b><font color:#990000>Total:</font></td><td align=right><font color:#990000>" + this.OrderTotal.ToString("c") + "</font></td></tr>");

                sb.Append("</table>");
                sOut = sb.ToString();
            }
            else
            {
                sOut = GetASCII();
            }
            return sOut;
        }

        /// <summary>
        /// Helper for the output of the string
        /// </summary>
        /// <returns></returns>
        string GetASCII()
        {
            StringBuilder sb = new StringBuilder();
            decimal runningTotal = 0;
            foreach (OrderItem item in this.Items)
            {
                runningTotal += item.LineTotal;
                sb.AppendLine("Item        :" + item.ProductName);
                sb.AppendLine("Quantity    :" + item.Quantity.ToString());
                sb.AppendLine("Price Paid  :" + item.PricePaid.ToString("C"));
                sb.AppendLine("");
                sb.AppendLine("");
            }
            sb.AppendLine("");
            sb.AppendLine("========================================");
            sb.AppendLine("Grand Total: " + runningTotal.ToString("C"));
            return sb.ToString();
        }
        #endregion

        #region Public Props
        //enum
        public OrderStatus OrderStatus
        {
            get
            {
                return (OrderStatus)this.GetColumnValue("orderStatusID");
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("orderStatusID", value);
            }
        }
        #endregion

    }
}
