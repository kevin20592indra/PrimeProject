<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginHeader.ascx.cs" Inherits="PrimeProject.Website.Application._Widget.LoginHeader" %>

<header class="main-header">
    <nav class="navbar navbar-static-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <a href="#" class="navbar-brand"><b>Prime</b>Project</a>
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse">
                    <i class="fa fa-bars"></i>
                </button>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <form runat="server">
                <div class="navbar-form navbar-right" role="search">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="TxtUsername" class="form-control navbar-input" placeholder="Username" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="TxtPass" class="form-control navbar-input" placeholder="Pass" />
                    </div>
                </div>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <asp:LinkButton runat="server" ID="LnkBtnLogin" Text="Login"></asp:LinkButton>
                    </li>
                </ul>
            </form>
        </div>
    </nav>
</header>
