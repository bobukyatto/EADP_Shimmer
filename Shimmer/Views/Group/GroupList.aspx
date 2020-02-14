<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="Shimmer.GroupList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid pt-5 pb-3 border-bottom px-lg-5">
      <div class="row">
        <div class="col-xl-8">
          <h1>Look for your ideal groups</h1>
          <p class="lead text-muted">You can join multiple group to participate into many events without worry of no friends to work with.</p>
        </div>
      </div>
    </div>
    <div class="container-fluid py-5 px-lg-5">
      <div class="row">
        <div class="col-lg-3 pt-3">
            <div class="mb-4">
              <label for="form_dates" class="form-label">Name</label>
              <div class="datepicker-container datepicker-container-left">
                  <asp:TextBox ID="name" CssClass="form-control" placeholder="Search by name" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="mb-4">
              <label class="form-label">Availability</label>
              <ul class="list-inline mb-0 mt-1">
                <li class="list-inline-item mb-2">
                  <div class="custom-control custom-switch">
                    <input type="checkbox" class="custom-control-input" runat="server" id="available" ClientIDMode="static">
                    <label for="available" class="custom-control-label"> <span class="text-sm">Show Available Group Only</span></label>
                  </div>
                    <div class="custom-control custom-switch">
                    <input id="instantJoin" type="checkbox" runat="server" class="custom-control-input" ClientIDMode="static">
                    <label for="instantJoin" class="custom-control-label"> <span class="text-sm">Instant Join</span></label>
                  </div>
                </li>
              </ul>
            </div>
            <div class="mb-4">
                <asp:LinkButton ID="filter" CssClass="btn btn-primary" OnClick="filter_Click" runat="server"><i class="fas fa-filter mr-1"></i>Filter</asp:LinkButton>
              </div>
        </div>
        <div class="col-lg-9">
          <div class="d-flex justify-content-between align-items-center flex-column flex-md-row mb-4">
            <div class="mr-3">
              <p class="mb-3 mb-md-0"><strong runat="server" id="itemCount"></strong> results found</p>
            </div>
            <div>
              <label for="form_sort" class="form-label mr-2">Sort by</label>
                <asp:DropDownList OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" ID="DropDownList1" data-style="btn-selectpicker" CssClass="selectpicker" runat="server">
                    <asp:ListItem Selected="True" Value="0">Default</asp:ListItem>
                    <asp:ListItem Value="1">Most Recent</asp:ListItem>
                    <asp:ListItem Value="2">Most Member</asp:ListItem>
                </asp:DropDownList>
            </div>
          </div>
            <!-- place item-->
              <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                  <ItemTemplate>
                      <div class="col-sm-6 col-xl-4 mb-5 hover-animate">
              <div class="card h-100 border-0 shadow">
                <div class="card-img-top overflow-hidden gradient-overlay" style="max-height:250px"> <img src='<%# GetImage(Eval("Image").ToString()) %>' class="img-fluid" />
                  <div class="card-img-overlay-bottom z-index-20">
                    <div class="media text-white text-sm align-items-center"><img src='<%# GetLeaderImage(Convert.ToInt32(Eval("Leader"))) %>' alt="Barbora" class="avatar avatar-border-white mr-2"/>
                      <div class="media-body"><%# GetLeaderName(Convert.ToInt32(Eval("Leader")))%></div>
                    </div>
                  </div>
                </div>
                <div class="card-body d-flex align-items-center">
                  <div class="w-100">
                    <h6 class="card-title"><a href='./GroupDetail.aspx?id=<%#Eval("Id") %>' class="text-decoration-none text-dark"><%#Eval("Name") %></a></h6>
                    <div class="d-flex card-subtitle mb-3">
                      <p class="flex-grow-1 mb-0 text-muted text-sm"><%# CheckAvailability(Convert.ToInt32(Eval("Available"))) %></p>
                      
                    </div>
                    <p class="card-text text-muted"><span class="h4 text-primary"><%#Eval("MemberNum") %></span> member</p>
                  </div>
                </div>
              </div>
            </div>
                  </ItemTemplate>
                  <LayoutTemplate>
                      <table runat="server">
                          <tr runat="server">
                              <td runat="server" class="row">
                                      <tr id="itemPlaceholder" runat="server">
                                      </tr>
                              </td>
                          </tr>
                      </table>
                  </LayoutTemplate>
              </asp:ListView>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM [Group]"></asp:SqlDataSource>
            
      </div>
    </div>
</asp:Content>
