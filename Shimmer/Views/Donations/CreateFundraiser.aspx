<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="CreateFundraiser.aspx.cs" Inherits="Shimmer.Views.Donations.CreateFundraiser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Create your fundraiser</h1><br/>
        <table class="auto-style1">
            
            <tr>
                
                <td class="auto-style2">
                    <asp:Label CssClass ="form-control-plaintext" ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Name" CssClass ="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" CssClass ="form-control-plaintext" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Desc" CssClass ="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" CssClass ="form-control-file" runat="server" Text="Image (.jpg or .png only)"></asp:Label>
                </td>
                <td>
                    <input id="File1" type="file" /></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" CssClass ="form-control-plaintext" runat="server" Text="Donation Goal"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_DGoal" CssClass ="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" CssClass ="form-control-plaintext" runat="server" Text="Category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Category" runat="server">
                        <asp:ListItem Value="Placeholder"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    <p>
        <asp:Label ID="Lbl_err" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p> 
        <asp:Button ID="Btn_Submit" CssClass="btn btn-primary px-2" runat="server" OnClick="Btn_Submit_Click" Text="Submit" />
    </p>
        <p>
            <asp:Label ID="Lbl_success" runat="server" ForeColor="Green"></asp:Label>
    </p>
        <p>
            <asp:Button ID="btnDonations" CssClass="btn btn-primary px-3" runat="server" OnClick="btnDonations_Click" Text="Go to Donations Page" />
        </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
