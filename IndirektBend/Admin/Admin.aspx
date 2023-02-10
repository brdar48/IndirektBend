<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IndirektBend.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Admin stranica Indirekt benda</h1>

    <asp:Panel ID="Panel1" runat="server">
         <h3>Sviraci</h3>
        <asp:GridView ID="GridView1" runat="server" 
            CssClass="table"
            SelectedRowStyle-BackColor="Orange"
            SelectedRowStyle-Font-Bold="true"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
             SelectedRowStyle-ForeColor="Black"
            AutoGenerateSelectButton="true"></asp:GridView>

        <h4>Kod unosa sviraca, polje za ID ostaje prazno jer je u bazi IDENTITY(1,1)</h4>
        <asp:Label ID="Label1" runat="server" Text="Svirac ID:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ime i prezime:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Instrument: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="24%" AutoPostBack="true"></asp:DropDownList>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Unesi sviraca" CssClass="btn btn-success" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Azuriraj izabranog sviraca" CssClass="btn btn-warning" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Obrisi izabranog sviraca" CssClass="btn btn-danger" OnClick="Button3_Click" />

        <br />
        <br />

        <asp:Label ID="SviracError" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
         <h3>Instrumenti</h3>
        <asp:GridView ID="GridView2" runat="server" 
            CssClass="table"
            SelectedRowStyle-BackColor="Orange"
            SelectedRowStyle-Font-Bold="true"
            OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
            SelectedRowStyle-ForeColor="Black"
            AutoGenerateSelectButton="true"></asp:GridView>

        <h4>Kod unosa instrumenata, polje za ID ostaje prazno jer je u bazi IDENTITY(1,1)</h4>
        <asp:Label ID="Label5" runat="server" Text="Instrument ID:"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label6" runat="server" Text="Naziv:"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Button ID="Button4" runat="server" Text="Unesi instrument" CssClass="btn btn-success" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="Azuriraj izabrani instrument" CssClass="btn btn-warning" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="Obrisi izabrani instrument" CssClass="btn btn-danger" OnClick="Button6_Click" />

        <br />
        <br />

        <asp:Label ID="InstrumentError" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server">
         <h3>Svirke</h3>
        <asp:GridView ID="GridView3" runat="server" 
            CssClass="table"
            SelectedRowStyle-BackColor="Orange"
            SelectedRowStyle-Font-Bold="true"
            OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
             SelectedRowStyle-ForeColor="Black"
            AutoGenerateSelectButton="true"></asp:GridView>

        <h4>Kod unosa svirki, polje za ID ostaje prazno jer je u bazi IDENTITY(1,1)</h4>
        <asp:Label ID="Label4" runat="server" Text="Svirka ID:"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label7" runat="server" Text="Lokacija:"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label8" runat="server" Text="Datum (GGGG-MM-DD SS:MM:ss):"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Button ID="Button7" runat="server" Text="Unesi svirku" CssClass="btn btn-success" OnClick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Text="Azuriraj izabranu svirku" CssClass="btn btn-warning" OnClick="Button8_Click" />
        <asp:Button ID="Button9" runat="server" Text="Obrisi izabranu svirku" CssClass="btn btn-danger" OnClick="Button9_Click" />

        <br />
        <br />

        <asp:Label ID="SvirkaError" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
    </asp:Panel>


</asp:Content>
