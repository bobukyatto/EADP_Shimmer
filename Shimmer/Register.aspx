<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Shimmer.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Register</title>
    <link href="Stylesheet/register.css" rel="stylesheet" />
     <style type="text/css">
         .auto-style1 {
             float: left;
             width: 48%;
             padding: 10px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="sec2">
        <div class="container">
            <h2>Registraion</h2>
            <div class="content">
                <div class="row">
                    <div class="auto-style1">
                        <h2>Public</h2>
                        <asp:Image class="image" ID="publicPhoto" runat="server" ImageUrl="~/Image/publicPhoto.png" Height="420px" Width="415px" />
                        <p>
                            By registering as a public user, you will be able to take part in events, donate, etc.
                        </p>
                        <asp:Button class="button" ID="publicRegister" runat="server" Text="Register" OnClick="publicRegister_Click" />
                    </div>
                    <div class="column">
                        <h2>Organization</h2>
                        <asp:Image class="image" ID="orgPhoto" runat="server" ImageUrl="~/Image/orgPhoto.png" Height="440px" Width="423px" />
                        <p>
                            By registering as an organization user, you will be able to put up your organization's events, 
                            donation, etc.
                        </p>
                        <asp:Button class="button" ID="orgRegister" runat="server" Text="Register" OnClick="orgRegister_Click" />
                    </div>
                </div>
                
               
               
            </div>
        </div>
    </div>
</asp:Content>
