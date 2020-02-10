<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="viewevent.aspx.cs" Inherits="Shimmer.viewevent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Views/index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="/Views/Event/events.aspx">Events</a></li>
            <li class="breadcrumb-item active">
                <asp:Label ID="lbBreadcrumbCurrent" runat="server" Text=""></asp:Label>
            </li>
        </ol>
    </nav>
    <div class="row">
        <div class="col-sm-8">
            <asp:Image ID="imgEventImage" CssClass="img-fluid w-100 rounded mb-1 max-height" runat="server" Height="475px" />
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
                <asp:Button ID="btnInfoEvent" runat="server" Text="Default" disabled/>
                <asp:Button ID="btnLeaveEvent" runat="server" CssClass="btn btn-danger btn-lg btn-block" Text="Leave Event" OnClick="btnLeaveEvent_Click"  />
            </div>
        </div>
    </div>
    <div class="row p-3">
        <asp:Label ID="lbHeadingDescription" runat="server" Text="About the event" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </div>
    <div class="row p-3 border-bottom">
         <asp:Label ID="lbEventDescription" runat="server" Text=""></asp:Label>
    </div>

    
    <div id="groupDiv" runat="server" class="row p-3 border-bottom">
        <div class="row p-3">
            <asp:Label ID="lbGroupHeading" runat="server" Text="Join as a group" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
        <div class="row p-3">
            <div class="col-6">
                <asp:Label ID="lbGroupList" runat="server" Text="Select Group:" Font-Bold="True" Font-Size="Larger"></asp:Label>
                <asp:DropDownList ID="ddlGroupList" CssClass="w-100" runat="server" DataSourceID="groupListSqlDataSource" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="groupListSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM [Group] WHERE ([Leader] = @Leader)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Leader" SessionField="userId" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-6 my-auto">
                <asp:Button ID="btnGroupJoinEvent" runat="server" CssClass="btn btn-primary " Text="Join Event as Group" OnClick="btnGroupJoinEvent_Click" />
                <asp:Button ID="btnGroupInfoEvent" runat="server" CssClass="btn btn-info" Text="Default" />
                <asp:Button ID="btnGroupLeaveEvent" runat="server" CssClass="btn btn-danger" Text="Leave Event as Group" />
            </div>
        </div>
    </div>


    <div class="row p-3">
        <asp:Label ID="lbHeadingConfirmedAttendee" runat="server" Text="Confirmed Attendees:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbEventConfirmedAttendee" CssClass="pl-2" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </div>
    <div class="row p-3">
        <asp:Repeater ID="repeaterConfirmedAttendees" runat="server" DataSourceID="attendeeDataSource">
            <ItemTemplate>
                <div class="m-2 p-2 border shadow text-center">
                    <asp:Image ID="imgConfirmedAttendees" ImageUrl=<%# "../../Public/Image/Uploads/"+ Eval("image") %> CssClass="img-thumbnail" runat="server" Height="75px" Width="75px" /><br />
                    <%# Eval("fullname") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="attendeeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT Account.fullname, Account.email, Account.password, Account.phoneno, Account.usertype, Account.Id, Account.image FROM Account INNER JOIN EventAssociation ON Account.Id = EventAssociation.userId WHERE (EventAssociation.status = @eventStatus) AND (EventAssociation.eventId = @eventId)">
            <SelectParameters>
                <asp:Parameter DefaultValue="Accepted" Name="eventStatus" ConvertEmptyStringToNull="False" />
                <asp:QueryStringParameter DefaultValue="1" Name="eventId" QueryStringField="eventid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
