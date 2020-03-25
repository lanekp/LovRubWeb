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
using System.Xml;
using System.Xml.Serialization;

namespace Commerce.Common
{

    /// <summary>
    /// A collection of attributes. 
    /// </summary>
    [Serializable]
    public partial class Attributes : System.Collections.CollectionBase
    {

        public void Add(Attribute att)
        {
            List.Add(att);
        }

        public void Remove(int itemIndex)
        {
            List.RemoveAt(itemIndex);
        }
        /// <summary>
        /// Indexer for this collection. Returns the CSK_Store_Attribute object in the specified position.
        /// </summary>
        public Attribute this[int index]
        {
            get { return (Attribute)List[index]; }
        }

        public override string ToString()
        {
            string attSelections = "";
            foreach (Attribute att in this)
            {
                attSelections += "<b>"+att.Name + "</b>: " + att.SelectionList+"<br>";
            }
            return attSelections;

        }
        public string ToXML()
        {
            return Utility.ObjectToXML(typeof(Attributes), this);
        }

    }
    
    /// <summary>
    /// A class that describes a product attribute, such as "Size"
    /// </summary>
    [Serializable]
    public partial class Attribute
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string  description;

        public string  Description
        {
            get { return description; }
            set { description = value; }
        }
        public decimal GetPriceAdjustment(string selection)
        {
            decimal dOut=0;
            foreach (AttributeSelection sel in this.selections)
            {
                if(sel.Value.ToLower().Equals(selection.ToLower())){
                    dOut=sel.PriceAdjustment;
                    break;
                }
            }
            return dOut;
        }
        public string SelectionList
        {
            get
            {
                string sOut = "";
                if (this.selections != null)
                {
                    foreach (AttributeSelection sel in this.selections)
                    {
                        sOut += sel.Value + ", ";
                    }
                    if (sOut.Length > 1)
                        sOut = sOut.Remove(sOut.Length - 2, 2);
                }
                return sOut;
            }
        }
        private List<AttributeSelection> selections;

        public List<AttributeSelection> Selections
        {
            get { return selections; }
            set { selections = value; }
        }
	

        private AttributeType selectionType;

        public AttributeType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }

    }

    /// <summary>
    /// A class representing the selections for an attribute. Example: "Large", "Small", etc
    /// </summary>
    [Serializable]
    public partial class AttributeSelection
    {
        private string  selectionValue;
        public string FormattedValue
        {
            get
            {
                //if there is a price adjustment we want to show it
                //you can alter this however needed.
                string sOut = selectionValue;
                if (priceAdjustment != 0)
                {
                    sOut += " ";
                    if (priceAdjustment > 0)
                        sOut += "+";

                    sOut += priceAdjustment.ToString("c");

                }
                return sOut;

            }
            set { selectionValue = value; }
        }
        public string  Value
        {
            get {
                return selectionValue; 
            
            }
            set { selectionValue = value; }
        }

        private string imageFile;

        public string ImageFile
        {
            get { return imageFile; }
            set { imageFile = value; }
        }
	

        private decimal priceAdjustment;

        public decimal PriceAdjustment
        {
            get { return priceAdjustment; }
            set {
                priceAdjustment = value; 
            
            }
        }
	
    }
}
