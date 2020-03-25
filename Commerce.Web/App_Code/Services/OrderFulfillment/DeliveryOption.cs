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
using Commerce.Common;

namespace Commerce.Providers{

    public class DeliveryOptionCollection : List<DeliveryOption>
    {
        public void Load(IDataReader rdr)
        {
            DeliveryOption option;
            while (rdr.Read())
            {
                option = new DeliveryOption();
                option.Load(rdr);
                this.Add(option);
            }
        }
        public void Combine(DeliveryOptionCollection options)
        {
            foreach (DeliveryOption option  in options)
            {
                this.Add(option);
            }
        }
    }

    public class DeliveryOption
	{

        private decimal rate;

        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        private decimal amountPerUnit;

        public decimal AmountPerUnit
        {
            get { return amountPerUnit; }
            set { amountPerUnit = value; }
        }
        private string service;

        public string Service
        {
            get { return service; }
            set { service = value; }
        }

        private bool isAirOnly;

        public bool IsAirOnly
        {
            get { return isAirOnly; }
            set { isAirOnly = value; }
        }
        private bool isGroundOnly;

        public bool IsGroundOnly
        {
            get { return isGroundOnly; }
            set { isGroundOnly = value; }
        }
        private bool isDownloadOnly;

        public bool IsDownloadOnly
        {
            get { return isDownloadOnly; }
            set { isDownloadOnly = value; }
        }
	
        public void Load(IDataReader rdr)
        {
            try { this.service = rdr["service"].ToString(); }
            catch { };
            try { this.rate = (decimal)rdr["rate"]; }
            catch { };
            try { this.amountPerUnit = (decimal)rdr["amountPerUnit"]; }
            catch { };
            try { this.isAirOnly = (bool)rdr["isAirOnly"]; }
            catch { };
            try { this.isDownloadOnly = (bool)rdr["isDownloadOnly"]; }
            catch { };

        }
	
	
	}
}
