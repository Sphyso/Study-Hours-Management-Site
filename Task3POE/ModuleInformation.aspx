<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModuleInformation.aspx.cs" Inherits="Task3POE.ModuleInformation" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Welcome: "></asp:Label>
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <br />
    <h3 class="heading">Module Information</h3>
    <p></p>
    <div class="MIdiv">
    <asp:GridView ID="gvDisplayModules" Class="gridDisplay" runat="server"></asp:GridView>
    <br />

    <asp:Chart ID="chtModuleData" runat="server">
        <Titles>
            <asp:Title Text="Self study hours by Module"></asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Column" XValueMember="ModuleCode" YValueMembers="SelfStudyHours"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Module Code"></AxisX>
                <AxisY Title="Self Study Hours"></AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    </div>
    <br />
    <asp:Button ID="btnLogOut" class="buttons" runat="server" Text="Log out" OnClick="btnLogOut_Click" />

</asp:Content>
