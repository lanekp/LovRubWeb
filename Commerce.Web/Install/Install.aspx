<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Install.aspx.cs" Inherits="_Install"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>dashCommerce Web Installer</title>
  <style type="text/css">
      body {
        font-family: Verdana, Arial;
      }
      
      a {
        color: #E03300;
        text-decoration: none;
        font-weight: bold;
        font-size: 1em;
      }
      
      .payPalLink {
        color: #E03300;
        text-decoration: underline;
        font-weight: bold;
        font-size: 1em;
      }
      
      .mainContent {
      	margin: 10px auto;
        /*margin: 20px;*/
        width: 760px;
        padding: 5px;
      }
      
      .logo {
        display: block;
        padding-bottom: 10px;
      }
      
      .wizard {
        display: block;
        width: 100%;
      }
      
      .stepHeader {
        font-size: 1.1em;
        font-weight: bold;
        text-align: center;
        width: 100%;
      }

      .messageCenter {
        width: 100%;
        height: 30px;
        color: #004A78;
        font-size: .9em;
      }
      
      .imgIcon {
        float: left;
      }
    </style>
</head>
<body>
  <form id="form1" runat="server">
    <div class="mainContent">
      <div class="logo">
        <img src="<%=Page.ResolveUrl("~/images/dash_commerce_logo.gif")%>" alt="dashCommerce" />
      </div>
      <asp:Wizard ID="wizInstaller" runat="server" DisplaySideBar="false" OnNextButtonClick="next_Click"
        OnFinishButtonClick="finish_Click" OnActiveStepChanged="activeStepChanged" CssClass="wizard">
        <WizardSteps>
          <asp:WizardStep ID="wzsWelcome" runat="server">
            <div class="stepHeader">
              <asp:Label ID="lblStepHeader" runat="server" Text="Welcome" />
            </div>
            <p>
              This installation wizard will guide you through the installation of dashCommerce.</p>
            <p>
              This install process supports new installs.</p>
            <p>
              Before you begin, you need to grant the ASPNET or the NETWORK SERVICE accounts "<strong>Modify</strong>"
              and "<strong>Write</strong>" access to the Web.config file located at
              <%= Server.MapPath("../Web.config") %>
              .</p>
            <p>
              Why do you need to do grant these permissions? The installer will write the database
              connection string information to the Web.config. In addition, the administration
              portion of dashCommerce will also write additional configuration information to
              the Web.config at runtime.</p>
          </asp:WizardStep>
          <asp:WizardStep ID="wzs1" runat="server">
            <div class="stepHeader">
              <asp:Label ID="Label3" runat="server" Text="Step 1 of 6: Test Write Access to web.config" />
            </div>
            <p>
              Clicking "Next" will test a write operation to the Web.config to ensure it has the
              correct permissions . . .</p>
          </asp:WizardStep>
          <asp:WizardStep ID="wzs2" runat="server">
            <div class="stepHeader">
              <asp:Label ID="Label1" runat="server" Text="Step 2 of 6: Gather Database Server Credentials" />
            </div>
            <p>Now it is time to set up the dashCommerce database.</p>
            <p>This step will gather the neccessary database server credentials, which will then
              be used to install the database in the next step.</p>
            <p>If you would prefer to manually install the database, the SQL Script files are located at 
            <%= Server.MapPath("~/Install/InstallScripts") %>.</p> Please run them in the following order:
            <ol>
              <li>Tables.sql</li>
              <li>Functions.sql</li>
              <li>Views.sql</li>
              <li>SPs.sql</li>
              <li>BaseData.sql</li>
              <li>Membership.sql</li>
              <li>BaseMembershipData.sql</li>
              <li>SampleData.sql <strong>(OPTIONAL)</strong></li>
            </ol>
            <asp:Label ID="lblDbServer" runat="server" CssClass="stepHeader" Text="Database Server:" /><br />
            <asp:TextBox ID="txtDbServer" runat="server" CssClass="textbox" Text="localhost\SQLEXPRESS"
              Width="150px" /><br />
            <br />
            <asp:Label ID="lblTrustedConnection" runat="server" CssClass="stepHeader" Text="Use Trusted Connection:" /><br />
            <asp:CheckBox ID="chkTrustedConnection" runat="server" AutoPostBack="True" Checked="True"
              OnCheckedChanged="chkTrusted_CheckedChanged" /><br />
            <br />
            <asp:Panel ID="pnlSqlMode" runat="server" Visible="false">
              <p>Please note: This wizard will give you the opportunity to either select the 
              database from the a list or create a new database. If you choose to create a new 
              database, the account provided here must have <strong>dbCreator</strong> rights 
              on the SQL Server. If your account does not have these rights, you will have to create 
              the database first and then select from the list provided in the next step.</p>
              <asp:Label ID="lblDbUserName" runat="server" Text="Username:" /><br />
              <asp:TextBox ID="txtDbUserName" runat="server" CssClass="textbox" /><br />
              <br />
              <asp:Label ID="lblDbPassword" runat="server" Text="Password:" /><br />
              <asp:TextBox ID="txtDbPassword" runat="server" CssClass="textbox" /><br />
              <br />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDbUserName"
                ErrorMessage="Please supply a Username." Display="None" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDbPassword"
                ErrorMessage="Please supply a Password." Display="None" />
            </asp:Panel>
            <asp:RequiredFieldValidator ID="rfvDbServer" runat="server" ControlToValidate="txtDbServer"
              ErrorMessage="Please supply a Database Server." Display="None" />
          </asp:WizardStep>
          <asp:WizardStep ID="wzs3" runat="server">
            <div class="stepHeader">
              <asp:Label ID="Label2" runat="server" Text="Step 3 of 6: Select or Create the dashCommerce Database" />
            </div>
            <p>
              This step will install the necessary database objects and the base data needed to
              run dashCommerce. This includes the ASP.NET Membership database objects.</p>
            <asp:Label ID="lblDbList" runat="server" CssClass="label" Text="Databases:" /><br />
            <asp:DropDownList ID="ddlDbList" runat="server" CssClass="textbox" /><br /><br />
            <asp:CheckBox ID="chkDropObjects" runat="server" /><asp:Label ID="lblDropObjects" runat="server" Text=" Drop dashCommerce objects in target database." />
            <p><strong>Please Note: Droping dashCommerce objects will remove all data and database objects. 
            Use this feature only if you understand what it does. This feature may cause the operation to 
            take a few minutes to complete.</strong></p>
            - or -<br />
            <br />
            <asp:Label ID="lblCreateDb" runat="server" Text="Create Database:" /><br />
            <asp:TextBox ID="txtCreateDb" runat="server" CssClass="textbox" Width="150px" /><br /><br />
          </asp:WizardStep>
          <asp:WizardStep ID="wzs4" runat="server">
            <div class="stepHeader">
              <asp:Label ID="Label5" runat="server" Text="Step 4 of 6: Create the dashCommerce Administrator Account" />
            </div>
            <p>
              You will now create the Administrator account which will allow you administer dashCommerce.</p>
            <p>
              Please keep this account information in a safe location and do not give it out.</p>
            <table border="0">
              <tr>
                <td>
                  <asp:Label ID="lblUsername" runat="server" Text="Username:" /><br />
                  <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" Width="150px" TabIndex="1" /><br />
                  <br />
                </td>
                <td>
                  <asp:Label ID="lblEmail" runat="server" Text="Email:" /><br />
                  <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="150px"  TabIndex="4"/><br />
                  <br />
                </td>
              </tr>
              <tr>
                <td>
                  <asp:Label ID="lblPassword" runat="server" Text="Password:" /><br />
                  <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="150px" TabIndex="2" /><br />
                  <br />
                </td>
                <td>
                  <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email:"></asp:Label><br />
                  <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="textbox" Width="150px" TabIndex="5"/><br />
                  <br />
                </td>
              </tr>
              <tr>
                <td>
                  <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" /><br />
                  <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textbox" Width="150px" TabIndex="3" /><br />
                  <br />
                </td>
                <td>
                  <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question:"></asp:Label><br />
                  <asp:TextBox ID="txtSecurityQuestion" runat="server" CssClass="textbox" Width="150px"  TabIndex="6"/><br />
                  <br />
                </td>
              </tr>
              <tr>
                <td>
                </td>
                <td>
                  <asp:Label ID="lblSecurityAnswer" runat="server" Text="Security Answer:"></asp:Label><br />
                  <asp:TextBox ID="txtSecurityAnswer" runat="server" CssClass="textbox" Width="150px"  TabIndex="7"/><br />
                  <br />
                </td>
              </tr>
            </table>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
            ErrorMessage="Please supply a Username." Display="None" />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
            ErrorMessage="Please supply a Password." Display="None" />
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
            ErrorMessage="Please supply a Confirm Password." Display="None" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Please supply an Email." Display="None" />
            <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ControlToValidate="txtConfirmEmail"
            ErrorMessage="Please supply a Confirm Email." Display="None" />
            <asp:RequiredFieldValidator ID="rfvSecurityQuestion" runat="server" ControlToValidate="txtSecurityQuestion"
            ErrorMessage="Please supply a Security Question." Display="None" />
            <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"
            ErrorMessage="Please supply a Security Answer." Display="None" />
            <asp:CompareValidator ID="cmpPassword" runat="server" ControlToValidate="txtPassword"
            ControlToCompare="txtConfirmPassword" ErrorMessage="Passwords do not match." Display="None" />
            <asp:CompareValidator ID="cmpEmail" runat="server" ControlToValidate="txtEmail"
            ControlToCompare="txtConfirmEmail" ErrorMessage="Emails do not match." Display="None" />            
          </asp:WizardStep>
          <asp:WizardStep ID="wzs5" runat="server">
            <div class="stepHeader">
              <asp:Label ID="Label4" runat="server" Text="Step 5 of 6: Populate Sample Data" />
            </div>
            <p>Please decide if you would like to have the database loaded with sample data.</p>
            <p>If this is your first time using the product, you may wish to have the sample data 
            loaded so you can evaluate the functionality.</p>
            <asp:Label ID="lblLoadSampleData" runat="server" Text="Load Sample Data:" />
            <asp:RadioButton ID="rdoYes" runat="server" Text="Yes" Checked="true" GroupName="SampleData" />
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rdoNo" runat="server" Text="No" Checked="false" GroupName="SampleData" />
          </asp:WizardStep>
          <asp:WizardStep ID="wzs6" runat="server">
            <div class="stepHeader">
              <asp:Label ID="Label6" runat="server" Text="Step 6 of 6: Sign Up for a PayPal Business Account" />
            </div>
            <p>Mettle Systems LLC has partnered with PayPal to give you a complete e-commerce and 
            all-in-one payment solution using PayPal's Express Checkout and Website Payments Pro.</p>
            <ul>
              <li>Accept credit card payments without requiring the buyer to have a PayPal account.</li>
              <li>Get PayPal's industry-leading security fraud-prevention systems.</li>
              <li>Take advantage of PayPal's comprehensive online reports that help you measure sales and manage your business easily.</li>
            </ul>
            <p><strong>Step 1: Set Up a Verified PayPal Business Account</strong></p>
            <p>If you don't have an existing PayPal account:</p>
            <ol>
                <li><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><span class="payPalLink">Go to Paypal</span></a></li>
                <li>Click Sign Up Today.</li>
                <li>Set up an account for Business Owners.</li>
                <li>Follow the instructions on the PayPal site.</li>
            </ol>
            <p>If you already have a Personal or Premier account:</p>
            <ol>
                <li><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><span class="payPalLink">Go to Paypal</span></a></li>
                <li>Click the Upgrade your Account link.</li>
                <li>Click the Upgrade Now button.</li>
                <li>Choose to upgrade to a Business account and follow instructions to complete the upgrade.</li>
                <li>If you haven't already, add a bank account to become a Verified member. Follow the instructions on the PayPal site. (This process may take 2-3 business days.)</li>
            </ol>
            <p><strong>Step 2: Apply for Website Payments Pro</strong></p>
            <p>Get the features of an internet merchant account and payment gateway with Website Payments Pro. Control your checkout from start to finish by integrating PayPal Website Payments Pro with dashCommerce.</p>
            <ol>
              <li><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><span class="payPalLink">Go to Paypal</span></a></li>
              <li>Login to your PayPal Business Account</li>
              <li>Click the Merchant Services tab.</li>
              <li>Click Website Payments Pro (U.S. Only).</li>
              <li>Click Sign Up Now.</li>
              <li>Fill in your information, and submit your application. Approval takes between 24 and 48 hours.</li>
              <li>Once approved, accept the Pro billing agreement. Check the Getting Started section on the upper left of your account overview page.</li>
            </ol>
            <!-- Begin PayPal Logo -->
            <p align="center"><a target="_blank" href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W"><img alt="Sign up for PayPal and start accepting credit card payments instantly." border="0" src="http://images.paypal.com/en_US/i/bnr/paypal_mrb_banner.gif" /></a></p>
            <!-- End PayPal Logo -->            
          </asp:WizardStep>
        </WizardSteps>
      </asp:Wizard>
      <div class="messageCenter">
        <asp:Image ID="imgMessage" runat="server" ImageUrl="" CssClass="imgIcon" /><asp:Label
          ID="lblMessage" runat="server" Text="" />
        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" ShowSummary="true" />
      </div>
      <br />
      <div id="footer">
        <asp:HyperLink id="footerLink" runat="server" NavigateUrl="http://www.mettlesystems.com" ImageUrl="~/images/powered_by_dashcommerce.gif" Target="_blank" /><br /><br />
        <a href="http://www.dashcommerce.org" target="_blank">dashCommerce Version 2.2.0</a><br /><br />
        <asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="http://www.mettlesystems.com" Text="Copyright &copy; 2007 - Mettle Systems LLC" Target="_blank" />
      </div>
      
    </div>
  </form>
</body>
</html>
