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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging; // KPL 04/09/08 Added
using System.Data.Common;
using System.Collections;
using Commerce.Providers;
using SubSonic;

/// <summary>
/// Summary description for OrderController
/// </summary>
public static class OrderController {
  /// <summary>
  /// Uses the tax provider to calculate sales tax based on zipcode and subtotal. Returns 
  /// the rate as a decimal
  /// </summary>
  /// <param name="zip"></param>
  /// <param name="subtotal"></param>
  /// <returns>System.Decimal</returns>
  public static decimal CalculateTax(string zip, decimal subtotal) {

    return TaxService.CalculateAmountByZIP(zip, subtotal);

  }

  /// <summary>
  /// Cancel's a pending order
  /// </summary>
  /// <param name="order"></param>
  /// <param name="cancellationReason"></param>
  public static void CancelOrder(Order order, string cancellationReason) {

    //first, update the status
    order.OrderStatus = OrderStatus.OrderCancelledPriorToShipping;
    order.Save(Utility.GetUserName());

    //next, add a note to say it was cancelled
    OrderNote note = new OrderNote();
    note.OrderID = order.OrderID;
    note.OrderStatus = Enum.GetName(typeof(OrderStatus), OrderStatus.OrderCancelledPriorToShipping);
    note.Note = "Order Cancelled by " + Utility.GetUserName() + ": " + cancellationReason;
    note.Save(Utility.GetUserName());


  }


  public static void AddNote(string note, Order order) {

    string orderStatus = order.OrderStatus.ToString();
    if (orderStatus == "NotProcessed")
      orderStatus = "Not checked out";

    OrderNote.Insert(order.OrderID, note, orderStatus);
  }

  #region Getters

  /// <summary>
  /// Returns a filtered order set, based on the passed-in information
  /// </summary>
  /// <param name="dtStart">Beginning of date range</param>
  /// <param name="dtEnd">End of date range</param>
  /// <param name="userName">User's name</param>
  /// <param name="orderNumber">Order number (partial)</param>
  /// <returns>System.Data.IDataReader</returns>
  public static IDataReader GetAllByFilter(DateTime dtStart, DateTime dtEnd, string userName, string orderNumber) {

    return SPs.StoreOrderQuery(dtStart, dtEnd, userName, orderNumber).GetReader();

  }
  /// <summary>
  /// Get's all orders for the logged-in user
  /// </summary>
  /// <returns>OrderCollection</returns>
  public static OrderCollection GetByUser() {
    return GetByUser(Utility.GetUserName());
  }
  /// <summary>
  /// Get's all orders for the specified user
  /// </summary>
  /// <returns>OrderCollection</returns>

  public static OrderCollection GetByUser(string userName) {

    return new OrderCollection().Where("userName", userName).Where("orderStatusID", Comparison.NotEquals, (int)OrderStatus.NotProcessed).OrderByDesc("orderDate").Load();

  }
  /// <summary>
  /// Returns any unchecked out order (aka "The Cart") for the currently logged-in user
  /// </summary>
  /// <returns></returns>
  public static Order GetCurrentOrder() {
    int orderID = GetCartOrderID();
    return GetOrder(orderID);

  }
  /// <summary>
  /// Returns any unchecked out order (aka "The Cart") for a user
  /// </summary>
  /// <returns></returns>
  public static Order GetCurrentOrder(string userName) {
    IDataReader rdr = new Query(Order.GetTableSchema()).AddWhere("OrderStatusID", OrderStatus.NotProcessed).AddWhere("userName", userName).ExecuteReader();
    Order order = new Order();
    order.Load(rdr);
    rdr.Close();

    return order;

  }
  /// <summary>
  /// Returns an order by it's GUID ID.
  /// </summary>
  /// <param name="orderID"></param>
  /// <returns></returns>
  public static Order GetOrder(int orderID) {

    Order order = new Order();
    DataSet ds = new DataSet();
    //set to false since this is not a new order
    order.IsNew = false;
    string sql = "";

    //use a multiple return set to load up the order info

    //0 - the order itself
    Query q = new Query(Order.GetTableSchema());
    q.AddWhere("orderID", orderID);

    //append the sql
    sql += DataService.GetSql(q) + "\r\n";

    //1 - items
    q = new Query(OrderItem.GetTableSchema());
    q.AddWhere("orderID", orderID);
    q.OrderBy = OrderBy.Asc("createdOn");

    //append the sql
    sql += DataService.GetSql(q) + "\r\n";

    //2 - notes
    q = new Query(OrderNote.GetTableSchema());
    q.AddWhere("orderID", orderID);

    //append the sql
    sql += DataService.GetSql(q) + "\r\n";

    //3 - transactions
    q = new Query(Transaction.GetTableSchema());
    q.AddWhere("orderID", orderID);

    //append the sql
    sql += DataService.GetSql(q) + "\r\n";

    //Build the Command
    QueryCommand cmd = new QueryCommand(sql);
    cmd.AddParameter("@orderID", orderID, DbType.Int32);

    //load the dataset
    ds = DataService.GetDataSet(cmd);

    //load up the bits - order first
    order.Load(ds.Tables[0]);

    //then items
    order.Items = new OrderItemCollection();
    order.Items.Load(ds.Tables[1]);
    if (order.Items.Count > 0)
      order.LastAdded = order.Items[order.Items.Count - 1];

    //notes
    order.Notes = new OrderNoteCollection();
    order.Notes.Load(ds.Tables[2]);

    //transactions
    order.Transactions = new TransactionCollection();
    order.Transactions.Load(ds.Tables[3]);


    return order;
  }

  /// <summary>
  /// Get's an order based on it's unique ID
  /// </summary>
  /// <param name="orderGuid"></param>
  /// <returns></returns>
  public static Order GetOrder(string orderGuid) {
    int orderID = 0;
    Query q = new Query(Order.GetTableSchema());
    q.AddWhere("orderGuid", orderGuid);
    q.SelectList = "orderID";
    object result = q.ExecuteScalar();

    if (result != null)
      orderID = (int)result;

    return GetOrder(orderID);
  }

  #endregion

  #region Address Methods
  /// <summary>
  /// Get's a count of a user's addresses
  /// </summary>
  /// <returns></returns>
  public static int GetAddressBookCount() {
    Where where = new Where();
    where.ColumnName = "userName";
    where.ParameterValue = Utility.GetUserName();

    int iOut = Query.GetCount("CSK_Store_Address", "addressID", where);
    return iOut;

  }

  /// <summary>
  /// Returns all addresses stored for a user
  /// </summary>
  /// <returns></returns>
  public static AddressCollection GetUserAddresses() {
    return new AddressCollection().Where("userName", Utility.GetUserName()).Load();
  }
  /// <summary>
  /// Saves the address to the DB
  /// </summary>
  /// <param name="address"></param>
  /// <param name="isBilling"></param>
  public static void SaveAddress(Address address) {

    //check to see if this address exists
    Address addCheck = new Address();
    addCheck.Address1 = address.Address1;
    addCheck.City = address.City;
    addCheck.StateOrRegion = address.StateOrRegion;
    addCheck.Country = address.Country;
    addCheck.UserName = address.UserName;

    //use the Find() method to see if this address exists
    AddressCollection list = new AddressCollection();
    IDataReader rdr = Address.Find(addCheck);
    list.Load(rdr);
    rdr.Close();

    if (list.Count > 0) {
      //this is an old address
      //set the address ID and mark it as old
      //this will tell the base class to run an Update
      address.AddressID = list[0].AddressID;
      address.IsNew = false;

    }
    //save it back
    address.Save(Utility.GetUserName());

  }
  #endregion

  #region Permission Sets
  /// <summary>
  /// Defines if an order can be refunded. Used on the Admin_Orders page
  /// </summary>
  /// <param name="order"></param>
  /// <returns></returns>
  public static bool CanRefund(Order order) {
    bool bOut = false;

    //if the order is not set to shipped
    //or if it hasn't already been refunded
    //we're good to go

    //your rules might be different, alter as needed
    switch (order.OrderStatus) {
      case OrderStatus.NotProcessed:
        break;
      case OrderStatus.ReceivedAwaitingPayment:
        bOut = true;
        break;
      case OrderStatus.ReceivedPaymentProcessingOrder:
        bOut = true;
        break;
      case OrderStatus.GatheringItemsFromInventory:
        bOut = true;
        break;
      case OrderStatus.AwatingShipmentToCustomer:
        bOut = true;
        break;
      case OrderStatus.DelayedItemsNotAvailable:
        break;
      case OrderStatus.ShippedToCustomer:
        break;
      case OrderStatus.DelayedReroutingShipping:
        break;
      case OrderStatus.DelayedCustomerRequest:
        bOut = true;
        break;
      case OrderStatus.DelayedOrderUnderReview:
        bOut = true;
        break;
      case OrderStatus.OrderCancelledPriorToShipping:
        break;
      case OrderStatus.OrderRefunded:
        break;
      default:
        break;
    }

    //make sure the order total is valid
    if (order.CalculateSubTotal() <= 0)
      bOut = false;

    return bOut;
  }

  /// <summary>
  /// Defines if an order can be shipped
  /// </summary>
  /// <param name="order"></param>
  /// <returns></returns>
  public static bool CanShip(Order order) {
    bool bOut = false;
    //if the order is not set to shipped
    //or if it hasn't already been refunded
    //we're good to go

    //your rules might be different, alter as needed
    switch (order.OrderStatus) {
      case OrderStatus.NotProcessed:
        break;
      case OrderStatus.ReceivedAwaitingPayment:
        bOut = true;
        break;
      case OrderStatus.ReceivedPaymentProcessingOrder:
        bOut = true;
        break;
      case OrderStatus.GatheringItemsFromInventory:
        bOut = true;
        break;
      case OrderStatus.AwatingShipmentToCustomer:
        bOut = true;
        break;
      case OrderStatus.DelayedItemsNotAvailable:
        break;
      case OrderStatus.ShippedToCustomer:
        break;
      case OrderStatus.DelayedReroutingShipping:
        break;
      case OrderStatus.DelayedCustomerRequest:
        bOut = true;
        break;
      case OrderStatus.DelayedOrderUnderReview:
        bOut = true;
        break;
      case OrderStatus.OrderCancelledPriorToShipping:
        break;
      case OrderStatus.OrderRefunded:
        break;
      default:
        break;
    }

    return bOut;

  }

  /// <summary>
  /// Defines if an order can be cancelled
  /// </summary>
  /// <param name="order"></param>
  /// <returns></returns>
  public static bool CanCancel(Order order) {
    bool bOut = true;
    switch (order.OrderStatus) {
      case OrderStatus.NotProcessed:
        break;
      case OrderStatus.ReceivedAwaitingPayment:
        break;
      case OrderStatus.ReceivedPaymentProcessingOrder:
        break;
      case OrderStatus.GatheringItemsFromInventory:
        break;
      case OrderStatus.AwatingShipmentToCustomer:
        break;
      case OrderStatus.DelayedItemsNotAvailable:
        break;
      case OrderStatus.ShippedToCustomer:
        bOut = false;
        break;
      case OrderStatus.DelayedReroutingShipping:
        break;
      case OrderStatus.DelayedCustomerRequest:
        break;
      case OrderStatus.DelayedOrderUnderReview:
        break;
      case OrderStatus.OrderCancelledPriorToShipping:
        bOut = false;
        break;
      case OrderStatus.OrderRefunded:
        bOut = false;
        break;
      default:
        break;
    }
    return bOut;

  }
  #endregion

  #region Transaction Methods

  /// <summary>
  /// Validates an order before the transaction tabkes place
  /// </summary>
  /// <param name="order">The Commerce.Common.Order</param>
  /// <param name="validateAddress">Whether to validate billing/shipping</param>
  static void ValidateOrder(Order order, bool validateAddress) {

    if (validateAddress) {
      //need to have shipping and billing
      TestCondition.IsNotNull(order.ShippingAddress, "Need a shipping address");
      TestCondition.IsNotNull(order.BillingAddress, "Need a billing address");

    }

    //need to have the IP, email, first and last set
    TestCondition.IsNotNull(order.UserIP, "Need a valid IP address for this order");
    TestCondition.IsNotNull(order.Email, "Need a valid Email for this order");
    TestCondition.IsNotNull(order.FirstName, "Need a valid First Name for this order");
    TestCondition.IsNotNull(order.LastName, "Need a valid Last Name for this order");

    //validation
    //uncomment the following line if you don't give out freebies
    //TestCondition.IsGreaterThanZero(order.CalculateSubTotal(), "Invalid Subtotal");
    TestCondition.IsNotEmptyString(order.UserName, "Invalid User Name for the Order. Please set Order.UserName accordingly.");
    TestCondition.IsGreaterThanZero(order.Items.Count, "No items have been added to the order");


    //finally, for good measure, go through each monetary figure
    //and make sure it's decimal setting is appropriate
    //the subtotal is always rounded
    int currencyDecimals = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits;
    order.ShippingAmount = Math.Round(order.ShippingAmount, currencyDecimals);
    order.TaxAmount = Math.Round(order.TaxAmount, currencyDecimals);
    foreach (OrderItem item in order.Items) {
      item.PricePaid = Math.Round(item.PricePaid, currencyDecimals);
      item.OriginalPrice = Math.Round(item.OriginalPrice, currencyDecimals);
    }


  }

  #region Chargers
  /// <summary>
  /// Executes the charge using the gateway of choice. If you are going to accept
  /// Different types of payments (like POs or Offline Cards), then this is 
  /// the place to put your routines.
  /// </summary>
  /// <param name="transType">Enum to define type of purchase</param>
  /// <returns>Commerce.Common.Transaction</returns>
  static Transaction ExecuteCharge(Order order, TransactionType transType) {
    Transaction trans = null;
    if (transType == TransactionType.CreditCardPayment) {
      //if this is successful, there's no going back
      //NO errors after this!
      trans = Commerce.Providers.PaymentService.RunCharge(order);
      trans.TransactionNotes = "Credit card transaction completed " + DateTime.UtcNow.ToString();

    }
    else if (transType == TransactionType.PayPalPayment) {
      //this is an express checkout, use the PayPal API
      //string certPath = HttpContext.Current.Server.MapPath("~/App_Data/" + SiteConfig.PayPalAPICertificate);
      Commerce.PayPal.APIWrapper wrapper =
        new Commerce.PayPal.APIWrapper(SiteConfig.PayPalAPIUserName,
        SiteConfig.PayPalAPIPassword, SiteConfig.PayPalAPISignature,
        SiteConfig.CurrencyCode, SiteConfig.PayPalAPIIsLive);

      //the token should be in the BillingAddress of the order
      //check to be sure
      TestCondition.IsNotEmptyString(order.BillingAddress.PayPalToken, "Invalid PayPal Token");

      trans = wrapper.DoExpressCheckout(order, SiteConfig.AuthorizeSaleOnly);
      if (trans != null) {
        trans.TransactionNotes = "PayPal ExpressCheckout transaction completed " + DateTime.UtcNow.ToString();

        //an acknowledgement is received from PayPal
        //and it says "Success" if, well, it was a success
        if (trans.GatewayResponse != "Success") {
          throw new Exception("PayPal ExpressCheckout Error: " + trans.GatewayResponse);
        }

      }

    }
    if (trans != null) {
      //add the baseline information
      trans.OrderID = order.OrderID;
      trans.Amount = order.OrderTotal;
      trans.TransactionType = transType;
      trans.TransactionDate = DateTime.UtcNow;

    }
    else {
      //if the transaction's null, an error occurred along the way
      //throw an exception, as the order is not valid
      throw new Exception("Invalid transaction, the transaction did not record properly");
    }
    return trans;

  }
  #endregion

  /// <summary>
  /// Transacts an order
  /// </summary>
  /// <param name="order">The order to be transacted</param>
  /// <param name="transType">The type of order (Credit Card, PO, etc)</param>
  /// <returns>Commerce.Common.Transaction</returns>
  public static Transaction TransactOrder(Order order, TransactionType transType) 
  {
    Database db = DatabaseFactory.CreateDatabase();

    //Validate the Order
    ValidateOrder(order, true);

    //update the order info
    order.OrderDate = DateTime.Now;
    order.SubTotalAmount = order.CalculateSubTotal();
    order.UserIP = HttpContext.Current.Request.UserHostAddress;

    //set the status to processing
    order.OrderStatus = OrderStatus.ReceivedPaymentProcessingOrder;

    //setting the final order number. This is for internal reference
    //to your business. Update as needed to reflect your companies
    //ordering system
    string companyOrderIdentifier = ConfigurationManager.AppSettings["companyOrderIdentifier"];
    switch (transType) {
      case TransactionType.PayPalPayment:
        order.OrderNumber = companyOrderIdentifier + "-PP-" + Utility.GetRandomString();
        break;
      case TransactionType.PurchaseOrder:
        order.OrderNumber = companyOrderIdentifier + "-PO-" + Utility.GetRandomString();
        break;
      case TransactionType.CreditCardPayment:
      case TransactionType.OfflineCreditCardPayment:
        order.OrderNumber = companyOrderIdentifier + "-CC-" + Utility.GetRandomString();
        break;
    }
    DbCommand orderCommand = order.GetUpdateCommand("Order System").ToDbCommand();

    //create a note for the order
    OrderNote note = new OrderNote();
    note.Note = "Order Created";
    note.OrderID = order.OrderID;
    note.OrderStatus = OrderStatus.ReceivedAwaitingPayment.ToString();


    DbCommand noteCommand = note.GetInsertCommand("Order System").ToDbCommand();

    //the transaction to hold the charge info
    Transaction trans = null;


    // test email comment MessagingController.SendOrderReceived_Customer(order);
    using (DbConnection connection = db.CreateConnection()) {
      connection.Open();
      DbTransaction transaction = connection.BeginTransaction();

      try {
        //Execute the order update
        db.ExecuteNonQuery(orderCommand, transaction);

        //add in the order note
        db.ExecuteNonQuery(noteCommand, transaction);

        //execute the charge - this charges the user
        //NO ERRORS after this, cannot roll back
        trans = ExecuteCharge(order, transType);

        //add the transaction to the order
        if (trans != null)
          order.Transactions.Add(trans);

        try {
          //record the transaction
          //since the order is paid, the order record MUST be comitted
          //if this call fails, enter it manually
          DbCommand transRecordCommand = trans.GetInsertCommand("Order System").ToDbCommand();

          //finally add in the transaction
          db.ExecuteNonQuery(transRecordCommand, transaction);

          OrderNote successNote = new OrderNote();
          successNote.Note = "Transaction for order " + order.OrderNumber + " successfully transacted";
          successNote.OrderID = order.OrderID;
          successNote.OrderStatus = OrderStatus.ReceivedPaymentProcessingOrder.ToString();
          db.ExecuteNonQuery(successNote.GetInsertCommand("Order System").ToDbCommand(), transaction);
        }
        catch (Exception x) 
        {
          //do nothing
          //if the transaction record does not record in the DB for some reason
          //we do NOT want to fail the overall transaction because they have already been
          //charged. Log this failure....

          //TODO: CMC - Log failure - Try to write to FileSystem - XML?
          LovRubLogger.LogException(x); //KPL added 04/09/08
        }

        // Commit the transaction
        transaction.Commit();
        //close the connection ... we are done with it.  
        connection.Close();

        //send off notification *after* the transaction commits ...
        //that way, we close the transacation ASAP.  
        //send off the notifications
        //NO ERRORS 
        try {
          //to user saying thank you
          MessagingController.SendOrderReceived_Customer(order);

          //to merchant
          MessagingController.SendOrderReceived_Merchant(order);

        }
        /* catch
            {
            //TODO - CMC - Log Errror
            } 
         */ // Original code KPL 04/09/08
        // KPL 04/05/08
        catch(Exception x)
        {
            LovRubLogger.LogException(x);
        }

      }
      catch (Exception x) {
        // Rollback transaction 
        transaction.Rollback();
        //ResultMessage1.ShowFail(x.Message); // KPL added 12/24/07
        LovRubLogger.LogException( x ); // KPL 04/05/08
        throw x;

      }

    }

    return trans;

  }

  /// <summary>
  /// Refunds an order
  /// </summary>
  /// <param name="order"></param>
  public static void Refund(Order order) {

    //add a transaction to the order, indicating it's been refunded
    Transaction trans = new Transaction();
    trans.Amount = 0 - order.OrderTotal;
    trans.TransactionNotes = "Order Refunded on " + DateTime.UtcNow.ToString();
    trans.TransactionType = TransactionType.Refund;
    trans.OrderID = order.OrderID;
    trans.TransactionDate = DateTime.UtcNow;
    DbCommand cmdTrans = trans.GetInsertCommand(Utility.GetUserName()).ToDbCommand();

    //add a note as well
    OrderNote note = new OrderNote();
    note.OrderID = order.OrderID;
    note.Note = "Order Refunded";
    note.OrderStatus = Enum.GetName(typeof(OrderStatus), order.OrderStatus);
    DbCommand cmdNote = note.GetInsertCommand(Utility.GetUserName()).ToDbCommand();

    //set the status
    order.OrderStatus = OrderStatus.OrderRefunded;
    DbCommand cmdOrder = order.GetUpdateCommand(Utility.GetUserName()).ToDbCommand();
    //commit
    Database db = DatabaseFactory.CreateDatabase();
    using (DbConnection connection = db.CreateConnection()) {
      connection.Open();
      DbTransaction transaction = connection.BeginTransaction();

      try {
        //get the commands

        //run the queries
        db.ExecuteNonQuery(cmdTrans, transaction);
        db.ExecuteNonQuery(cmdNote, transaction);
        db.ExecuteNonQuery(cmdOrder, transaction);

        //call the provider to refund the order
        //if this fails, toss the DB bits
        //NO ERRORS after this
        PaymentService.Refund(order);

        // Commit the transaction
        transaction.Commit();
        //close the connection ... we are done with it.  
        connection.Close();


      }
      catch (Exception x) {
        // Rollback transaction 
        transaction.Rollback();
        LovRubLogger.LogException(x);// KPL 04/09/08
        throw x;

      }


    }
  }
  #region PP Standard Methods
  /// <summary>
  /// This method creates an order in the database, without applying a transaction to it.
  /// The order id is created for sending to PayPal in the "Custom" field. When the IPN/PDT 
  /// come back to the site, this value is used to Reconcile the transaction.
  /// </summary>
  public static void CreateStandardOrder() {
    string companyOrderIdentifier = ConfigurationManager.AppSettings["companyOrderIdentifier"];
    Order order = GetCurrentOrder();

    //validate the order without address info since we won't know the billing address
    ValidateOrder(order, false);

    order.OrderGUID = System.Guid.NewGuid().ToString();

    //use your own logic for this one :)
    order.OrderNumber = companyOrderIdentifier + "-PPS-" + Utility.GetRandomString();

    //flag the status as awaiting payment
    order.OrderStatus = OrderStatus.ReceivedAwaitingPayment;
    order.OrderDate = DateTime.Now;
    order.SubTotalAmount = order.CalculateSubTotal() - order.DiscountAmount;

    //update the order status to "paid"
    Query q = new Query(Order.GetTableSchema());
    q.AddUpdateSetting("orderStatusID", OrderStatus.ReceivedPaymentProcessingOrder);
    q.AddWhere("orderID", order.OrderID);
    DbCommand orderCommand = q.BuildUpdateCommand().ToDbCommand();

    //create a note for the order
    OrderNote note = new OrderNote();
    note.Note = "Order Created";
    note.OrderID = order.OrderID;
    note.OrderStatus = OrderStatus.ReceivedAwaitingPayment.ToString();

    //get the command to transact in the transaction
    DbCommand noteCommand = note.GetInsertCommand("Order System").ToDbCommand();


    //open the default db from the EL factory
    Database db = DatabaseFactory.CreateDatabase();
    using (DbConnection connection = db.CreateConnection()) {
      connection.Open();
      DbTransaction transaction = connection.BeginTransaction();

      try {
        //input the order
        db.ExecuteNonQuery(orderCommand, transaction);


        //add in the order note
        db.ExecuteNonQuery(noteCommand, transaction);


        // Commit the transaction
        transaction.Commit();
        //close the connection ... we are done with it.  
        connection.Close();


      }
      catch (Exception x) {
        // Rollback transaction 
        transaction.Rollback();
        LovRubLogger.LogException(x);  // KPL 04/0/08
        throw x;

      }
    }
  }

  /// <summary>
  /// This method commits the PayPal Standard order once received by the PDT or IPN.
  /// </summary>
  /// <returns></returns>
  public static Transaction CommitStandardOrder(Order order, string transactionID, decimal reportedAmount) {
    //the IPN and PDT return a transactionID as well as the amount paid.
    //make sure the amount is >= the amount of the transaction

    //create a transaction for this order
    Commerce.Common.Transaction trans = new Transaction();

    //if there are transactions for this order, that means that the PDT or IPN has already 
    //been received, so ignore it
    if (order.Transactions.Count == 0) {

      //no transactions
      //validate the transactionID
      TestCondition.IsNotEmptyString(transactionID, "Invalid PayPal TransactionID");

      //now check the amount of the order versus that paid for
      TestCondition.IsTrue(order.OrderTotal <= reportedAmount, "The amount returned from PayPal does match that of the order");

      //add the baseline information
      trans.OrderID = order.OrderID;
      trans.Amount = order.OrderTotal;

      trans.TransactionType = TransactionType.PayPalPayment;
      trans.TransactionDate = DateTime.UtcNow;
      trans.AuthorizationCode = transactionID;
      trans.TransactionNotes = "PayPal Standard Payment Received on " + DateTime.UtcNow.ToString() + ": ID=" + transactionID;

      //add a note to the Order
      OrderNote note = new OrderNote();
      note.Note = "PayPal payment received and applied";
      note.OrderID = order.OrderID;
      note.OrderStatus = Utility.ParseCamelToProper(OrderStatus.ReceivedPaymentProcessingOrder.ToString());


      //finally, update the order status
      order.OrderStatus = OrderStatus.ReceivedPaymentProcessingOrder;
      order.OrderDate = DateTime.Now;
      order.SubTotalAmount = order.CalculateSubTotal();

      //save em down
      //open the default db from the EL factory
      Database db = DatabaseFactory.CreateDatabase();
      using (DbConnection connection = db.CreateConnection()) {
        connection.Open();
        DbTransaction transaction = connection.BeginTransaction();

        try {
          //get the commands
          DbCommand orderCommand = order.GetUpdateCommand("Order System").ToDbCommand();
          DbCommand noteCommand = note.GetInsertCommand("Order System").ToDbCommand();
          DbCommand transCommand = trans.GetInsertCommand("Order System").ToDbCommand();

          //run the queries
          db.ExecuteNonQuery(orderCommand, transaction);
          db.ExecuteNonQuery(noteCommand, transaction);
          db.ExecuteNonQuery(transCommand, transaction);

          // Commit the transaction
          transaction.Commit();
          //close the connection ... we are done with it.  
          connection.Close();


        }
        catch (Exception x) {
          // Rollback transaction 
          transaction.Rollback();
          throw x;
        }

        //notifications
        try {
          //send off notification *after* the transaction commits ...
          MessagingController.SendOrderReceived_Customer(order);

          //to merchant; this is redundant a bit, as the standard bits
          //will tell merchant anyway.
          MessagingController.SendOrderReceived_Merchant(order);
        }
        catch {
          //Do Nothing
        }
      }
    }
    else {
      //set it to the first transaction for this order
      trans = order.Transactions[0];
    }

    return trans;

  }

  #endregion


  #endregion

  #region Cart Methods
  /// <summary>
  /// Executes the CSK_Store_Order_MigrateOrder Stored Procedure, which merges the cart items 
  /// from an anonymous account to a known account transactionally.
  /// </summary>
  /// <param name="oldUserName">Anonymous User</param>
  /// <param name="newUserName">Known User</param>
  public static void MigrateCart(string oldUserName, string newUserName) {


    Order fromOrder = GetOrder(GetCartOrderID(oldUserName));
    Order toOrder = GetOrder(GetCartOrderID(newUserName));

    //first see if there is an order for the now-recognized user
    if (toOrder.OrderNumber == string.Empty) {
      //if not, just update the old order with the new user's username
      fromOrder.UserName = newUserName;
      fromOrder.Save(Utility.GetUserName());
    }
    else {
      //the logged-in user has an existing basket. 
      //if there is no basket from their anon session, 
      //we don't need to do anything
      if (fromOrder.OrderNumber != string.Empty) {

        //in this case, there is an order (cart) from their anon session
        //and an order that they had open from their last session
        //need to marry the items.

        //this part is up to your business needs - some merchants
        //will want to replace the cart contents
        //others will want to synch them. We're going to assume that
        //this scenario will synch the existing items.

        //############### Synch the Cart Items
        if (toOrder.Items.Count > 0 && fromOrder.Items.Count > 0) {
          //there are items in both carts, move the old to the new
          //when synching, find matching items in both carts
          //update the quantities of the matching items in the logged-in cart
          //removing them from the anon cart

          //a switch to tell us if we need to update the from orders


          //1.) Find items that are the same between the two carts and add the anon quantity to the registered user quantity
          //2.) Mark found items as items to be removed from the anon cart.
          ArrayList toBeRemoved = new ArrayList(fromOrder.Items.Count);
          for (int i = 0; i < fromOrder.Items.Count; i++) {
            OrderItem foundItem = toOrder.Items.FindItem(fromOrder.Items[i]);
            if (foundItem != null) {
              foundItem.Quantity += fromOrder.Items[i].Quantity;
              toBeRemoved.Add(i);
            }
          }
          //3.) Now remove any foundItems from the anon cart, but trim it up first
          toBeRemoved.TrimToSize();
          for (int i = 0; i < toBeRemoved.Count; i++) {
            fromOrder.Items.RemoveAt((int)toBeRemoved[i]);
          }

          //4.) Move over to the registered user cart any remaining items in the anon cart.
          foreach (OrderItem anonItem in fromOrder.Items) {
            //reset the orderID
            anonItem.OrderID = toOrder.OrderID;
            toOrder.Items.Add(anonItem);
          }

          //5.) Finally, save it down to the DB
          // (Since we know toOrder.Items.Count > 0 && fromOrder.Items.Count > 0, we know a Save needs to occur)
          toOrder.SaveItems();
        }
        else if (toOrder.Items.Count == 0) {
          //items exist only in the anon cart
          //move the anon items to the new cart
          //then save the order and the order items.
          toOrder.IsNew = true;
          toOrder.OrderGUID = fromOrder.OrderGUID;
          toOrder.UserName = newUserName;
          toOrder.OrderNumber = fromOrder.OrderNumber;
          toOrder.OrderDate = fromOrder.OrderDate;
          toOrder.Save(newUserName);
          foreach (OrderItem item in fromOrder.Items) {
            //reset the orderID on each item
            item.OrderID = toOrder.OrderID;
            toOrder.Items.Add(item);
          }
          toOrder.SaveItems();

        }
        else if (fromOrder.Items.Count == 0) {
          //no items in the old cart, do nothing
        }


        //finally, drop the anon order from the DB, we don't want to 
        //keep it
        fromOrder.DeletePermanent();
      }
    }

  }

  /// <summary>
  /// Returns the number of items in the current cart
  /// </summary>
  /// <returns>System.Int32</returns>
  public static int GetCartItemCount() {
    int orderID = GetCartOrderID();
    Where where = new Where();
    where.ColumnName = "orderID";
    where.ParameterValue = orderID;

    int iOut = Query.GetCount("CSK_Store_OrderItem", "orderItemID", where);

    return iOut;
  }

  /// <summary>
  /// Returns the items in the current cart
  /// </summary>
  /// <returns>OrderItemCollection</returns>
  public static OrderItemCollection GetCartItems() {
    //get the cart items for the current user's cart
    int orderID = GetCartOrderID();
    OrderItemCollection list = new OrderItemCollection();

    if (orderID != 0) {
      list = list.Where("orderID", orderID).Load();

    }
    return list;
  }

  /// <summary>
  /// Adds an item to the cart
  /// </summary>
  /// <param name="product">Commerce.Common.Product</param>
  public static void AddItem(Product product) {

    //handle the exceptions in the page itself
    //let bubble up

    //get the current orderID
    int orderID = ProvisionOrder(Utility.GetUserName());

    string selectedAttrbutes = string.Empty;
    if (product.SelectedAttributes != null)
      selectedAttrbutes = product.SelectedAttributes.ToString().Trim();

    //make sure that the discount, if any, is applied
    product.OurPrice -= product.DiscountAmount;

    /////////////////////////////////
    // Change for Volume Discount
    decimal attributesPrice = 0;
    if (product.DiscountAmount != 0)
    {
        attributesPrice = -product.DiscountAmount;
    }
    //add the order using the CSK_Store_AddItemToCart_QtyDiscount SP
    SPsQtyDiscount.StoreAddItemToCart(Utility.GetUserName(), product.ProductID,
        selectedAttrbutes, product.OurPrice, product.PromoCode, product.Quantity, attributesPrice).Execute();
    /////////////////////////////////

    //add the order using the CSK_Store_AddItemToCart SP
    //SPs.StoreAddItemToCart(Utility.GetUserName(), product.ProductID,
    //    selectedAttrbutes, product.OurPrice, product.PromoCode, product.Quantity).Execute();

    //get the current quantity
    int oldQuantity = GetExistingQuantity(orderID, product);

    /////////////////////////////////
    // Change for Volume Discount
    //QtyDiscountController.SetDiscount(); 09/14/08 KPL
    /////////////////////////////////
  }

  /// <summary>
  /// Adds a Call Center item to the cart.  Doesn't make a call to 'SetDiscount()' like "AddItem()" does.
  /// </summary>
  /// <param name="product">Commerce.Common.Product</param>
  public static void AddCallCenterItem(Product product)
  {
      //handle the exceptions in the page itself
      //let bubble up
      //get the current orderID
      int orderID = ProvisionOrder(Utility.GetUserName());

      string selectedAttrbutes = string.Empty;
      if (product.SelectedAttributes != null)
          selectedAttrbutes = product.SelectedAttributes.ToString().Trim();

      //make sure that the discount, if any, is applied
      product.OurPrice -= product.DiscountAmount;

      /////////////////////////////////
      // Change for Volume Discount
      decimal attributesPrice = 0;
      if (product.DiscountAmount != 0)
      {
          attributesPrice = -product.DiscountAmount;
      }
      //add the order using the CSK_Store_AddItemToCart_QtyDiscount SP
      SPsQtyDiscount.StoreAddItemToCart( Utility.GetUserName(), 
                                         product.ProductID,
                                         selectedAttrbutes, 
                                         product.OurPrice, 
                                         product.PromoCode, 
                                         product.Quantity, 
                                         attributesPrice).Execute();
      /////////////////////////////////

      //add the order using the CSK_Store_AddItemToCart SP
      //SPs.StoreAddItemToCart(Utility.GetUserName(), product.ProductID,
      //    selectedAttrbutes, product.OurPrice, product.PromoCode, product.Quantity).Execute();

      //get the current quantity
      int oldQuantity = GetExistingQuantity(orderID, product);
  }

  /// <summary>
  /// Adjusts the quantity of an item in the cart
  /// </summary>
  /// <param name="orderID"></param>
  /// <param name="productID"></param>
  /// <param name="selectedAttributes"></param>
  /// <param name="newQuantity"></param>
  public static void AdjustQuantity(int orderID, int productID, string selectedAttributes, int newQuantity) {
    //check to see if this product is already added, if not, add it. If it's there, adjust the quantity
    Query q = new Query(OrderItem.GetTableSchema());
    q.AddWhere("orderID", orderID);
    q.AddWhere("productID", productID);
    q.AddWhere("attributes", selectedAttributes);

    q.AddUpdateSetting("quantity", newQuantity);
    q.AddUpdateSetting("modifiedOn", DateTime.UtcNow.ToString());
    q.AddUpdateSetting("modifiedBy", Utility.GetUserName());

    //check the rows updated, if it's more than one the item has already been set and we're done
    q.Execute();

/*********** old code. Don't call this for CALLCENTER KPL 06/08/08
    /////////////////////////////////
    // Change for Volume Discount
    QtyDiscountController.SetDiscount();
    /////////////////////////////////
 *********************************************/
    // Don't call SetDiscount() for CALLCENTER orders.
    bool bIsCallCtrOrder = false;
    Order currentOrder = OrderController.GetCurrentOrder();
    OrderNoteCollection noteCollection = currentOrder.Notes;
    int nCount = noteCollection.Count;
    for (int nIndex = 0; nCount > nIndex; nIndex++)
    {
        OrderNote note = noteCollection[nIndex];
        if (true == note.Note.Equals("CALLCENTER"))
        {
            bIsCallCtrOrder = true;
            break;
        }
    }
    //if (false == bIsCallCtrOrder)
        //QtyDiscountController.SetDiscount();  KPL 09/14/08
    // END. Don't call SetDiscount() for CALLCENTER orders.
  }


    public static void RemoveValentineItem(int productID, string selectedAttributes)
    {
        OrderItemCollection items = GetCartItems();

        Query q = new Query(OrderItem.GetTableSchema());
        int orderID = items[0].OrderID;
        q.QueryType = QueryType.Delete;
        q.AddWhere("orderID", orderID);
        q.AddWhere("productID", productID);
        //q.AddWhere("productID", item.ProductID);
        if (selectedAttributes != string.Empty)
            q.AddWhere("attributes", selectedAttributes);

        q.Execute();

        //remove it from the collection
        OrderItem removeItem = items.Find(productID);
        if (removeItem != null)
            items.Remove(removeItem);

    }

    /****************************************************************
     * 
     * DetermineBasketContents()
     * 
     ***************************************************************/
    public static void DetermineBasketContents(
                                            out int nTotalPaidQty,
                                            out int nMaleFullQty,
                                            out int nFemaleFullQty,
                                            out int nRL6FullQty,
                                            out int nRLFreeQty,
                                            out int nLipLovFullQty,
                                            out int nSurvivalFullQty,
                                            out int nChocBDFullQty,
                                            out int nCherBDFullQty)
    {
        nTotalPaidQty = 0;
        nMaleFullQty = 0;
        nFemaleFullQty = 0;
        nRL6FullQty = 0;
        nRLFreeQty = 0;
        nLipLovFullQty = 0;
        nSurvivalFullQty = 0;
        nChocBDFullQty = 0;
        nCherBDFullQty = 0;

        // Calculate total, male, female qty
        OrderItemCollection orderItemCollection = OrderController.GetCartItems();

        foreach (OrderItem currentItem in orderItemCollection)
        {
            if ("LRM1" == currentItem.Sku)
                nMaleFullQty += currentItem.Quantity;

            if ("LRW1" == currentItem.Sku)
                nFemaleFullQty += currentItem.Quantity;

            if (("DFDF" == currentItem.Sku))
                nRLFreeQty += currentItem.Quantity;

            if ("RLG6" == currentItem.Sku)
                nRL6FullQty += currentItem.Quantity;

            if ("LRLL" == currentItem.Sku)
                nLipLovFullQty += currentItem.Quantity;

            if ("LRSURV" == currentItem.Sku)
                nSurvivalFullQty += currentItem.Quantity;

            if ("LRCHERBD" == currentItem.Sku)
                nCherBDFullQty += currentItem.Quantity;
            
            if ("LRCHOCBD" == currentItem.Sku)
                nChocBDFullQty += currentItem.Quantity;
        }

        nTotalPaidQty = nMaleFullQty +
                        nFemaleFullQty +
                        nRL6FullQty +
                        nLipLovFullQty +
                        nSurvivalFullQty +
                        nChocBDFullQty +
                        nCherBDFullQty;
    }

    /******************** 11/24 **********
    public static void DetermineBasketContents(
                                           out int nTotalPaidQty,
                                           out int nMaleFullQty,
                                           out int nMaleDiscountQty,
                                           out int nFemaleFullQty,
                                           out int nFemaleDiscountQty,
                                           out int nRL6FullQty,
                                           out int nRLG6DiscountQty,
                                           out int nRLFreeQty,
                                           out int nSeasonalQty,
                                           out int nLipLovFullQty,
                                           out int nLipLovDiscountQty,
                                           out int nSurvivalFullQty)
    {
        nTotalPaidQty = 0;
        nMaleFullQty = 0;
        nMaleDiscountQty = 0;
        nFemaleFullQty = 0;
        nFemaleDiscountQty = 0;
        nRL6FullQty = 0;
        nRLG6DiscountQty = 0;
        nRLFreeQty = 0;
        nSeasonalQty = 0;
        nLipLovFullQty = 0;
        nLipLovDiscountQty = 0;
        nSurvivalFullQty = 0;

        // Calculate total, male, female qty
        OrderItemCollection orderItemCollection = OrderController.GetCartItems();

        foreach (OrderItem currentItem in orderItemCollection)
        {
            if ("LRM1" == currentItem.Sku)
                nMaleFullQty += currentItem.Quantity;

            if ("LRMCC1" == currentItem.Sku)
                nMaleDiscountQty += currentItem.Quantity;

            if ("LRW1" == currentItem.Sku)
                nFemaleFullQty += currentItem.Quantity;

            if ("LRWCC1" == currentItem.Sku)
                nFemaleDiscountQty += currentItem.Quantity;

            if (("DFDF" == currentItem.Sku))
                nRLFreeQty += currentItem.Quantity;

            if ("RLG6" == currentItem.Sku)
                nRL6FullQty += currentItem.Quantity;

            if ("RLG6CC1" == currentItem.Sku)
                nRLG6DiscountQty += currentItem.Quantity;

            if ( ("LRHHVAL" == currentItem.Sku) || 
                 ("LRMALEVAL" == currentItem.Sku) || 
                 ("LRFEMALEVAL" == currentItem.Sku) || 
                 ("LRXMSTO" == currentItem.Sku) )
                    nSeasonalQty += currentItem.Quantity;

            if ("LRLL" == currentItem.Sku)
                nLipLovFullQty += currentItem.Quantity;

            if ("LRLLCC1" == currentItem.Sku)
                nLipLovDiscountQty += currentItem.Quantity;

            if ("LRSURV" == currentItem.Sku)
                nSurvivalFullQty += currentItem.Quantity;
        }

        nTotalPaidQty = nMaleFullQty +
                        nMaleDiscountQty +
                        nFemaleFullQty +
                        nFemaleDiscountQty +
                        nRL6FullQty +
                        nRLG6DiscountQty +
                        //nRLFreeQty +
                        nSeasonalQty +
                        nLipLovFullQty +
                        nLipLovDiscountQty +
                        nSurvivalFullQty;
    }
     ****************** 11/24 *******************/
 

    public static void RemoveFullPriceItem(int productID, string selectedAttributes)
    {
/*********************************************************
        items = GetCartItems();
        OrderItem item = items[0];
        int nCount = items.Count;
        int orderID = 0;
        
        for (int nIndex = 0; nIndex < nCount; nIndex++)
        {
            Query q = new Query(OrderItem.GetTableSchema());
            orderID = items[0].OrderID;
            q.QueryType = QueryType.Delete;
            q.AddWhere("orderID", orderID);

            q.AddWhere("productID", items[0].ProductID);
            if (selectedAttributes != string.Empty)
                q.AddWhere("attributes", selectedAttributes);

            q.Execute();

            //remove it from the collection
            //OrderItem removeItem = items.Find(productID);
            OrderItem removeItem = items.Find(items[0].ProductID);
            if (removeItem != null)
                items.Remove(removeItem);
        }
 **************************************************/
    }



    /*****************************
     * 0) figure out what is currently in cart: DetermineBasketContents()
     *    what type and how many of each item.(free, discount, full, seasonal)
     * 
     * ) figure out what type of item to remove.(free, discount, full, seasonal)
     * 
     * 
    * 1) if remove "full price" LR item
    *              remove all discounted items
    *              don't remove seasonal items
    *              if no seasonal item 
    *                   remove free item
    *              
    * 
    * 2) if remove "discount" item(s)
    *              remove the 1 item but if removing a discount item makes total item quantity 
    *              (not including any free items) == 1, then also remove the free item.
    * 
    * 
    * 3) if remove "seasonal" item(s)
    *              remove it, but if removing seasonal item makes total item quantity 
    *              (not including any free items) == 0 or 1, then also remove the free item.
    *              
    * 4) remove "free" item
    *              just remove it
    *              
    *************************/
    /**************** 11/24 *******
    public static void RemoveCallCenterItem(int productID, string selectedAttributes)
    {
        int nTotalPaidQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;
        int nRL6FullQty = 0;
        int nRLG6DiscountQty = 0;
        int nRLFreeQty = 0;
        int nSeasonalQty = 0;
        int nSurvivalFullQty = 0;

        int nLipLovFullQty = 0;
        int nLipLovDiscountQty = 0;


        // Calculate total, male, female, RubLov qty
        DetermineBasketContents(out nTotalPaidQty,
                                out nMaleFullQty,
                                out nMaleDiscountQty,
                                out nFemaleFullQty,
                                out nFemaleDiscountQty,
                                out nRL6FullQty,
                                out nRLG6DiscountQty,
                                out nRLFreeQty,
                                out nSeasonalQty,
                                out nLipLovFullQty,
                                out nLipLovDiscountQty,
                                out nSurvivalFullQty);

        bool bRemoveAll = false, bRemoveFullPrice = false, bRemoveDiscount = false, bRemoveSeasonal = false, bRemoveFree = false;
        
        OrderItemCollection items = GetCartItems();
        foreach (OrderItem item in items)
        {
            if (productID != item.ProductID)
                continue;

            if (("LRM1" == item.Sku) || ("LRW1" == item.Sku) || ("RLG6" == item.Sku) || ("LRLL" == item.Sku))
            {
                bRemoveFullPrice = true;
                break;
            }

            if (("LRSURV" == item.Sku))
            {
                bRemoveFullPrice = true;
                break;
            }

            if (("LRMCC1" == item.Sku) || ("LRWCC1" == item.Sku) || ("RLG6CC1" == item.Sku) || "LRLLCC1" == item.Sku)
            {
                bRemoveDiscount = true;
                break;
            }


            if (("LRFEMALEVAL" == item.Sku) || 
                ("LRMALEVAL" == item.Sku) || 
                ("LRHHVAL" == item.Sku) || 
                ("LRXMSTO" == item.Sku) )
            {
                bRemoveSeasonal = true;
                break;
            }

            if (("DFDF" == item.Sku) )
            {
                bRemoveFree = true;
                break;
            }
        }


        items = GetCartItems();
        int nCount = items.Count;
        int orderID = 0;
        bool bDelete = false;

        if (true == bRemoveFullPrice)
        {
            for (int nIndex = nCount - 1; nIndex > -1; nIndex--)
            {
                bDelete = false;

                // if item == full or discount                 
                if (("LRM1" == items[nIndex].Sku) || 
                    ("LRW1" == items[nIndex].Sku) || 
                    ("RLG6" == items[nIndex].Sku) || 
                    ("LRLL" == items[nIndex].Sku) ||
                    ("LRSURV" == items[nIndex].Sku) )
                {
                    bDelete = true;
                }

                if (("LRMCC1" == items[nIndex].Sku) || 
                    ("LRWCC1" == items[nIndex].Sku) || 
                    ("RLG6CC1" == items[nIndex].Sku)||
                    ("LRLLCC1" == items[nIndex].Sku))
                {
                    bDelete = true;
                }
                
                if (("DFDF" == items[nIndex].Sku) && (0 == nSeasonalQty) )
                {
                    bDelete = true;    
                }

                if (bDelete)
                {
                    Query q = new Query(OrderItem.GetTableSchema());
                    orderID = items[nIndex].OrderID;
                    q.QueryType = QueryType.Delete;
                    q.AddWhere("orderID", orderID);

                    q.AddWhere("productID", items[nIndex].ProductID);
                    if (selectedAttributes != string.Empty)
                        q.AddWhere("attributes", selectedAttributes);

                    q.Execute();

                    //remove it from the collection
                    OrderItem removeItem = items.Find(items[nIndex].ProductID);
                    if (removeItem != null)
                        items.Remove(removeItem);
                }
            }
        }

        //* if remove "discount" item(s)
        //*  remove the 1 item but if removing a discount item makes total item quantity 
        //*  (not including any free items or seasonal items) == 1, then also remove the free item.
        if (true == bRemoveDiscount)
        {
            int nTotalAfterDeletion;
            if ((nRLFreeQty > 0) && (0 == nSeasonalQty))
            {
                nTotalAfterDeletion = nTotalPaidQty - 2;
            }
            else
                nTotalAfterDeletion = nTotalPaidQty - 1;

            for (int nIndex = nCount - 1; nIndex > -1; nIndex--)
            {
                bDelete = false;

                if (("LRMCC1" == items[nIndex].Sku) || 
                    ("LRWCC1" == items[nIndex].Sku) || 
                    ("RLG6CC1" == items[nIndex].Sku)||
                    ("LRLLCC1" == items[nIndex].Sku))
                {
                    bDelete = true;
                }

                if (("DFDF" == items[nIndex].Sku) && 
                    (nTotalAfterDeletion == 1) && 
                    (0 == nSeasonalQty) && 
                    (1 == nRLFreeQty))
                {
                    bDelete = true;
                }

                if (bDelete)
                {
                    Query q = new Query(OrderItem.GetTableSchema());
                    orderID = items[nIndex].OrderID;
                    q.QueryType = QueryType.Delete;
                    q.AddWhere("orderID", orderID);

                    q.AddWhere("productID", items[nIndex].ProductID);
                    if (selectedAttributes != string.Empty)
                        q.AddWhere("attributes", selectedAttributes);

                    q.Execute();

                    //remove it from the collection
                    OrderItem removeItem = items.Find(items[nIndex].ProductID);
                    if (removeItem != null)
                        items.Remove(removeItem);
                }
            }
        }

        //* remove "seasonal" item(s)
        //*  remove it, but if removing seasonal item makes total item quantity 
        //*  (not including any free items) == 0 or 1, then also remove the free item.
        if (true == bRemoveSeasonal)
        {
            int nTotalAfterDeletion;
            if ((nRLFreeQty > 0))
            {
                nTotalAfterDeletion = nTotalPaidQty - 2;
            }
            else
                nTotalAfterDeletion = nTotalPaidQty - 1;

            for (int nIndex = nCount - 1; nIndex > -1; nIndex--)
            {
                bDelete = false;

                if (("LRFEMALEVAL" == items[nIndex].Sku) ||
                    ("LRMALEVAL" == items[nIndex].Sku) || 
                    ("LRHHVAL" == items[nIndex].Sku) ||
                    ("LRXMSTO" == items[nIndex].Sku))
                {
                    bDelete = true;
                }

                if (("DFDF" == items[nIndex].Sku) &&
                    ((nTotalAfterDeletion == 1) || (nTotalAfterDeletion == 0)) &&
                    (1 == nRLFreeQty))
                {
                    bDelete = true;
                }

                if (bDelete)
                {
                    Query q = new Query(OrderItem.GetTableSchema());
                    orderID = items[nIndex].OrderID;
                    q.QueryType = QueryType.Delete;
                    q.AddWhere("orderID", orderID);

                    q.AddWhere("productID", items[nIndex].ProductID);
                    if (selectedAttributes != string.Empty)
                        q.AddWhere("attributes", selectedAttributes);

                    q.Execute();

                    //remove it from the collection
                    OrderItem removeItem = items.Find(items[nIndex].ProductID);
                    if (removeItem != null)
                        items.Remove(removeItem);
                }
            }
        }
    }

     *****************************/
 
    
    public static void RemoveCallCenterItem(int productID, string selectedAttributes)   
    {
            int nTotalPaidQty = 0;
            int nMaleFullQty = 0;
            int nFemaleFullQty = 0;
            int nRL6FullQty = 0;
            int nRLFreeQty = 0;
            int nSurvivalFullQty = 0;
            int nLipLovFullQty = 0;
            int nChocBDFullQty = 0;
            int nCherBDFullQty = 0;

            Query q = null;

            // Calculate total, male, female, RubLov qty
            DetermineBasketContents(out nTotalPaidQty,
                                    out nMaleFullQty,
                                    out nFemaleFullQty,
                                    out nRL6FullQty,
                                    out nRLFreeQty,
                                    out nLipLovFullQty,
                                    out nSurvivalFullQty,
                                    out nChocBDFullQty,
                                    out nCherBDFullQty);

            OrderItemCollection items = GetCartItems();
            foreach (OrderItem item in items)
            {
                if (productID != item.ProductID)
                    continue;

                q = new Query(OrderItem.GetTableSchema());
                q.QueryType = QueryType.Delete;
                q.AddWhere("orderID", item.OrderID);

                q.AddWhere("productID", item.ProductID);
                if (selectedAttributes != string.Empty)
                    q.AddWhere("attributes", selectedAttributes);

                q.Execute();
                break;
            }

            //remove it from the collection
            OrderItem removeItem = items.Find( productID );
            if (removeItem != null)
                items.Remove(removeItem);

            int nCount = items.Count;
            // if nCount == 1 and it's a free item, remove it also
            if (1 == nCount)
            {
                if ("DFDF" == items[0].Sku)
                {
                    q = new Query(OrderItem.GetTableSchema());
                    q.QueryType = QueryType.Delete;
                    q.AddWhere("orderID", items[0].OrderID);

                    q.AddWhere("productID", items[0].ProductID);
                    if (selectedAttributes != string.Empty)
                        q.AddWhere("attributes", selectedAttributes);

                    q.Execute();

                    //remove it from the collection
                    items.Remove(items[0]);

                }
            }
    } 
    



    /// <summary>
  /// Removes a CallCenter item from the cart with specified attributes
  /// </summary>
  /// <param name="productID"></param>
  /// <param name="selectedAttributes"></param>
  /// 
    public static void OLDRemoveCallCenterItem(int productID, string selectedAttributes)
  {
      
      /************************
      Removing "Full Price" item will remove all discounted items and free Massage Gel
      Removing "Discount" item will remove just that 1 item
      If removing a discount item makes total item quantity == 1, then also remove the Free Massage Gel
      ************************/
      bool bRemoveAll = false, bRemoveDiscount = false, bRemoveFree = false;

      OrderItemCollection items = GetCartItems();
      foreach (OrderItem item in items)
      {
          if (productID != item.ProductID)
              continue;


          if (("LRFEMALEVAL" == item.Sku) || ("LRMALEVAL" == item.Sku) || ("LRHHVAL" == item.Sku))
          {
              RemoveValentineItem(productID, selectedAttributes);
              break;
          }
               

          // If its a full price item, remove everything from cart.
          if (("LRM1" == item.Sku) || ("LRW1" == item.Sku) || ("RLG6" == item.Sku))
          {
              bRemoveAll = true;
              break;
          }

          if (("LRMCC1" == item.Sku) || ("LRWCC1" == item.Sku) || ("RLG6CC1" == item.Sku) )
          {
              bRemoveDiscount = true;
              break;
          }

          if (("DFDF" == item.Sku))
          {
              bRemoveFree = true;
              break;
          }

          /*** 01/07/09 KPL. No more Christmas stocking.
          if (("DFDF" == item.Sku) || ("LRXMSTO" == item.Sku))
          {
              bRemoveFree = true;
              break;
          }
          ***/
      }

        // Remove all items
        if (true == bRemoveAll)
        {
            items = GetCartItems();
            OrderItem item = items[0];
            int nCount = items.Count;
            int orderID = 0;
            for(int nIndex = 0; nIndex < nCount; nIndex++) 
            {
                Query q = new Query(OrderItem.GetTableSchema());
                orderID = items[0].OrderID;
                q.QueryType = QueryType.Delete;
                q.AddWhere("orderID", orderID);
                
                //q.AddWhere("productID", productID);
                q.AddWhere("productID", items[0].ProductID);
                if (selectedAttributes != string.Empty)
                    q.AddWhere("attributes", selectedAttributes);

                q.Execute();

                //remove it from the collection
                //OrderItem removeItem = items.Find(productID);
                OrderItem removeItem = items.Find(items[0].ProductID);
                if (removeItem != null)
                    items.Remove(removeItem);
            }
        }
        // Removing "Discount" item will remove just that 1 item
        // but if removing a discount item makes total item quantity == 1, 
        // then also remove the Free Massage Gel
        if (true == bRemoveDiscount || (true == bRemoveFree))
        {
            Query q = new Query(OrderItem.GetTableSchema());
            int orderID = items[0].OrderID;
            q.QueryType = QueryType.Delete;
            q.AddWhere("orderID", orderID);
            q.AddWhere("productID", productID);
            //q.AddWhere("productID", item.ProductID);
            if (selectedAttributes != string.Empty)
                q.AddWhere("attributes", selectedAttributes);

            q.Execute();

            //remove it from the collection
            //OrderItem removeItem = items.Find(productID);
            OrderItem removeItem = items.Find(productID);
            if (removeItem != null)
                items.Remove(removeItem);
        }

        // Removing "Discount" item will remove just that 1 item
        // but if removing a discount item makes total item quantity == 2, 
        // then also remove the Free Massage Gel
        if ((true == bRemoveDiscount) && (2 == items.Count))
        {
            //OrderItemCollection items = GetCartItems();
            foreach (OrderItem item in items)
            {
                if (("DFDF" == item.Sku))
                {
                    Query q = new Query(OrderItem.GetTableSchema());
                    int orderID = items[0].OrderID;
                    q.QueryType = QueryType.Delete;
                    q.AddWhere("orderID", orderID);
                    q.AddWhere("productID", item.ProductID);
                    if (selectedAttributes != string.Empty)
                        q.AddWhere("attributes", selectedAttributes);

                    q.Execute();

                    //remove it from the collection
                    if (item != null)
                        items.Remove(item);
                    break;
                }
            }
        }
        //if the current order items are 0, make sure to reset the coupons
        //use the EnsureOrderCoupon SP to do this
        //SPs.PromoEnsureOrderCoupon(orderID).Execute();

  }    
    
    
    /// <summary>
  /// Removes an item from the cart with specified attributes
  /// </summary>
  /// <param name="productID"></param>
  /// <param name="selectedAttributes"></param>
  public static void RemoveItem(int productID, string selectedAttributes) {


    bool isPartOfBundle = false;
    string bundleName = "";
    Hashtable bundledProducts = new Hashtable();
    ;
    //check to see if the product to be removed
    //is part of a bundle
    OrderItemCollection items = GetCartItems();

    foreach (OrderItem item in items) {
      if (item.ProductID.Equals(productID) && item.Attributes.Equals(selectedAttributes)) {
        if (item.PromoCode.StartsWith("BUNDLE:")) {
          bundleName = item.PromoCode;
          isPartOfBundle = true;
          break;

        }
      }
    }

    //remove the item from the order items table
    Query q = new Query(OrderItem.GetTableSchema());
    int orderID = items[0].OrderID;
    q.QueryType = QueryType.Delete;
    q.AddWhere("orderID", orderID);
    q.AddWhere("productID", productID);

    if (selectedAttributes != string.Empty)
      q.AddWhere("attributes", selectedAttributes);

    q.Execute();

    //remove it from the collection
    OrderItem removeItem = items.Find(productID);
    if (removeItem != null)
      items.Remove(removeItem);

    //if this was a bundle, loop the remaining items
    //and remove the BUNDLE tag, as well as the discount
    if (isPartOfBundle) {
      //need to loop through the items
      //find those that are part of this bundle
      foreach (OrderItem item in items) {
        if (item.PromoCode.Equals(bundleName)) {
          item.PromoCode = "";

          //pull the product
          Product thisProduct = ProductController.GetProduct(item.ProductID);

          //make sure to apply any other discounts back to the product
          Commerce.Promotions.PromotionService.SetProductPricing(thisProduct);

          //reset the pricing
          item.OriginalPrice = thisProduct.RetailPrice;
          item.PricePaid = thisProduct.OurPrice;

          //save it down to the order
          item.Save(Utility.GetUserName());
        }

      }
    }



    //if the current order items are 0, make sure to reset the coupons
    //use the EnsureOrderCoupon SP to do this
    SPs.PromoEnsureOrderCoupon(orderID).Execute();

    /*********** old code. Don't call this for CALLCENTER KPL 06/08/08
        /////////////////////////////////
        // Change for Volume Discount
        QtyDiscountController.SetDiscount();
        /////////////////////////////////
     *********************************************/
    // Don't call SetDiscount() for CALLCENTER orders.
    bool bIsCallCtrOrder = false;
    Order currentOrder = OrderController.GetCurrentOrder();
    OrderNoteCollection noteCollection = currentOrder.Notes;
    int nCount = noteCollection.Count;
    for (int nIndex = 0; nCount > nIndex; nIndex++)
    {
        OrderNote note = noteCollection[nIndex];
        if (note.Equals("CALLCENTER"))
            bIsCallCtrOrder = true;
    }
    //if (!bIsCallCtrOrder) KPL 09/14/08
    //    QtyDiscountController.SetDiscount();
    // END. Don't call SetDiscount() for CALLCENTER orders.
  }

  /// <summary>
  /// Removes an item from the cart
  /// </summary>
  /// <param name="productID"></param>
  public static void RemoveItem(int productID) {
    RemoveItem(productID, "");
  }

  /// <summary>
  /// Returns the current quantity of an item
  /// </summary>
  /// <param name="orderID"></param>
  /// <param name="product"></param>
  /// <returns></returns>
  static int GetExistingQuantity(int orderID, Product product) {
    int iOut = 0;
    Query q = new Query(OrderItem.GetTableSchema());
    q.AddWhere("orderID", orderID);
    q.AddWhere("productID", product.ProductID);
    if (product.SelectedAttributes != null)
      q.AddWhere("attributes", product.SelectedAttributes.ToString());
    q.SelectList = "quantity";

    object result = q.ExecuteScalar();
    if (result != null) {
      int.TryParse(result.ToString(), out iOut);
    }
    return iOut;

  }

  /// <summary>
  /// Gets the order ID of a cart for the specified user
  /// </summary>
  /// <param name="userName"></param>
  /// <returns></returns>
  public static int GetCartOrderID(string userName) {
    int iOut = 0;
    //get the current order for the user. if there isn't one, make one
    Query q = new Query(Order.GetTableSchema());
    q.AddWhere("userName", userName);
    q.AddWhere("orderStatusID", (int)OrderStatus.NotProcessed);
    q.SelectList = "orderID";

    object oResult = q.ExecuteScalar();
    if (oResult != null) {
      iOut = (int)oResult;
    }
    return iOut;

  }

  /// <summary>
  /// Gets the order ID of a cart for the current user
  /// </summary>
  /// <param name="userName"></param>
  /// <returns></returns>
  public static int GetCartOrderID() {
    return GetCartOrderID(Utility.GetUserName());

  }

  /// <summary>
  /// Get's the GUID of the current user's order
  /// </summary>
  /// <returns></returns>
  public static string GetCartOrderGUID() {
    string sOut = "";
    //get the current order for the user. if there isn't one, make one
    Query q = new Query(Order.GetTableSchema());

    q.AddWhere("userName", Utility.GetUserName());
    q.AddWhere("orderStatusID", OrderStatus.NotProcessed);
    q.SelectList = "orderGUIID";

    object oResult = q.ExecuteScalar();
    if (oResult != null) {
      sOut = oResult.ToString();
    }
    return sOut;

  }

  /// <summary>
  /// Creates an order for a user when first-adding an item to the basket
  /// </summary>
  /// <param name="userName"></param>
  /// <returns></returns>
  static int ProvisionOrder(string userName) {
    int orderID = GetCartOrderID();

    if (orderID == 0) {
      //create an order
      string companyOrderIdentifier = ConfigurationManager.AppSettings["companyOrderIdentifier"];
      Order newOrder = new Order();
      newOrder.OrderGUID = System.Guid.NewGuid().ToString();
      newOrder.OrderStatus = OrderStatus.NotProcessed;
      newOrder.SubTotalAmount = 0;
      newOrder.UserIP = HttpContext.Current.Request.UserHostAddress;
      newOrder.UserName = userName;
      newOrder.OrderNumber = companyOrderIdentifier + "-XX-" + Utility.GetRandomString();
      newOrder.Save(userName);
      orderID = newOrder.OrderID;
    }

    return orderID;
  }

  /// <summary>
  /// Saves an order item to the DB
  /// </summary>
  /// <param name="product"></param>
  /// <param name="orderID"></param>
  /// <param name="userName"></param>
  static void SaveOrderItem(Product product, int orderID, string userName) {
    decimal adjustedPrice = product.OurPrice;

    if (product.DiscountAmount != 0) {
      adjustedPrice = product.OurPrice - product.DiscountAmount;
    }
    OrderItem item = new OrderItem();
    item.OrderID = orderID;
    item.ProductID = product.ProductID;
    item.Sku = product.Sku;
    item.PromoCode = product.PromoCode;
    item.PricePaid = adjustedPrice;
    item.OriginalPrice = product.RetailPrice;
    item.ProductName = product.ProductName;
    item.ProductDescription = product.ShortDescription;
    item.ImageFile = product.ImageFile;
    item.ShippingEstimate = product.ShippingEstimate;

    //save them as a list - no need for the XML structure here.
    //especially since the structure of the Attributes might change
    //making this hard to inflate properly
    if (product.SelectedAttributes != null)
      item.Attributes = product.SelectedAttributes.ToString();

    item.Weight = product.Weight;
    item.Quantity = product.Quantity;
    item.Width = product.Width;
    item.Height = product.Height;
    item.Length = product.Length;
    item.DateAdded = DateTime.UtcNow;
    item.ImageFile = product.ImageFile;
    item.Rating = product.Rating;
    item.Save(userName);
  }

    public static bool IsFreeItemInCart()
    {
        OrderItemCollection orderItemCollection = OrderController.GetCartItems();

        foreach (OrderItem currentItem in orderItemCollection)
        {
            /* commented. No more christmas stocking. 01/08/09 KPL. */
            //if (("DFDF" == currentItem.Sku) || ("LRXMSTO" == currentItem.Sku))
            
            if (("DFDF" == currentItem.Sku))
                return (true);
        }

        return( false );
    }

    /*
    public static string GetFreeItemInCart()
    {
        OrderItemCollection orderItemCollection = OrderController.GetCartItems();

        foreach (OrderItem currentItem in orderItemCollection)
        {
            if (("DFDF" == currentItem.Sku))
                return "DFDF";
            if (("LRXMSTO" == currentItem.Sku))
                return ("LRXMSTO");
        }
     
        return ("");
    }
     */


  #endregion

    
    
}
