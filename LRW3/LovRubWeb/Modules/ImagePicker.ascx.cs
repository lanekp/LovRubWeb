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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Modules_ImagePicker : System.Web.UI.UserControl
{
    public string ImageFolder = "images";
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        imgPic.Visible = true;
    }

    protected string GetImage()
    {
        string sImage = imgPic.ImageUrl;
        sImage = System.IO.Path.GetFileName(sImage);
        return sImage;

    }
    public string GetSelectedImage()
    {
        string imgName = Request.Form[ClientID + "_bob"].ToString();
        return imgName;
    }
    public void LoadImage(string imageName)
    {
        if (imageName != string.Empty)
        {
            imgPic.ImageUrl = Utility.GetSiteRoot() + "/" + ImageFolder + "/" + imageName;
        }
        else
        {
            imgPic.ImageUrl = Page.ResolveUrl("~/images/1pix.gif"); 
        }

    }
}
