<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="UserTable.aspx.cs" Inherits="Shimmer.Views.Admin.UserTabe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Table</h2>
    <asp:GridView ID="GvAccount" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvAccount_SelectedIndexChanged" Width="1090px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
            <asp:BoundField DataField="Fullname" HeaderText="Fullname" ReadOnly="True" />
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
            <asp:BoundField DataField="Phone" HeaderText="Phone No." ReadOnly="True" />
            <asp:BoundField DataField="UserType" HeaderText="User Type" ReadOnly="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:Label ID="LblMsg" runat="server"></asp:Label>
</asp:Content>
