<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="Shimmer.Views.User.UpdateDeleteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 499px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Your Profile</h2>
    <table class="w-100">
        <tr>
            <td class="auto-style1">Name:</td>
            <td>
                <asp:TextBox ID="UpdateName" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email:</td>
            <td>
                <asp:TextBox ID="UpdateEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Phone No:</td>
            <td>
                <asp:TextBox ID="UpdatePhone" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
         <%--<tr>
            <td class="auto-style1">Current Password:</td>
            <td>
                <asp:TextBox ID="CurrPass" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td class="auto-style1">New Password:</td>
            <td>
                <asp:TextBox ID="UpdatePass" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Re-enter Password:</td>
            <td>
                <asp:TextBox ID="rePass" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style1"></td>
            <td>
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Button ID="BtnUpdate" runat="server" cssClass="btn btn-outline-success" Text="Update" OnClick="BtnUpdate_Click" />
    <asp:Button ID="BtnBack" runat="server" cssClass="btn btn-outline-success" Text="Back" OnClick="BtnBack_Click" />
</asp:Content>
