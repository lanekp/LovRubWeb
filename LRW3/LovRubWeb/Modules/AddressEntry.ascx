<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressEntry.ascx.cs" Inherits="AddressEntry" %>
  <!-- <table bgcolor="3A3A3C" width="733" cellspacing="1" cellpadding="2"> -->
  <table width="585" cellspacing="1" cellpadding="2">
        <tr>
            <td colspan="2">
            <!-- KPL commented out. Don't want to show address book 
            <%if(OrderController.GetAddressBookCount()>1){ %>
                <img src="images/icons/addressbook.gif" alt="" align="absmiddle"/>
                <asp:LinkButton ID="lnkToggle" runat="server" OnClick="lnkToggle_Click" CausesValidation="False">Show Address Book</asp:LinkButton>
                <asp:Panel ID="pnlAddBook" runat="server">
                <asp:DataList ID="dtAddresses" runat="server" CellPadding="4" CellSpacing="2" 
                RepeatColumns="2" Width="550" OnItemCommand="SelectAddress" >
                <ItemTemplate>
                    <asp:Label ID="lblAddressID" runat="server" Text='<%#Eval("addressID")%>' Visible="false"></asp:Label>
                    <%#Eval("FullAddress")%>
                    <br />
                    <asp:Button ID="btnUse" runat="server" Text="Use This Address"  CausesValidation="false"/>
                </ItemTemplate>
                
                </asp:DataList>
                 
                <br /><br /> 
                </asp:Panel>  
             <%} %>         
             -->
            </td>
        </tr>
        <tr>
            <td  class="smalltext" >First:</td>
            <td>
                <asp:TextBox Runat="server" ID="txtFirst"></asp:TextBox>
                <asp:RequiredFieldValidator Runat="server" ControlToValidate="txtFirst" ErrorMessage="Required"
                    ID="RequiredFieldValidator1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  class="smalltext">
                Last:</td>
            <td>
                <asp:TextBox Runat="server" ID="txtLast"></asp:TextBox>
                <asp:RequiredFieldValidator Runat="server" ControlToValidate="txtLast" ErrorMessage="Required"
                    ID="Requiredfieldvalidator5"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <!-- KPL comment out phone # here 02/09/08 -->
        <tr>
            <td  class="smalltext" >
                Email</td>
            <td height="28">
                <asp:TextBox Runat="server" ID="txtEmail"></asp:TextBox>
                <asp:RequiredFieldValidator Runat="server" ControlToValidate="txtEmail" ErrorMessage="Required"
                    ID="Requiredfieldvalidator4"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  class="smalltext">
                Address</td>
            <td>
                <asp:TextBox Runat="server" ID="txtAddress1"></asp:TextBox>
                <asp:RequiredFieldValidator Runat="server" ControlToValidate="txtAddress1" ErrorMessage="Required"
                    ID="RequiredFieldValidator2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  class="smalltext">
                Address 2</td>
            <td>
                <asp:TextBox Runat="server" ID="txtAddress2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="smalltext"> <!-- smalltext -->
                City</td>
            <td>
                <asp:TextBox Runat="server" ID="txtCity"></asp:TextBox>
                <asp:RequiredFieldValidator Runat="server" ControlToValidate="txtCity" ErrorMessage="Required"
                    ID="RequiredFieldValidator3"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
	        <td width="148" class="smalltext">State/Region</td>
	        <td>
		        <asp:TextBox id="txtState" runat="server"></asp:TextBox>
		        <asp:DropDownList id="ddlState" runat="server">
			        <asp:ListItem value="AL">Alabama</asp:ListItem>
			        <asp:ListItem value="AK">Alaska</asp:ListItem>
			        <asp:ListItem value="AZ">Arizona</asp:ListItem>
			        <asp:ListItem value="AR">Arkansas</asp:ListItem>
			        <asp:ListItem value="CA">California</asp:ListItem>
			        <asp:ListItem value="CO">Colorado</asp:ListItem>
			        <asp:ListItem value="CT">Connecticut</asp:ListItem>
			        <asp:ListItem value="DE">Delaware</asp:ListItem>
			        <asp:ListItem value="DC">District of Columbia</asp:ListItem>
			        <asp:ListItem value="FL">Florida</asp:ListItem>
			        <asp:ListItem value="GA">Georgia</asp:ListItem>
			        <asp:ListItem value="HI">Hawaii</asp:ListItem>
			        <asp:ListItem value="ID">Idaho</asp:ListItem>
			        <asp:ListItem value="IL">Illinois</asp:ListItem>
			        <asp:ListItem value="IN">Indiana</asp:ListItem>
			        <asp:ListItem value="IA">Iowa</asp:ListItem>
			        <asp:ListItem value="KS">Kansas</asp:ListItem>
			        <asp:ListItem value="KY">Kentucky</asp:ListItem>
			        <asp:ListItem value="LA">Louisiana</asp:ListItem>
			        <asp:ListItem value="ME">Maine</asp:ListItem>
			        <asp:ListItem value="MD">Maryland</asp:ListItem>
			        <asp:ListItem value="MA">Massachusetts</asp:ListItem>
			        <asp:ListItem value="MI">Michigan</asp:ListItem>
			        <asp:ListItem value="MN">Minnesota</asp:ListItem>
			        <asp:ListItem value="MS">Mississippi</asp:ListItem>
			        <asp:ListItem value="MO">Missouri</asp:ListItem>
			        <asp:ListItem value="MT">Montana</asp:ListItem>
			        <asp:ListItem value="NE">Nebraska</asp:ListItem>
			        <asp:ListItem value="NV">Nevada</asp:ListItem>
			        <asp:ListItem value="NH">New Hampshire</asp:ListItem>
			        <asp:ListItem value="NJ">New Jersey</asp:ListItem>
			        <asp:ListItem value="NM">New Mexico</asp:ListItem>
			        <asp:ListItem value="NY">New York</asp:ListItem>
			        <asp:ListItem value="NC">North Carolina</asp:ListItem>
			        <asp:ListItem value="ND">North Dakota</asp:ListItem>
			        <asp:ListItem value="OH">Ohio</asp:ListItem>
			        <asp:ListItem value="OK">Oklahoma</asp:ListItem>
			        <asp:ListItem value="OR">Oregon</asp:ListItem>
			        <asp:ListItem value="PA">Pennsylvania</asp:ListItem>
			        <asp:ListItem value="RI">Rhode Island</asp:ListItem>
			        <asp:ListItem value="SC">South Carolina</asp:ListItem>
			        <asp:ListItem value="SD">South Dakota</asp:ListItem>
			        <asp:ListItem value="TN">Tennessee</asp:ListItem>
			        <asp:ListItem value="TX">Texas</asp:ListItem>
			        <asp:ListItem value="UT">Utah</asp:ListItem>
			        <asp:ListItem value="VT">Vermont</asp:ListItem>
			        <asp:ListItem value="VA">Virginia</asp:ListItem>
			        <asp:ListItem value="WA">Washington</asp:ListItem>
			        <asp:ListItem value="WV">West Virginia</asp:ListItem>
			        <asp:ListItem value="WI">Wisconsin</asp:ListItem>
			        <asp:ListItem value="WY">Wyoming</asp:ListItem>
		        </asp:DropDownList>
		        <asp:RequiredFieldValidator id="valState" runat="server" EnableClientScript="False" ControlToValidate="ddlState"
			        ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>			        
        </tr>
        <tr>
	        <td width="148" class="smalltext">Country</td>
	        <td>
		        <asp:DropDownList id="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
			        <asp:ListItem Value="US">United States</asp:ListItem>
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
			        <asp:ListItem Value="GB">United Kingdom</asp:ListItem>
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
		        </asp:DropDownList>&nbsp;
            </td>		        
        </tr>
        <tr>
            <td  class="smalltext">
                Zip</td>
            <td>
                <asp:TextBox Runat="server" ID="txtZip"></asp:TextBox>
                <asp:RequiredFieldValidator Runat="server" ControlToValidate="txtZip" Display="Dynamic"
                    ErrorMessage="Required" ID="RequiredFieldValidator6"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
        </tr>

    </table>

