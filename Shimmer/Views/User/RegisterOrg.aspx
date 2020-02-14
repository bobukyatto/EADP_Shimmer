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
    <h1>
            Organization</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Organization Name:</td>
                <td>
                    <asp:TextBox ID="TbNameOrg" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Organization Email:</td>
                <td>
                    <asp:TextBox ID="TbEmailOrg" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Organization Phone No.:</td>
                <td>
                    <asp:TextBox ID="TbPhoneOrg" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td>
                    <asp:TextBox ID="TbPassOrg" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Re-enter Password:</td>
                <td>
                    <asp:TextBox ID="TbRePassOrg" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnRegisterOrg" cssClass="btn btn-outline-success" runat="server" OnClick="BtnRegisterOrg_Click" Text="Register" />
                    <br />
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>
