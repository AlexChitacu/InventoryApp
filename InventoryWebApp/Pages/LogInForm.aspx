<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="InventoryWebApp.Pages.LogInForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="LogInMainArea" onsubmit="LoginUser">
         <br />
         <br />
        <div id="FormContainter" class="jumbotron">
                <div class="form-group row" >
                    <label for="User" class="col-form-label">User Name</label>
                    <div class="col" >
                        <input id="User" runat="server" class="form-control" placeholder="User Name"/>
                    </div>
                </div>
                <div class="form-group row" >
                    <label for="UserPassword" class="col-form-label">Password</label>
                    <div class="col" >
                        <input id="UserPassword" type="password" runat="server" class="form-control" placeholder="User Password"/>
                    </div>
                </div>
                <div class="form-group row">
                    <label id="ErrorMessage" runat="server">Error!</label>
                </div>
                <div class="form-group row" style="display: flex;justify-content: center;">
                    <asp:Button runat="server" id="formSubmit" text="LogIn" class="btn btn-primary" OnClick="FormSubmit"/>
                </div>
        </div>
    </div>
</asp:Content>
