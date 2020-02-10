<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="ManageFundraiser.aspx.cs" Inherits="Shimmer.Views.Donations.ManageFundraiser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Manage Fundraiser"></asp:Label>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Id:</td>
                <td>
                    <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Organised By:</td>
                <td>
                    <asp:Label ID="lblOrgBy" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Fundraiser Name:</td>
                <td>
                    <asp:TextBox ID="tbFdrName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Description:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Donation Goal:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="tbDonGoal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Fundraiser" />
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
