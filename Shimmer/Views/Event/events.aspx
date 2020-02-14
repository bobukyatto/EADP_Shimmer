<%@ Page Title="Events" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="Shimmer.events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="events.aspx">Events</a></li>
        </ol>
    </nav>

    <div class="row">
        <asp:Button ID="btnCreateEvent" runat="server" CssClass="btn btn-success btn-lg mx-auto" Text="Create Event" OnClick="btnCreateEvent_Click" />
    </div>
    <div class="row p-3">
        <asp:Label ID="lbHeading" runat="server" Text="Current events" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbEmpty" runat="server" CssClass="mx-auto" Text=""></asp:Label>

        <asp:Label ID="lbSortBy" runat="server" CssClass="float-right pr-2 pt-2" Text="Sort By:"></asp:Label>
        <asp:DropDownList ID="ddlSort" CssClass="float-right col-2 form-control" runat="server" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True">Recent</asp:ListItem>
            <asp:ListItem>Upcoming</asp:ListItem>
            <asp:ListItem>Duration (Short)</asp:ListItem>
            <asp:ListItem>Duration (Long)</asp:ListItem>
            <asp:ListItem>Ended</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="row">
        <asp:Repeater ID="eventRepeater" runat="server" DataSourceID="eventDataSource">
            <ItemTemplate>
                <div class="col-4 h-100 mb-5">
                    <div class="card">
                        <img src="/Public/Image/Uploads/<%# Eval("eventImage") %>" class="card-img-top" alt="..." height="250">
                        <div class="card-body text-center bg-gray-100 shadow ">
                            <asp:Label ID="lbEventName" runat="server" Text='<%# Eval("eventName") %>' Font-Bold="True"></asp:Label>
                            <p class="card-text"><small class="text-muted">By <%# Eval("fullName") %></small></p>
                            <i class="far fa-calendar">
                                <asp:Label ID="lbEventDate" runat="server" Text='<%# string.Format("{0:dd/MM/yyyy }", Eval("eventStartDateTime"))%>'></asp:Label></i><br />
                            <i class="far fa-clock">
                                <asp:Label ID="lbEventTime" runat="server" Text='<%# string.Format("{0:hh:mm tt }", Eval("eventStartDateTime"))%>'></asp:Label></i><br />

                            <i class="far fa-hourglass">
                                <asp:Label ID="lbEventDuration" runat="server" Text='<%# " "+Eval("eventDuration") %>'></asp:Label></i><br />
                            <i class="far fa-compass">
                                <asp:Label ID="lbEventLocation" runat="server" Text='<%# Eval("eventLocation") %>'></asp:Label></i><br />
                            <a href="viewevent.aspx?eventid=<%# Eval("Id") %>" class="btn btn-info mt-2">More information</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:SqlDataSource ID="eventDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM Event INNER JOIN Account ON Event.eventOrganizedBy = Account.Id WHERE (Event.eventStatus = @eventStatus) ORDER BY Event.Id DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="eventStatus" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p>
    </p>
</asp:Content>
