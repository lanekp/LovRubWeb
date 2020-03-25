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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using Commerce.Common;

public partial class AffiliateFeed : System.Web.UI.Page
{
    private int _affiliateID;
    private int _categoryID;
    private string _connectionString;
    private string _siteUrl = "";
    private string _appPath = "";

    const string FEED_TITLE = "Commerce Starter Kit 2.0 Products";
    const string FEED_DESCRIPTION = "Commerce Starter Kit 2.0 Products that can be added quickly and easily to your aggregator or site.";
    //Many thanks to Randy "Kenpo" Jones for this one!

    protected void Page_Load(object sender, EventArgs e)
    {
        _affiliateID = Convert.ToInt32(Request.QueryString["aid"]);
        _categoryID = Convert.ToInt32(Request.QueryString["catid"]);
        _connectionString = ConfigurationManager.ConnectionStrings["CommerceTemplate"].ConnectionString;
        //Get the application's URL
        if (Request.ApplicationPath == "/")
            _appPath = Request.ApplicationPath;
        else
            _appPath = Request.ApplicationPath + "/";
        _siteUrl = Request.Url.ToString();
        _siteUrl = _siteUrl.Replace(Request.Path, "") + _appPath;
        Response.Clear();
        Response.ContentType = "text/xml";
        BuildRssFeed();
    }

    public void BuildRssFeed()
    {
        XmlTextWriter rssFeed = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        rssFeed.WriteStartDocument();
        // The mandatory rss tag
        rssFeed.WriteStartElement("rss");
        rssFeed.WriteAttributeString("version", "2.0");
        // The channel tag contains RSS feed details
        rssFeed.WriteStartElement("channel");
        rssFeed.WriteElementString("title", FEED_TITLE);
        rssFeed.WriteElementString("link", _siteUrl);
        rssFeed.WriteElementString("description", FEED_DESCRIPTION);
        rssFeed.WriteElementString("language", System.Globalization.CultureInfo.CurrentCulture.Name);

        ProductCollection products = new ProductCollection();
        IDataReader rdr = ProductController.GetByCategoryID(_categoryID);
        products.Load(rdr);
        rdr.Close();
        string imagePath = "";
        string link = "";
        foreach (Commerce.Common.Product product in products)
        {

            link = Utility.GetRewriterUrl("product", product.ProductGUID, "aid="+_affiliateID.ToString());
            rssFeed.WriteStartElement("item");
            rssFeed.WriteElementString("title", product.ProductName);
            rssFeed.WriteElementString("description", product.ShortDescription);
            rssFeed.WriteElementString("link", link);
            rssFeed.WriteElementString("imagelink", Utility.GetSiteRoot() + "/" + product.ImageFile);
            rssFeed.WriteElementString("price", product.OurPrice.ToString("C"));
            rssFeed.WriteEndElement();

        }

        // Close all tags 
        rssFeed.WriteEndElement();
        rssFeed.WriteEndElement();
        rssFeed.WriteEndDocument();
        rssFeed.Flush();
        rssFeed.Close();
        Response.End();
    }
}
