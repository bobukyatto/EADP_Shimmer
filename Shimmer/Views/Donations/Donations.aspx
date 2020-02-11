<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="Donations.aspx.cs" Inherits="Shimmer.Views.Donations.Donations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="lbCreateFdr" runat="server" OnClick="lbCreateFdr_Click">Create Fundraiser</asp:LinkButton>
        <br />


        <asp:Repeater ID="RptDonations" runat="server" OnItemCommand="RptDonations_ItemCommand">
            <ItemTemplate>
                <div class="col-4 h-100 mb-5">
                    <div class="card">
                        
                        <div class="card-body text-center">
                            <asp:Label ID="lbTitle" runat="server" Text=<%# Eval("name") %> Font-Bold="True"></asp:Label>
                            <p class="card-text"><small class="text-muted">By <%# Eval("organisedBy") %></small></p>
                            
                            <i class="fa fa-align-justify"><asp:Label ID="lbDesc" runat="server" Text=<%# " "+Eval("description") %>></asp:Label></i><br />
                            <i class="fa fa-usd"> <asp:Label ID="lbDonGoal" runat="server" Text=<%# Eval("donationGoal") %>></asp:Label></i><br />
                            <asp:LinkButton ID="btnLearnMore" class="btn btn-primary mt-2" Text="Learn More" CommandName="LearnMore" CommandArgument='<%# Eval("Id") %>' runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <asp:GridView ID="GvDonation"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvDonation_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="organisedBy" HeaderText="Organised By" />
                <asp:BoundField DataField="name" HeaderText="Fundraiser Title" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="donationGoal" HeaderText="Donation Goal" />
                <asp:BoundField DataField="category" HeaderText="Category" />
                <asp:ButtonField CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Select" />
            </Columns>
        </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
