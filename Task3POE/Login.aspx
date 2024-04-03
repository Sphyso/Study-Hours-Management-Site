<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Task3POE.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 class="heading">Login</h3>
    <p></p>
    <div class="loginDiv">
    <asp:Label ID="Label1" class="txtBoxes" runat="server" Text="Student Number: "></asp:Label><br />
    <asp:TextBox ID="txtStudNum" runat="server"></asp:TextBox> <br />

    <asp:Label ID="Label2" class="txtBoxes" runat="server" Text="Password: "></asp:Label><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox> <br />
    <p></p>

    <asp:Button ID="btnLogin" Class="buttons" runat="server" Text="Login" OnClick="btnLogin_Click" />
    <asp:Button ID="btnRegister" Class="buttons" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>


</asp:Content>
