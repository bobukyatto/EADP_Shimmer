<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="viewevent.aspx.cs" Inherits="Shimmer.viewevent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="events.aspx">Events</a></li>
            <li class="breadcrumb-item active">
                <asp:Label ID="lbBreadcrumbCurrent" runat="server" Text=""></asp:Label>
            </li>
        </ol>
    </nav>
    <div class="row">
        <div class="col-sm-8">
            <asp:Image ID="imgEventImage" CssClass="img-fluid w-100 rounded mb-1" runat="server" />
        </div>
        <div class="col">
            <div class="row pb-4">
                <div class="col-12">
                    <h3><asp:Label ID="lbEventName" runat="server" Text="" Font-Bold="True"></asp:Label><br /></h3>
                    
                </div>
                <div class="col-12 ml-4">
                    <asp:Label ID="lbHeadingOrganizedBy" runat="server" Text="Organized By: "></asp:Label>
                    <asp:Label ID="lbEventOrganizedBy" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-1">
                    <i class="far fa-calendar"></i>
                </div>
                <div class="col-11">
                    <asp:Label ID="lbEventDate" runat="server" Text=""></asp:Label>
                </div>
                    

                

            </div>
            <div class="row">
                <div class="col-1">
                    <i class="far fa-clock"></i>
                </div>
                <div class="col-11">
                    <asp:Label ID="lbEventTime" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <i class="far fa-hourglass"></i>
                </div>
                <div class="col-11">
                    <asp:Label ID="lbEventDuration" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-1">
                    <i class="far fa-compass"></i>
                </div>
                <div class="col-11">
                    <asp:HyperLink ID="hlEventLocation" runat="server" Text=""></asp:HyperLink>
                    
                </div>
                
            </div>
            <div class="row mb-4 pr-3">
                <asp:ImageButton ID="imgbtnEventMap" CssClass="card-img-top rounded" runat="server" OnClick="imgbtnEventMap_Click" />
            </div>
            <div class="row text-center pr-3">
                <asp:Button ID="btnJoinEvent" runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Join Event" OnClick="btnJoinEvent_Click" />
                <asp:Button ID="btnLeaveEvent" runat="server" CssClass="btn btn-danger btn-lg btn-block" Text="Leave Event" OnClick="btnLeaveEvent_Click"  />
            </div>

        </div>
    </div>
    <div class="row p-3">
        <asp:Label ID="lbHeadingDescription" runat="server" Text="About the event" Font-Bold="True" Font-Size="Larger"></asp:Label>
       
        
    </div>
    <div class="row p-3">
         <asp:Label ID="lbEventDescription" runat="server" Text=""></asp:Label>
        <hr />
    </div>

    <br />
    <asp:Label ID="lbTest" runat="server" Text="Test"></asp:Label>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">
                    <asp:Label ID="lbHeadingName" runat="server" Text="Name"></asp:Label>
                </th>
                <td>
                    
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">
                    
                </th>
                <td>
                    descr
                </td>
            </tr>
            <tr>
                <th scope="row">
                    <asp:Label ID="lbHeadingMinAttendee" runat="server" Text="Minimum attendees required for the event"></asp:Label>
                </th>
                <td>
                    <asp:Label ID="lbEventMinAttendee" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <th scope="row">
                    <asp:Label ID="lbHeadingCurrentAttendee" runat="server" Text="Current attendees signed up for the event"></asp:Label>
                </th>
                <td>
                    <asp:Label ID="lbEventCurrentAttendee" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <p>
    </p>

</asp:Content>
