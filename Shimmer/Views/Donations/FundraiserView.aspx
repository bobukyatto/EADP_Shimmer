<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="FundraiserView.aspx.cs" Inherits="Shimmer.Views.Donations.FundraiserView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblID" runat="server"></asp:Label>
        <br />
        <img alt="" class="auto-style3" src="img/fundraiser_img1.png" /><br />
        <table class="auto-style4">
            <tr>
                <td class="auto-style5">Fundraiser Name:</td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Organised By:</td>
                <td>
                    <asp:Label ID="lblOrgBy" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Description:</td>
                <td>
                    <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Donation Goal:</td>
                <td>
                    <asp:Label ID="lblDonGoal" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Category:</td>
                <td>
                    <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
