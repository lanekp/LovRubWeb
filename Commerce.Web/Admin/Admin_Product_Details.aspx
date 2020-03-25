<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
	CodeFile="Admin_Product_Details.aspx.cs" Inherits="Admin_Admin_Product_Details"
	Title="Product Administration" %>
<%@ Register Src="../Modules/Admin/ProductQtyDiscounts.ascx" TagName="ProductQtyDiscounts"
	TagPrefix="uc8" %>
<%@ Register Src="../Modules/Admin/ProductDescriptors.ascx" TagName="ProductDescriptors"
	TagPrefix="uc7" %>
<%@ Register Src="../Modules/Admin/ProductCrossSells.ascx" TagName="ProductCrossSells"
	TagPrefix="uc6" %>
<%@ Register Src="../Modules/Admin/ProductAttributes.ascx" TagName="ProductAttributes"
	TagPrefix="uc5" %>
<%@ Register Src="../Modules/Admin/ProductCategories.ascx" TagName="ProductCategories"
	TagPrefix="uc4" %>
<%@ Register Src="../Modules/Admin/ProductImages.ascx" TagName="ProductImages" TagPrefix="uc3" %>
<%@ Register Src="../Modules/ImageManager.ascx" TagName="ImagePicker" TagPrefix="uc2" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" runat="Server">

	<div id="centercontent">
		<h4>
			<a href="admin_products.aspx">Products</a> >>> Product Details >>>
			<asp:Label ID="lblProductName" runat="server"></asp:Label></h4>
				<uc1:ResultMessage ID="ResultMessage1" runat="server" />
				<table>
					<tr>
						<td>
							<table cellpadding="4" cellspacing="1">
								<tr>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkMain_Click" CausesValidation="false">Main</asp:LinkButton></td>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton3" runat="server" OnClick="lnkDesc_Click" CausesValidation="false">Descriptors</asp:LinkButton></td>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton4" runat="server" OnClick="lnkCat_Click" CausesValidation="false">Categories</asp:LinkButton></td>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton5" runat="server" OnClick="lnkAtt_Click" CausesValidation="false">Attributes</asp:LinkButton></td>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton6" runat="server" OnClick="lnkImages_Click" CausesValidation="false">Images</asp:LinkButton></td>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton7" runat="server" OnClick="lnkCross_Click" CausesValidation="false">Cross-Sells</asp:LinkButton></td>
									<td class="tableNavLink">
										<asp:LinkButton ID="LinkButton8" runat="server" OnClick="lnkDiscount_Click" CausesValidation="false">Qty-Discounts</asp:LinkButton></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Panel ID="pnlMain" runat="server">
								<table class="admintable">
									<tr>
										<td colspan="2">
											<h4>
												Main</h4>
											<asp:ValidationSummary runat="server" ID="vsResultMessage" DisplayMode="List" ShowSummary="true"
												HeaderText="Page Errors:" CssClass="adminitem" />
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Sku</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtSku" runat="server" Width="500px"></asp:TextBox>
											<asp:Label ID="lblID" runat="server" Visible="false"></asp:Label></td>
									</tr>
									<tr>
										<td class="adminlabel">
											Product Name</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtProductName" runat="server" Width="500px"></asp:TextBox><asp:RequiredFieldValidator
												runat="server" ID="rfvProductName" ControlToValidate="txtProductName" ErrorMessage="Product Name is required."
												Text="*" />
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Short Description</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtShortDescription" runat="server" TextMode="MultiLine" Height="60px"
												Width="500px"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Our Price</td>
										<td class="adminitem" style="width: 475px">
											$
                                            <asp:TextBox ID="txtOurPrice" runat="server" Width="60px">0</asp:TextBox>
                                            <asp:RequiredFieldValidator
												ID="rfvOurPrice" runat="server" ControlToValidate="txtOurPrice" ErrorMessage="Our Price is required."
												Text="*">
											</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtOurPrice"
                                                Display="Dynamic" ErrorMessage="Invalid Price" MaximumValue="99999999" MinimumValue="0"
                                                Type="Currency"></asp:RangeValidator></td>
									</tr>
									<tr>
										<td class="adminlabel">
											Retail Price</td>
										<td class="adminitem" style="width: 475px">
											$
                                            <asp:TextBox ID="txtRetailPrice" runat="server" Width="60px">0</asp:TextBox>
                                            <asp:RequiredFieldValidator
												ID="rfvRetailPrice" runat="server" ControlToValidate="txtRetailPrice" ErrorMessage="Retail Price is required."
												Text="*">
											</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtRetailPrice"
                                                Display="Dynamic" ErrorMessage="Invalid Price" MaximumValue="99999999" MinimumValue="0"
                                                Type="Currency"></asp:RangeValidator></td>
									</tr>
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
												<asp:Button ID="btnQuickMan" runat="server" OnClick="btnQuickMan_Click" Text="Quick Add" />
											</div>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Status</td>
										<td class="adminitem" style="width: 475px">
											<asp:DropDownList ID="ddlStatusID" runat="server">
											</asp:DropDownList><asp:RequiredFieldValidator runat="server" ID="rfvStatusID" ControlToValidate="ddlStatusID"
												ErrorMessage="Status is required." Text="*" />
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Product Type</td>
										<td class="adminitem" style="width: 475px">
											<asp:DropDownList ID="ddlProductTypeID" runat="server">
											</asp:DropDownList><asp:RequiredFieldValidator ID="rfvProductTypeID" runat="server"
												ControlToValidate="ddlProductTypeID" ErrorMessage="Product Type is required." Text="*">
											</asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Shipping Type</td>
										<td class="adminitem" style="width: 475px">
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
										<td class="adminitem" style="width: 475px">
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
										<td class="adminitem" style="width: 475px">
											<asp:DropDownList ID="ddlTaxTypeID" runat="server">
											</asp:DropDownList><asp:RequiredFieldValidator ID="rfvTaxTypeID" runat="server" ControlToValidate="ddlTaxTypeID"
												ErrorMessage="Tax Type is required." Text="*">
											</asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td class="adminlabel" style="height: 118px">
											Stock Location</td>
										<td class="adminitem" style="height: 118px; width: 475px;">
											<asp:TextBox ID="txtStockLocation" runat="server" Height="100px" TextMode="MultiLine"
												Width="400px"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Weight</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtWeight" runat="server" Width="41px" DecimalPlaces="2">0</asp:TextBox><asp:RequiredFieldValidator
												ID="rfvWeight" runat="server" ControlToValidate="txtWeight" ErrorMessage="Weight is required."
												Text="*">
											</asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Currency Code</td>
										<td class="adminitem" style="width: 475px">
											<asp:DropDownList ID="ddlCurrencyCodeID" runat="server" /><asp:RequiredFieldValidator
												ID="rfvCurrencyCodeID" runat="server" ControlToValidate="ddlCurrencyCodeID" ErrorMessage="Currency Code is required."
												Text="*" />
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Unit Of Measure</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtUnitOfMeasure" runat="server" Text="single item"></asp:TextBox><br />
						                    (inches, cm, m, ft, yds, etc)
										</td>
									</tr>
									<tr>
										<td class="adminlabel" style="height: 29px">
											Admin Comments</td>
										<td class="adminitem" style="height: 29px; width: 475px;">
											<asp:TextBox ID="txtAdminComments" runat="server" TextMode="MultiLine" Height="47px"
												Width="331px"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											Dimensions</td>
										<td class="adminitem" style="width: 475px">
											L
											<asp:TextBox ID="txtLength" runat="server" Width="24px">0</asp:TextBox><asp:RequiredFieldValidator
												ID="rfvLength" runat="server" ControlToValidate="txtLength" ErrorMessage="Dimensions:Length is required."
												Text="*">
											</asp:RequiredFieldValidator>
											H
											<asp:TextBox ID="txtHeight" runat="server" Width="24px">0</asp:TextBox><asp:RequiredFieldValidator
												ID="rfvHeight" runat="server" ControlToValidate="txtHeight" ErrorMessage="Dimensions:Height is required."
												Text="*">
											</asp:RequiredFieldValidator>
											W
											<asp:TextBox ID="txtWidth" runat="server" Width="24px">0</asp:TextBox><asp:RequiredFieldValidator
												ID="rfvWidth" runat="server" ControlToValidate="txtWidth" ErrorMessage="Dimensions:Width is required."
												Text="*">
											</asp:RequiredFieldValidator></td>
									</tr>
									<tr>
										<td class="adminlabel">
											Dimension Unit</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtDimensionUnit" runat="server" Text="inches"></asp:TextBox><asp:RequiredFieldValidator
												ID="rfvDimensionUnit" runat="server" ControlToValidate="txtDimensionUnit" ErrorMessage="Dimension Unit is required."
												Text="*">
											</asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td class="adminlabel">
											List Order</td>
										<td class="adminitem" style="width: 475px">
											<asp:TextBox ID="txtListOrder" runat="server" Width="24px">99</asp:TextBox><asp:RequiredFieldValidator
												ID="rfvListOrder" runat="server" ControlToValidate="txtListOrder" ErrorMessage="List Order is required."
												Text="*">
											</asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td colspan="2">
											<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton">
											</asp:Button>&nbsp;
											<input type="button" onclick="location.href='admin_products.aspx'" value="Return"
												class="frmbutton" />&nbsp;
											<asp:Button ID="btnDelete" runat="server" CausesValidation="False" Text="Delete"
												OnClick="btnDelete_Click" CssClass="frmbutton"></asp:Button>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<asp:Panel ID="pnlDescriptions" runat="server">
								<uc7:ProductDescriptors ID="ProductDescriptors1" runat="server"></uc7:ProductDescriptors>
							</asp:Panel>
							<asp:Panel ID="pnlImages" runat="server">
								<div id="divImages">
									<uc3:ProductImages ID="ProductImages1" runat="server"></uc3:ProductImages>
								</div>
							</asp:Panel>
							<asp:Panel ID="pnlCategories" runat="server">
								<uc4:ProductCategories ID="ProductCategories1" runat="server" />
							</asp:Panel>
							<asp:Panel ID="pnlAtts" runat="server">
								<uc5:ProductAttributes ID="ProductAttributes1" runat="server"></uc5:ProductAttributes>
							</asp:Panel>
							<asp:Panel ID="pnlCross" runat="server">
								<uc6:ProductCrossSells ID="ProductCrossSells1" runat="server"></uc6:ProductCrossSells>
							</asp:Panel>
							<asp:Panel ID="pnlDiscount" runat="server">
								<uc8:ProductQtyDiscounts ID="ProductQtyDiscounts1" runat="server"></uc8:ProductQtyDiscounts>
							</asp:Panel>
						</td>
					</tr>
				</table>
	</div>

	<script type="text/javascript">
			function CheckDelete(){
				return confirm("Delete this record? This action cannot be undone...");
  		}
	</script>

</asp:Content>
