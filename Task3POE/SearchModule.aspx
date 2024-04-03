<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchModule.aspx.cs" Inherits="Task3POE.SearchModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label9" runat="server" Text="Welcome: "></asp:Label>
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <br />
    <h3 class="heading">Look for a Module</h3>
    <p></p>
    <div class="loginDiv">
    <asp:Label ID="Label1" class="txtBoxes" runat="server" Text="Module Code: "></asp:Label><br />
    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox><br /><br />

    <asp:Button ID="btnSearch" Class="buttons" runat="server" Text="Search" OnClick="btnSearch_Click" /><br /><br />
    <asp:Label ID="Label2" class="txtBoxes" runat="server" Text="Module Name: "></asp:Label><br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" class="txtBoxes" runat="server" Text="Credits: "></asp:Label><br />
    <asp:TextBox ID="txtCredits" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label5" class="txtBoxes" runat="server" Text="Class Hours: "></asp:Label><br />
    <asp:TextBox ID="txtClassHours" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label6" class="txtBoxes" runat="server" Text="Self Study Hours: "></asp:Label><br />
    <asp:TextBox ID="txtSelfStudyHours" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label7" class="txtBoxes" runat="server" Text="Study Date: "></asp:Label><br />
    <asp:TextBox ID="txtStudyDate" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label8" class="txtBoxes" runat="server" Text="Hours to Study: "></asp:Label><br />
    <asp:TextBox ID="txtHoursToStudy" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label3" class="txtBoxes" runat="server" Text="Hours Remaining: "></asp:Label><br />
    <asp:TextBox ID="txtHoursRemaining" runat="server"></asp:TextBox><br /><br />
    </div>
    <br />
    <asp:Button ID="btnLogOut" class="buttons" runat="server" Text="Log out" OnClick="btnLogOut_Click" />



</asp:Content>
