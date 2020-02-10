<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Shimmer.Views.User.ProfileOrg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 551px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="subtitle text-primary">Profile Page</h2>
    <table class="auto-style4">
        <tr>
            <td class="subtitle text-primary">Name:</td>
            <td>
                <div class="col-sm-4">
                    <asp:Label ID="LblName" class="form-label" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="subtitle text-primary">Email:</td>
            <td>
                <div class="col-sm-4">
                <asp:Label ID="LblEmail" class="form-label" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="subtitle text-primary">Contact No.:</td>
            <td>
                <div class="col-sm-4">
                <asp:Label ID="LblPhone" class="form-label" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Button ID="BtnUpdate" cssClass="btn btn-outline-success" runat="server" OnClick="BtnUpdate_Click" Text="Update" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        
    </table>

   
</asp:Content>
