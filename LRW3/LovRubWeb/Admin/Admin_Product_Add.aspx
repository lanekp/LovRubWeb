<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Product_Add.aspx.cs"
	Inherits="Admin_Admin_Product_Add" Title="Product Administration" %>

<%@ Register Src="../Modules/Admin/ProductCrossSells.ascx" TagName="ProductCrossSells"
	TagPrefix="uc6" %>
<%@ Register Src="../Modules/Admin/ProductAttributes.ascx" TagName="ProductAttributes"
	TagPrefix="uc5" %>
<%@ Register Src="../Modules/Admin/ProductCategories.ascx" TagName="ProductCategories"
	TagPrefix="uc4" %>
<%@ Register Src="../Modules/Admin/ProductImages.ascx" TagName="ProductImages" TagPrefix="uc3" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Register Src="../Modules/ImageManager.ascx" TagName="ImagePicker" TagPrefix="uc2" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" runat="Server">
	<div id="centercontent">
		<div id="divMain">
			<h4>
				<a href="admin_products.aspx">Products</a> >>> Add a Product</h4>
			<table class="admintable">
				<tr>
					<td colspan="2" bgcolor="whitesmoke">
						<h4>
							<asp:Label ID="lblProductName" runat="server"></asp:Label></h4>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<uc1:ResultMessage ID="ResultMessage1" runat="server" />
						<asp:ValidationSummary runat="server" ID="vsResultMessage" DisplayMode="List" ShowSummary="true"
							HeaderText="Page Errors:" CssClass="adminitem" />
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Sku</td>
					<td class="adminitem" style="width: 465px">
						<asp:TextBox ID="txtSku" runat="server" MaxLength="50" Width="500px"></asp:TextBox>
						<asp:Label ID="lblID" runat="server" Visible="false"></asp:Label></td>
				</tr>
				<tr>
					<td class="adminlabel">
						Product Name</td>
					<td class="adminitem" style="width: 465px">
						<asp:TextBox ID="txtProductName" runat="server" Width="500px"></asp:TextBox><asp:RequiredFieldValidator
							runat="server" ID="rfvProductName" ControlToValidate="txtProductName" ErrorMessage="Product Name is required."
							Text="*" />
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Short Description</td>
					<td class="adminitem" style="width: 465px">
						<asp:TextBox ID="txtShortDescription" runat="server" TextMode="MultiLine" Height="60px"
							Width="600px" MaxLength="450"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Our Price</td>
					<td class="adminitem" style="width: 465px">
						$<ew:NumericBox ID="txtOurPrice" runat="server" Width="71px" DecimalPlaces="2">0</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvOurPrice" runat="server" ControlToValidate="txtOurPrice" ErrorMessage="Our Price is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Retail Price</td>
					<td class="adminitem" style="width: 465px">
						$<ew:NumericBox ID="txtRetailPrice" runat="server" Width="71px" DecimalPlaces="2">0</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvRetailPrice" runat="server" ControlToValidate="txtRetailPrice" ErrorMessage="Retail Price is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<ajax:AjaxPanel ID="Ajaxpanel4" runat="server">
					<tr>
						<td class="adminlabel">
							Manufacturer</td>
						<td class="adminitem" style="width: 465px">
							<div>
								<asp:DropDownList ID="ddlManufacturerID" runat="server">
								</asp:DropDownList><asp:RequiredFieldValidator runat="server" ID="rfvManufacturerID"
									ControlToValidate="ddlManufacturerID" ErrorMessage="Manufacturer is required."
									Text="*" />
								<asp:TextBox ID="txtQuickMan" runat="server"></asp:TextBox>
								<asp:Button ID="btnQuickMan" runat="server" OnClick="btnQuickMan_Click" Text="Quick Add" CausesValidation="false" />
							</div>
						</td>
					</tr>
				</ajax:AjaxPanel>
				<tr>
					<td class="adminlabel">
						Status</td>
					<td class="adminitem" style="width: 465px">
						<asp:DropDownList ID="ddlStatusID" runat="server">
						</asp:DropDownList><asp:RequiredFieldValidator runat="server" ID="rfvStatusID" ControlToValidate="ddlStatusID"
							ErrorMessage="Status is required." Text="*" />
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Product Type</td>
					<td class="adminitem" style="width: 465px">
						<asp:DropDownList ID="ddlProductTypeID" runat="server">
						</asp:DropDownList><asp:RequiredFieldValidator ID="rfvProductTypeID" runat="server"
							ControlToValidate="ddlProductTypeID" ErrorMessage="Product Type is required." Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Shipping Type</td>
					<td class="adminitem" style="width: 465px">
						<asp:DropDownList ID="ddlShippingTypeID" runat="server">
						</asp:DropDownList><asp:RequiredFieldValidator ID="rfvShippingTypeID" runat="server"
							ControlToValidate="ddlShippingTypeID" ErrorMessage="Shipping Type is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Ship Estimate</td>
					<td class="adminitem" style="width: 465px">
						<asp:DropDownList ID="ddlShipEstimateID" runat="server">
						</asp:DropDownList><asp:RequiredFieldValidator ID="rfvShipEstimateID" runat="server"
							ControlToValidate="ddlShipEstimateID" ErrorMessage="Ship Estimate is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Tax Type</td>
					<td class="adminitem" style="width: 465px">
						<asp:DropDownList ID="ddlTaxTypeID" runat="server">
						</asp:DropDownList><asp:RequiredFieldValidator ID="rfvTaxTypeID" runat="server" ControlToValidate="ddlTaxTypeID"
							ErrorMessage="Tax Type is required." Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel" style="height: 118px">
						Stock Location</td>
					<td class="adminitem" style="height: 118px; width: 465px;">
						<asp:TextBox ID="txtStockLocation" runat="server" Height="100px" TextMode="MultiLine"
							Width="400px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Weight</td>
					<td class="adminitem" style="width: 465px">
						<ew:NumericBox ID="txtWeight" runat="server" Width="41px" DecimalPlaces="2">0</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvWeight" runat="server" ControlToValidate="txtWeight" ErrorMessage="Weight is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Currency Code</td>
					<td class="adminitem" style="width: 465px">
						<asp:DropDownList ID="ddlCurrencyCodeID" runat="server" /><asp:RequiredFieldValidator
							ID="rfvCurrencyCodeID" runat="server" ControlToValidate="ddlCurrencyCodeID" ErrorMessage="Currency Code is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Unit Of Measure</td>
					<td class="adminitem" style="width: 465px">
						<asp:TextBox ID="txtUnitOfMeasure" runat="server" Text="single item" MaxLength="5"></asp:TextBox><br />
						(inches, cm, m, ft, yds)
					</td>
				</tr>
				<tr>
					<td class="adminlabel" style="height: 29px">
						Admin Comments</td>
					<td class="adminitem" style="height: 29px; width: 465px;">
						<asp:TextBox ID="txtAdminComments" runat="server" TextMode="MultiLine" Height="47px"
							Width="331px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Dimensions</td>
					<td class="adminitem" style="width: 465px">
						L
						<ew:NumericBox ID="txtLength" runat="server" Width="24px">0</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvLength" runat="server" ControlToValidate="txtLength" ErrorMessage="Dimensions:Length is required."
							Text="*">
						</asp:RequiredFieldValidator>
						H
						<ew:NumericBox ID="txtHeight" runat="server" Width="24px">0</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvHeight" runat="server" ControlToValidate="txtHeight" ErrorMessage="Dimensions:Height is required."
							Text="*">
						</asp:RequiredFieldValidator>
						W
						<ew:NumericBox ID="txtWidth" runat="server" Width="24px">0</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvWidth" runat="server" ControlToValidate="txtWidth" ErrorMessage="Dimensions:Width is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						Dimension Unit</td>
					<td class="adminitem" style="width: 465px">
						<asp:TextBox ID="txtDimensionUnit" runat="server" Text="inches"></asp:TextBox><asp:RequiredFieldValidator
							ID="rfvDimensionUnit" runat="server" ControlToValidate="txtDimensionUnit" ErrorMessage="Dimension Unit is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="adminlabel">
						List Order</td>
					<td class="adminitem" style="width: 465px">
						<ew:NumericBox ID="txtListOrder" runat="server" Width="24px">99</ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvListOrder" runat="server" ControlToValidate="txtListOrder" ErrorMessage="List Order is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true"
							CssClass="frmbutton"></asp:Button>&nbsp;
						<input type="button" onclick="location.href='admin_products.aspx'" value="Return"
							class="frmbutton" />
					</td>
				</tr>
			</table>
		</div>
	</div>
</asp:Content>
