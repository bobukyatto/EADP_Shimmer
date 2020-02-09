<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Shimmer.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="mt-n5">
        <section style="background-image: url(/Public/Image/indexbg.jpg);" class="d-flex align-items-center dark-overlay bg-cover">
      <div class="container py-6 py-lg-7 text-white overlay-content text-center"> 
        <div class="row">
          <div class="col-xl-10 mx-auto">
            <h1 class="display-3 font-weight-bold text-shadow">Shimmers</h1>
            <p class="text-lg text-shadow">The smallest act of kindness is worth more than the grandest action.</p>
          </div>
        </div>
      </div>
    </section>
    <section class="py-6" runat="server" id="groupSection">
      <div class="container">
        <div class="row mb-5">
          <div class="col-md-8">
            <p class="subtitle text-secondary">My Groups</p>
          </div>
        </div>
          </div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate>
            <div class="container-fluid">
              <div class="swiper-container swiper-container-mx-negative items-slider-full px-lg-5 pt-3">
              <!-- Additional required wrapper-->
              <div class="swiper-wrapper pb-5">
            </HeaderTemplate>
            <ItemTemplate>
        <!-- Slides-->
                    <a href='GroupDetail.aspx?id=<%#Eval("GroupId") %>' class="swiper-slide h-auto px-2">
                      <!-- venue item-->
                      <div class="w-100 h-100 hover-animate">
                        <div class="card h-100 border-0 shadow">
                          <div style="background-image: url(/Public/Image/indexRestaurant.jpg); min-height: 200px;" class="card-img-top overflow-hidden dark-overlay bg-cover">
                            <div class="card-img-overlay-bottom z-index-20">
                              <h4 class="text-white text-shadow"><%#getGroupName(Convert.ToInt32(Eval("GroupId"))) %></h4>
                            </div>
                          </div>
                        </div>
                      </div>
                        </a>

            </ItemTemplate>
            <FooterTemplate>
                </div>
                </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ShimmerConnectionString %>' SelectCommand="SELECT * FROM [GroupMember] WHERE ([Username] = @Username)">
            <SelectParameters>
                <asp:SessionParameter SessionField="Username" Name="Username" Type="Int32"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        
            
            
    </section>
    </div>
    
</asp:Content>
