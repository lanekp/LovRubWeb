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
using System.Configuration.Provider;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Data.Common;

namespace Commerce.Providers
{
    public class ZeroTaxRateProvider:TaxProvider
    {
        #region Provider specific behaviors
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            base.Initialize(name, config);


        }
        #endregion

        public override decimal GetTaxRate(string zip)
        {

            return 0;

        }

        public override decimal GetTaxRate(Commerce.Common.USState state)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override DataSet GetTaxTable(Commerce.Common.USState state)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
