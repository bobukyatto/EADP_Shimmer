<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="RegisterPublic.aspx.cs" Inherits="Shimmer.RegisterPublic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Individual Registration</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 375px;
        }
    </style>
    <link href="../../Public/CSS/style.default.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            Individual</div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Full Name:</td>
                <td>
                    <asp:TextBox ID="TbfullName" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td>
                    <asp:TextBox ID="TbEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td>
                    <asp:TextBox ID="TbPassword" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Re-enter Password:</td>
                <td>
                    <asp:TextBox ID="TbRePass" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnRegister" cssClass="btn btn-outline-success" runat="server" OnClick="BtnRegister_Click" Text="Register" />
                    <br />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>
