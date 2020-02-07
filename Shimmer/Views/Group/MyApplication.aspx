<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="MyApplication.aspx.cs" Inherits="Shimmer.MyApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="py-5">
      <div class="container">
        <!-- Breadcrumbs -->
        <ol class="breadcrumb pl-0  justify-content-start">
          <li class="breadcrumb-item"><a href="Index.aspx">Home</a></li>
          <li class="breadcrumb-item active">My Application   </li>
        </ol>
        <h1 class="hero-heading mb-4">My pending application</h1>
          <div runat="server" id="noPending" visible="false">
        <p class="text-muted mb-5">You have no application that is currently pending.</p>
        <p class="mb-6"> <img src="img/illustration/undraw_trip_dv9f.svg" alt="" style="width: 400px;" class="img-fluid"></p>
          </div>
          <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
              <HeaderTemplate>
                  <div class="row">
              </HeaderTemplate>
              <ItemTemplate>
                  <div class="col-xl-3 col-md-4 col-sm-6 mb-5">
            <div class="card h-100 border-0 shadow">
              <div class="card-img-t op overflow-hidden" style="max-height:250px"><img src='<%# getApplicationImage(Convert.ToInt32(Eval("GroupId"))) %>' class="img-fluid"/></div>
              <div class="card-body d-flex align-items-center">
                <div class="w-100">
                  <h6 class="card-title"><a href='./GroupDetail.aspx?id=<%#Eval("GroupId") %>' class="text-decoration-none text-dark"><%# getApplicationName(Convert.ToInt32(Eval("GroupId"))) %></a></h6>
                  <div class="d-flex card-subtitle mb-3">
                    <p class="flex-grow-1 mb-0 text-muted text-sm">Pending</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
              </ItemTemplate>
              <FooterTemplate>
                  </div>
              </FooterTemplate>
          </asp:Repeater>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM [GroupApplication] WHERE (([Status] = @Status) AND ([Username] = @Username)) ORDER BY [Id] DESC">
              <SelectParameters>
                  <asp:Parameter DefaultValue="Pending" Name="Status" Type="String" />
                  <asp:SessionParameter SessionField="Username" Name="Username" Type="String"></asp:SessionParameter>
              </SelectParameters>
          </asp:SqlDataSource>
        <h2 class="mb-5">My past application</h2>
          <div runat="server" id="noPast" visible="false">
        <p class="text-muted mb-5">You have no past application.</p>
        <p class="mb-6"> <img src="img/illustration/undraw_trip_dv9f.svg" alt="" style="width: 400px;" class="img-fluid"></p>
          </div>
          <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
              <HeaderTemplate>
                  <div class="row">
              </HeaderTemplate>
              <ItemTemplate>
                  <div class="col-xl-3 col-md-4 col-sm-6 mb-5">
            <div class="card h-100 border-0 shadow">
              <div class="card-img-top overflow-hidden" style="max-height:250px"><img src='<%# getApplicationImage(Convert.ToInt32(Eval("GroupId"))) %>' class="img-fluid"/></div>
              <div class="card-body d-flex align-items-center">
                <div class="w-100">
                  <h6 class="card-title"><a href='./GroupDetail.aspx?id=<%#Eval("GroupId") %>' class="text-decoration-none text-dark"><%# getApplicationName(Convert.ToInt32(Eval("GroupId"))) %></a></h6>
                  <div class="d-flex card-subtitle mb-3">
                    <p class="flex-grow-1 mb-0 text-muted text-sm"><%# Eval("Status") %></p>
                  </div>
                </div>
              </div>
            </div>
          </div>
              </ItemTemplate>
              <FooterTemplate>
                  </div>
              </FooterTemplate>
          </asp:Repeater>
          <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ShimmerConnectionString %>' SelectCommand="SELECT * FROM [GroupApplication] WHERE (([Status] <> @Status) AND ([Username] = @Username)) ORDER BY [Id] DESC">
              <SelectParameters>
                  <asp:Parameter DefaultValue="Pending" Name="Status" Type="String"></asp:Parameter>
                  <asp:SessionParameter SessionField="Username" Name="Username" Type="String"></asp:SessionParameter>
              </SelectParameters>
          </asp:SqlDataSource>
      </div>
    </section>
</asp:Content>
