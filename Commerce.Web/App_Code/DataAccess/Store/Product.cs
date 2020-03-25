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
    /// This is an empty partial construct for you to extend the base class as needed, without
    /// needing to inheret from it. 
    /// </summary>
    public partial class ProductCollection : ActiveList<Product> {

    }

    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Store_Product table.
    /// </summary>
    public partial class Product : ActiveRecord<Product>
    {

        #region Custom Constructors
        public Product(string sku)
        {

            SetSQLProps();
            LoadByParam("sku", sku);

        }

        #endregion

        #region Custom

        //enum
        public ProductStatus Status {
            get {
                return (ProductStatus)this.GetColumnValue("statusID");
            }
            set {
                this.MarkDirty();
                this.SetColumnValue("statusID", value);
            }
        }

        //enum
        public ProductType ProductType {
            get {
                return (ProductType)this.GetColumnValue("productTypeID");
            }
            set {
                this.MarkDirty();
                this.SetColumnValue("productTypeID", value);
            }
        }

        //enum
        public ShippingType ShippingType {
            get {
                return (ShippingType)this.GetColumnValue("shippingTypeID");
            }
            set {
                this.MarkDirty();
                this.SetColumnValue("shippingTypeID", value);
            }
        }
        //holds the XML and is responsible for putting/pulling from DB
        //XML attribute listing
        private Attributes attributes;
        public Attributes Attributes
        {
            get
            {
                attributes = (Attributes)Utility.XmlToObject(typeof(Attributes), this.AttributeXML);
                return attributes;
            }
            set
            {
                attributes = value;
                this.AttributeXML = Utility.ObjectToXML(typeof(Attributes), attributes);
            }
        }
        private Attributes selectedAttributes;
        public Attributes SelectedAttributes
        {
            get
            {
                return selectedAttributes;
            }
            set
            {
                selectedAttributes = value;
            }
        }

        //images
        private ImageCollection images;

        public ImageCollection Images
        {
            get { return images; }
            set { images = value; }
        }

        //reviews
        private ProductReviewCollection reviews;

        public ProductReviewCollection Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        //descriptors
        private ProductDescriptorCollection descriptors;

        public ProductDescriptorCollection Descriptors
        {
            get { return descriptors; }
            set { descriptors = value; }
        }



        private decimal rating;

        public decimal Rating
        {
            get {

                if (this.TotalRatingVotes > 0)
                {
                    rating = this.RatingSum / TotalRatingVotes;
                }
                else
                {
                    rating = 4;
                }
                return rating; 
            
            }

        }

        private string shippingEstimate;

        public string ShippingEstimate
        {
            get { return shippingEstimate; }
            set { shippingEstimate = value; }
        }

        private string imageFile;

        public string ImageFile
        {
            get { return imageFile; }
            set { imageFile = value; }

        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private decimal discountAmount;

        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }

        private string promoCode;

        public string PromoCode
        {
            get { return promoCode; }
            set { promoCode = value; }
        }
        private decimal _youSavePercent;

        public decimal YouSavePercent
        {
            get
            {
                return _youSavePercent;
            }
            set
            {
                _youSavePercent = value;
            }
        }

        private decimal _youSavePrice;

        public decimal YouSavePrice
        {
            get
            {
                return _youSavePrice;
            }
            set
            {
                _youSavePrice = value;
            }
        }

        #endregion

	}
}
