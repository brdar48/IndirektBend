<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="IndirektBend.Account.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Dobrodosli, ovo su sledece svirke benda Indirekt!</h1>

    <br />

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" CssClass="table"></asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        SelectCommand="SELECT lokacija, datum FROM Svirke ORDER BY datum ASC"
        ConnectionString=""></asp:SqlDataSource>

    <!-- Connectstion string staviti u SQL data source -->

</asp:Content>
