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
using Commerce.Providers;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using System.Web.Caching;
using System.Data;

namespace Commerce.Providers
{
    /// <summary>
    /// The tax calculator uses the TaxProvider to calculate the tax amount on 
    /// a set amount. You should consult your local tax laws before using/implementing.
    /// </summary>
    
    public class TaxService
    {
        #region Provider-specific bits
        private static TaxProvider _provider = null;
        private static object _lock = new object();

        public TaxProvider Provider
        {
            get { return _provider; }
        }

        public static TaxProvider Instance
        {
            get
            {
                LoadProviders();
                return _provider;
            }
        }
        private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (_lock)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Get a reference to the <TaxServiceSection> section
                        TaxServiceSection section = (TaxServiceSection)
                            WebConfigurationManager.GetSection
                            ("TaxService");

                        // Only want one provider here
                         _provider = (TaxProvider)ProvidersHelper.InstantiateProvider
                            (section.Providers[0], typeof(TaxProvider));

                        
                        if (_provider == null)
                            throw new ProviderException
                                ("Unable to load default TaxProvider");
                    }
                }
            }
        }
        #endregion


        public static decimal CalculateAmountByZIP(string zipCode, decimal subTotal) {
            decimal dOut = 0;
			try {
				decimal dRate = Instance.GetTaxRate(zipCode);
				dOut = subTotal * dRate;
			} catch(Exception x) {
				throw new ApplicationException("Tax calculation failed: " + x.Message, x);
			}
            return dOut;
        }
        public static decimal GetUSTaxRate(string zipCode)
        {
            return Instance.GetTaxRate(zipCode);

        }
        public static decimal GetUSTaxRate(Commerce.Common.USState state)
        {
            return Instance.GetTaxRate(state);
        }
    }
}
