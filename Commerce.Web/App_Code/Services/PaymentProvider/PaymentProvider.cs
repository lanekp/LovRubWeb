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
using System.Data;

namespace Commerce.Providers
{
    public class PaymentProviderCollection : System.Configuration.Provider.ProviderCollection
    {
        public new PaymentProvider this[string name]
        {
            get { return (PaymentProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is PaymentProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }
    public abstract class PaymentProvider : System.Configuration.Provider.ProviderBase
    {


	
        #region Payment Methods

        public abstract Commerce.Common.Transaction Charge(Commerce.Common.Order order);
        public abstract string Refund(Commerce.Common.Order order);

        #endregion

    }


}