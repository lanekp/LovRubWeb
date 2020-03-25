<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="PaymentConfiguration.aspx.cs"
  Inherits="Admin_PaymentConfiguration" Title="Payment Configuration" %>

<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" runat="Server">
  <asp:ScriptManager runat="server" EnablePartialRendering="true" ID="scriptManager">
  </asp:ScriptManager>
  <asp:UpdateProgress ID="uProgress" runat="server">
    <ProgressTemplate>
      <div class="loadingbox">
        <img src="../images/spinner.gif" align="absmiddle" />&nbsp;&nbsp;Processing...
      </div>
    </ProgressTemplate>
  </asp:UpdateProgress>
  <div id="centercontent">
    <h2>
      Payment Configuration</h2>
    <p>
      Here is the place where you can determine how you want your checkout process to
      work. There are a number of scenarios to think about, and we'll do our best to help
      you as needed! First and foremost is security - what makes the most sense for you
      and your business? Many times this means letting someone else handle the transaction.
      Next is impression - if you feel that it reflects poorly to send the customer to
      another site to finish the transaction, then there are some decisions you'll need
      to make in order to setup a payment plan (and often this involves more money on
      your part).</p>
    <p>
      The recommended setup is to allow your users to checkout in as many ways as possible.
      Give them the choice, and tell them why you are doing so. Many customers like to
      know they can checkout using Google and PayPal, and they also like to know that
      they can use their credit card safely.</p>
    <p>
      <strong>General Settings </strong>
    </p>
    <asp:UpdatePanel ID="WizUpdatePanel" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <table>
          <tr>
            <td>
              Your Site's Currency</td>
            <td class="adminitem">
              <asp:DropDownList ID="ddlCurrencyType" runat="server">
              </asp:DropDownList></td>
          </tr>
          <tr>
            <td>
              Login Requirements</td>
            <td class="adminitem">
              <asp:DropDownList ID="ddlLogin" runat="server">
                <asp:ListItem Selected="True" Value="checkout">At Checkout</asp:ListItem>
                <asp:ListItem Value="basket">When Adding to Cart</asp:ListItem>
                <asp:ListItem Value="never">Never - Anonymous Shopping</asp:ListItem>
              </asp:DropDownList></td>
          </tr>
          <tr>
            <td>
              <asp:Button ID="btnSetGeneral" runat="server" Text="Set" OnClick="btnSetGeneral_Click"
                CssClass="frmbutton" /></td>
            <td>
              <uc1:ResultMessage ID="ResultMessage1" runat="server" />
            </td>
          </tr>
        </table>
        <br />
        <div class="sectionoutline">
          <div class="sectionheader">
            Optional Checkout: Use PayPal</div>
          <br />
          <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_wp-standard-overview-outside"
            target="_blank"></a>
          <img src="../images/paypal_logo.gif" />
          <div>
            PayPal offers two ways to allow users to purchase your goods through their site.
            They are:<br />
            <ul>
              <li>PayPal Website Payments Standard </li>
              <li>PayPal Website Payments Pro with Express Checkout</li>
            </ul>
            <br />
            Each transaction service charges a small amount per transaction - usually about
            1%.
            <br />
            <br />
            <div class="sectionoutline">
              <div class="sectionheader">
                PayPal Website Payments Standard - Setup</div>
              <br />
              <strong>PayPal Website Payments Standard</strong> is the low-cost alternative. Your
              shopper is sent to PayPal where they complete the transaction; PayPal then sends
              your website (in this case, dashCommerce) information back about the transaction.
              dashCommerce logs this info when the buyer returns from PayPal and records the transaction.<br />
              <br />
              Standard is the easiest to setup, but is the most vulnerable to failure since the
              sale is not purely transactional. In other words, money changes hands at another
              site, and your site is told about it after the fact. This can cause issues with
              inventory if the sale is not immediate, as well as if your site goes down.<br />
              <br />
              <strong>To setup Payments Standard, you must:</strong><br />
              <ol>
                <li><a href="http://www.paypal.com">Create a PayPal Account (it's free)<br />
                </a></li>
                <li>Validate your email and Verify your account using a Bank Account or Credit Card<br />
                </li>
                <li><a href="https://www.paypal.com/cgi-bin/webscr?cmd=p/xcl/rec/pdt-techview-outside"
                  target="_blank">Setup your PDT<br />
                </a></li>
                <li>Enter the Settings Below</li>
              </ol>
              <table border="0">
                <tr>
                  <td colspan="2" class="selected">
                    PayPal Website Payments Standard Settings</td>
                </tr>
                <tr>
                  <td>
                    Use Payments Standard</td>
                  <td class="adminitem">
                    <asp:CheckBox ID="chkUsePPStandard" runat="server" /></td>
                </tr>
                <tr>
                  <td>
                    Use Sandbox</td>
                  <td class="adminitem">
                    <asp:CheckBox ID="chkUsePPStandardSandbox" runat="server" /></td>
                </tr>
                <tr>
                  <td>
                    Business Email
                  </td>
                  <td class="adminitem">
                    <asp:TextBox ID="txtBusinessEmail" runat="server" Width="171px"></asp:TextBox><br />
                    This is the email address of your PayPal business account</td>
                </tr>
                <tr>
                  <td>
                    PDT ID</td>
                  <td class="adminitem">
                    <asp:TextBox ID="txtPDTID" runat="server" Width="413px"></asp:TextBox><br />
                    The PDT is PayPal's "Payment Data Transfer" system. When you sign up with PayPal,
                    you need to setup the PDT in order for PayPal to notify dashCommerce when a payment
                    has been made. When you do this, PayPal gives you an ID number - place this here.</td>
                </tr>
                <tr>
                  <td style="width: 147px">
                    <asp:Button ID="btnSetPPStandard" runat="server" Text="Set" OnClick="btnSetPPStandard_Click"
                      CssClass="frmbutton" /></td>
                  <td style="width: 391px">
                    <uc1:ResultMessage ID="ResultMessage2" runat="server" />
                  </td>
                </tr>
              </table>
            </div>
            <br />
            <div class="sectionoutline">
              <div class="sectionheader">
                PayPal Website Payments Pro with Express Checkout - Setup</div>
              <br />
              <strong>PayPal Website Payments Pro with Express Checkout</strong> is much the same,
              but the buyer is sent to PayPal only to authorize the sale. They are returned to
              your site to make the actual purchase. This is a step up from Standard since the
              transaction happens on your site.<br />
              PayPal Website Payments Pro with Express Checkout is only available for US and UK
              websites at this time.
              <br />
              <br />
              <a href="http://www.mettlesystems.com" target="_blank">Mettle Systems LLC</a> has
              partnered with PayPal to give you a complete e-commerce and all-in-one payment solution
              using PayPal Website Payments Pro with Express Checkout.
              <br />
              <ul>
                <li>Accept credit card payments without requiring the buyer to have a PayPal account.</li>
                <li>Get PayPal's industry-leading security fraud-prevention systems.</li>
                <li>Take advantage of PayPal's comprehensive online reports that help you measure
                  sales and manage your business easily.</li>
              </ul>
              <p>
                <strong>Step 1: Set Up a Verified PayPal Business Account</strong></p>
              <p>
                If you don't have an existing PayPal account:</p>
              <ol>
                <li><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><span
                  class="payPalLink">Go to Paypal</span></a></li>
                <li>Click Sign Up Today.</li>
                <li>Set up an account for Business Owners.</li>
                <li>Follow the instructions on the PayPal site.</li>
              </ol>
              <p>
                If you already have a Personal or Premier account:</p>
              <ol>
                <li><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><span
                  class="payPalLink">Go to Paypal</span></a></li>
                <li>Click the Upgrade your Account link.</li>
                <li>Click the Upgrade Now button.</li>
                <li>Choose to upgrade to a Business account and follow instructions to complete the
                  upgrade.</li>
                <li>If you haven't already, add a bank account to become a Verified member. Follow
                  the instructions on the PayPal site. (This process may take 2-3 business days.)</li>
              </ol>
              <p>
                <strong>Step 2: Apply for Website Payments Pro</strong></p>
              <p>
                Get the features of an internet merchant account and payment gateway with Website
                Payments Pro. Control your checkout from start to finish by integrating PayPal Website
                Payments Pro with dashCommerce.</p>
              <ol>
                <li><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><span
                  class="payPalLink">Go to Paypal</span></a></li>
                <li>Login to your PayPal Business Account</li>
                <li>Click the Merchant Services tab.</li>
                <li>Click Website Payments Pro (U.S. Only).</li>
                <li>Click Sign Up Now.</li>
                <li>Fill in your information, and submit your application. Approval takes between
                  24 and 48 hours.</li>
                <li>Once approved, accept the Pro billing agreement. Check the Getting Started section
                  on the upper left of your account overview page.</li>
              </ol>
              <p>
                <strong>Step 3: Get your API Account Name, API Account Password, and the API Signature.</strong></p>
              <p>
                <strong>Step 4: Enter your settings below.</strong></p>
              <table>
                <tr>
                  <td colspan="2" class="selected">
                    PayPal Website Payments Pro with Express Checkout Settings</td>
                </tr>
                <tr>
                  <td>
                    Use Payments Pro (Express Checkout)</td>
                  <td class="adminitem" style="width: 315px">
                    <asp:CheckBox ID="chkUsePPPro" runat="server" /></td>
                </tr>
                <tr>
                  <td>
                    Use Sandbox</td>
                  <td class="adminitem" style="width: 315px">
                    <asp:CheckBox ID="chkUsePPSandbox" runat="server" /></td>
                </tr>
                <tr>
                  <td>
                    API Account Name</td>
                  <td class="adminitem" style="width: 315px">
                    <asp:TextBox ID="txtPPAPIAccount" runat="server" Width="200px"></asp:TextBox><br />
                    should be something like "email_api.domain.com"</td>
                </tr>
                <tr>
                  <td>
                    API Account Password</td>
                  <td class="adminitem" style="width: 315px">
                    <asp:TextBox ID="txtPPAPIPassword" runat="server" Width="199px"></asp:TextBox><br />
                    whatever password you specified when applying for PaymentsPro</td>
                </tr>
                <tr>
                  <td>
                    API Signature</td>
                  <td>
                    <asp:TextBox ID="txtPPAPISignature" runat="server" Width="500px" /></td>
                </tr>
                <tr>
                  <td>
                    <asp:Button ID="btnSetPPPro" runat="server" Text="Set" OnClick="btnSetPPPro_Click"
                      CssClass="frmbutton" /></td>
                  <td style="width: 315px">
                    <uc1:ResultMessage ID="ResultMessage3" runat="server" />
                  </td>
                </tr>
              </table>
            </div>
            <br />
            <div class="sectionoutline">
              <div class="sectionheader">
                Payment Provider: Setup Credit Card Checkout Through The Site</div>
              <br />
              <img src="../images/ccs.gif" />
              <br />
              <div>
                Most online merchants want to be able to accept credit cards through their website.
                This is made fairly easy these days by companies such as Authorize.NET, PayPal,
                and Verisign offering cheap and easy integration. To accept credit cards through
                the site, you can use one of our pre-installed Gateway providers, or your developer
                can create another provider pretty easily. To accept credit cards through dashCommerce,
                you must:<br />
                <br />
                <ol>
                  <li>Create an account with the gateway of your choice<br />
                  </li>
                  <li>If not part of our provider list here, create your own payment provider<br />
                  </li>
                  <li>Enter the information below</li>
                </ol>
                <strong>Credit Card Settings<br />
                </strong>
                <br />
              </div>
              <table>
                <tr>
                  <td>
                    Accept Credit Cards</td>
                  <td class="adminitem">
                    <asp:CheckBox ID="chkAcceptCC" runat="server" /></td>
                </tr>
                <tr>
                  <td>
                    Gateway Provider</td>
                  <td class="adminitem">
                    <asp:DropDownList ID="ddlCCProvider" runat="server">
                      <asp:ListItem Value="AuthorizeNetPaymentProvider">Authorize.NET</asp:ListItem>
                      <asp:ListItem Selected="True" Value="PayPalPaymentProvider">PayPal DirectPay</asp:ListItem>
                    </asp:DropDownList><br />
                    Note: If you select PayPal DirectPay, you don't need to add the information below;
                    you will however need to set the PayPal Website Payments Pro with Express Checkout
                    Settings above as DirectPay is part of PayPal Website Payments Pro with Express
                    Checkout</td>
                </tr>
                <tr>
                  <td>
                    Username</td>
                  <td class="adminitem">
                    <asp:TextBox ID="txtCCUserName" runat="server"></asp:TextBox><br />
                    The username to access the gateway</td>
                </tr>
                <tr>
                  <td>
                    Password</td>
                  <td class="adminitem">
                    <asp:TextBox ID="txtCCPassword" runat="server"></asp:TextBox><br />
                    The password to access the gateway</td>
                </tr>
                <tr>
                  <td>
                    Key</td>
                  <td class="adminitem">
                    <asp:TextBox ID="txtCCKey" runat="server"></asp:TextBox><br />
                    Sometimes you are given an access key for a given gateway</td>
                </tr>
                <tr>
                  <td>
                    Server URL</td>
                  <td class="adminitem">
                    <asp:TextBox ID="txtCCUrl" runat="server" Width="411px"></asp:TextBox><br />
                    The access URL</td>
                </tr>
                <tr>
                  <td>
                    <asp:Button ID="btnSetCC" runat="server" Text="Set" OnClick="btnSetCC_Click" CssClass="frmbutton" /></td>
                  <td>
                    <uc1:ResultMessage ID="ResultMessage5" runat="server" />
                  </td>
                </tr>
              </table>
            </div>
            <br />
            <br />
          </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    <div>
    </div>
    </ContentTemplate> </asp:UpdatePanel>
    <div>
    </div>
</asp:Content>
