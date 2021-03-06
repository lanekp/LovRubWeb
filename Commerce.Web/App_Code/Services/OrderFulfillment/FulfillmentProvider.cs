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

namespace Commerce.Providers
{

    public class FulfillmentProviderCollection :ProviderCollection
    {

    }
    public abstract class FulfillmentProvider:ProviderBase
    {
        public abstract DeliveryOptionCollection GetDeliveryOptions(PackageInfo package);
        public abstract DeliveryOptionCollection GetDeliveryOptions(PackageInfo package, DeliveryRestrictions restrictions);

    }
}
