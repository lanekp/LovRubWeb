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
using System.Collections;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Web.Caching;
using System.Web.Configuration;

namespace Commerce.Providers {
    public class TaxProviderCollection : System.Configuration.Provider.ProviderCollection
    {
        public new TaxProvider this[string name]
        {
            get { return (TaxProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is TaxProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }    
    public abstract class TaxProvider : ProviderBase {

        private string serviceLogin;
        /// <summary>
        /// Used for remote service calls
        /// </summary>
        public string ServiceLogin
        {
            get { return serviceLogin; }
            set { serviceLogin = value; }
        }
        private string servicePassword;

        /// <summary>
        /// Used for remote service calls
        /// </summary>
        public string ServicePassword
        {
            get { return servicePassword; }
            set { servicePassword = value; }
        }

        private string serviceKey;

        public string ServiceKey
        {
            get { return serviceKey; }
            set { serviceKey = value; }
        }
	
        private const string _providerType = "CommerceTaxProvider";

        private static volatile TaxProvider _provider = null;
        private static object padLock = new object();

        #region Tax Calls
		public abstract decimal GetTaxRate(string zip);
        public abstract decimal GetTaxRate(Commerce.Common.USState state);
        
        /// <summary>
        /// Returns a DataSet containing State, Zip, and Tax Rate info for a 
        /// given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract DataSet GetTaxTable(Commerce.Common.USState state);
        #endregion

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }

    }
}
