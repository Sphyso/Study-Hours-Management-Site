<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Task3POE.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 class="heading">Register</h3>
    <p></p>
    <div class="loginDiv">
    <asp:Label ID="Label1" class="txtBoxes" runat="server" Text="Student Number: "></asp:Label><br />
    <asp:TextBox ID="txtStudNum" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label2" class="txtBoxes" runat="server" Text="Name: "></asp:Label><br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label3" class="txtBoxes" runat="server" Text="Surname: "></asp:Label><br />
    <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label4" class="txtBoxes" runat="server" Text="Age: "></asp:Label><br />
    <asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label5" class="txtBoxes" runat="server" Text="Password: "></asp:Label><br />
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
    <p></p>

    <asp:Button ID="btnRegister" Class="buttons" runat="server" Text="Register" OnClick="btnRegister_Click" />
    <asp:Button ID="btnBackLogin" Class="buttons" runat="server" Text="Back to Login" OnClick="btnBackLogin_Click" />
    </div>


</asp:Content>
