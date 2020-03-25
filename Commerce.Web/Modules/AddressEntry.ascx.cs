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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Commerce.Common;

public partial class AddressEntry : System.Web.UI.UserControl
{
    bool countrySet = false;
    Address address = null;
    private bool useAddressBook=true;

    public bool UseAddressBook
    {
        get { return useAddressBook; }
        set { useAddressBook = value; }
    }
    private string addressBookTitle;

    public string AddressBookTitle
    {
        get { return addressBookTitle; }
        set { addressBookTitle = value; }
    }
	
    public Address SelectedAddress
    {
        get { 
        
            //return the entered text bits as an address
            address = new Address();
            address.FirstName = txtFirst.Text;
            address.LastName = txtLast.Text;
            address.Address1 = txtAddress1.Text;
            address.City = txtCity.Text;
            address.Email = txtEmail.Text;
            address.Address2 = txtAddress2.Text;
            address.Zip = txtZip.Text;
            //address.Phone = txtPhone.Text; //KPL Commented out phone 2/09/08

            if (ddlCountry.SelectedValue == "US")
            {
                address.StateOrRegion = ddlState.SelectedValue;

            }
            else
            {
                address.StateOrRegion = txtState.Text;

            }
            address.Country = ddlCountry.SelectedValue;
            
            return address;

        }
        set {
            address = value;
            txtFirst.Text=address.FirstName;
            txtLast.Text = address.LastName;
            txtAddress1.Text =  address.Address1;
            txtCity.Text =  address.City;
            txtEmail.Text = address.Email;
            txtAddress2.Text=address.Address2;
            txtZip.Text=address.Zip;
            //txtPhone.Text = address.Phone; //KPL Commented out phone 2/09/08

            if (address.Country == "US" || address.Country == "United States") //TODO: CMC - The || statement is a hack for PayPal - fix this up.
            {
                ddlState.SelectedValue=address.StateOrRegion;
                ToggleStateDrop(true);
            }
            else
            {
                txtState.Text=address.StateOrRegion ;
                ToggleStateDrop(false);

            }

            if(address.Country.Trim().Length > 0) {
              ddlCountry.SelectedValue = address.Country;
              countrySet = true;
            }
        }
    }
	
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            pnlAddBook.Visible = false;
            if (useAddressBook)
            {
                dtAddresses.DataSource = OrderController.GetUserAddresses();
                dtAddresses.DataBind();
            }
            if (!countrySet) {
                ddlCountry.SelectedValue = "US";
                ToggleStateDrop(true);
            }
        }
    }

    protected void SelectAddress(object sender, DataListCommandEventArgs e)
    {
        Label lblID = (Label)e.Item.FindControl("lblAddressID");
        if (lblID != null)
        {
            int shipAddressID = int.Parse(lblID.Text);
            Address shipAddress = new Address(shipAddressID);

            this.SelectedAddress = shipAddress;

        }
    }

    void ToggleStateDrop(bool showIt)
    {

        ddlState.Visible = showIt;
        valState.Visible = showIt;
        txtState.Visible = !showIt;
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlCountry.SelectedValue == "US")
        {
            ToggleStateDrop(true);
        }
        else
        {
            ToggleStateDrop(false);
        }
    }

    protected void lnkToggle_Click(object sender, EventArgs e)
    {
        pnlAddBook.Visible = !pnlAddBook.Visible;
        
    }
}
