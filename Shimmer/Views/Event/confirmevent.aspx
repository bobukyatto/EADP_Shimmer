<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="confirmevent.aspx.cs" Inherits="Shimmer.confirmevent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Views/index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="/Views/Event/events.aspx">Events</a></li>
            <li class="breadcrumb-item active">
                <asp:Label ID="lbBreadcrumbCurrent" runat="server" Text="Your Group Events"></asp:Label>
            </li>
        </ol>
    </nav>
    <div class="row">
        <asp:Repeater ID="confirmationRepeater" runat="server">
            <ItemTemplate>
                <div class="col-2">
                    <asp:CheckBox ID="chkbApproval" runat="server" />
                </div>
                <div class="col-4">
                    <asp:Image ID="imgProfile" runat="server" />
                </div>
                <div class="col-6">
                    <asp:Label ID="lb" runat="server" Text="Label"></asp:Label>
                </div>
            </ItemTemplate>

        </asp:Repeater>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
