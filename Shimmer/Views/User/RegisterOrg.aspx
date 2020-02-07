<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="RegisterOrg.aspx.cs" Inherits="Shimmer.RegisterOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Organization Registration</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 424px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            Organization</div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Organization Name:</td>
                <td>
                    <asp:TextBox ID="TbNameOrg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Organization Email:</td>
                <td>
                    <asp:TextBox ID="TbEmailOrg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Organization Phone No.:</td>
                <td>
                    <asp:TextBox ID="TbPhoneOrg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td>
                    <asp:TextBox ID="TbPassOrg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Re-enter Password:</td>
                <td>
                    <asp:TextBox ID="TbRePassOrg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnRegisterOrg" runat="server" OnClick="BtnRegisterOrg_Click" Text="Register" />
                    <br />
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>
