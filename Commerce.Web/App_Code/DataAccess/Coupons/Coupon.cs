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
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Commerce.Common;
using SubSonic;
 

namespace Commerce.Promotions
{
    public class CouponType
    {
        private static System.Collections.Generic.Dictionary<int, CouponType> _couponTypes;
        
        /// <summary>
        /// Gets the CouponType by the coupon type id
        /// </summary>
        /// <param name="CouponTypeId">ID for the coupon type</param>
        /// <returns>The CouponType corresponding to the type id supplied</returns>
        /// <exception cref="System.ArgumentException">Thrown if the supplied type is not found.</exception>
        public static CouponType GetCouponType(int CouponTypeId)
        {
            if (_couponTypes == null)
            {
                GetAllCouponTypes(); 
            }
            if (_couponTypes.ContainsKey(CouponTypeId))
            {
                return _couponTypes[CouponTypeId];
            }
            else
            {
                //Not found in cache.  Retrieve from the database.  
                //TODO: Integrate with standard DataAccess 
                using (IDataReader rdr = GetCouponTypeReader(CouponTypeId))
                {
                    if (rdr.Read())
                    {
                        return  CreateCouponTypeFromReader(rdr);
                    }
                    else
                    {
                        //Coupon Type was not found.  
                        throw new ArgumentException("Specified coupon type was not found", "CouponTypeId");
                    }
                }
            }
        }

		private static CouponType CreateCouponTypeFromReader(IDataReader rdr)
        {
            CouponType newType = new CouponType(
                rdr.GetInt32(rdr.GetOrdinal("CouponTypeId")),
                rdr.GetString(rdr.GetOrdinal("Description")),
                rdr.GetString(rdr.GetOrdinal("ProcessingClassName")));
            //Add to the cache.  

            _couponTypes.Add(newType.CouponTypeID, newType);
            return newType;
        }

        public static System.Collections.Generic.Dictionary<int, CouponType> GetAllCouponTypes()
        {
            return GetAllCouponTypes(false); 
        }
        public static System.Collections.Generic.Dictionary<int, CouponType>GetAllCouponTypes(bool refreshCache)
        {
            if (refreshCache || _couponTypes == null)
            {
                //force refill of the cache
                _couponTypes = new Dictionary<int, CouponType>();
                using (IDataReader rdr = GetCouponTypeReader())
                {
                    while (rdr.Read())
                    {
                        CreateCouponTypeFromReader(rdr);
                    }
                }
            }
            return _couponTypes; 
           
        }
        private static IDataReader GetCouponTypeReader(int CouponTypeId)
        {

            return SPs.CouponsGetCouponType(CouponTypeId).GetReader();

        }
		private static IDataReader GetCouponTypeReader()
        {
            return SPs.CouponsGetCouponType(0).GetReader();

        }


        public CouponType()
        {
            _couponTypeId = -1;
        }

        public CouponType(int couponTypeId, string description, string classTypeName)
        {
            _couponTypeId = couponTypeId;
            _description = description;
            _couponClassType = System.Web.Compilation.BuildManager.GetType(classTypeName, true);
            
        }
        private int _couponTypeId;
        public int CouponTypeID
        {
            get { return _couponTypeId; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Type _couponClassType;
        public Type CouponClassType
        {
            get { return _couponClassType; }
            set { _couponClassType = value; }
        }

        public void Save()
        {

            SPs.CouponsSaveCouponType(this.CouponTypeID, this.Description, this.CouponClassType.FullName).Execute();

        }
    }

    public class CouponValidationResponse
    {
        public CouponValidationResponse(bool isValid, string validationMessage)
        {
            _isValid = isValid;
            _validationMessage = validationMessage;
        }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get { return _validationMessage; }
        }

    }
    public abstract class Coupon
    {

        protected Coupon ()
        {

        }
        protected Coupon(string couponCode, CouponType couponType)
        {
            _couponCode = couponCode;
            _couponType = couponType;
        }

        private string _couponCode;
        [XmlIgnore()]
        public virtual string CouponCode
        {
            get { return _couponCode; }
            protected set { _couponCode = value; }
        }

        private CouponType _couponType;
        [XmlIgnore()]
        public CouponType CouponType
        {
            get
            {
                return _couponType;
            }

        }

        private bool _isSingleUse;
        [XmlIgnore()]
        public virtual bool IsSingleUse
        {
            get { return _isSingleUse; }
            set { _isSingleUse = value; }
        }

        private Guid? _userId;
        [XmlIgnore()]
        public virtual Guid? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _numUses;
        [XmlIgnore()]
        public virtual int NumberOfUses
        {
            get { return _numUses; }
            protected set { _numUses = value; }
        }

        private DateTime? _expirationDate;
        [XmlIgnore()]
        public virtual DateTime? ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        /// <summary>
        /// Returns the Xml representation of coupon-specific data as a string
        /// </summary>
        /// <returns></returns>
        public string GetXmlData()
        {
            //Create the serializer
            XmlSerializer ser = new XmlSerializer(this.CouponType.CouponClassType); 
            using (System.IO.MemoryStream stm = new System.IO.MemoryStream())
            {

                //serialize to a memory stream
                ser.Serialize(stm, this);
                //reset to beginning so we can read it.  
                stm.Position = 0; 
                //Convert a string. 
                using (System.IO.StreamReader stmReader = new System.IO.StreamReader(stm))
                {
                    string xmlData = stmReader.ReadToEnd();
                    return xmlData; 
                }
            }

        }

        /// <summary>
        /// Applies a coupon to an order
        /// </summary>
        /// <param name="order">Order to apply the coupon to</param>
        public abstract void ApplyCouponToOrder(Commerce.Common.Order order);

        /// <summary>
        /// Performs basic validation based on common coupon properties
        /// </summary>
        /// <param name="order">Order to validate</param>
        /// <returns></returns>
        public virtual CouponValidationResponse ValidateCouponForOrder(Commerce.Common.Order order)
        {
            if (IsSingleUse && NumberOfUses > 0)
            {
                return new CouponValidationResponse(false, "This coupon has already been used");
            }

            if (ExpirationDate.HasValue)
            {
                if (ExpirationDate < DateTime.UtcNow)
                {
                    return new CouponValidationResponse(false, "This coupon has expired"); 
                }
            }
            
            //TODO: how to check the current user id?  

            return new CouponValidationResponse(true, ""); 
        }

        /// <summary>
        /// Returns a coupon by the coupon code.  
        /// </summary>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Thrown if the coupon cannot be found</exception>
        public static Coupon GetCoupon(string couponCode)
        {
            return GetCoupon(couponCode, true); 
        }
        public static Coupon GetCoupon(string couponCode, bool throwOnError)
        {
            using (IDataReader reader = GetCouponReader(couponCode))
            {
                if (reader.Read())
                {
                    return CreateCoupon(reader);
                }
                else
                {
                    if (throwOnError)
                    {
                        throw new ArgumentException("Coupon specified was not found", "couponCode");
                    }
                    else 
                    { 
                        return null; 
                    }
                }
            }
        }
        private static Coupon CreateCoupon(IDataReader reader)
        {
            //Get the coupon type id.  
            int couponTypeId = reader.GetInt32(reader.GetOrdinal("CouponTypeId"));
            CouponType couponType = CouponType.GetCouponType(couponTypeId);

            //Get an XmlReader for the XmlData 
            string xmlString = reader.GetString(reader.GetOrdinal("XmlData"));
			System.IO.StringReader rdr = new System.IO.StringReader(xmlString);
			XmlReader xmlData = XmlReader.Create(rdr); 
	
            //Deserialize the Xml to the object.  
            XmlSerializer serializer = new XmlSerializer(couponType.CouponClassType);
            Coupon newCoupon = (Coupon)serializer.Deserialize(xmlData);

			//Load the common properties. 
            newCoupon._couponCode = reader.GetString(reader.GetOrdinal("CouponCode")); 
            newCoupon._couponType = couponType;
            newCoupon._isSingleUse = reader.GetBoolean(reader.GetOrdinal("IsSingleUse"));
            newCoupon._numUses = reader.GetInt32(reader.GetOrdinal("NumberUses"));
            //the following is a stupid hack. 
            //it seems to me that a nullable type should just convert from DbNull ... 
            if (reader["ExpirationDate"] != DBNull.Value)
            {
                newCoupon._expirationDate = (DateTime?)reader["ExpirationDate"];
            }
            if (reader["UserId"] != DBNull.Value)
            {
                newCoupon._userId = (Guid?)reader["UserId"];
            }
            return newCoupon;
        }

        /// <summary>
        /// Saves a coupon to the database. 
        /// </summary>
        public virtual void SaveCoupon()
        {
            DateTime expDate = (DateTime)this.ExpirationDate;

            SPs.CouponsSaveCoupon(this.CouponCode, this.CouponType.CouponTypeID, this.IsSingleUse, this.NumberOfUses, expDate, this.GetXmlData()).Execute();
            

        }

        public static IDataReader GetAllCoupons() {
            return new Query("CSK_Coupons").ExecuteReader();
        }
        private static IDataReader GetCouponReader(string couponCode)
        {

            return SPs.CouponsGetCoupon(couponCode).GetReader();
 

        }


        private static List<Coupon> CreateListFromReader( IDataReader couponReader)
        {
            List<Coupon> couponList = new List<Coupon>(); 
            while (couponReader.Read())
            {
                couponList.Add(Coupon.CreateCoupon(couponReader));
            }
            return couponList; 
        }

        public static string GenerateCouponCode(int minCharacters, int maxCharacters)
        {
            string newCode;
            Coupon testCoupon;
            do
            {
                //This is not cryptographically random, but should be good enough.  
                System.Random rnd = new Random();
                int numCharacters = rnd.Next(minCharacters, maxCharacters);
                StringBuilder sb = new StringBuilder(numCharacters);
                for (int i = 0; i < numCharacters; i++)
                {
                    sb.Append(char.ConvertFromUtf32(rnd.Next(65, 90)));
                }
                newCode = sb.ToString();
                testCoupon = GetCoupon(newCode, false);
            }
            while (testCoupon != null);
            return newCode; 
            
        }
        public static string GenerateCouponCode()
        {
            return GenerateCouponCode(5, 10); 
        }
    }
}
