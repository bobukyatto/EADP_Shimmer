<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shimmer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 241px;
        }
    </style>
    <link href="../../Public/CSS/style.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <div class="container-fluid px-6">

          
          <div class="w-100 py-5 px-md-5 px-xl-6 position-relative">
            
              <h3>Welcome back</h3>
            </div>
            
              
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="TbEmailLogin" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style2">Password:</td>
            <td>
                <asp:TextBox ID="TbPassLogin" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="BtnLogin" cssClass="btn btn-outline-success" runat="server" Text="Login" OnClick="BtnLogin_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Label ID="lblMsgLogin" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        <p class="text-center"><small class="text-muted text-center">Don't have an account yet? <a href="Register.aspx">Sign Up                </a></small></p>
                  </div>
</asp:Content>
