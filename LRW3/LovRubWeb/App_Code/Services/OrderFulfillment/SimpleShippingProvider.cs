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
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Configuration;
using System.Collections.Specialized;
using System.Configuration.Provider;

namespace Commerce.Providers
{
    public class SimpleShippingProvider:FulfillmentProvider
    {
        string _connectionString = "";
        string _connectionStringName = "";

        #region Provider overrides
        public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
                throw new ArgumentNullException("config");

            base.Initialize(name, config);

            _connectionStringName = config["connectionStringName"].ToString();

            if (String.IsNullOrEmpty(_connectionStringName))
                throw new ProviderException("Empty or missing connectionStringName");

            config.Remove("connectionStringName");

            if (WebConfigurationManager.ConnectionStrings[_connectionStringName] == null)
                throw new ProviderException("Missing connection string");

            _connectionString = WebConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;

            if (String.IsNullOrEmpty(_connectionString))
                throw new ProviderException("Empty connection string");

        }
        #endregion

        
        
        public override DeliveryOptionCollection GetDeliveryOptions(PackageInfo package)
        {
            Database db = DatabaseFactory.CreateDatabase();
            
            using (DbCommand cmd = db.GetStoredProcCommand("CSK_Shipping_GetRates"))
            {
                db.AddInParameter(cmd,"@weight",DbType.Decimal, package.Weight);
                IDataReader rdr = db.ExecuteReader(cmd);

                DeliveryOptionCollection coll = new DeliveryOptionCollection();
                coll.Load(rdr);
                rdr.Close();
                return coll;
            }
        }
        public override DeliveryOptionCollection GetDeliveryOptions(PackageInfo package, DeliveryRestrictions restrictions)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sp = "CSK_Shipping_GetRates";
            if (restrictions == DeliveryRestrictions.Air)
            {
                sp="CSK_Shipping_GetRates_Air";
            }
            else if (restrictions == DeliveryRestrictions.Freight || restrictions == DeliveryRestrictions.Ground)
            {
                sp = "CSK_Shipping_GetRates_Ground";

            }

            using (DbCommand cmd = db.GetStoredProcCommand(sp))
            {
                db.AddInParameter(cmd, "@weight", DbType.Decimal, package.Weight);
                IDataReader rdr = db.ExecuteReader(cmd);

                DeliveryOptionCollection coll = new DeliveryOptionCollection();
                coll.Load(rdr);
                rdr.Close();
                return coll;
            }
        }

    }
}
