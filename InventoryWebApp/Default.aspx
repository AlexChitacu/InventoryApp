<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventoryWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Inventory App</h1>
        <p class="lead">Inventory App is a free web application for maniging your company inventory.</p>
        <p><a href="~/About" runat="server" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                Register your company to start using the application.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Pages/RegisterForm">Register &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Companies</h2>
            <p>
                Check the companies that are currently using the application.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Pages/Display/Companies">Companies &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Traffic</h2>
            <p>
                See how busy the application is :)
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Pages/Display/Traffic">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
