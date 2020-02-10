<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="CreateFundraiser.aspx.cs" Inherits="Shimmer.Views.Donations.CreateFundraiser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Create your fundraiser</p><br/>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Desc" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Image (.jpg or .png only)"></asp:Label>
                </td>
                <td>
                    <input id="File1" type="file" /></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Donation Goal"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_DGoal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
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
        <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="Submit" />
    </p>
        <p>
            <asp:Label ID="Lbl_success" runat="server" ForeColor="Green"></asp:Label>
    </p>
        <p>
            <asp:Button ID="btnDonations" runat="server" OnClick="btnDonations_Click" Text="Go to Donations Page" />
        </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
