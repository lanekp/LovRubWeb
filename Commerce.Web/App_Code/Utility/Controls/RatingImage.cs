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
    /// Summary description for RatingImage
    /// </summary>
    public class RatingImage : PlaceHolder
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlImage image = new HtmlImage();
            image.Border = 0;

            SetRatingImage(ref image);

            image.RenderControl(writer);
        }

        #region Properties

        /// <summary>
        /// Rating image path.
        /// </summary>
        private string imagePath = null;
        public string ImagePath
        {
            get
            {
                if (Utility.IsNullOrEmpty(imagePath))
                    imagePath = Utility.GetSiteRoot() + "/images/rating/";

                return (imagePath.EndsWith("/") ? imagePath : string.Format("{0}{1}", imagePath, "/"));
            }
            set { imagePath = value; }
        }

        /// <summary>
        /// Rating value.
        /// </summary>
        private double rating = 0.0;
        public double Rating
        {
            get {
                if (ViewState != null && ViewState["Rating"] != null)
                    rating = (double)ViewState["Rating"];

                return rating; 
            }
            set { 
                rating = value;

                if (ViewState != null)
                    ViewState["Rating"] = rating;
            }
        }

        private int totalVotes = 0;
        public int TotalVotes
        {
            get { 
                if (ViewState != null && ViewState["TotalVotes"] != null)
                    totalVotes = (int)ViewState["TotalVotes"];

                return totalVotes; 

            }
            set { 
                totalVotes = value;

                if (ViewState != null)
                    ViewState["TotalVotes"] = totalVotes;
            }
        }

        bool showTooltip = false;
        public bool ShowTooltip
        {
            get {
                if (ViewState != null && ViewState["ShowTooltip"] != null)
                    showTooltip = (bool)ViewState["ShowTooltip"];

                return showTooltip; 
            }
            set { 
                showTooltip = value;

                if (ViewState != null)
                    ViewState["ShowTooltip"] = showTooltip;
            }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Formats rating image path.
        /// </summary>
        protected string BuildImagePath(string imageName)
        {
            return string.Format("{0}{1}", ImagePath, imageName);
        }

        /// <summary>
        /// Selects the right rating image to be displayed.
        /// </summary>
        protected void SetRatingImage(ref HtmlImage ratingImage)
        {
            if (ratingImage == null)
                return;

            string text = "";

            if (Rating <= 0.25)
            {
                ratingImage.Src = BuildImagePath("star_0.gif");
                text = "Terrible";
            }
            else if (Rating <= 0.5)
            {
                ratingImage.Src = BuildImagePath("star_0h.gif");
                text = "Terrible";
            }
            else if (Rating <= 1)
            {
                ratingImage.Src = BuildImagePath("star_1.gif");
                text = "Poor";
            }
            else if (Rating <= 1.5)
            {
                ratingImage.Src = BuildImagePath("star_1h.gif");
                text = "Poor";
            }
            else if (Rating <= 2)
            {
                ratingImage.Src = BuildImagePath("star_2.gif");
                text = "Fair";
            }
            else if (Rating <= 2.5)
            {
                ratingImage.Src = BuildImagePath("star_2h.gif");
                text = "Fair";
            }
            else if (Rating <= 3)
            {
                ratingImage.Src = BuildImagePath("star_3.gif");
                text = "Average";
            }
            else if (Rating <= 3.5)
            {
                ratingImage.Src = BuildImagePath("star_3h.gif");
                text = "Average";
            }
            else if (Rating <= 4)
            {
                ratingImage.Src = BuildImagePath("star_4.gif");
                text = "Good";
            }
            else if (Rating <= 4.5)
            {
                ratingImage.Src = BuildImagePath("star_4h.gif");
                text = "Good";
            }
            else
            {
                ratingImage.Src = BuildImagePath("star_5.gif");
                text = "Excellent";
            }

            if (!ShowTooltip)
                return;

            if (Rating == 0)
                ratingImage.Alt = "Not rated";
                //ratingImage.Alt = string.Format("Rated {0} [{1} out of 5]", text, "0");
            else
                ratingImage.Alt = string.Format("Rated {0} [{1} out of 5 / rated {2} time(s)]", text, Rating.ToString("#.##"), TotalVotes);
        }

        #endregion
    }
}
