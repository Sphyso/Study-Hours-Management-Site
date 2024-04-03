<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="Task3POE.AddModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label9" runat="server" Text="Welcome: "></asp:Label>
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <br />
    <h3 class="heading">Add Module</h3>
    <p></p>
    <div class="loginDiv">
    <asp:Label ID="Label1" class="txtBoxes" runat="server" Text="Module Code: "></asp:Label><br />
    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" class="txtBoxes" runat="server" Text="Module Name: "></asp:Label><br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label3" class="txtBoxes" runat="server" Text="Credits: "></asp:Label><br />
    <asp:TextBox ID="txtCredits" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" class="txtBoxes" runat="server" Text="Class Hours: "></asp:Label><br />
    <asp:TextBox ID="txtClassHours" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label5" class="txtBoxes" runat="server" Text="Number of Weeks: "></asp:Label><br />
    <asp:TextBox ID="txtWeeks" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label6" class="txtBoxes" runat="server" Text="Start Date: (dd/mm/yyyy)"></asp:Label><br />
    <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox><br /><br />
    <p class="para">Enter the amount of hours you plan to use studying on a certain date: </p>
    <asp:Label ID="Label7" class="txtBoxes" runat="server" Text="Enter Date: (dd/mm/yyyy)"></asp:Label><br />
    <asp:TextBox ID="txtStudyDate" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label8" class="txtBoxes" runat="server" Text="Hours to Study: "></asp:Label><br />
    <asp:TextBox ID="txtHoursToStudy" runat="server"></asp:TextBox><br />
    <p></p>

    <asp:Button ID="btnAddModule" Class="buttons" runat="server" Text="Add Module" OnClick="btnAddModule_Click" />
    </div>
    <br />
    <div class="logOut">
        <asp:Button ID="btnLogOut" class="buttons" runat="server" Text="Log out" OnClick="btnLogOut_Click" />
    </div>

</asp:Content>
