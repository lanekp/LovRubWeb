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
using System.Text.RegularExpressions;


    public  static class TestCondition
    {

        public static void IsTrue(bool condition, string failMessage) {
            if (!condition) {
                AssertFailed(failMessage);
            }

        }
        
        public static void IsNotNull(object o, string failMessage)
        {
            if (o == null)
            {
                AssertFailed(failMessage);
            }

        }
        public static void IsNotEmptyString(string s, string failMessage)
        {
            if (s == string.Empty)
            {
                AssertFailed(failMessage);
            }

        }
        public static void IsNotNullOrEmptyString(string s, string failMessage) {
            if (!String.IsNullOrEmpty(s)) {
                AssertFailed(failMessage);
            }

        }
        public static void IsGreaterThanZero(int i, string failMessage)
        {

            if (i <= 0)
            {
                AssertFailed(failMessage);
            }
        }
        public static void IsGreaterThanZero(decimal i, string failMessage)
        {

            if (i <= 0)
            {
                AssertFailed(failMessage);
            }
        }
        // Function to test for Positive Integers.
        public static void IsNaturalNumber(String strNumber, string failMessage)
        {
            Regex regNotNaturalPattern = new Regex("[^0-9]");
            Regex regNaturalPattern = new Regex("0*[1-9][0-9]*");

            if (!regNotNaturalPattern.IsMatch(strNumber) &&
                regNaturalPattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);

            }
        }

        // Function to test for Positive Integers with zero inclusive

        public static void IsWholeNumber(string strNumber, string failMessage)
        {
            Regex regNotWholePattern = new Regex("[^0-9]");

            if (regNotWholePattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);
            }
        }

        // Function to Test for Integers both Positive & Negative

        public static void IsInteger(string strNumber, string failMessage)
        {
            Regex regNotIntPattern = new Regex("[^0-9-]");
            Regex regIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");

            if (regNotIntPattern.IsMatch(strNumber) &&
                regIntPattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);
            }
        }

        // Function to test whether the string is valid number or not
        public static void IsNumber(string strNumber, string failMessage)
        {
            Regex regNotNumberPattern = new Regex("[^0-9.-]");
            Regex regTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex regTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex regNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            if (regNotNumberPattern.IsMatch(strNumber) &&
                !regTwoDotPattern.IsMatch(strNumber) &&
                !regTwoMinusPattern.IsMatch(strNumber) &&
                regNumberPattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);
            }
        }

        // Function To test for Alphabets.

        public static void IsAlpha(string strToCheck, string failMessage)
        {
            Regex regAlphaPattern = new Regex("[^a-zA-Z]");

            if (regAlphaPattern.IsMatch(strToCheck))
            {
                AssertFailed(failMessage);

            }
        }

        public static void IsValidEmail(string email, string failMessage)
        {
            string emailPattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            Regex regEmailPattern = new Regex(emailPattern);
            if (regEmailPattern.IsMatch(email))
            {
                AssertFailed(failMessage);

            }

        }
        // Function to Check for AlphaNumeric.

        public static void IsAlphaNumeric(string strToCheck, string failMessage)
        {
            Regex regAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

            if (regAlphaNumericPattern.IsMatch(strToCheck))
            {
                AssertFailed(failMessage);

            }
        }

        static void AssertFailed(string message)
        {
            throw new Exception(message);
        }
    }
