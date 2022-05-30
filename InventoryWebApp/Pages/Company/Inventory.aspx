<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="InventoryWebApp.Pages.Company.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="AddInventoryMain" runat="server">
        <div id="FormContainter" class="jumbotron">
            <div class="form-group row">
                <label for="ProductSelect">Product Select</label>
                <div class="col">
                    <select id="ProductSelect" class="form-control" runat="server"></select>
                </div>
            </div>
            <div class="form-group row">
                <label for="DepoSelect">Depo Select</label>
                <div class="col">
                    <select id="DepoSelect" class="form-control" runat="server"></select>
                </div>
            </div>
            <div class="form-group row">
                <label for="ProductAmount">Quantity</label>
                <div class="col">
                    <input id="ProductAmount" class="form-control" runat="server" placeholder="Product Amount" value="0"/>
                </div>
            </div>
            <div class="form-group row">
                <label id="ErrorMessage" runat="server">Error!</label>
            </div>
            <div class="form-group row" style="display: flex;justify-content: center;">
                <asp:Button ID="InvetoryAddButton" class="btn btn-primary" Text="Add" runat="server" OnClick="AddInvetory" />
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />

    <div id="InventoryTable" runat="server">
    <asp:UpdatePanel ID="InventoryUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="InventoryItems" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">    
                 <Columns>    
                     <asp:BoundField DataField="ID" HeaderText="Item ID" ItemStyle-Width="30" />    
                     <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="150" />    
                     <asp:BoundField DataField="ProductQuantity" HeaderText="Product Quantity" ItemStyle-Width="150" />
                     <asp:BoundField DataField="DepoName" HeaderText="Depo Name" ItemStyle-Width="150" />   
                 </Columns>    
             </asp:GridView> 
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

</asp:Content>
