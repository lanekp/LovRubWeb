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
using System.Collections.Specialized;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration.Provider;
using System.Web.Configuration;
using Commerce.Common;

namespace Commerce.Providers
{
    class UpsShippingProvider : FulfillmentProvider
    {
        string _connectionUrl = "";
        string _upsAccessKey = "";
        string _upsUserName = "";
        string _upsPassword = "";
        string _upsPickupTypeCode = "";
        string _upsCustomerClassification = "";
        string _upsPackagingTypeCode = "";
        string _upsAdditionalHandlingCharge = "";
        DeliveryRestrictions _deliveryRestriction = DeliveryRestrictions.None;

        #region Provider specific behaviors
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            base.Initialize(name, config);

            _connectionUrl = config["connectionUrl"].ToString();
            if (String.IsNullOrEmpty(_connectionUrl))
                throw new ProviderException("Empty or missing connectionUrl");
            config.Remove("connectionUrl");

            _upsAccessKey = config["upsAccessKey"].ToString();
            if (String.IsNullOrEmpty(_upsAccessKey))
                throw new ProviderException("Empty or missing upsAccessKey");
            config.Remove("upsAccessKey");

            _upsUserName = config["upsUserName"].ToString();
            if (String.IsNullOrEmpty(_upsUserName))
                throw new ProviderException("Empty or missing upsUserName");
            config.Remove("upsUserName");

            _upsPassword = config["upsPassword"].ToString();
            if (String.IsNullOrEmpty(_upsPassword))
                throw new ProviderException("Empty or missing upsPassword");
            config.Remove("upsPassword");

            _upsPickupTypeCode = config["upsPickupTypeCode"].ToString();
            if (String.IsNullOrEmpty(_upsPickupTypeCode))
                throw new ProviderException("Empty or missing upsPickupTypeCode");
            config.Remove("upsPickupTypeCode");

            _upsCustomerClassification = config["upsCustomerClassification"].ToString();
            if (String.IsNullOrEmpty(_upsCustomerClassification))
                throw new ProviderException("Empty or missing upsCustomerClassification");
            config.Remove("upsCustomerClassification");

            _upsPackagingTypeCode = config["upsPackagingTypeCode"].ToString();
            if (String.IsNullOrEmpty(_upsPackagingTypeCode))
                throw new ProviderException("Empty or missing upsPackagingTypeCode");
            config.Remove("upsPackagingTypeCode");

            _upsAdditionalHandlingCharge = config["upsAdditionalHandlingCharge"].ToString();
            if (String.IsNullOrEmpty(_upsAdditionalHandlingCharge))
                throw new ProviderException("Empty or missing upsAdditionalHandlingCharge");
            config.Remove("upsAdditionalHandlingCharge");

            //Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException
                        ("Unrecognized attribute: " + attr);
            }
        }

        #endregion

        #region Constructors

        public UpsShippingProvider()
		{

		}

		#endregion

		#region Methods



        public override DeliveryOptionCollection GetDeliveryOptions(PackageInfo package)
        {
            HttpRequestHandler http = new HttpRequestHandler(_connectionUrl);
            string rateXml = http.POST( rateRequest(package) );
            DeliveryOptionCollection collection = UpsParseRates(rateXml);
            return collection;
        }

        public override DeliveryOptionCollection GetDeliveryOptions(PackageInfo package, DeliveryRestrictions restrictions)
        {
            //TODO: I need to put a little more thought into the restrictions
            if (restrictions == DeliveryRestrictions.Download)
            {
                throw new Exception("Shipping Error: This item is download only.");
            }
            _deliveryRestriction = restrictions;
            HttpRequestHandler http = new HttpRequestHandler(_connectionUrl);
            string rateXml = http.POST(rateRequest(package));
            DeliveryOptionCollection collection = UpsParseRates(rateXml);
            return collection;
        }
        private DeliveryOptionCollection UpsParseRates(string response)
        {
            DeliveryOptionCollection optionCollection = new DeliveryOptionCollection();
            StringReader sr = new StringReader(response);
            XmlTextReader tr = new XmlTextReader(sr);
            try
            {
                while (tr.Read())
                {
                    if ((tr.Name == "Error") && (tr.NodeType == XmlNodeType.Element))
                    {
                        string errorText = "";
                        while (tr.Read())
                        {
                            if ((tr.Name == "ErrorCode") && (tr.NodeType == XmlNodeType.Element))
                            {
                                errorText += "UPS Rating Error, Error Code: " + tr.ReadString() + ", ";
                            }
                            if ((tr.Name == "ErrorDescription") && (tr.NodeType == XmlNodeType.Element))
                            {
                                errorText += "Error Desc: " + tr.ReadString();
                            }
                        }
                        throw new ProviderException("UPS Error returned: " + errorText);
                    }
                    if ((tr.Name == "RatedShipment") && (tr.NodeType == XmlNodeType.Element))
                    {
                        string serviceCode = "";
                        string monetaryValue = "";
                        while (tr.Read())
                        {
                            if ((tr.Name == "Service") && (tr.NodeType == XmlNodeType.Element))
                            {
                                while (tr.Read())
                                {
                                    if ((tr.Name == "Code") && (tr.NodeType == XmlNodeType.Element))
                                    {
                                        serviceCode = tr.ReadString();
                                        tr.ReadEndElement();
                                    }
                                    if ((tr.Name == "Service") && (tr.NodeType == XmlNodeType.EndElement))
                                    {
                                        break;
                                    }
                                }
                            }
                            if (((tr.Name == "RatedShipment") && (tr.NodeType == XmlNodeType.EndElement)) || ((tr.Name == "RatedPackage") && (tr.NodeType == XmlNodeType.Element)))
                            {
                                break;
                            }
                            if ((tr.Name == "TotalCharges") && (tr.NodeType == XmlNodeType.Element))
                            {
                                while (tr.Read())
                                {
                                    if ((tr.Name == "MonetaryValue") && (tr.NodeType == XmlNodeType.Element))
                                    {
                                        monetaryValue = tr.ReadString();
                                        tr.ReadEndElement();
                                    }
                                    if ((tr.Name == "TotalCharges") && (tr.NodeType == XmlNodeType.EndElement))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        string service = GetServiceName(serviceCode);
                        decimal rate = Convert.ToDecimal(monetaryValue);
                        if (!String.IsNullOrEmpty(_upsAdditionalHandlingCharge))
                        {
                            decimal additionalHandling = Convert.ToDecimal(_upsAdditionalHandlingCharge);
                            rate += additionalHandling;
                        }
                        //Weed out unwanted or unkown service rates
                        if (service.ToUpper() != "UNKNOWN")
                        {
                            DeliveryOption option = new DeliveryOption();
                            option.Rate = rate;
                            option.Service = service;
                            optionCollection.Add(option);
                        }

                    }
                }
                sr.Dispose();
                return optionCollection;
            }
            catch
            {
                throw;
            }
            finally
            {
                sr.Close();
                tr.Close();
            }
        }
        // Changed Package Size and Weight restrictions based on:
        // http://www.ups.com/content/us/en/resources/prepare/weight_size.html?WT.svl=SubNav
        // old values were 130 for totalPackageSize and 70 for weight
        private bool IsPackageTooLarge(int length, int height, int width)
        {
            int total = totalPackageSize(length, height, width);
            if (total > 165)
                return true;
            else
                return false;
        }

        private int totalPackageSize(int length, int height, int width)
        {
            int girth = height + height + width + width;
            int total = girth + length;
            return total;
        }

        private bool IsPackageTooHeavy(int weight)
        {
            if (weight > 150)
                return true;
            else
                return false;
        }

        private string GetServiceName(string serviceID)
        {
            switch (serviceID)
            {
                case "01":
                    return "UPS NextDay Air";
                case "02":
                    return "UPS 2nd Day Air";
                case "03":
                    return "UPS Ground";
                case "07":
                    return "UPS Worldwide Express";
                case "08":
                    return "UPS Worldwide Expidited";
                case "11":
                    return "UPS Standard";
                case "12":
                    return "UPS 3 Day Select";
                case "13":
                    return "UPS Next Day Air Saver";
                case "14":
                    return "UPS Next Day Air Early A.M.";
                case "54":
                    return "UPS Worldwide Express Plus";
                case "59":
                    return "UPS 2nd Day Air A.M.";
                default:
                    return "Unknown";
            }
        }

        //Create rating request XML string
        private string rateRequest(PackageInfo package)
        {
            //Changed weight logic per JeffreyABecker suggestions
            int Weight = (int)Math.Ceiling(package.Weight);
            StringBuilder sb = new StringBuilder();
            //Build Access Request
            sb.Append("<?xml version='1.0'?>");
            sb.Append("<AccessRequest xml:lang='en-US'>");
            sb.AppendFormat("<AccessLicenseNumber>{0}</AccessLicenseNumber>", _upsAccessKey);
            sb.AppendFormat("<UserId>{0}</UserId>", _upsUserName);
            sb.AppendFormat("<Password>{0}</Password>", _upsPassword);
            sb.Append("</AccessRequest>");
            //Build Rate Request
            sb.Append("<?xml version='1.0'?>");
            sb.Append("<RatingServiceSelectionRequest xml:lang='en-US'>");
            sb.Append("<Request>");
            sb.Append("<TransactionReference>");
            sb.Append("<CustomerContext>Bare Bones Rate Request</CustomerContext>");
            sb.Append("<XpciVersion>1.0001</XpciVersion>");
            sb.Append("</TransactionReference>");
            sb.Append("<RequestAction>Rate</RequestAction>");
            sb.Append("<RequestOption>Shop</RequestOption>");
            sb.Append("</Request>");
            sb.Append("<PickupType>");
            sb.AppendFormat("<Code>{0}</Code>", _upsPickupTypeCode);
            sb.Append("</PickupType>");
            sb.Append("<CustomerClassification>");
            sb.AppendFormat("<Code>{0}</Code>", _upsCustomerClassification);
            sb.Append("</CustomerClassification>");
            sb.Append("<Shipment>");
            sb.Append("<Shipper>");
            sb.Append("<Address>");
            sb.AppendFormat("<PostalCode>{0}</PostalCode>", package.FromZip);
            sb.AppendFormat("<CountryCode>{0}</CountryCode>", package.FromCountryCode);
            sb.Append("</Address>");
            sb.Append("</Shipper>");
            sb.Append("<ShipTo>");
            sb.Append("<Address>");
            //Required to get accurate residential delivery rates
            sb.Append( "<ResidentialAddressIndicator/>" ); 
            sb.AppendFormat("<PostalCode>{0}</PostalCode>", package.ToZip);
            sb.AppendFormat("<CountryCode>{0}</CountryCode>", package.ToCountryCode);
            sb.Append("</Address>");
            sb.Append("</ShipTo>");
            sb.Append("<ShipFrom>");
            sb.Append("<Address>");
            sb.AppendFormat("<PostalCode>{0}</PostalCode>", package.FromZip);
            sb.AppendFormat("<CountryCode>{0}</CountryCode>", package.FromCountryCode);
            sb.Append("</Address>");
            sb.Append("</ShipFrom>");
            sb.Append("<Service>");
            sb.Append("<Code>03</Code>");
            sb.Append("</Service>");
            string packageStr = BuildRatePackage(_upsPackagingTypeCode, package.Length,
                package.Width, package.Height, Weight);
            sb.Append(packageStr);
            sb.Append("</Shipment>");
            sb.Append("</RatingServiceSelectionRequest>");
            return sb.ToString();
        }

        private string BuildRatePackage(string upsPackagingTypeCode, int length, 
            int width, int height, int packageWeight)
        {
            if ((!IsPackageTooHeavy(packageWeight))
                && (!IsPackageTooLarge(length, height, width)))
            {
                //Rate single package
                StringBuilder sb = new StringBuilder();
                sb.Append("<Package>");
                sb.Append("<PackagingType>");
                sb.AppendFormat("<Code>{0}</Code>", upsPackagingTypeCode);
                sb.Append("</PackagingType>");
                sb.Append("<Dimensions>");
                sb.AppendFormat("<Length>{0}</Length>", length);
                sb.AppendFormat("<Width>{0}</Width>", width);
                sb.AppendFormat("<Height>{0}</Height>", height);
                sb.Append("</Dimensions>");
                sb.Append("<PackageWeight>");
                sb.AppendFormat("<Weight>{0}</Weight>", packageWeight);
                sb.Append("</PackageWeight>");
                sb.Append("</Package>");
                return sb.ToString();
            }
            else
            {
                //Rate multiple packages
                int totalPackages = 1;
                int tempPackageWeight = 0;
                int tempPackageHeight = 0;
                int tempPackageWidth = 0;
                if (length != 0 && height != 0 && width != 0)
                {
                    totalPackages = totalPackageSize(length, height, width) / 108;
                    tempPackageWeight = packageWeight / totalPackages;
                    tempPackageHeight = height / totalPackages;
                    tempPackageWidth = width / totalPackages;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= totalPackages; i++)
                {
                    sb.Append("<Package>");
                    sb.Append("<PackagingType>");
                    sb.AppendFormat("<Code>{0}</Code>", upsPackagingTypeCode);
                    sb.Append("</PackagingType>");
                    sb.Append("<Dimensions>");
                    sb.AppendFormat("<Length>{0}</Length>", length);
                    sb.AppendFormat("<Width>{0}</Width>", tempPackageWidth);
                    sb.AppendFormat("<Height>{0}</Height>", tempPackageHeight);
                    sb.Append("</Dimensions>");
                    sb.Append("<PackageWeight>");
                    sb.AppendFormat("<Weight>{0}</Weight>", tempPackageWeight);
                    sb.Append("</PackageWeight>");
                    sb.Append("</Package>");
                }

                return sb.ToString();
            }
        }
		#endregion
    }
}