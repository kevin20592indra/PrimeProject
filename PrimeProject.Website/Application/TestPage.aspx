<%@ Page Title="" Language="C#" MasterPageFile="~/Application/_Master/BaseMaster.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="PrimeProject.Website.Application.TestPage" %>

<%@ Register Src="~/Application/_Content/Listing.ascx" TagPrefix="uc1" TagName="Listing" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <uc1:Listing runat="server" ID="Listing" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PluginsPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#example1").dataTable();
            $('#example2').dataTable({
                "bPaginate": true,
                "bLengthChange": true,
                "bFilter": true,
                "bSort": true,
                "bInfo": true,
                "bAutoWidth": false
            });
        });
    </script>
</asp:Content>
