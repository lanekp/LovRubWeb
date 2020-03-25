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
using SubSonic;

namespace Commerce.Common
{
    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Store_Transaction table.
    /// </summary>
    public partial class Transaction : ActiveRecord<Transaction>
    {

        #region Custom - not in DB
        private string _CVV2Code;

        public string CVV2Code
        {
            get
            {
                return _CVV2Code;
            }
            set
            {
                _CVV2Code = value;
            }
        }

        private string _GatewayResponse;

        public string GatewayResponse
        {
            get
            {
                return _GatewayResponse;
            }
            set
            {
                _GatewayResponse = value;
            }
        }
        //enum
        public TransactionType TransactionType
        {
            get
            {
                return (TransactionType)this.GetColumnValue("transactionTypeID");
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("transactionTypeID", value);
            }
        }
        #endregion

    }
}
