<%@ Page Title="Your Events" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="userevent.aspx.cs" Inherits="Shimmer.userevent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Views/index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="/Views/Event/events.aspx">Events</a></li>
            <li class="breadcrumb-item active">
                <asp:Label ID="lbBreadcrumbCurrent" runat="server" Text="Your Events"></asp:Label>
            </li>
        </ol>
    </nav>
    <ul class="nav nav-tabs nav-justified" id="eventTab" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" id="Open-tab" data-toggle="tab" href="#Open" role="tab" aria-controls="Open" aria-selected="true">Open Events</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="Closed-tab" data-toggle="tab" href="#Closed" role="tab" aria-controls="Closed" aria-selected="false">Closed Events</a>
        </li>
    </ul>
    <div class="tab-content" id="eventTabContent">

        <div class="tab-pane fade show active" id="Open" role="tabpanel" aria-labelledby="Open-tab">
            <asp:Repeater ID="eventOpenRepeater" runat="server" DataSourceID="eventOpenSqlDataSource">
                <ItemTemplate>
                    <div class="row mb-3 border m-0">
                        <div class="col-4">
                            <asp:Image ID="imgEventImage" ImageUrl='<%#"/Public/Image/Uploads/"+ Eval("eventImage") %>' CssClass="rounded" Width="175" Height="175" runat="server" />
                        </div>
                        <div class="col-4 my-auto">
                            <asp:Label ID="lbEventName" runat="server" Text='<%# Eval("eventName") %>' Font-Bold="True" Font-Size="Larger"></asp:Label>
                            <br />
                            <i class="far fa-calendar">
                                <asp:Label ID="lbHeadingDate" runat="server" Text="Date:"></asp:Label>
                                <asp:Label ID="lbEventDate" runat="server" Text='<%# string.Format("{0:dd/MM/yyyy }", Eval("eventStartDateTime"))%>'></asp:Label></i><br />
                            <i class="far fa-clock">
                                <asp:Label ID="lbHeadingTime" runat="server" Text="Time:"></asp:Label>
                                <asp:Label ID="lbEventTime" runat="server" Text='<%# string.Format("{0:hh:mm tt }", Eval("eventStartDateTime"))%>'></asp:Label></i><br />
                            <i class="far fa-hourglass">
                                <asp:Label ID="lbHeadingDuration" runat="server" Text="Duration:"></asp:Label>
                                <asp:Label ID="lbEventDuration" runat="server" Text='<%# " "+Eval("eventDuration") %>'></asp:Label></i><br />
                            <i class="far fa-compass">
                                <asp:Label ID="lbHeadingLocation" runat="server" Text="Location:"></asp:Label>
                                <asp:Label ID="lbEventLocation" runat="server" Text='<%# Eval("eventLocation") %>'></asp:Label></i><br />
                        </div>
                        <div class="col-4 text-center my-auto">
                            <asp:Label ID="lbHeadingUserStatus" runat="server" Text="Status:"></asp:Label>
                            <asp:Label ID="lbEventUserStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                            <a href="viewevent.aspx?eventid=<%# Eval("Id") %>" class="btn btn-primary">Event information</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:SqlDataSource ID="eventOpenSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM Event INNER JOIN EventAssociation ON Event.Id = EventAssociation.eventId WHERE (EventAssociation.userId = @paraUserId) AND (Event.eventStatus = 1)">
                <SelectParameters>
                    <asp:SessionParameter Name="paraUserId" SessionField="userId" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
        <div class="tab-pane fade" id="Closed" role="tabpanel" aria-labelledby="Closed-tab">
            <asp:Repeater ID="eventClosedRepeater" runat="server" DataSourceID="eventClosedSqlDataSource">
                <ItemTemplate>
                    <div class="row mb-3 border m-0">
                        <div class="col-4">
                            <asp:Image ID="imgEventImage" ImageUrl='<%#"/Public/Image/Uploads/"+ Eval("eventImage") %>' CssClass="rounded" Width="175" Height="175" runat="server" />
                        </div>
                        <div class="col-4 my-auto">
                            <asp:Label ID="lbEventName" runat="server" Text='<%# Eval("eventName") %>' Font-Bold="True" Font-Size="Larger"></asp:Label>
                            <br />
                            <i class="far fa-calendar">
                                <asp:Label ID="lbHeadingDate" runat="server" Text="Date:"></asp:Label>
                                <asp:Label ID="lbEventDate" runat="server" Text='<%# string.Format("{0:dd/MM/yyyy }", Eval("eventStartDateTime"))%>'></asp:Label></i><br />
                            <i class="far fa-clock">
                                <asp:Label ID="lbHeadingTime" runat="server" Text="Time:"></asp:Label>
                                <asp:Label ID="lbEventTime" runat="server" Text='<%# string.Format("{0:hh:mm tt }", Eval("eventStartDateTime"))%>'></asp:Label></i><br />
                            <i class="far fa-hourglass">
                                <asp:Label ID="lbHeadingDuration" runat="server" Text="Duration:"></asp:Label>
                                <asp:Label ID="lbEventDuration" runat="server" Text='<%# " "+Eval("eventDuration") %>'></asp:Label></i><br />
                            <i class="far fa-compass">
                                <asp:Label ID="lbHeadingLocation" runat="server" Text="Location:"></asp:Label>
                                <asp:Label ID="lbEventLocation" runat="server" Text='<%# Eval("eventLocation") %>'></asp:Label></i><br />
                        </div>
                        <div class="col-4 text-center my-auto">
                            <asp:Label ID="lbHeadingUserStatus" runat="server" Text="Status:"></asp:Label>
                            <asp:Label ID="lbEventUserStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                            <a href="viewevent.aspx?eventid=<%# Eval("Id") %>" class="btn btn-primary">Event information</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:SqlDataSource ID="eventClosedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM Event INNER JOIN EventAssociation ON Event.Id = EventAssociation.eventId WHERE (EventAssociation.userId = @paraUserId) AND (Event.eventStatus = 0)">
                <SelectParameters>
                    <asp:SessionParameter Name="paraUserId" SessionField="userId" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
