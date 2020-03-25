<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="admin_productreviews.aspx.cs" Inherits="Admin_admin_productreviews" Title="Review Administration" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<%@ Register Namespace="Commerce.Web.UI.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
 <div id="centercontent">

    <h4>Review Edit: <%=Utility.GetParameter("pn")%></h4>
    <asp:Panel ID=pnlGrid runat=server>
    </asp:Panel>
	<asp:panel id="pnlEdit" Runat="server" Visible=false>
        <uc1:ResultMessage ID="uResult" runat="server" visible="false" />
		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
			<TR id="trError" runat="server" visible="false" enableviewstate="false">
				<TD id="tdError" bgColor="#ffcc33" colSpan="2" runat="server">
					<asp:Label id="lblError" runat="server"></asp:Label>
				</TD>
			</TR>
			<TR>
				<TD colSpan="2">
					<TABLE id="Table4" cellSpacing="1" width="100%" bgColor="gainsboro">
						<TR id="trID" runat="server">
							<TD bgColor="whitesmoke" style="width: 73px">ID</TD>
							<TD bgColor="white">
								<asp:Label id="lblID" runat="server"></asp:Label>
							</TD>
						</TR>
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Rating</TD>
							<TD bgColor="white">
							    <cc1:ProductRatingDropDownList id="ddlRating" runat="server" />
							</TD>
						</TR>
						
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Title</TD>
							<TD bgColor="white">
								<asp:textbox id="txtTitle" runat="server" Columns="94" MaxLength="100"></asp:textbox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtTitle"
									ErrorMessage="Required">*</asp:RequiredFieldValidator>
							</TD>
						</TR>
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Body</TD>
							<TD bgColor="white">
								<asp:textbox id="txtBody" runat="server" Columns="70" Rows="10" TextMode="MultiLine"></asp:textbox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtBody"
									ErrorMessage="Required">*</asp:RequiredFieldValidator>
							</TD>
						</TR>
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Author</TD>
							<TD bgColor="white">
								<asp:textbox id="thxAuthor" runat="server" Columns="25" MaxLength="256"></asp:textbox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="thxAuthor"
									ErrorMessage="Required">*</asp:RequiredFieldValidator>
							</TD>
						</TR>
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Post Date</TD>
							<TD bgColor="white">
								<asp:textbox id="txtPostDate" runat="server" Columns="25"></asp:textbox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtPostDate"
									ErrorMessage="Required">*</asp:RequiredFieldValidator>
							</TD>
						</TR>
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Helpful Rating</TD>
							<TD bgColor="white">
								<asp:Label id="lblHelpful" runat="server" />
							</TD>
						</TR>
						<TR>
							<TD bgColor="whitesmoke" style="width: 73px">Approved</TD>
							<TD bgColor="white">
								<asp:checkbox id="ckbApproved" runat="server"></asp:checkbox>
							</TD>
						</TR>						
					</TABLE>
				</TD>
			</TR>
				<TR>
				<TD>
					<asp:Button id="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button>&nbsp;
					&nbsp;<asp:Button ID="btnPerm" runat="server" Text="Permanently Delete" OnClick="btnPerm_Click" /></TD>
				<TD align="right">
                    &nbsp;<input type=button value="Return" onclick="location.href='admin_reviews.aspx'" id="Button1" /></TD>
			</TR>
		</TABLE>
	</asp:panel> 
</div>
	<script>
        function CheckDelete() {
        		
	        return confirm("Permanently delete this review? This action cannot be undone...");

        }
    </script>	   
</asp:Content>

