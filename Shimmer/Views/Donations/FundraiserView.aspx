<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="FundraiserView.aspx.cs" Inherits="Shimmer.Views.Donations.FundraiserView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <img alt="" class="auto-style3" src="img/fundraiser_img1.png" /><br />
        <table class="auto-style4">            
            <tr>
                <td class="auto-style5">Fundraiser Name:</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Event Id:</td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Organised By:</td>
                <td>
                    <asp:Label ID="lblOrgBy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Description:</td>
                <td class="auto-style1">
                    <asp:Label ID="lblDesc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Donation Goal (SG$):</td>
                <td>
                    <asp:Label ID="lblDonGoal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Category:</td>
                <td>
                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnDonate" runat="server" Text="Donate to this Fundraiser" OnClick="btnDonate_Click" />
                </td>
            </tr>
        </table>
        <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
