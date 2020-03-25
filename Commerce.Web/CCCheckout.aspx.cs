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
using Commerce.Common;
using Commerce.Providers;
using Commerce.PayPal;

public partial class CCCheckout : System.Web.UI.Page {
  protected Order currentOrder = null;

  void ValidatePage() 
  {
    //Page Validation
    //1) Need items in order to checkout
    try {
      TestCondition.IsTrue(currentOrder.Items.Count > 0, "There are no items in your cart");
    }
    catch {
      //send them to the basket page
      Response.Redirect("~/CCBasket.aspx", false);
    }
    //2) Need to have this page under SSL!
    Utility.TestForSSL();
  }

  protected void Page_Load(object sender, EventArgs e) {

    pnlCoupons.Visible = false;   // KPL 12/23/07 turn off coupon panel.
    radShipChoices.Enabled = false; // KPL 12/23/07 turn off shipping radio buttons.
    radShipChoices.Visible = false; // KPL 12/23/07 turn off shipping radio buttons.
    //show the panels according to payment settings
    
    pnlPPStandard.Visible = SiteConfig.UsePayPalPaymentsStandard;
    //pnlExpressCheckout.Visible = SiteConfig.UsePayPalExpressCheckout;
    
    wizCheckout.Visible = SiteConfig.AcceptCreditCards;
    pnlNav.Visible = SiteConfig.AcceptCreditCards;

    //pull the order from the ViewState or DB as needed
    currentOrder = GetCurrentOrder();

    //make sure the page is valid
    ValidatePage();

    //turn the submit button off when they submit the order. This prevents double (or more) orders
    this.btnComplete.Attributes.Add("onclick", "this.value='Please wait...';this.disabled = true;" + Page.ClientScript.GetPostBackEventReference(this.btnComplete, ""));
    if (!Page.IsPostBack) {

      //check to see if they require a login
      if (SiteConfig.RequireLogin == "checkout") {
        if (!User.Identity.IsAuthenticated)
          Response.Redirect("~/login.aspx?ReturnUrl=checkout.aspx", true);
      }

      //Check to make sure the site accept's credit cards
      if (SiteConfig.AcceptCreditCards) {

        LoadShippingList();

        //default the addresses
        if (Profile.LastShippingAddress != null)
          SetAddressEntry("addShipping", Profile.LastShippingAddress);
        if (Profile.LastBillingAddress != null)
          SetAddressEntry("addBilling", Profile.LastBillingAddress);

        //this is the package info for UPS/USPS
        //PackageInfo package = LoadPackage();
        //BindShipping(package);

        //check the URL for a return from PayPal using Express Checkout
        if (Utility.GetParameter("token") != string.Empty) {
          //get the info from PayPal about this buyer
          //and populate the addresses,etc
          ProcessExpressReturn(Utility.GetParameter("token"));

          //load the final wizard screen
          wizCheckout.MoveTo(wizCheckout.WizardSteps[2]);
        }
      }
      else {
        //it's PP Standard only
        //redirect to the PP Standard checkout page
        Response.Redirect("CheckoutPPStandard.aspx", true);
      }
    }
    SetOrderInfo();
  }

  Order GetCurrentOrder() 
  {
    Order result = null;
    if (ViewState["CurrentOrder"] != null) {
      result = (Order)ViewState["CurrentOrder"];
    }
    else {
      result = OrderController.GetCurrentOrder();
    }
    return result;
  }
  
    void SetOrderInfo() {

    RadioButtonList radShipChoices = (RadioButtonList)wizCheckout.FindControl("radShipChoices");
    if (radShipChoices != null) {
      //currentOrder.ShippingAmount = Profile.CurrentOrderShipping;
      //currentOrder.ShippingMethod = Profile.CurrentOrderShippingMethod;
        // KPL added 12/22/07
        int nQuantity = 0;
        for (int nIndex = 1; nIndex <= currentOrder.Items.Count; nIndex++)
        {
            nQuantity += currentOrder.Items[nIndex-1].Quantity;
        }

      if (1 == nQuantity)
      {
          currentOrder.ShippingAmount = 4.15m;
          currentOrder.ShippingMethod = "US Postal Service 1st Class $4.15 Flat Rate";  // KPL added 12/23/07
      }
      if (2 == nQuantity)
      {
          currentOrder.ShippingAmount = 4.66m;
          currentOrder.ShippingMethod = "US Postal Service 1st Class $4.66 Flat Rate";  // KPL added 12/23/07
      }
      if (nQuantity > 2)
      {
          currentOrder.ShippingAmount = 6.60m;
          currentOrder.ShippingMethod = "US Postal Service 1st Class $6.60 Flat Rate";  // KPL added 12/23/07
      }
      // KPL end added 12/22/07

    }
    //these are set by the wizard in steps 1 & 2
    currentOrder.ShippingAddress = addShipping.SelectedAddress;
    currentOrder.BillingAddress = addBilling.SelectedAddress;

    //put them to HTML string for display to our admins
    currentOrder.ShipToAddress = addShipping.SelectedAddress.ToHtmlString();
    currentOrder.BillToAddress = addBilling.SelectedAddress.ToHtmlString();

    //need a phone for shipping address
    currentOrder.ShipPhone = addShipping.SelectedAddress.Phone;

    //see if this is an ExpressCheckout order
    //if it is, then we need to put the Checkout Tokens into the Billing Address
    if (ViewState["ppToken"] != null && ViewState["ppID"] != null) {
      currentOrder.BillingAddress.PayPalPayerID = ViewState["ppID"].ToString();
      currentOrder.BillingAddress.PayPalToken = ViewState["ppToken"].ToString();

    }


    /************************** KPL commented for shipping purposes 12/23/07
    if (radShipChoices.Items.Count > 0) 
    {
      currentOrder.ShippingAmount = decimal.Parse(radShipChoices.SelectedValue);
      currentOrder.ShippingMethod = radShipChoices.SelectedItem.Text;
    }
    ************************************************************************/
    //tax is stored in the Profile for this order
    currentOrder.TaxAmount = Profile.CurrentOrderTax;

    //pull the CC info from the PaymentBox
    currentOrder.CreditCardNumber = PaymentBox1.CCNumber;
    currentOrder.CreditCardExpireMonth = PaymentBox1.ExpirationMonth;
    currentOrder.CreditCardExpireYear = PaymentBox1.ExpirationYear;
    currentOrder.CreditCardSecurityNumber = PaymentBox1.SecurityCode;
    currentOrder.CreditCardType = PaymentBox1.CCType;

    if (currentOrder.BillingAddress != null) {
      currentOrder.FirstName = currentOrder.BillingAddress.FirstName;
      currentOrder.LastName = currentOrder.BillingAddress.LastName;
      currentOrder.Email = currentOrder.BillingAddress.Email;
    }

//******** KPL 12/23/07 removed coupons    
      //check to see if there's been a coupon applied
    //if there has, un-enable the coupons
    //change this as your business dicates
    if (!string.IsNullOrEmpty(currentOrder.CouponCodes)) {
      couponMessage.Text = currentOrder.CouponCodes + " has already been applied to this order. You must empty your basket to remove the coupon.";
      couponCode.Enabled = false;
      applyCoupon.Enabled = false;
    }
//******** KPL 12/23/07 removed coupons

    //put the order in the ViewState to spare our DB
    ViewState["CurrentOrder"] = currentOrder;
  }


  #region Addressing
  void SetAddressEntry(string controlName, Address address) {
    AddressEntry addBox = (AddressEntry)wizCheckout.FindControl(controlName);
    if (addBox != null)
      addBox.SelectedAddress = address;

  }
  Address GetAddressEntry(string controlName) {
    Address add = null;
    AddressEntry addBox = (AddressEntry)wizCheckout.FindControl(controlName);
    if (addBox != null)
      add = addBox.SelectedAddress;
    return add;

  }
  void SaveAddresses() {
    //pull the addresses and save them to the DB for the user
    Address billAddress = addBilling.SelectedAddress;
    billAddress.UserName = Utility.GetUserName();
    OrderController.SaveAddress(billAddress);

    //if the billing/shipping are different, save that as well
    Address shipAddress = addShipping.SelectedAddress;
    if (!shipAddress.Equals(billAddress)) {
      shipAddress.UserName = Utility.GetUserName();
      OrderController.SaveAddress(shipAddress);
    }
  }
  #endregion

  #region Shipping Bits
  PackageInfo LoadPackage() {

    //Create shipping package
    PackageInfo package = new PackageInfo();
    package.FromZip = SiteConfig.ShipFromZip;
    package.FromCountryCode = SiteConfig.ShipFromCountryCode;
    package.ToZip = Profile.LastShippingAddress.Zip;
    ;
    package.ToCountryCode = Profile.LastShippingAddress.Country;
    package.Weight = currentOrder.GetItemsWeight();
    package.Width = Convert.ToInt16(currentOrder.GetTotalWidth());
    package.Height = Convert.ToInt16(currentOrder.GetTotalHeight());
    package.Length = Convert.ToInt16(currentOrder.GetMaxLength());
    package.DimensionUnit = SiteConfig.DimensionUnit;
    package.PackagingBuffer = SiteConfig.ShipPackagingBuffer;
    //Create Dictionary args for future expansion options
    package.Args = new Dictionary<string, string>();
    return package;

  }

  void BindShipping(PackageInfo package) {
    //IDataReader rdr = Commerce.Providers.ShippingService.GetShippingChoices(package);

    Commerce.Providers.DeliveryOptionCollection options = Commerce.Providers.FulfillmentService.GetOptions(package);
    radShipChoices.DataSource = options;
    radShipChoices.DataTextField = "Service";
    radShipChoices.DataValueField = "Rate";
    radShipChoices.DataBind();
    radShipChoices.SelectedIndex = 0;

    //localize it using the C formatter for local currency
    decimal dRate = 0;
    foreach (ListItem l in radShipChoices.Items) {
      dRate = decimal.Parse(l.Value);
      l.Text += ": " + dRate.ToString("C");

    }

    //set the Profile Shipping Bits
    Profile.CurrentOrderShipping = decimal.Parse(radShipChoices.SelectedValue);
    Profile.CurrentOrderShippingMethod = radShipChoices.SelectedItem.Text;
  }

  void LoadShippingList() {
    DataList dtAddresses = (DataList)wizCheckout.FindControl("dtAddresses");
    if (dtAddresses != null) {
      dtAddresses.DataSource = OrderController.GetUserAddresses();
      dtAddresses.DataBind();

    }
  }

  protected decimal GetSelectedShipping() {
    decimal dOut = 0;
    decimal.TryParse(radShipChoices.SelectedValue, out dOut);
    return dOut;
  }
  protected string GetShippingAddress() {
    return addShipping.SelectedAddress.ToHtmlString();
  }
  protected string GetBillingAddress() {
    return addBilling.SelectedAddress.ToHtmlString();
  }
  protected string GetShippingZip() {
    string zip = "";
    Address add = GetAddressEntry("addShipping");
    if (add != null)
      zip = add.Zip;

    return zip;
  }

  void EnsurePanelsHidden() {
    //bit of a hack here - an atlas workaround
    //the visible property of the PayPal checkout thingers isn't honored
    //if we're here, they shouldn't be showing
    //pnlExpressCheckout.Visible = false;
    pnlPPStandard.Visible = false;
    pnlNav.Visible = false;

  }
  protected void radShipChoices_SelectedIndexChanged(object sender, EventArgs e) {
    //reset the order items
    //the change to the shipping amount happens on page load
    //in SetOrderInfo()
    lblOrderItems.Text = currentOrder.ItemsToString(true);

    EnsurePanelsHidden();
  }
  #endregion

  #region Checkout
  protected void btnComplete_Click(object sender, EventArgs e) {
    EnsurePanelsHidden();

    //set the final order info
    SetOrderInfo();

    //saving down the addresses is a convenience, if it bombs
    //swallow the exception and let it go.
    try {
      SaveAddresses();
    }
    catch {

    }

    //if there is a token in the querystring
    //this is a return from PayPal, and is therefore
    //an express checkout
    string transactionID = "";
    if (Request.QueryString["token"] != null) {
      transactionID = RunExpressCheckout();

    }
    else {
      transactionID = RunCharge();
    }

    //if an error occurred, the transactionId will be null or empty. 
    if (!String.IsNullOrEmpty(transactionID)) {
      radShipChoices.Enabled = false;
      pnlCoupons.Visible = false;
      pnlComplete.Visible = false;
      pnlFinalHeadNav.Visible = false;
      pnlReceipt.Visible = true;
    }
  }

  string RunExpressCheckout() {

    //InitOrder();

    //this is the PayPal response holder
    string orderID = "";

    string sToken = Utility.GetParameter("token");

    //run the Final Express Checkout
    try {
      Transaction trans = OrderController.TransactOrder(currentOrder, TransactionType.PayPalPayment);
      orderID = currentOrder.OrderGUID;
    }
    catch (Exception x) 
    {
      LovRubLogger.LogException(x); // 04/10/08 KPL added
      ResultMessage1.ShowFail(x.Message);
    }

    return orderID;
  }

  string RunCharge() {
    string sOut = "";

    try {

      Transaction trans = OrderController.TransactOrder(currentOrder, TransactionType.CreditCardPayment);
      //the orderID is set during the TransactOrder process
      sOut = currentOrder.OrderGUID;

    }
    catch (Exception x) 
    {
      LovRubLogger.LogException(x); // 04/10/08 KPL added
      ResultMessage1.ShowFail(x.Message);
    }

    return sOut;
  }

  #endregion

  protected string GetPaymentInfo() {
    //this can be one of two things
    //Express Checkout payment
    //or credit card.
    string result = "";
    if (Utility.GetParameter("token") != string.Empty) {
      result = "PayPal Express Checkout Payment";
    }
    else {
      result = "Credit Card Payment: " + Enum.GetName(typeof(CreditCardType), PaymentBox1.CCType) + "<br>" +
          Utility.MaskCreditCard(PaymentBox1.CCNumber);
    }
    return result;
  }

  #region Express Checkout Bits

  void ProcessExpressReturn(string sToken) {

    //get the wrapper
    APIWrapper wrapper = GetPPWrapper();

    //they have come back from the PayPal site and have a token, so use this token to go get their info
    //and populate the shipping etc.
    Commerce.Common.Address payer = wrapper.GetExpressCheckout(sToken);

    //set it as well in the billing/shippig controls
    //TODO: CMC - Profile.LastBillingAddress == null was not valid - figure this out.
    if (string.IsNullOrEmpty(Profile.LastBillingAddress.Address1)) {
      addBilling.SelectedAddress = payer;
    }
    else {
      addBilling.SelectedAddress = Profile.LastBillingAddress;
    }
    if (!payer.Equals(Profile.LastShippingAddress)) {
      Profile.LastShippingAddress = payer;
    }
    if (string.IsNullOrEmpty(Profile.LastShippingAddress.Address1)) {
      addShipping.SelectedAddress = payer;
    }
    else {
      addShipping.SelectedAddress = Profile.LastShippingAddress;
    }

    //save this address for this user
    OrderController.SaveAddress(payer);

    //set the token in the ViewState 
    ViewState.Add("ppToken", payer.PayPalToken);
    ViewState.Add("ppID", payer.PayPalPayerID);

    //need to run the tax calc now that we have an address
    Profile.CurrentOrderTax = OrderController.CalculateTax(payer.Zip, currentOrder.CalculateSubTotal());


    //save down the order to the ViewState so that it can be picked up when Running the Charge
    SetOrderInfo();


  }
  APIWrapper GetPPWrapper() {
    //string certPath = Server.MapPath("~/App_Data/" + SiteConfig.PayPalAPICertificate);
    APIWrapper wrapper =
      new APIWrapper(SiteConfig.PayPalAPIUserName, SiteConfig.PayPalAPIPassword,
      SiteConfig.PayPalAPISignature, SiteConfig.CurrencyCode, SiteConfig.PayPalAPIIsLive);
    return wrapper;
  }
  protected void imgPayPal_Click(object sender, ImageClickEventArgs e) {
    SetExpressOrder();
  }
  void SetExpressOrder() {
    //use the API to get the SetCheckout response.
    //Then, redirect to PayPal
    int currencyDecimals = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits;
    //get the wrapper
    APIWrapper wrapper = GetPPWrapper();

    string sEmail = "";
    if (Profile.LastShippingAddress != null) {
      if (Profile.LastShippingAddress.Email != string.Empty) {
        sEmail = Profile.LastShippingAddress.Email;
      }
      else {
        sEmail = "nobody@nowhere.com";
      }
    }

    //send them back here for all occassions
    string successURL = Utility.GetSiteRoot() + "/checkout.aspx";
    string failURL = Utility.GetSiteRoot() + "/default.aspx";


    if (currentOrder.Items.Count > 0) {

      string ppToken = wrapper.SetExpressCheckout(sEmail, currentOrder.CalculateSubTotal(),
        successURL, failURL, true, addShipping.SelectedAddress);
      if (ppToken.ToLower().Contains("error")) {
        //lblPPErr.Text="PayPal has returned an error message: "+ppToken;
      }
      else {
        string sUrl = "https://www.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + ppToken;

        if (!SiteConfig.PayPalAPIIsLive) {
          sUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + ppToken;
        }

        try {
          Response.Redirect(sUrl, false);
        }
        catch (Exception x) 
        {
          LovRubLogger.LogException(x); // 04/10/08 KPL added
          ResultMessage1.ShowFail(x.Message);
        }
      }

    }
    else {
      Response.Redirect("CCBasket.aspx", false);
    }

  }

  #endregion

  #region Coupons
  protected void applyCoupon_Click(object sender, EventArgs e) {
    //Get the coupon.  
    try {
      Commerce.Promotions.Coupon selectedCoupon = Commerce.Promotions.Coupon.GetCoupon(couponCode.Text);
      //we have the coupon .. validate the order.  
      Commerce.Promotions.CouponValidationResponse valid =
          selectedCoupon.ValidateCouponForOrder(currentOrder);
      if (valid.IsValid) {
        //apply the coupon to the order 
        selectedCoupon.ApplyCouponToOrder(currentOrder);
        couponMessage.Text = "Coupon code " + selectedCoupon.CouponCode + " was applied to your order!";
        currentOrder.CouponCodes = selectedCoupon.CouponCode;

        //add a note to the order that the coupon was applied
        OrderController.AddNote("Applied coupon " + selectedCoupon.CouponCode + " to order during checkout", currentOrder);

        //re-display the order
        lblOrderItems.Text = currentOrder.ItemsToString(true);

      }
      else {
        couponMessage.Text = "The selected coupon could not be applied to your order.  " + valid.ValidationMessage;
      }
    }
    catch (ArgumentException ex) {
      couponMessage.Text = "The code you entered could not be found or verified.";


    }
    couponMessage.Visible = true;
    EnsurePanelsHidden();
  }

  #endregion

  #region Wizard Event Handlers


  protected void btnBack_Click(object sender, EventArgs e) {
    //move to the second step

    wizCheckout.MoveTo(wizCheckout.WizardSteps[1]);
  }
  protected void Step_Changed(object sender, EventArgs e) {

    pnlComplete.Visible = false;
    pnlNav.Visible = true;
    //pnlExpressCheckout.Visible = false;
    pnlPPStandard.Visible = false;


    if (wizCheckout.ActiveStepIndex == 0) {
      //********************* SHIPPING PAGE ***************************
      btnPrev.Visible = false;
      btnNext.Text = "Billing >>";

      //if (SiteConfig.UsePayPalExpressCheckout)
      //pnlExpressCheckout.Visible = true;
      if (SiteConfig.UsePayPalPaymentsStandard)
        pnlPPStandard.Visible = true;


    }
    if (wizCheckout.ActiveStepIndex == 1) {
      //********************* BILLING PAGE ***************************
      btnPrev.Visible = true;
      btnPrev.Text = "<< Shipping";
      btnNext.Text = "Finalize >>";

      //default the billing address to the shipping address
      //if they haven't filled it out yet
      if (addBilling.SelectedAddress.FirstName.Trim() == string.Empty)
        addBilling.SelectedAddress = addShipping.SelectedAddress;

      //save down the billing address to the Profile
      Profile.LastShippingAddress = addShipping.SelectedAddress;

      //we have the shipping address so we can now calculate tax

        // KPL 1/2/08.  Determine what tax to charge, if any.
        // if state == NY than calculate tax
        // else  don't charge tax.
      decimal dTax = 0.0m;
      if ("NY" == Profile.LastShippingAddress.StateOrRegion)
      {
          // KPL 02/28/08 commented out cuz turned off StrikeIron. NYS tax.
          //dTax = OrderController.CalculateTax(Profile.LastShippingAddress.Zip, currentOrder.CalculateSubTotal());
          dTax = 0.08375m * currentOrder.CalculateSubTotal();
      }
      
      Profile.CurrentOrderTax = dTax;

    }
    else if (wizCheckout.ActiveStepIndex == 2) {
      //********************* FINAL PAGE ***************************
      PackageInfo package = LoadPackage();
      if (currentOrder.ShippingAddress != null && currentOrder.BillingAddress != null) {
        BindShipping(package);
      }
      SetOrderInfo();
      pnlNav.Visible = false;
      lblShipTo.Text = GetShippingAddress();
      lblBillTo.Text = GetBillingAddress();
      lblPaySummary.Text = GetPaymentInfo();
      lblOrderItems.Text = currentOrder.ItemsToString(true);
      //save down the shipping address
      Profile.LastBillingAddress = addBilling.SelectedAddress;
      // KPL lovrub doesn't take paypal
      //if (currentOrder.CreditCardType == CreditCardType.PayPal) {
      //  SetExpressOrder();
      //}
      pnlComplete.Visible = true;
      //

    }



  }
  protected void lbShipping_Click(object sender, EventArgs e) {
    wizCheckout.ActiveStepIndex = 0;
  }

  protected void lbBilling_Click(object sender, EventArgs e) {
    wizCheckout.ActiveStepIndex = 1;

  }
  protected void btnNext_Click(object sender, EventArgs e) {
    //this button advances the wizard
    wizCheckout.ActiveStepIndex = wizCheckout.ActiveStepIndex + 1;


  }
  protected void btnPrev_Click(object sender, EventArgs e) {
    wizCheckout.ActiveStepIndex = wizCheckout.ActiveStepIndex - 1;

  }
  #endregion

}
