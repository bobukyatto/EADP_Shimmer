<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shimmer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 241px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="TbEmailLogin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Password:</td>
            <td>
                <asp:TextBox ID="TbPassLogin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Label ID="lblMsgLogin" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
