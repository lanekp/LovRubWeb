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
using SubSonic;

namespace Commerce.Common
{

    public static class Lookups
    {
        /// <summary>
        /// This is a simple function to use with lookup tables
        /// that are not represented with a business object.
        /// </summary>
        /// <param name="tableName">Name of the table to query. All results will be returned</param>
        /// <returns>IDataReader</returns>
        public static IDataReader GetList(string tableName)
        {

            return new Query(tableName).ExecuteReader();

        }

        /// <summary>
        /// This is a simple function to use with lookup tables
        /// that are not represented with a business object.
        /// You can supply a parameter name and value
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <param name="paramField">The column to use </param>
        /// <param name="paramValue">The column value</param>
        /// <returns></returns>
        public static IDataReader GetListByIntParam(string tableName, string paramField, int paramValue)
        {
            return new Query(tableName).AddWhere(paramField,paramValue).ExecuteReader();

        }
        /// <summary>
        /// This is a simple function to use with lookup tables
        /// that are not represented with a business object.
        /// You can supply a parameter name and value
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <param name="paramField">The column to use </param>
        /// <param name="paramValue">The column value</param>
        /// <returns></returns>
        public static IDataReader GetListByStringParam(string tableName, string paramField, string paramValue)
        {
            return new Query(tableName).AddWhere(paramField, paramValue).ExecuteReader();

        }

        public static void QuickAdd(string tableName, string paramField, string paramValue)
        {

            QueryCommand cmd = new QueryCommand("INSERT INTO " + tableName + " (" + paramField + ") VALUES(@p1) ");
            cmd.AddParameter("@p1", paramValue);
            DataService.ExecuteQuery(cmd);

        }
    
    }
}
