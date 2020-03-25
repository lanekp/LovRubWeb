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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Commerce.Common;
namespace Commerce.Web.UI.Controls
{
    /// <summary>
    /// Renders a transparent gif image with a particular size.
    /// Default size is 1x1.
    /// </summary>
    public class Spacer : Control
    {
        #region Members

        string htmlImage = "<div><img src=\"{0}\" border=\"0\" width=\"{1}\" height=\"{2}\"></div>";

        #endregion

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(string.Format(htmlImage,
                string.Format("{0}{1}", ImagePath, ImageName),
                Convert.ToInt32(Width.Value).ToString(),
                Convert.ToInt32(Height.Value).ToString()));
        }

        #region Properties

        /// <summary>
        /// Spacer image path.
        /// </summary>
        private string imagePath = null;
        public string ImagePath
        {
            get {
                if (Utility.IsNullOrEmpty(imagePath))
                    imagePath = Utility.GetSiteRoot() + "/images/";

                return (imagePath.EndsWith("/") ? imagePath : string.Format("{0}{1}", imagePath, "/"));
            }
            set { imagePath = value; }
        }

        /// <summary>
        /// Spacer image name. This usually is a 1x1 transparent gif.
        /// </summary>
        private string imageName = null;
        public string ImageName
        {
            get {
                if (Utility.IsNullOrEmpty(imageName))
                    imagePath = "1pix.gif";

                return imagePath;
            }
            set { imagePath = value; }
        }

        /// <summary>
        /// Spacer width.
        /// </summary>
        Unit width = Unit.Pixel(1);
        public Unit Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Spacer height.
        /// </summary>
        Unit height = Unit.Pixel(1);
        public Unit Height
        {
            get { return height; }
            set { height = value; }
        }

        #endregion
    }
}
