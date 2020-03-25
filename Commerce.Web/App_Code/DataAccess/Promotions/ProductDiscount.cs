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
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SubSonic;
using Commerce.Common;

namespace Commerce.Promotions
{
    
    
    public class ProductDiscount 
    {

        public ProductDiscount()
        {

        }
        public bool IsLoaded = false;
        #region private vars

        int _CampaignID;
        string _Campaign;
        int _PromoID;
        string _PromoCode;
        string _Title;
        string _Description;
        int _ProductID;
        string _Sku;
        string _ProductName;
        decimal _OurPrice;
        decimal _RetailPrice;
        decimal _DiscountAmount;
        decimal _DiscountedPrice;
        decimal _Discount;
        int _QtyThreshold;
        bool _IsActive;
        DateTime _DateEnd;
        #endregion

        #region Public Props
        public int CampaignID
        {
            get { return _CampaignID; }
            set { _CampaignID = value; }
        }
        public string Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }
        public int PromoID
        {
            get { return _PromoID; }
            set { _PromoID = value; }
        }
        public string PromoCode
        {
            get { return _PromoCode; }
            set { _PromoCode = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string Sku
        {
            get { return _Sku; }
            set { _Sku = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public decimal OurPrice
        {
            get { return _OurPrice; }
            set { _OurPrice = value; }
        }
        public decimal RetailPrice
        {
            get { return _RetailPrice; }
            set { _RetailPrice = value; }
        }
        public decimal DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }
        public decimal DiscountedPrice
        {
            get { return _DiscountedPrice; }
            set { _DiscountedPrice = value; }
        }
        public decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public int QtyThreshold
        {
            get { return _QtyThreshold; }
            set { _QtyThreshold = value; }
        }
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public DateTime DateEnd
        {
            get { return _DateEnd; }
            set { _DateEnd = value; }
        }
        #endregion

        public void Load(IDataReader rdr)
        {
                IsLoaded = true;
                try { _CampaignID = (int)rdr["CampaignID"]; } catch { };
                try {_Campaign = rdr["CampaignName"].ToString(); } catch { };
                try {_PromoID = (int)rdr["PromoID"]; } catch { };
                try { _PromoCode = rdr["PromoCode"].ToString(); } catch { };
                try { _Title = rdr["Title"].ToString(); } catch { };
                try { _Description = rdr["Description"].ToString(); } catch { };
                try {_ProductID = (int)rdr["ProductID"]; } catch { };
                try { _Sku = rdr["Sku"].ToString(); } catch { };
                try { _ProductName = rdr["ProductName"].ToString(); } catch { };
                try {_OurPrice = (decimal)rdr["OurPrice"]; } catch { };
                try {_RetailPrice = (decimal)rdr["RetailPrice"]; } catch { };
                try {_DiscountAmount = (decimal)rdr["DiscountAmount"]; } catch { };
                try {_DiscountedPrice = (decimal)rdr["DiscountedPrice"]; } catch { };
                try {_Discount = (decimal)rdr["Discount"]; } catch { };
                try {_QtyThreshold = (int)rdr["QtyThreshold"]; } catch { };
                try {_IsActive =(bool)rdr["IsActive"]; } catch { };
                try {_DateEnd = (DateTime)rdr["DateEnd"]; } catch { };
            }

        #region Extended Data Access
        public static List<ProductDiscount> GetDiscounts()
        {

            IDataReader rdr = SPs.PromoProductMatrix().GetReader();
            List<ProductDiscount> coll = new List<ProductDiscount>();
            ProductDiscount disc;
            while (rdr.Read())
            {
                disc = new ProductDiscount();
                disc.Load(rdr);
                coll.Add(disc);
            }
            rdr.Close();
            return coll;

        }
        #endregion


        }

}