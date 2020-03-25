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
using System.Configuration.Provider;
using System.Configuration;
using System.Web.Configuration;

namespace Commerce.Providers
{
    public enum DeliveryRestrictions
    {
        Ground,
        Air,
        Freight,
        Download,
        None

    }

    public class FulfillmentService
    {

        #region Provider-specific bits
        private static FulfillmentProvider _provider = null;
        private static FulfillmentProviderCollection _providers = null;
        private static object _lock = new object();

        public FulfillmentProvider Provider
        {
            get { return _provider; }
        }

        public FulfillmentProviderCollection Providers
        {
            get { return _providers; }
        }
        public static FulfillmentProvider Instance
        {
            get
            {
                LoadProviders();
                return _provider;
            }
        }

        static Commerce.Providers.FulfillmentServiceSection ThisConfig;
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
                        // Get a reference to the <imageService> section
                        ThisConfig = (Commerce.Providers.FulfillmentServiceSection)
                            WebConfigurationManager.GetSection
                            ("FulfillmentService");
                        
                        // Load registered providers and point _provider
                        // to the default provider
                        _providers = new FulfillmentProviderCollection();
                        ProvidersHelper.InstantiateProviders(ThisConfig.Providers, _providers, typeof(FulfillmentProvider));
                        _provider = (FulfillmentProvider)_providers[ThisConfig.DefaultProvider];

                        if (_provider == null)
                            throw new ProviderException
                                ("Unable to load default FulfillmentProvider");
                    }
                }
            }
        }
        #endregion

        
        


        public static DeliveryOptionCollection GetOptions(PackageInfo package)
        {
            LoadProviders();
            DeliveryOptionCollection options = new DeliveryOptionCollection();

            //if there are no restrictions, hit every provider and return the collection
            foreach (FulfillmentProvider provider in _providers)
            {
                options.Combine(provider.GetDeliveryOptions(package));
            }
            return options;
        }

        public static DeliveryOptionCollection GetOptions(PackageInfo package, DeliveryRestrictions restrictions)
        {
            LoadProviders();
            DeliveryOptionCollection options = new DeliveryOptionCollection();

            //if there are no restrictions, hit every provider and return the collection
            foreach (FulfillmentProvider provider in _providers)
            {
                options.Combine(provider.GetDeliveryOptions(package,restrictions));
            }
            return options;
        }

    }
}
