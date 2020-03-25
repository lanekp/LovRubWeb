<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ShippingConfiguration.aspx.cs" Inherits="Admin_ShippingConfiguration" Title="Shipping Configuration" %>

<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<asp:ScriptManager runat="server" EnablePartialRendering="true" ID="scriptManager">
</asp:ScriptManager >
    <asp:UpdateProgress ID="uProgress" runat="server">
        <ProgressTemplate>
        <div class="loadingbox">
            <img src="../images/spinner.gif" align="absmiddle"/>&nbsp;&nbsp;Processing...
        </div>
        </ProgressTemplate>
     </asp:UpdateProgress> 
<asp:UpdatePanel ID="WizUpdatePanel" runat="server" UpdateMode="Conditional" >
<ContentTemplate>    

<div id="leftcontent"></div>
<div id="centercontent">
<h4>Fulfillment Configuration</h4>
    <div>
        You can use this page to designate how your buyer will receive the goods that you sell them. It is important
        to note that dashCommerce uses the concept of "Providers" - meaning that you can have 0 or more "Services" that 
        plug into the site which will allow you to determine rates, delivery dates, set pickup, etc.
        
        Currently dashCommerce supports the following Providers (with more on the way!):
        <br />
        <ul>
            <li>
        UPS
                <br />
            </li>
            <li>
        US Post Office
                <br />
            </li>
            <li>
        Digital Downloads
                <br />
            </li>
            <li>
        Flat Rate Shipping (Custom) </li>
        </ul>
        <p>
            We do not currently have a plan to integrate FedEx.</p>
        <p>
            To use these services you must sign up with them and create an account. When you've
            done that, head on back and set them up.</p>
    </div>
    <div class="tenpixspacer"></div>
    <div class="sectionheader">General Settings</div>
    <table>
        <tr>
            <td class="adminlabel">
                Use Shipping</td>
            <td class="adminitem">
                <asp:CheckBox ID="chkUseShipping" runat="server" /><br />
                Some sites do not require shipping at all (such as software download or membership
                sites). If this is unchecked, a shipping section will not be displayed during checkout.</td>
        </tr>
        <tr>
            <td class="adminlabel">
                Ship-from Zip</td>
            <td class="adminitem">
                <asp:TextBox ID="txtShipFromZip" runat="server"></asp:TextBox><br />
                We use this to tell services such as FedEx, UPS, etc where we're shipping from.</td>
        </tr>
        <tr>
            <td class="adminlabel">
                Ship From Country Code</td>
            <td class="adminitem">
                <asp:DropDownList id="ddlShipFromCountry" runat="server" >
    <asp:ListItem Value="AF">Afghanistan</asp:ListItem>
    <asp:ListItem Value="AL">Albania</asp:ListItem>
    <asp:ListItem Value="DZ">Algeria</asp:ListItem>
    <asp:ListItem Value="AS">American Samoa</asp:ListItem>
    <asp:ListItem Value="AD">Andorra</asp:ListItem>
    <asp:ListItem Value="AO">Angola</asp:ListItem>
    <asp:ListItem Value="AI">Anguilla</asp:ListItem>
    <asp:ListItem Value="AQ">Antarctica</asp:ListItem>
    <asp:ListItem Value="AG">Antigua and Barbuda</asp:ListItem>
    <asp:ListItem Value="AR">Argentina</asp:ListItem>
    <asp:ListItem Value="AM">Armenia</asp:ListItem>
    <asp:ListItem Value="AW">Aruba</asp:ListItem>
    <asp:ListItem Value="AU">Australia</asp:ListItem>
    <asp:ListItem Value="AT">Austria</asp:ListItem>
    <asp:ListItem Value="AZ">Azerbaijan</asp:ListItem>
    <asp:ListItem Value="BS">Bahamas</asp:ListItem>
    <asp:ListItem Value="BH">Bahrain</asp:ListItem>
    <asp:ListItem Value="BD">Bangladesh</asp:ListItem>
    <asp:ListItem Value="BB">Barbados</asp:ListItem>
    <asp:ListItem Value="BY">Belarus</asp:ListItem>
    <asp:ListItem Value="BE">Belgium</asp:ListItem>
    <asp:ListItem Value="BZ">Belize</asp:ListItem>
    <asp:ListItem Value="BJ">Benin</asp:ListItem>
    <asp:ListItem Value="BM">Bermuda</asp:ListItem>
    <asp:ListItem Value="BT">Bhutan</asp:ListItem>
    <asp:ListItem Value="BO">Bolivia</asp:ListItem>
    <asp:ListItem Value="BA">Bosnia and Herzegovina</asp:ListItem>
    <asp:ListItem Value="BW">Botswana</asp:ListItem>
    <asp:ListItem Value="BV">Bouvet Island</asp:ListItem>
    <asp:ListItem Value="BR">Brazil</asp:ListItem>
    <asp:ListItem Value="IO">British Indian Ocean Territory</asp:ListItem>
    <asp:ListItem Value="VG">British Virgin Islands</asp:ListItem>
    <asp:ListItem Value="BN">Brunei Darussalam</asp:ListItem>
    <asp:ListItem Value="BG">Bulgaria</asp:ListItem>
    <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
    <asp:ListItem Value="BI">Burundi</asp:ListItem>
    <asp:ListItem Value="KH">Cambodia</asp:ListItem>
    <asp:ListItem Value="CM">Cameroon</asp:ListItem>
    <asp:ListItem Value="CA">Canada</asp:ListItem>
    <asp:ListItem Value="CV">Cape Verde</asp:ListItem>
    <asp:ListItem Value="KY">Cayman Islands</asp:ListItem>
    <asp:ListItem Value="CF">Central African Republic</asp:ListItem>
    <asp:ListItem Value="TD">Chad</asp:ListItem>
    <asp:ListItem Value="CL">Chile</asp:ListItem>
    <asp:ListItem Value="CN">China</asp:ListItem>
    <asp:ListItem Value="CX">Christmas Island</asp:ListItem>
    <asp:ListItem Value="CC">Cocos</asp:ListItem>
    <asp:ListItem Value="CO">Colombia</asp:ListItem>
    <asp:ListItem Value="KM">Comoros</asp:ListItem>
    <asp:ListItem Value="CG">Congo</asp:ListItem>
    <asp:ListItem Value="CK">Cook Islands</asp:ListItem>
    <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
    <asp:ListItem Value="HR">Croatia</asp:ListItem>
    <asp:ListItem Value="CU">Cuba</asp:ListItem>
    <asp:ListItem Value="CY">Cyprus</asp:ListItem>
    <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>
    <asp:ListItem Value="DK">Denmark</asp:ListItem>
    <asp:ListItem Value="DJ">Djibouti</asp:ListItem>
    <asp:ListItem Value="DM">Dominica</asp:ListItem>
    <asp:ListItem Value="DO">Dominican Republic</asp:ListItem>
    <asp:ListItem Value="TP">East Timor</asp:ListItem>
    <asp:ListItem Value="EC">Ecuador</asp:ListItem>
    <asp:ListItem Value="EG">Egypt</asp:ListItem>
    <asp:ListItem Value="SV">El Salvador</asp:ListItem>
    <asp:ListItem Value="GQ">Equatorial Guinea</asp:ListItem>
    <asp:ListItem Value="ER">Eritrea</asp:ListItem>
    <asp:ListItem Value="EE">Estonia</asp:ListItem>
    <asp:ListItem Value="ET">Ethiopia</asp:ListItem>
    <asp:ListItem Value="FK">Falkland Islands</asp:ListItem>
    <asp:ListItem Value="FO">Faroe Islands</asp:ListItem>
    <asp:ListItem Value="FJ">Fiji</asp:ListItem>
    <asp:ListItem Value="FI">Finland</asp:ListItem>
    <asp:ListItem Value="FR">France</asp:ListItem>
    <asp:ListItem Value="GF">French Guiana</asp:ListItem>
    <asp:ListItem Value="PF">French Polynesia</asp:ListItem>
    <asp:ListItem Value="TF">French Southern Territories</asp:ListItem>
    <asp:ListItem Value="GA">Gabon</asp:ListItem>
    <asp:ListItem Value="GM">Gambia</asp:ListItem>
    <asp:ListItem Value="GE">Georgia</asp:ListItem>
    <asp:ListItem Value="DE">Germany</asp:ListItem>
    <asp:ListItem Value="GH">Ghana</asp:ListItem>
    <asp:ListItem Value="GI">Gibraltar</asp:ListItem>
    <asp:ListItem Value="GR">Greece</asp:ListItem>
    <asp:ListItem Value="GL">Greenland</asp:ListItem>
    <asp:ListItem Value="GD">Grenada</asp:ListItem>
    <asp:ListItem Value="GP">Guadeloupe</asp:ListItem>
    <asp:ListItem Value="GU">Guam</asp:ListItem>
    <asp:ListItem Value="GT">Guatemala</asp:ListItem>
    <asp:ListItem Value="GN">Guinea</asp:ListItem>
    <asp:ListItem Value="GW">Guinea-Bissau</asp:ListItem>
    <asp:ListItem Value="GY">Guyana</asp:ListItem>
    <asp:ListItem Value="HT">Haiti</asp:ListItem>
    <asp:ListItem Value="HM">Heard and McDonald Islands</asp:ListItem>
    <asp:ListItem Value="HN">Honduras</asp:ListItem>
    <asp:ListItem Value="HK">Hong Kong</asp:ListItem>
    <asp:ListItem Value="HU">Hungary</asp:ListItem>
    <asp:ListItem Value="IS">Iceland</asp:ListItem>
    <asp:ListItem Value="IN">India</asp:ListItem>
    <asp:ListItem Value="ID">Indonesia</asp:ListItem>
    <asp:ListItem Value="IR">Iran</asp:ListItem>
    <asp:ListItem Value="IQ">Iraq</asp:ListItem>
    <asp:ListItem Value="IE">Ireland</asp:ListItem>
    <asp:ListItem Value="IL">Israel</asp:ListItem>
    <asp:ListItem Value="IT">Italy</asp:ListItem>
    <asp:ListItem Value="CI">Ivory Coast</asp:ListItem>
    <asp:ListItem Value="JM">Jamaica</asp:ListItem>
    <asp:ListItem Value="JP">Japan</asp:ListItem>
    <asp:ListItem Value="JO">Jordan</asp:ListItem>
    <asp:ListItem Value="KZ">Kazakhstan</asp:ListItem>
    <asp:ListItem Value="KE">Kenya</asp:ListItem>
    <asp:ListItem Value="KI">Kiribati</asp:ListItem>
    <asp:ListItem Value="KW">Kuwait</asp:ListItem>
    <asp:ListItem Value="KG">Kyrgyzstan</asp:ListItem>
    <asp:ListItem Value="LA">Laos</asp:ListItem>
    <asp:ListItem Value="LV">Latvia</asp:ListItem>
    <asp:ListItem Value="LB">Lebanon</asp:ListItem>
    <asp:ListItem Value="LS">Lesotho</asp:ListItem>
    <asp:ListItem Value="LR">Liberia</asp:ListItem>
    <asp:ListItem Value="LY">Libya</asp:ListItem>
    <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
    <asp:ListItem Value="LT">Lithuania</asp:ListItem>
    <asp:ListItem Value="LU">Luxembourg</asp:ListItem>
    <asp:ListItem Value="MO">Macau</asp:ListItem>
    <asp:ListItem Value="MK">Macedonia</asp:ListItem>
    <asp:ListItem Value="MG">Madagascar</asp:ListItem>
    <asp:ListItem Value="MW">Malawi</asp:ListItem>
    <asp:ListItem Value="MY">Malaysia</asp:ListItem>
    <asp:ListItem Value="MV">Maldives</asp:ListItem>
    <asp:ListItem Value="ML">Mali</asp:ListItem>
    <asp:ListItem Value="MT">Malta</asp:ListItem>
    <asp:ListItem Value="MH">Marshall Islands</asp:ListItem>
    <asp:ListItem Value="MQ">Martinique</asp:ListItem>
    <asp:ListItem Value="MR">Mauritania</asp:ListItem>
    <asp:ListItem Value="MU">Mauritius</asp:ListItem>
    <asp:ListItem Value="YT">Mayotte</asp:ListItem>
    <asp:ListItem Value="MX">Mexico</asp:ListItem>
    <asp:ListItem Value="FM">Micronesia</asp:ListItem>
    <asp:ListItem Value="MD">Moldova</asp:ListItem>
    <asp:ListItem Value="MC">Monaco</asp:ListItem>
    <asp:ListItem Value="MN">Mongolia</asp:ListItem>
    <asp:ListItem Value="MS">Montserrat</asp:ListItem>
    <asp:ListItem Value="MA">Morocco</asp:ListItem>
    <asp:ListItem Value="MZ">Mozambique</asp:ListItem>
    <asp:ListItem Value="MM">Myanmar</asp:ListItem>
    <asp:ListItem Value="NA">Namibia</asp:ListItem>
    <asp:ListItem Value="NR">Nauru</asp:ListItem>
    <asp:ListItem Value="NP">Nepal</asp:ListItem>
    <asp:ListItem Value="NL">Netherlands</asp:ListItem>
    <asp:ListItem Value="AN">Netherlands Antilles</asp:ListItem>
    <asp:ListItem Value="NC">New Caledonia</asp:ListItem>
    <asp:ListItem Value="NZ">New Zealand</asp:ListItem>
    <asp:ListItem Value="NI">Nicaragua</asp:ListItem>
    <asp:ListItem Value="NE">Niger</asp:ListItem>
    <asp:ListItem Value="NG">Nigeria</asp:ListItem>
    <asp:ListItem Value="NU">Niue</asp:ListItem>
    <asp:ListItem Value="NF">Norfolk Island</asp:ListItem>
    <asp:ListItem Value="KP">North Korea</asp:ListItem>
    <asp:ListItem Value="MP">Northern Mariana Islands</asp:ListItem>
    <asp:ListItem Value="NO">Norway</asp:ListItem>
    <asp:ListItem Value="OM">Oman</asp:ListItem>
    <asp:ListItem Value="PK">Pakistan</asp:ListItem>
    <asp:ListItem Value="PW">Palau</asp:ListItem>
    <asp:ListItem Value="PA">Panama</asp:ListItem>
    <asp:ListItem Value="PG">Papua New Guinea</asp:ListItem>
    <asp:ListItem Value="PY">Paraguay</asp:ListItem>
    <asp:ListItem Value="PE">Peru</asp:ListItem>
    <asp:ListItem Value="PH">Philippines</asp:ListItem>
    <asp:ListItem Value="PN">Pitcairn</asp:ListItem>
    <asp:ListItem Value="PL">Poland</asp:ListItem>
    <asp:ListItem Value="PT">Portugal</asp:ListItem>
    <asp:ListItem Value="PR">Puerto Rico</asp:ListItem>
    <asp:ListItem Value="QA">Qatar</asp:ListItem>
    <asp:ListItem Value="RE">Reunion</asp:ListItem>
    <asp:ListItem Value="RO">Romania</asp:ListItem>
    <asp:ListItem Value="RU">Russian Federation</asp:ListItem>
    <asp:ListItem Value="RW">Rwanda</asp:ListItem>
    <asp:ListItem Value="GS">S. Georgia and S. Sandwich Islands</asp:ListItem>
    <asp:ListItem Value="KN">Saint Kitts and Nevis</asp:ListItem>
    <asp:ListItem Value="LC">Saint Lucia</asp:ListItem>
    <asp:ListItem Value="VC">Saint Vincent and The Grenadines</asp:ListItem>
    <asp:ListItem Value="WS">Samoa</asp:ListItem>
    <asp:ListItem Value="SM">San Marino</asp:ListItem>
    <asp:ListItem Value="ST">Sao Tome and Principe</asp:ListItem>
    <asp:ListItem Value="SA">Saudi Arabia</asp:ListItem>
    <asp:ListItem Value="SN">Senegal</asp:ListItem>
    <asp:ListItem Value="SC">Seychelles</asp:ListItem>
    <asp:ListItem Value="SL">Sierra Leone</asp:ListItem>
    <asp:ListItem Value="SG">Singapore</asp:ListItem>
    <asp:ListItem Value="SK">Slovakia</asp:ListItem>
    <asp:ListItem Value="SI">Slovenia</asp:ListItem>
    <asp:ListItem Value="SB">Solomon Islands</asp:ListItem>
    <asp:ListItem Value="SO">Somalia</asp:ListItem>
    <asp:ListItem Value="ZA">South Africa</asp:ListItem>
    <asp:ListItem Value="KR">South Korea</asp:ListItem>
    <asp:ListItem Value="SU">Soviet Union</asp:ListItem>
    <asp:ListItem Value="ES">Spain</asp:ListItem>
    <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
    <asp:ListItem Value="SH">St. Helena</asp:ListItem>
    <asp:ListItem Value="PM">St. Pierre and Miquelon</asp:ListItem>
    <asp:ListItem Value="SD">Sudan</asp:ListItem>
    <asp:ListItem Value="SR">Suriname</asp:ListItem>
    <asp:ListItem Value="SJ">Svalbard and Jan Mayen Islands</asp:ListItem>
    <asp:ListItem Value="SZ">Swaziland</asp:ListItem>
    <asp:ListItem Value="SE">Sweden</asp:ListItem>
    <asp:ListItem Value="CH">Switzerland</asp:ListItem>
    <asp:ListItem Value="SY">Syria</asp:ListItem>
    <asp:ListItem Value="TW">Taiwan</asp:ListItem>
    <asp:ListItem Value="TJ">Tajikistan</asp:ListItem>
    <asp:ListItem Value="TZ">Tanzania</asp:ListItem>
    <asp:ListItem Value="TH">Thailand</asp:ListItem>
    <asp:ListItem Value="TG">Togo</asp:ListItem>
    <asp:ListItem Value="TK">Tokelau</asp:ListItem>
    <asp:ListItem Value="TO">Tonga</asp:ListItem>
    <asp:ListItem Value="TT">Trinidad and Tobago</asp:ListItem>
    <asp:ListItem Value="TN">Tunisia</asp:ListItem>
    <asp:ListItem Value="TR">Turkey</asp:ListItem>
    <asp:ListItem Value="TM">Turkmenistan</asp:ListItem>
    <asp:ListItem Value="TC">Turks and Caicos Islands</asp:ListItem>
    <asp:ListItem Value="TV">Tuvalu</asp:ListItem>
    <asp:ListItem Value="UG">Uganda</asp:ListItem>
    <asp:ListItem Value="UA">Ukraine</asp:ListItem>
    <asp:ListItem Value="AE">United Arab Emirates</asp:ListItem>
    <asp:ListItem Value="UK">United Kingdom</asp:ListItem>
    <asp:ListItem Value="US" Selected="True">United States</asp:ListItem>
    <asp:ListItem Value="UY">Uruguay</asp:ListItem>
    <asp:ListItem Value="UM">US Minor Outlying Islands</asp:ListItem>
    <asp:ListItem Value="VI">US Virgin Islands</asp:ListItem>
    <asp:ListItem Value="UZ">Uzbekistan</asp:ListItem>
    <asp:ListItem Value="VU">Vanuatu</asp:ListItem>
    <asp:ListItem Value="VE">Venezuela</asp:ListItem>
    <asp:ListItem Value="VN">Viet Nam</asp:ListItem>
    <asp:ListItem Value="WF">Wallis and Futuna Islands</asp:ListItem>
    <asp:ListItem Value="EH">Western Sahara</asp:ListItem>
    <asp:ListItem Value="YE">Yemen</asp:ListItem>
    <asp:ListItem Value="YU">Yugoslavia</asp:ListItem>
    <asp:ListItem Value="ZR">Zaire</asp:ListItem>
    <asp:ListItem Value="ZM">Zambia</asp:ListItem>
    <asp:ListItem Value="ZW">Zimbabwe</asp:ListItem>
</asp:DropDownList>
                
                
                <br />
                We also need the country code, since we're not smart enough to determine it from
                the zip :).</td>
        </tr>
        <tr>
            <td class="adminlabel">
                Dimension Units</td>
            <td class="adminitem">
                <asp:TextBox ID="txtDimensionUnits" runat="server" Text="inches"></asp:TextBox><br />
                inches, centimeters, etc.</td>
        </tr>
    </table>
    <h4>Services</h4>
    <div class="sectionheader">Simple Shipping</div><br />
    <div class="sectionoutline">
    <div >
        Sometimes shipping can very simple - just multiply the weight of the packages times some sort of 
        rate and you're good to go. As a default, this is the way dashCommerce is setup. This is obviously not
        optimized for real-world scenarios.</div><br />
        <asp:CheckBox ID="chkUseSimple" runat="server" Text="Use Simple Shipping" CssClass="adminitem"/>
        <div class="tenpixspacer" />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" DataKeyNames="shippingRateID"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Service" HeaderText="Service" SortExpression="Service" />
                <asp:BoundField DataField="AmountPerUnit" HeaderText="Rate/Unit" SortExpression="AmountPerUnit" />
            </Columns>
        </asp:GridView>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="shippingRateID" DataSourceID="SqlDataSource1"
            DefaultMode="Insert">
            <InsertItemTemplate>
                Service<br />
                <asp:TextBox ID="ServiceTextBox" runat="server" Text='<%# Bind("Service") %>'>
            </asp:TextBox><br />
                Amount Per Unit<br />
                <asp:TextBox ID="DollarsPerPoundTextBox" runat="server" Text='<%# Bind("AmountPerUnit") %>'>
            </asp:TextBox><br />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
            </asp:LinkButton>
            </InsertItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CommerceTemplate %>"
            DeleteCommand="DELETE FROM [CSK_Shipping_Rate] WHERE [shippingRateID] = @shippingRateID"
            InsertCommand="INSERT INTO [CSK_Shipping_Rate] ([Service], [AmountPerUnit]) VALUES (@Service, @AmountPerUnit)"
            SelectCommand="SELECT [shippingRateID], [Service], [AmountPerUnit] FROM [CSK_Shipping_Rate]"
            UpdateCommand="UPDATE [CSK_Shipping_Rate] SET [Service] = @Service, [AmountPerUnit] = @AmountPerUnit WHERE [shippingRateID] = @shippingRateID">
            <DeleteParameters>
                <asp:Parameter Name="shippingRateID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Service" Type="String" />
                <asp:Parameter Name="AmountPerUnit" Type="Decimal" />
                <asp:Parameter Name="original_shippingRateID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Service" Type="String" />
                <asp:Parameter Name="AmountPerUnit" Type="Decimal" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
    </div>
    <div class="tenpixspacer"></div>
    <div class="sectionheader">Real-time Services</div><br />
    <div class="sectionoutline">
    <div >dashCommerce comes pre-setup to talk to UPS and the US Post Office in real time using web services.
       To enable this, you must setup an account with them first, so you can access their APIs. Select which 
       of these services you'd like to use below.</div>
        <div class="tenpixspacer"></div>
        <h4>UPS</h4>
        <table>
            <tr>
                <td class="adminlabel">
                    Use UPS</td>
                <td class="adminitem">
                    <asp:CheckBox ID="chkUseUPS" runat="server" /></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Username</td>
                <td class="adminitem">
                    <asp:TextBox ID="upsUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Password</td>
                <td class="adminitem">
                    <asp:TextBox ID="upsPassword" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Access Key</td>
                <td class="adminitem">
                    <asp:TextBox ID="upsAccessKey" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Connection URL</td>
                <td class="adminitem">
                    <asp:TextBox ID="upsURL" runat="server" Width="390px">https://www.ups.com/ups.app/xml/Rate</asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Handling Charge</td>
                <td class="adminitem">
                    <asp:TextBox ID="upsHandlingCharge" runat="server">1.0</asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Pickup Type Code</td>
                <td class="adminitem">
                    <asp:DropDownList ID="upsPickupTypeCode" runat="server">
                        <asp:ListItem Selected="True" Value="01">01 - Daily Pickup</asp:ListItem>
                        <asp:ListItem Value="03">03 - Customer Counter</asp:ListItem>
                        <asp:ListItem Value="06">06 - One Time Pickup</asp:ListItem>
                        <asp:ListItem Value="07">07 - On Call Air</asp:ListItem>
                        <asp:ListItem Value="11">11 - Suggested Retail Rates</asp:ListItem>
                        <asp:ListItem Value="19">19 - Letter Center</asp:ListItem>
                        <asp:ListItem Value="20">20 - Air Service Center</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Customer Classification</td>
                <td class="adminitem">
                    <asp:DropDownList ID="upsCustomerClass" runat="server">
                        <asp:ListItem Selected="True" Value="04">04 - Retail</asp:ListItem>
                        <asp:ListItem Value="01">01 - Wholesale</asp:ListItem>
                        <asp:ListItem Value="03">03 - Ocassional</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Packaging Type Code</td>
                <td class="adminitem">
                    <asp:DropDownList ID="upsPackTypeCode" runat="server">
                        <asp:ListItem Selected="True" Value="02">02 - Package</asp:ListItem>
                        <asp:ListItem Value="01">01 - UPS letter/ UPS Express Envelope</asp:ListItem>
                        <asp:ListItem Value="03">03 - UPS Tube</asp:ListItem>
                        <asp:ListItem Value="04">04 - UPS Pak</asp:ListItem>
                        <asp:ListItem Value="21">21 - UPS Express Box</asp:ListItem>
                        <asp:ListItem Value="24">24 - UPS 25Kg Box</asp:ListItem>
                        <asp:ListItem Value="25">25 - UPS 10Kg Box</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
        
        <div class="tenpixspacer"></div>
        <h4>US Postal Service</h4>
        <table>
            <tr>
                <td class="adminlabel">
                    Use US Post Office</td>
                <td class="adminitem">
                    <asp:CheckBox ID="chkUsePO" runat="server" /></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Username</td>
                <td class="adminitem">
                    <asp:TextBox ID="poUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Password</td>
                <td class="adminitem">
                    <asp:TextBox ID="poPassword" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Handling Charge</td>
                <td class="adminitem">
                    <asp:TextBox ID="poHandling" runat="server">1.0</asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel">
                    Connection URL</td>
                <td class="adminitem">
                    <asp:TextBox ID="poURL" runat="server" Width="392px">http://production.shippingapis.com/ShippingAPI.dll</asp:TextBox></td>
            </tr>
        </table> 
     </div>
     <div style="margin-left: 200px;margin-right:200px;">
     <h4>Save Settings</h4>
    <p>
        <asp:Button ID="btnSaveSettings" runat="server" Text="Save" OnClick="btnSaveSettings_Click" CssClass="frmbutton" />
        <uc1:ResultMessage ID="ResultMessage2" runat="server" />
    </p>
    </div>
    <div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

