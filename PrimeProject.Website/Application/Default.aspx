<%@ Page Title="" Language="C#" MasterPageFile="~/Application/_Master/BaseMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimeProject.Website.Application.Default" %>

<%@ Register Src="~/Application/_Widget/LoginHeader.ascx" TagPrefix="uc1" TagName="LoginHeader" %>


<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
    <uc1:LoginHeader runat="server" ID="LoginHeader" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
