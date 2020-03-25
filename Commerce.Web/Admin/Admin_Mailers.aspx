<%@ Page validaterequest="false" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Mailers.aspx.cs" Inherits="Admin_Admin_Mailers" Title="Mailers Administration" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">
        <h4>Mailers</h4>
        <div >
        These mailers are automatically mailed out at certain times (order processing, etc). You can edit the text of
        the mailers, their subject, etc here. You can use HTML if you like.
        </div>
		<asp:panel id="pnlGrid" runat="server">

		<asp:datagrid id="dg" runat="server" Width="90%" CellPadding="3" GridLines="None"
			BorderColor="White" BorderWidth="0px" BorderStyle="Solid" BackColor="White" AutoGenerateColumns="False"
			AllowSorting="True" ForeColor="Black" Font-Names="Verdana" Font-Size="8pt"  OnEditCommand="GridEdit">
			<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="Gainsboro"></SelectedItemStyle>
			<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
			<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
			<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="LightSteelBlue"></HeaderStyle>
			<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="MailerID" HeaderText="MailerID"  Visible=false></asp:BoundColumn>
						<asp:BoundColumn DataField="MailerName" HeaderText="MailerName" ></asp:BoundColumn>
						<asp:BoundColumn DataField="IsSystemMailer" HeaderText="System Mailer" />
						<asp:BoundColumn DataField="ToList" HeaderText="ToList" ></asp:BoundColumn>
						<asp:BoundColumn DataField="CcList" HeaderText="CcList" ></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
				</asp:datagrid>
				<br />
				<asp:button id="cmdAdd"  runat="server" OnClick="btnAdd_Click" CausesValidation="False" Text="Add" CssClass="frmbutton"></asp:button>
			</asp:panel>
			<asp:panel id="pnlEdit" Runat="server">
			
			<table class="admintable" cellpadding="5" cellspacing="0">
				<tr id="trID" runat="server">
					<td class="adminlabel">ID</td>
					<td class="adminitem"><asp:label id="lblID" runat="server" /></td>
				</tr>
				<tr id="tr1" runat="server">
					<td class="adminlabel">System Mailer</td>
					<td class="adminitem"><asp:CheckBox ID="chkIsSystemMailer" runat="server" Enabled="false" /></td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Mailer Name</td>
					<td class="adminitem">
						<asp:textbox id="txtMailerName" runat="server" Width="373px" ></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        To List</td>
					<td class="adminitem">
						<asp:textbox id="txtToList" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:textbox><br />
                        Separate the emails with a semi-colon ";"&nbsp;Leave this blank if it's going
                        to a customer.</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Cc List</td>
					<td class="adminitem">
						<asp:textbox id="txtCcList" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:textbox><br />
                        Separate the emails with a semi-colon ";"&nbsp;
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        From Name</td>
					<td class="adminitem">
						<asp:textbox id="txtFromName" runat="server" Width="309px" ></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        From Email</td>
					<td class="adminitem">
						<asp:textbox id="txtFromEmail" runat="server" Width="309px" ></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">Subject</td>
					<td class="adminitem">
						<asp:textbox id="txtSubject" runat="server" Width="309px" ></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Message Body
                        <br />
                        <br />
                        The following macro definitions are available for use when creating Mailer Templates. When sent, the macro definition will be replaced with the appropriate value:<br /><br />
                        #NAME#<br />
                        #ORDERNUMBER#<br />
                        #ORDERDATE#<br />
                        #DATE#<br />
                        #TRACKINGNUMBER#<br />
                        #ORDER#<br />
                        #TAGLINE#<br />
                        #SITELINK#<br />
                        #STOREEMAIL#<br />
                        #ADMINPRODUCTLINK#<br />
                        
                        </td>
					<td class="adminitem">
                        &nbsp;<FTB:FreeTextBox id="txtMessageBody" runat="server" SupportFolder="~/ftb/"></FTB:FreeTextBox></td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Is HTML</td>
					<td class="adminitem">
						<asp:CheckBox id="chkIsHTML" runat="server" />
					</td>
				</tr>
				
					
				<tr>
					<td>
					<asp:Button id="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton"></asp:Button>&nbsp;
					<input type=button onclick="location.href='<%=Request.Url.PathAndQuery%>'" value="Return" class="frmbutton">
					<uc1:ResultMessage ID="uResult" runat="server" EnableViewState="false" />	
					</td>
					
					<td align="right"><asp:Button id="btnDelete" runat="server" CausesValidation="False" Text="Delete" OnClick="btnDelete_Click" CssClass="frmbutton"></asp:Button></td>
				</tr>
			</table>
			</asp:panel>
</div>
			<script>
			function CheckDelete(){
					
				return confirm("Delete this record? This action cannot be undone...");

			}

			</script>
			

</asp:Content>

