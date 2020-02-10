<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="GroupDetail.aspx.cs" Inherits="Shimmer.GroupDetail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
      <div class="row">
        <div class="col-lg-8"> 
          <div class="text-block">
            <h1 runat="server" id="name"></h1>
              <p class="text-muted text-uppercase mb-4" runat="server" id="available"></p>
            <ul class="list-inline text-sm mb-4">
              <li class="list-inline-item mr-3"><i class="fa fa-users mr-1 text-secondary"></i> <asp:Label ID="memberNo" runat="server" ></asp:Label></li>
            </ul>
            <p class="text-muted font-weight-light" runat="server" id="description"></p>
            </div>
          <div class="text-block">
            <div class="media"><img src="img/avatar/avatar-10.jpg" runat="server" id="leaderIcon" class="avatar avatar-lg mr-4">
              <div class="media-body">
                <p> <span class="text-muted text-uppercase text-sm">Created by </span><br><strong runat="server" id="leader"></strong></p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-lg-4">
          <div style="top: 100px;" class="p-4 shadow ml-lg-4 rounded sticky-top" runat="server" id="applySection">
            <p class="text-muted"><span class="text-primary h2">Join US now!</span></p>
            <hr class="my-4">
              <div class="form-group" runat="server" id="reasonSection">
                <label for="bookingDate" class="form-label">Your reason *</label>
                <div class="datepicker-container datepicker-container-right">
                    <asp:TextBox ID="reason" placeholder="State Your Reason" TextMode="MultiLine" Rows="5" required="required" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="form-group">
                  <asp:Button ID="apply" CssClass="btn btn-primary btn-block" OnClick="apply_Click" runat="server" Text="Apply" />
              </div>
          </div>
            <div class="card border-0 shadow mb-5" runat="server" visible="false" id="recordSection">
                <div class="card-header bg-gray-100 py-4 border-0">
                  <div class="media align-items-center">
                    <div class="media-body">
                      <p class="subtitle text-sm text-primary">Group Record</p>
                    </div>
                  </div>
                </div>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
                    <HeaderTemplate>
                        <div class="card-body">
                  <table class="table text-sm mb-0">
                    <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                      <th class="pl-0 border-0"><%#Eval("Detail") %></th>
                      <td class="pr-0 text-right border-0"><%#Eval("OccurTime") %></td>
                    </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ShimmerConnectionString %>' SelectCommand="SELECT * FROM [GroupRecord] WHERE ([GroupID] = @GroupID) ORDER BY [Id] DESC">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="Id" Name="GroupID" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
              </div>
        </div>
      </div>
    </div>
    <div class="py-6 bg-gray-100"> 
      <div class="container">
        <h5 class="mb-0">Groups</h5>
        <p class="subtitle text-sm text-primary mb-4">You may also like         </p>
        <!-- Slider main container-->
        <div data-swiper="{&quot;slidesPerView&quot;:4,&quot;spaceBetween&quot;:20,&quot;loop&quot;:true,&quot;roundLengths&quot;:true,&quot;breakpoints&quot;:{&quot;1200&quot;:{&quot;slidesPerView&quot;:3},&quot;991&quot;:{&quot;slidesPerView&quot;:2},&quot;565&quot;:{&quot;slidesPerView&quot;:1}},&quot;pagination&quot;:{&quot;el&quot;:&quot;.swiper-pagination&quot;,&quot;clickable&quot;:true,&quot;dynamicBullets&quot;:true}}" class="swiper-container swiper-container-mx-negative swiper-init pt-3">
          <!-- Additional required wrapper-->
            <asp:Repeater ID="similar" runat="server" DataSourceID="SqlDataSource1">
                <HeaderTemplate>
                    <div class="swiper-wrapper pb-5">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="swiper-slide h-auto px-2">
              <!-- place item-->
              <div class="w-100 h-100 hover-animate" style="max-height:360px; max-width:360px">
                <div class="card h-100 border-0 shadow">
                  <div class="card-img-top overflow-hidden gradient-overlay" style="max-height:250px" "> <img src='<%# getGroupImg(Eval("Image").ToString()) %>'  class="img-fluid"/>
                    <div class="card-img-overlay-bottom z-index-20">
                      <div class="media text-white text-sm align-items-center"><img src='<%# getLeaderImg(Convert.ToInt32(Eval("Leader"))) %>' class="avatar avatar-border-white mr-2"/>
                        <div class="media-body"><%# getLeaderName(Convert.ToInt32(Eval("Leader"))) %></div>
                      </div>
                    </div>
                  </div>
                  <div class="card-body d-flex align-items-center">
                    <div class="w-100">
                      <h6 class="card-title"><%#Eval("Name") %></h6>
                      <a href='GroupDetail.aspx?id=<%#Eval("Id") %>' class="btn btn-primary btn-block">View</a>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM [Group] WHERE ([State] = @State)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="State" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
          <!-- If we need pagination-->
          <div class="swiper-pagination"></div>
        </div>
      </div>
    </div>
</asp:Content>
