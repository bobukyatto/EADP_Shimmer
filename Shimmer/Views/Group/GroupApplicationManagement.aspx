<%@ Page Title="" Language="C#" MasterPageFile="Index.Master" AutoEventWireup="true" CodeBehind="GroupApplicationManagement.aspx.cs" Inherits="Shimmer.GroupApplicationManagement" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="py-5">
      <div class="container">
        <!-- Breadcrumbs -->
        <ol class="breadcrumb pl-0  justify-content-start">
          <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
          <li class="breadcrumb-item active">Application Management   </li>
        </ol>
        <div class="d-flex justify-content-between align-items-end mb-5">
          <h1 class="hero-heading mb-0">Your nearest application</h1>
        </div>
        <div class="d-flex justify-content-between align-items-center flex-column flex-lg-row mb-5">
          <div class="mr-3">
            <p class="mb-3 mb-lg-0">You have <strong runat="server" id="appNo">12 applications</strong> pending</p>
          </div>
        </div>
          <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
              <HeaderTemplate>
                <div class="list-group shadow mb-5">
              </HeaderTemplate>
              <ItemTemplate>
                 <div class="list-group-item list-group-item-action p-4">
                <div class="row">
                  <div class="col-lg-4 align-self-center mb-4 mb-lg-0">
                    <div class="d-flex align-items-center mb-3">
                      <h2 class="h5 mb-0"><%# getApplicantName(Convert.ToInt32(Eval("Username"))) %></h2><img src='<%# getApplicantIcon(Convert.ToInt32(Eval("Username"))) %>' class="avatar avatar-sm avatar-border-white ml-3">
                    </div>
                    <span class="badge badge-pill p-2 badge-primary-light">Pending</span>
                  </div>
                  <div class="col-lg-8">
                    <div class="row">
                      <div class="col-6 col-md-4 col-lg-3 py-3 mb-3 mb-lg-0">
                        <h6 class="label-heading">Group Name</h6>
                        <p class="text-sm font-weight-bold"><%#getGroupName(Convert.ToInt32(Eval("GroupId"))) %></p>
                      </div>
                      <div class="col-6 col-md-8 col-lg-6 py-3">
                        <h6 class="label-heading">Reason</h6>
                        <p class="text-sm font-weight-bold"><%#Eval("Reason") %></p>
                      </div>
                      <div class="col-12 col-lg-3 align-self-center">
                          <asp:HiddenField ID="applicationId" Value='<%#Eval("Id") %>' Visible="false" runat="server" />
                          <asp:HiddenField ID="applicantId" Value='<%#Eval("Username") %>' Visible="false" runat="server" />
                          <asp:HiddenField ID="groupId" Value='<%#Eval("GroupId") %>' Visible="false" runat="server" />
                          <asp:LinkButton ID="Approve" OnClick="Approve_Click" CssClass="text-primary text-sm text-uppercase mr-4 mr-lg-0" runat="server"><i class="fa fa-check fa-fw mr-2"/> </i>Approve</asp:LinkButton>
                          <br class="d-none d-lg-block">
                          <asp:LinkButton ID="Reject" OnClick="Reject_Click" CssClass="text-primary text-sm text-uppercase" runat="server"><i class="fa fa-times fa-fw mr-2">  </i>Reject</asp:LinkButton>                      
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
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM [GroupApplication] WHERE (([Status] = @Status) AND ([GroupLeader] = @GroupLeader)) ORDER BY [Id] DESC">
              <SelectParameters>
                  <asp:Parameter DefaultValue="Pending" Name="Status" Type="String" />
                  <asp:SessionParameter SessionField="userId" Name="GroupLeader" Type="Int32"></asp:SessionParameter>
              </SelectParameters>
          </asp:SqlDataSource>
      </div>
    </section>
</asp:Content>
