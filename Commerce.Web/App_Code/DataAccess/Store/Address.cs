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
    public partial class Address : ActiveRecord<Address>
    {


        #region Custom - not in db

        public string FullAddress
        {
            get { return this.ToHtmlString(); }
        }
	

        //Used for ExpressCheckouts
        private string _PayPalPayerID;
        private string _PayPalToken;

        public string PayPalToken
        {
            get
            {
                return _PayPalToken;
            }
            set
            {
                _PayPalToken = value;
            }
        }

        public string PayPalPayerID
        {
            get
            {
                return _PayPalPayerID;
            }
            set
            {
                _PayPalPayerID = value;
            }
        }
        #endregion

        #region ToString() Override
        /// <summary>
        /// Override the base ToString() so that it will format nicely for a web-page
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            string sOut = FirstName + " " + LastName + "\r\n" +
                Address1 + "\r\n";
            if (!String.IsNullOrEmpty(Address2))
            {
                sOut += Address2 + "\r\n";
            }
            sOut += City + ", " + StateOrRegion + "  " + Zip + " " + Country;
            return sOut;
        }
        public string ToHtmlString()
        {
            string sOut = "<table>";
            sOut += "<tr><td><b>"+FirstName + " " + LastName + "</b></td></tr>" +
                "<tr><td>" + Address1 + "</td></tr>";
            if (!String.IsNullOrEmpty(Address2))
            {
                sOut += "<tr><td>" + Address2 + "</td></tr>";
            }
            sOut += "<tr><td>" + City + ", " + StateOrRegion + "  " + Zip + " " + Country + "</td></tr>";
            sOut += "</table>";
            return sOut;
        }	
        #endregion

        #region Comparisons
        public bool Equals(Address compareAddress)
        {
            bool bOut = false;
            //if the first, last, address1, city, state, etc are equal return true
            if(compareAddress.FirstName.ToLower().Equals(this.FirstName.ToLower()) &&
                compareAddress.LastName.ToLower().Equals(this.LastName.ToLower()) &&
                compareAddress.Address1.ToLower().Equals(this.Address1.ToLower()) &&
                compareAddress.City.ToLower().Equals(this.City.ToLower()) &&
                compareAddress.StateOrRegion.ToLower().Equals(this.StateOrRegion.ToLower())
                ){
                bOut=true;
            }
            return bOut;
        }
        #endregion


        public void Remove() {
          Query q = new Query(Address.GetTableSchema());
          q.AddWhere("AddressId", this.AddressID);
          q.QueryType = QueryType.Delete;
          q.Execute();                
        }
      }
}
