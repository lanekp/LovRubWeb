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

namespace Commerce.Providers {
  public class FlatRateTaxProvider : TaxProvider {

    string _connectionString = "";
    string _connectionStringName = "";

    #region Provider Initialize

    public override void Initialize(string name, NameValueCollection config) {
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

    public override decimal GetTaxRate(string zip) {
      decimal dOut = 0;
      //load the default db from the base class
      Microsoft.Practices.EnterpriseLibrary.Data.Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase();
      //specify the SP
      string cmd = "CSK_Tax_GetTaxRate";
      using (DbCommand dbCommand = db.GetStoredProcCommand(cmd)) {
        db.AddInParameter(dbCommand, "@zip", DbType.String, zip);
        //return a reader using the Ent Blocks
        using (IDataReader rdr = db.ExecuteReader(dbCommand)) {
          if (rdr.Read()) {
            dOut = (decimal)rdr["rate"];
          }
        }
        //load routine closes the reader if flag is set to true;
        return dOut;
      }
    }

    public override decimal GetTaxRate(Commerce.Common.USState state) {
      throw new Exception("The method or operation is not implemented.");
    }
    public override DataSet GetTaxTable(Commerce.Common.USState state) {
      throw new Exception("The method or operation is not implemented.");
    }

  }
}
