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
using System.Web;
using System.Net;
using System.IO;

namespace Commerce.Providers
{
    public class HttpRequestHandler
    {
        #region Variables
		private string _url;
		#endregion

		#region Properties
		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}
		#endregion

		#region Constructors

        public HttpRequestHandler(string url)
		{
			Url = url;
		}

		#endregion

		#region Methods

		public string POST(string XmlPostData)
		{
			ASCIIEncoding encodedData=new ASCIIEncoding();
			byte[]  byteArray=encodedData.GetBytes(XmlPostData);
			HttpWebRequest wr = (HttpWebRequest) WebRequest.Create(new Uri(Url));
			wr.Method = "POST";
			wr.KeepAlive = false;
			wr.UserAgent = "dashCommerce";
			wr.ContentType = "application/x-www-form-urlencoded";
			wr.ContentLength = XmlPostData.Length;
			Stream SendStream=wr.GetRequestStream();
			SendStream.Write(byteArray,0,byteArray.Length);
			SendStream.Close();
			HttpWebResponse WebResp = (HttpWebResponse) wr.GetResponse();
			string res = "";
			try
			{
				using (StreamReader sr = new StreamReader(WebResp.GetResponseStream()) )
				{
					res = sr.ReadToEnd();
				}
				WebResp.Close();
				return res;
			}
			catch(Exception ex)
			{
                LovRubLogger.LogException(ex); //KPL Added 04/10/08 
				throw new Exception("Http Request has failed. Exception: " + ex.ToString());
			}
		}
		#endregion
    }
}
