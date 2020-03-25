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
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration.Provider;
using System.Web.Configuration;
using Commerce.Common;

namespace Commerce.Providers
{
    class USPostalServiceShippingProvider : FulfillmentProvider
    {
        #region Variables
        string _connectionUrl = "";
        string _uspsUserName = "";
        string _uspsPassword = "";
        string _uspsAdditionalHandlingCharge = "";
        DeliveryRestrictions _deliveryRestriction = DeliveryRestrictions.None;
        #endregion

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

            _uspsUserName = config["uspsUserName"].ToString();
            if (String.IsNullOrEmpty(_uspsUserName))
                throw new ProviderException("Empty or missing uspsUserName");
            config.Remove("uspsUserName");

            _uspsPassword = config["uspsPassword"].ToString();
            if(String.IsNullOrEmpty(_uspsPassword))
              throw new ProviderException("Empty or missing uspsPassword");
            config.Remove("uspsPassword");

            _uspsAdditionalHandlingCharge = config["uspsAdditionalHandlingCharge"].ToString();
            if (String.IsNullOrEmpty(_uspsAdditionalHandlingCharge))
                throw new ProviderException("Empty or missing uspsAdditionalHandlingCharge");
            config.Remove("uspsAdditionalHandlingCharge");

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
        
        #region Methods
        public override DeliveryOptionCollection GetDeliveryOptions(PackageInfo package)
        {
            HttpRequestHandler http = new HttpRequestHandler(_connectionUrl);
            string rateXml = http.POST(rateRequest(package));
            DeliveryOptionCollection collection = UspsParseRates(rateXml);
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
            DeliveryOptionCollection collection = UspsParseRates(rateXml);
            return collection;
        }


        private bool IsPackageTooLarge(int length, int height, int width)
        {
            int total = totalPackageSize(length, height, width);
            if (total > 130)
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
            if (weight > 70)
                return true;
            else
                return false;
        }

        private string GetPackageSize(int length, int height, int width)
        {
            int girth = height + height + width + width;
            int total = girth + length;
            if (total <= 84)
                return "REGULAR";
            if ((total > 84) && (total <= 108))
                return "LARGE";
            if ((total > 108) && (total <= 130))
                return "OVERSIZE";
            else
                throw new Exception("Shipping Error: Package too large.");
        }

        private DeliveryOptionCollection UspsParseRates(string response)
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
                            if ((tr.Name == "HelpContext") && (tr.NodeType == XmlNodeType.Element))
                            {
                                errorText += "USPS Help Context: " + tr.ReadString() + ", ";
                            }
                            if ((tr.Name == "Description") && (tr.NodeType == XmlNodeType.Element))
                            {
                                errorText += "Error Desc: " + tr.ReadString();
                            }
                        }
                        throw new ProviderException("USPS Error returned: " + errorText);
                    }
                    if ((tr.Name == "Postage") && (tr.NodeType == XmlNodeType.Element))
                    {
                        string serviceCode = "";
                        string postalRate = "";
                        while (tr.Read())
                        {
                            if ((tr.Name == "MailService") && (tr.NodeType == XmlNodeType.Element))
                            {
                                serviceCode = tr.ReadString();
                                tr.ReadEndElement();
                                if ((tr.Name == "MailService") && (tr.NodeType == XmlNodeType.EndElement))
                                {
                                    break;
                                }
                            }
                            if (((tr.Name == "Postage") && (tr.NodeType == XmlNodeType.EndElement)) || ((tr.Name == "Postage") && (tr.NodeType == XmlNodeType.Element)))
                            {
                                break;
                            }
                            if ((tr.Name == "Rate") && (tr.NodeType == XmlNodeType.Element))
                            {
                                postalRate = tr.ReadString();
                                tr.ReadEndElement();
                                if ((tr.Name == "Rate") && (tr.NodeType == XmlNodeType.EndElement))
                                {
                                    break;
                                }
                            }
                        }
                        string service = GetServiceName(serviceCode);
                        decimal rate = Convert.ToDecimal(postalRate);
                        if (!String.IsNullOrEmpty(_uspsAdditionalHandlingCharge))
                        {
                            decimal additionalHandling = Convert.ToDecimal(_uspsAdditionalHandlingCharge);
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

        private string GetServiceName(string serviceCode)
        {
            switch (serviceCode)
            {
                case "Parcel Post":
                    return "USPS Parcel Post";
                case "Priority Mail":
                    return "USPS Priority Mail";
                case "Express Mail PO to Addressee":
                    return "USPS Express Mail";
                default:
                    return "Unknown";
            }
        }

        //Create rating request XML string
        private string rateRequest(PackageInfo package)
        {
            //Changed weight logic per JeffreyABecker suggestions
            int tOz = (int)Math.Ceiling(package.Weight * 16.0m);
            int packageWeightPounds = tOz / 16;
            int packageWeightOunces = tOz % 16;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<RateV2Request USERID=\"{0}\" PASSWORD=\"{1}\">", _uspsUserName, _uspsPassword);
            string packageStr = BuildRatePackage(package, packageWeightPounds, 
                packageWeightOunces, package.Length, package.Height, 
                package.Width);
            sb.Append(packageStr);
            sb.Append("</RateV2Request>");
            return "API=RateV2&XML=" + sb.ToString();
            
        }

        private string BuildRatePackage(PackageInfo package, int packageWeightPounds, int packageWeightOunces,
            int length, int height, int width)
        {
            if ((!IsPackageTooHeavy(packageWeightPounds))
                && (!IsPackageTooLarge(length, height, width)))
            {
                //Rate single package
                string packageSize = GetPackageSize(length, height, width);
                StringBuilder sb = new StringBuilder();
                sb.Append("<Package ID=\"0\">");
                sb.Append("<Service>ALL</Service>");
                sb.AppendFormat("<ZipOrigination>{0}</ZipOrigination>", package.FromZip);
                sb.AppendFormat("<ZipDestination>{0}</ZipDestination>", package.ToZip);
                sb.AppendFormat("<Pounds>{0}</Pounds>", packageWeightPounds);
                sb.AppendFormat("<Ounces>{0}</Ounces>", packageWeightOunces);
                sb.AppendFormat("<Size>{0}</Size>", packageSize);
                sb.Append("<Machinable>FALSE</Machinable>");//Packages are not machinable
                sb.Append("</Package>");
                return sb.ToString();
            }
            else
            {
                //Rate multiple packages
                int totalPackages = totalPackageSize(length, height, width) / 108;
                int tempPackageWeightPounds = packageWeightPounds / totalPackages;
                int temppackageWeightOunces = packageWeightOunces / totalPackages;
                int tempPackageHeight = height / totalPackages;
                int tempPackageWidth = width / totalPackages;
                string packageSize = GetPackageSize(length,
                    tempPackageHeight, tempPackageWidth);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= totalPackages; i++)
                {
                    sb.AppendFormat("<Package ID=\"{0}\">", i.ToString());
                    sb.Append("<Service>ALL</Service>");
                    sb.AppendFormat("<ZipOrigination>{0}</ZipOrigination>", package.FromZip);
                    sb.AppendFormat("<ZipDestination>{0}</ZipDestination>", package.ToZip);
                    sb.AppendFormat("<Pounds>{0}</Pounds>", tempPackageWeightPounds);
                    sb.AppendFormat("<Ounces>{0}</Ounces>", temppackageWeightOunces);
                    sb.AppendFormat("<Size>{0}</Size>", packageSize);
                    sb.Append("<Machinable>FALSE</Machinable>");//Packages are not machinable
                    sb.Append("</Package>");
                }
                return sb.ToString();
            }
        }
        #endregion
    }
}
