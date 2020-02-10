<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="FundraiserDonate.aspx.cs" Inherits="Shimmer.Views.Donations.FundraiserDonate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Donation Form"></asp:Label>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Fundraiser Name:</td>
                <td>
                    <asp:Label ID="lblFdrName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Organised By:</td>
                <td>
                    <asp:Label ID="lblOrgBy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Fundraiser Id:</td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td class="auto-style3">Description:</td>
                <td class="auto-style4">
                    <asp:Label ID="lblDesc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Donation Goal:</td>
                <td class="auto-style4">
                    <asp:Label ID="lblDonGoal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Category:</td>
                <td>
                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" style="text-decoration:underline;">Donation Details*</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Donation By:</td>
                <td>
                    <asp:Label ID="lblUserId" runat="server">UserId</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Donation Amount (SG$):</td>
                <td>
                    <asp:TextBox ID="tbDonAmt" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Credit Type:</td>
                <td>
                    <asp:DropDownList ID="ddlCreditType" runat="server">
                        <asp:ListItem Value="-1">--Select Type--</asp:ListItem>
                        <asp:ListItem Value="1">MasterCard</asp:ListItem>
                        <asp:ListItem Value="2">Visa</asp:ListItem>
                        <asp:ListItem Value="3">AMEX</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnDonate" runat="server" OnClick="btnDonate_Click" Text="Submit" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return to Donation Page" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
