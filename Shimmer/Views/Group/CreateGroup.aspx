<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="Shimmer.CreateGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="py-5">
      <div class="container">
        <p class="subtitle text-primary">Add new group</p>
        <h1 class="h2 mb-5"> Basic information <span class="text-muted float-right">Create Group</span>      </h1>
          <div class="row form-block">
            <div class="col-lg-4">
              <h4>Basic</h4>
              <p class="text-muted text-sm">Compulsory information about your group.</p>
            </div>
            <div class="col-lg-7 ml-auto">
              <div class="form-group"></div>
              <div class="form-group">
                <label for="form_name" class="form-label">Group Name</label>
                  <asp:TextBox ID="groupName" CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="groupName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
              </div>
              <div class="form-group">
                <label for="form_type" class="form-label">Maximum members available</label>
                  <asp:TextBox ID="maxNo" CssClass="form-control" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="maxNo"></asp:RequiredFieldValidator>
              </div>
              <div class="form-group" >
                <label class="form-label">Do you want to enable auto-approve for this group?</label>
                <div class="custom-control custom-radio" >
                    <input type="radio" id="RadioButton1" runat="server" name="guests" class="custom-control-input" ClientIDMode="static">
                  <label for="RadioButton1" class="custom-control-label">Yes, all members are feeling free to join.</label>
                </div>
                <div class="custom-control custom-radio" >
                    <input type="radio" id="RadioButton2" runat="server" name="guests" class="custom-control-input" ClientIDMode="static">
                    <label for="RadioButton2" class="custom-control-label">No, members can only get in the group after I approve their applications.</label>
                </div>
              </div>
            </div>
          </div>
          <div class="row form-block">
            <div class="col-lg-4">
              <h4>Detail(Optional)</h4>
              <p class="text-muted text-sm">More details about the group, these information will be shown to all of the users.</p>
            </div>
            <div class="col-lg-7 ml-auto">
              <div class="form-group">
                <label for="form_street" class="form-label">Group Image</label>
                  <label class="form-label">
                      <span class="btn btn-light mb-2"><strong>Upload Image</strong></span>
                  <asp:FileUpload ID="imgUpload" runat="server" AllowMultiple="false" style="opacity:0">
                  </asp:FileUpload>
                  </label>
              </div>
                <div class="form-group">
                <label for="form_description" class="form-label">Group Description</label>
                  <asp:TextBox ID="description" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="8"></asp:TextBox>
              </div>
            </div>
          </div>
          <div class="row form-block flex-column flex-sm-row">
            <div class="col text-center text-sm-left">
                <asp:Label ID="alert" Visible="false" CssClass="alert alert-secondary" runat="server"></asp:Label>
                <asp:Label ID="success" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
            </div>
            <div class="col text-center text-sm-right">
                <asp:LinkButton ID="Submit" OnClick="Submit_Click" CssClass="btn btn-primary px-3" runat="server">Create<i class="fa-chevron-right fa ml-2"></i></asp:LinkButton>
                </div>
          </div>
      </div>
    </section>
</asp:Content>
