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

namespace Commerce.Providers {
  public class StrikeIronTaxProvider : TaxProvider {



    /// <summary>
    /// Calls strikeiron and gets rate for a zipcode
    /// </summary>
    /// <param name="zip"></param>
    /// <returns></returns>
    public override decimal GetTaxRate(string zip) {
      decimal dOut = 0;
      //create the service
      StrikeIron.TaxDataBasic tax = new StrikeIron.TaxDataBasic();

      //user credentials
      StrikeIron.RegisteredUser user = new StrikeIron.RegisteredUser();

      //you can get a free key for testing by registering at
      //strike iron. You can put you user/pass here, or a registration key

      if (this.ServiceKey != string.Empty) {
        user.UserID = ServiceKey;

      }
      else {
        user.UserID = ServiceLogin;
        user.Password = ServicePassword;
      }

      //license holder
      StrikeIron.LicenseInfo license = new StrikeIron.LicenseInfo();

      //add the user credentials
      license.RegisteredUser = user;

      //add the license info
      tax.LicenseInfoValue = license;

      //call the service, get the rate
      try {
        StrikeIron.TaxRateUSAData rate = tax.GetTaxRateUS(zip);
        dOut = Convert.ToDecimal(rate.total_sales_tax);
      }
      catch {

      }

      return dOut;
    }

    public override decimal GetTaxRate(Commerce.Common.USState state) {
      decimal dOut = 0;
      //create the service
      StrikeIron.TaxDataBasic tax = new StrikeIron.TaxDataBasic();

      //user credentials
      StrikeIron.RegisteredUser user = new StrikeIron.RegisteredUser();

      user.UserID = this.ServiceLogin;

      //license holder
      StrikeIron.LicenseInfo license = new StrikeIron.LicenseInfo();

      //add the user credentials
      license.RegisteredUser = user;

      //add the license info
      tax.LicenseInfoValue = license;

      //call the service, get the rate
      try {
        //StrikeIron.TaxRateUSAData rate = tax.GetTaxRateUS(zip);
        //dOut = Convert.ToDecimal(rate.total_sales_tax);
      }
      catch {

      }

      return dOut;
    }
    public override System.Data.DataSet GetTaxTable(Commerce.Common.USState state) {
      //talk to StrikeIron and get the rate info for a given state
      return null;

    }
    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config) {
      base.Initialize(name, config);
      try {
        this.ServiceKey = config["serviceKey"].ToString();
        //this.ServicePassword = config["servicePassword"].ToString();
        //this.ServiceLogin = config["serviceLogin"].ToString();
      }
      catch {
        throw new Exception("The Service Key must be set for the StrikeIronTaxProvider to work");
      }

    }

  }
}
