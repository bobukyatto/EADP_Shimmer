<%@ Page Title="" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="userevent.aspx.cs" Inherits="Shimmer.userevent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <ul class="nav nav-tabs" id="eventTab" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Profile</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">Contact</a>
        </li>
    </ul>
    <div class="tab-content" id="eventTabContent">
        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="joinedEventSqlDataSource">
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
                            <asp:Label ID="lbEventUserStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label><br />
                            <a href="viewevent.aspx?eventid=<%# Eval("Id") %>" class="btn btn-primary">More information</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="joinedEventSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ShimmerConnectionString %>" SelectCommand="SELECT * FROM Event INNER JOIN EventAssociation ON Event.Id = EventAssociation.eventId WHERE (EventAssociation.userId = 1)"></asp:SqlDataSource>

        </div>
        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
            profile
        </div>
        <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
            contact
        </div>
    </div>
</asp:Content>
