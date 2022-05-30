<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="InventoryWebApp.Pages.RegisterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="RegisterFormMain" runat="server">

    <br />
    <br />
        <div id="FormContainter" class="jumbotron">
            <div class="form-group row">
                <label id="ErrorMessage" runat="server">Error!</label>
            </div>
            <div class="form-group row" >
                <label for="CompanyName">Company Name</label>
                <div class="col">
                    <input id="CompanyName" class="form-control" runat="server" placeholder="Company Name"/>
                </div>
            </div>
            <div class="form-group row" >
                <label for="CompanyEmail">Company Email</label>
                <div class="col">
                    <input id="CompanyEmail" class="form-control" runat="server" placeholder="Company Email"/>
                </div>
            </div>
            <div class="form-group row" >
                <label for="CIF">CIF</label>
                <div class="col">
                    <input id="CIF" runat="server" class="form-control" aria-describedby="CIFDescription" placeholder="Company Indetifier"/>
                    <small id="CIFDescription" class="form-text text-muted">Country identifier for the country.</small>
                </div>
            </div>
            <br />
            <br />
            <div class="form-group row" >
                <label for="User">User Name</label>
                <div class="col">
                    <input id="User" runat="server" class="form-control" placeholder="User Name"/>
                </div>
            </div>
            <div class="form-group row" >
                <label for="UserEmail">User Email</label>
                <div class="col">
                    <input id="UserEmail" class="form-control" runat="server" placeholder="User Email"/>
                </div>
            </div>
            <div class="form-group row" >
                <label for="UserPassword">User Password</label>
                <div class="col">
                    <input id="UserPassword" type="password" class="form-control" runat="server" placeholder="User Password"/>
                </div>
            </div>
            <br />
            <div class="form-group row" style="display: flex;justify-content: center;">
                <asp:Button runat="server" id="formSubmit" text="Submit" class="btn btn-primary" OnClick="FormSubmit"/>
            </div>
        </div>
    </div>
</asp:Content>
