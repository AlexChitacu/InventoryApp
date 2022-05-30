<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyUsers.aspx.cs" Inherits="InventoryWebApp.Pages.Company.CompanyUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CompanyUsersFormMain" runat="server">
        <div id="FormContainter" runat="server">
            <div class="form-group row">
                <label for="UserName">User Name</label>
                <div class="col">
                    <input id="UserName" runat="server" class="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <label for="UserEmail">User Name</label>
                <div class="col">
                    <input id="UserEmail" runat="server" class="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <label for="UserPassword">User Password</label>
                <div class="col">
                    <input id="UserPassword" type="password" runat="server" class="form-control" />
                </div>
            </div>
            <div class="form-group row">
                <label for="UserRole">User Role</label>
                <div class="col">
                    <select id="UserRole" runat="server" class="form-control" ></select>
                </div>
            </div>
            <div class="form-group row">
                    <label id="ErrorMessage" runat="server">Error!</label>
            </div>
            <div class="form-group row" style="display: flex;justify-content: center;">
                <asp:Button runat="server" id="formSubmit" text="Submit" class="btn btn-primary" OnClick="FormSubmit"/>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />

    <div id="CompanyUserListmain" runat="server" >
         <asp:UpdatePanel ID="CompanyUserListUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="CompanyUserListItems" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">    
                 <Columns>    
                     <asp:BoundField DataField="ID" HeaderText="Item ID" ItemStyle-Width="30" />    
                     <asp:BoundField DataField="UserName" HeaderText="User Name" ItemStyle-Width="150" />    
                     <asp:BoundField DataField="UserEmail" HeaderText="User Email" ItemStyle-Width="150" />
                     <asp:BoundField DataField="Role" HeaderText="Role" ItemStyle-Width="150" />   
                 </Columns>    
             </asp:GridView> 
        </ContentTemplate>
    </asp:UpdatePanel>

    </div>
</asp:Content>
