<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="TaxConfiguration.aspx.cs" Inherits="_Config_TaxConfiguration" Title="Tax Configuration" %>

<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="leftcontent">

</div>
<div id="centercontent">
    <h4>Sales Tax Configuration</h4>
    <div class="sectionheader">US State Sales Tax</div><br />
    <div class="sectionoutline">
    <div>
    For US-based businesses, selling online has one general rule: You must charge sales tax (for taxable goods) to consumers who reside in a state within which you have a "nexxus". A nexxus is a physical presence requiring a state tax ID. If you live in California and sell goods online as a Sole Proprietor (meaning just yourself) then you should charge your fellow Californians sales tax. The amount typically needs to be in keeping with your state's sales tax rate. 
    <br />
    <br />
    The key is to figure out just how much to charge the buyer. Each state has different
    rules when it comes to eCommerce, but generally the safest approach is to charge
    the buyer tax according to where the actual transaction takes place (transaction
    meaning when/where the buyer takes posession of the goods).<br />
    <br />
    <strong>For Example:</strong><br />
    A buyer who lives in Turlock, CA comes to your site and buys $50.00 USD of Magic
    Cards. Your nexxus is in Modesto, where you work tirelessly out of your garage putting
    together box after box of Magic Cards. Your buyer will take posession of her new
    decks when the shipment arrives - in Turlock. In this scenario, you are compelled
    to charge her tax according to the jurisdiction rules of Turlock, CA (which is 7.38%
    btw).<br />
    <br />
    Usually the best case scenario is to use an online service to handle this for you.
    Companies such as StrikeIron, CyberSource, and Simpova make this simple via the
    use of Web Services. StrikeIron has been kind enough to work with us on this tax
    configuration page (and they are also very cheap), so the information you see below
    is all based on the StrikeIronTaxProvider.<br />
    <br />
    Another way to handle tax is to download a Tax Rate Database. You can buy these
    online from TaxDataSystems and other companies. The upside to this is that your
    site is not dependent on the tax web service being online. The downside is that
    you will need to reload these rates every six months (and pay for them again) as
    tax rates routinely change.<br />
    <br />
    <br />
   <div class="sectionheader">US State Jurisdiction Sales Tax</div>
    US Sales Tax rates are generally divided further by jurisdictions (city, county, region, etc.), each with its own sales tax rate. If you have a business with multiple locations in one state (e.g.. one in Northern California and another Southern California), you may be bound to comply not only with State tax requirements, but local jurisdiction adjustments as well. In Texas, the University of Texas at Austin has a 2% rate, whereas the surrounding area has a 6% rate. There is no set way to calculate this - it must be done by mailing address. If your site is for a large company with nexxi all over the US, this is what you&#39ll need to do.
    <br />
    <br />
    <div class="sectionheader">International Sales Tax</div> 
    CKS does not currently offer a model for calculating non-us sales tax (EU VAT tax, etc.). Non-US rates seem to be quite complicated and frankly we just don&#39t know enough. We invite you to provide us feedback about various international tax laws and we will add support they are they requested.

    <br />
    <br />
    <br />
    <h4>Select Your Tax Scenario</h4>
    As you can see, calculating online Sales Tax can be very complicated, and different
        businesses have different sales tax requirements. For your convenience, dashCommerce offers
        three options when calculating online sales tax: 
    <br />
    <ol>
        <li>Do not calculate sales tax (note:
        link each of these to their section below) </li>
        <li>Charge US State Sales Tax (but not
        jurisdiction sales tax) 
            <br />
        </li>
        <li>Charge US State &amp; Jurisdiction sales tax</li></ol>
    <br />
    <br />
        IN NO WAY,
        however, should you consider these options the authority on sales tax. It is your
        responsibility to get tax advice for your specific situation by speaking to a CPA,
        Tax Attorney, or your company's controller.
        <br />
        <br />


    <br />
    <div style="height:30px;margin-bottom:10px;background-color:#ffffcc;border:1px solid #990000;vertical-align:middle">
        Your Current Setting is: 
        <b><%=GetCurrentService() %></b>
    </div>
    </div>
    <uc1:ResultMessage ID="ResultMessage1" runat="server" />
     <table cellpadding="5">
       <tr>
            <td style="text-align:center;background-color:aliceblue;">
              <asp:Button ID="btnZero" runat="server" Text="Set" OnClick="btnZero_Click" CausesValidation="False" CssClass="frmbutton"/></td>
            <td>
            <div class="sectionheader">Option 1) Don't Charge Sales Tax&nbsp; - ZeroTaxProvider</div>
								<span class="adminlabel">
                There are some occassions when you won't need to charge sales tax. In New Hampshire
                and Oregon (for example) the tax rate is 0%. Other scenarios include non-taxable
                items and business to business exemption. Make sure you consult a tax attorney to
                confirm your situation.</span>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;background-color:aliceblue;">
               <asp:Button ID="btnFlat" runat="server" Text="Set" OnClick="btnFlat_Click" CausesValidation="False" CssClass="frmbutton" /></td>
            <td>
                <div class="sectionheader">Option 2) Charge State Sales Tax (but no jurisdiction sales tax) - FlatRateTaxProvider</div>
                <span class="adminlabel">
                A flat-rate sales tax solution is NOT ideal,&nbsp; however in some cases it is appropriate.
                We strongly recommend that you consult a tax attorney who can tell you specifically
                what your tax liability is for your state and location. Generally speaking, a flat
                rate will not completely cover hard goods sold.</span>
                <br />
                <br />
                <br />  
                   <h4>Tax Rates</h4>
                   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataKeyNames="rateID" DataSourceID="SqlDataSource1" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" >
                        <Columns>
                            <asp:BoundField DataField="rate" HeaderText="Rate" SortExpression="rate" />
                            <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                            <asp:BoundField DataField="zipCode" HeaderText="Zip" SortExpression="zipCode" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <h4>
                        Add a Tax Rate</h4>
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="rateID" DataSourceID="SqlDataSource1"
                        DefaultMode="Insert">

            <InsertItemTemplate>
                <b>Rate:</b><br />
                <asp:TextBox ID="rateTextBox" runat="server" Text='<%# Bind("rate") %>'>
                </asp:TextBox><br />
                <b>State:</b><br />
                  <asp:DropDownList ID="stateDropDownList" runat="server" Width="169px" SelectedValue='<%# Bind("state") %>' CssClass="adminitem">
                                <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                <asp:ListItem Value="CA">California</asp:ListItem>
                                <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                                <asp:ListItem Value="FL">Florida</asp:ListItem>
                                <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                <asp:ListItem Value="ME">Maine</asp:ListItem>
                                <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                <asp:ListItem Value="MT">Montana</asp:ListItem>
                                <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                <asp:ListItem Value="NY">New York</asp:ListItem>
                                <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                <asp:ListItem Value="TX">Texas</asp:ListItem>
                                <asp:ListItem Value="UT">Utah</asp:ListItem>
                                <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                <asp:ListItem Value="WA">Washington</asp:ListItem>
                                <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                            </asp:DropDownList><br />
                <b>Zip:</b><br />
                <asp:TextBox ID="zipCodeTextBox" runat="server" Text='<%# Bind("zipCode") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>

            </InsertItemTemplate>

                    </asp:FormView>
                &nbsp;&nbsp;
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CommerceTemplate %>"
                        SelectCommand="SELECT [rateID], [rate], [state], [zipCode] FROM [CSK_Tax_Rate]" 
                        DeleteCommand="DELETE FROM [CSK_Tax_Rate] WHERE [rateID] = @rateID" 
                        InsertCommand="INSERT INTO [CSK_Tax_Rate] ([rate], [state], [zipCode]) VALUES (@rate, @state, @zipCode)" 
                        UpdateCommand="UPDATE [CSK_Tax_Rate] SET [rate] = @rate, [state] = @state, [zipCode] = @zipCode WHERE [rateID] = @rateID">
                        <DeleteParameters>
                            <asp:Parameter Name="rateID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="rate" Type="Decimal" />
                            <asp:Parameter Name="state" Type="String" />
                            <asp:Parameter Name="zipCode" Type="String" />
                            <asp:Parameter Name="original_rateID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="rate" Type="Decimal" />
                            <asp:Parameter Name="state" Type="String" />
                            <asp:Parameter Name="zipCode" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                <br /><br />   
            </td>
        </tr>
        <tr>
             <td style="text-align:center;background-color:aliceblue;">
                 <asp:Button ID="btnStrikeIron" runat="server" Text="Set" OnClick="btnStrikeIron_Click" CausesValidation="False" CssClass="frmbutton"/></td>
            <td>
                <ajax:ajaxpanel ID="Ajaxpanel1" runat="server">
               <div class="sectionheader">Option 3) Charge State & Jurisdiction Sales Tax (more accurate) - StrikeIronTaxProvider</div>
               <span class="adminlabel">
                In addition to state sales tax, many regions (cities, counties, etc.) require you to charge additional sales tax.  As described above, this makes calculating sales tax very complicated. dashCommerce simplifies the calculation by basing sales tax on the buyer&#39s zip code. This is very accurate, but not 100% accurate.
                There are many zip codes for each state, so you will need to type them into the form below and keep the rates up to date. To simplify this process, dashCommerce has integrated with StrikeIron which gives you two options:<br />
                <ol>
                    <li>Batch Download of sales tax rates by zip code for specified states<br />
                    </li>
                    <li>Real-time lookup of sales tax rates by zip code for specified states (no batch download)
                    </li>
                </ol>
                For your convenience, both Batch and Real-Time options have been integrated with a Sales Tax Service available through StrikeIron. To use this service, you need to create a StrikeIron account and purchase its online tax service. Select the option below and follow the instructions provided.<br />
                <br />
                <br />
                <b>To enable Real-Time Lookup, you'll need to:<br />
                </b>
                <br />
                Step 1. <a href="http://www.strikeiron.com/Search.aspx?SearchString=tax&types=1" target="_blank">Create a StrikeIron account</a>
                <br />
                Step 2. Purchase the appropriate service
                <br />
                Step 3. Fill in your StrikeIron account details below
                     <br />
                     <br />
                <table>
                    <tr>
                        <td>
                            <strong>Key</strong></td>
                        <td>
                            <asp:TextBox ID="txtSIKey" runat="server" Width="313px"></asp:TextBox><br />
                            StrikeIron will issue you an access key when you sign up for this service</td>
                    </tr>
                
                </table>
               <strong>
                   <br />
                   Test Online Tax Service<br />
                </strong>
                Zip Code (US Only)
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></span>
                <asp:Button ID="btnRealTime" runat="server" Text="Go" OnClick="btnRealTime_Click" CssClass="frmbutton"/><br />
                <br />
                <asp:Panel ID="pnlRealTime" runat="server" Visible="false"></asp:Panel>
               </ajax:ajaxpanel>
            
            </td>
        </tr>

    </table>
</div>
<br /><br />
<div id="rightcontent">

</div>
</asp:Content>

