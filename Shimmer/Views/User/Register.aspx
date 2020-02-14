<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Shimmer.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Register</title>
    <link href="/Public/CSS/register.css" rel="stylesheet" />
     <style type="text/css">
         .auto-style1 {
             float: left;
             width: 48%;
             padding: 10px;
         }
     </style>
     <link href="/Public/CSS/style.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="sec2">
         <h2>Registraion</h2>
        <div class="container">
           
            <div class="content">
                <div class="row form-block">
                    <div class="col-lg-5">
                        <h2 class="align-content-center">Public</h2>
                        <asp:Image class="image" ID="publicPhoto" runat="server" ImageUrl="~/Public/Image/publicPhoto.png" Height="60%" Width="100%" />
                        <p>
                            By registering as a public user, you will be able to take part in events, donate, etc.
                        </p>
                        <asp:Button class="button" ID="publicRegister" CssClass="btn btn-outline-success" runat="server" Text="Register" OnClick="publicRegister_Click" />
                    </div>

                    <div class="col-lg-2"></div>

                    <div class="col-lg-5">
                        <h2 class="align-content-center">Organization</h2>
                        <asp:Image class="image" ID="orgPhoto" runat="server" ImageUrl="~/Public/Image/orgPhoto.png" Height="60%" Width="100%" />
                        <p>
                            By registering as an organization user, you will be able to put up your organization's events, 
                            donation, etc.
                        </p>
                        <asp:Button class="button" CssClass="btn btn-outline-success" ID="orgRegister" runat="server" Text="Register" OnClick="orgRegister_Click" />
                    </div>
                </div>
                
               
               
            </div>
           
        </div>
    </div>
</asp:Content>
