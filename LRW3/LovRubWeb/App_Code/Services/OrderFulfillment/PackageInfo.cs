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

namespace Commerce.Providers
{
    public class PackageInfo
    {
        private string _fromZip;

        public string FromZip
        {
            get { return _fromZip; }
            set { _fromZip = value; }
        }

        private string _fromCountryCode;

        public string FromCountryCode
        {
            get { return _fromCountryCode; }
            set { _fromCountryCode = value; }
        }

        private string _toZip;

        public string ToZip
        {
            get { return _toZip; }
            set { _toZip = value; }
        }

        private string _toCountryCode;

        public string ToCountryCode
        {
            get { return _toCountryCode; }
            set { _toCountryCode = value; }
        }

        private decimal _weight;

        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value + (value * _packagingBuffer); }
        }
	
        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value + (int)(value * _packagingBuffer); }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value + (int)(value * _packagingBuffer); }
        }

        private int _length;

        public int Length
        {
            get { return _length; }
            set { _length = value + (int)(value * _packagingBuffer); }
        }

        private string _dimensionUnit;

        public string DimensionUnit
        {
            get { return _dimensionUnit; }
            set { _dimensionUnit = value; }
        }

        private decimal _packagingBuffer;

        public decimal PackagingBuffer
        {
            get { return _packagingBuffer; }
            set { _packagingBuffer = value; }
        }

        private Dictionary<string, string> _args;

        public Dictionary<string, string> Args
        {
            get { return _args; }
            set { _args = value; }
        }

    }
}
