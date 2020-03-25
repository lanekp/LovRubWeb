<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="admin_taxrates.aspx.cs" Inherits="Admin_admin_taxrates" Title="Tax Rates Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">
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
           <b>Rate</b><br />
            <asp:TextBox ID="rateTextBox" runat="server" Text='<%# Bind("rate") %>' Width="82px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="rateTextBox" Display="Dynamic"
                ErrorMessage="Required"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="rateTextBox"
                ErrorMessage="Invalid Number" MaximumValue="1" MinimumValue="0.001"></asp:RangeValidator><br />
            <b>State</b><br />
            <asp:DropDownList ID="stateDropDownList" runat="server" Width="169px" SelectedValue='<%# Bind("state") %>'>
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
            <b>Zip Code</b><br />
            <asp:TextBox ID="zipCodeTextBox" runat="server" Text='<%# Bind("zipCode") %>' Width="84px"></asp:TextBox><br />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert">
            </asp:LinkButton>
        </InsertItemTemplate>

    </asp:FormView>
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


</div>

</asp:Content>

