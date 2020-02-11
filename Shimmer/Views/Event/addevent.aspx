<%@ Page Title="Create Event" Language="C#" MasterPageFile="~/Shimmer.Master" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="Shimmer.addevent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Views/index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="/Views/Event/events.aspx">Events</a></li>
            <li class="breadcrumb-item active">
                <asp:Label ID="lbBreadcrumbCurrent" runat="server" Text="Create Event"></asp:Label>
            </li>
        </ol>
    </nav>

    <div class="form-row mt-4">
        <div class="col-sm-12 pb-3">
            <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-5 pb-3">
            <asp:Label ID="lbEventName" runat="server" Text="Name of Event:"></asp:Label>
            <asp:TextBox ID="tbEventName" runat="server" CssClass="form-control" placeholder="Give your event a name!"></asp:TextBox>
        </div>
        <div class="col-sm-3 pb-3">
            <asp:Label ID="lbEventLocation" runat="server" Text="Address of Event"></asp:Label>
            <asp:TextBox ID="tbEventLocation" runat="server" CssClass="form-control" placeholder="10 Jalan Besar"></asp:TextBox>
        </div>
        <div class="col-sm-4 pb-3">
            <asp:Label ID="lbEventPostalCode" runat="server" Text="Postal Code of Event"></asp:Label>
            <asp:TextBox ID="tbEventPostalCode" runat="server" CssClass="form-control" placeholder="420123"></asp:TextBox>
        </div>

        <div class="col-sm-4 pb-3">
            <asp:Label ID="lbEventContactName" runat="server" Text="Contact Name for the Event"></asp:Label>
            <asp:TextBox ID="tbEventContactName" runat="server" CssClass="form-control" placeholder="Person in charge"></asp:TextBox>
        </div>
        <div class="col-sm-3 pb-3">
            <asp:Label ID="lbEventContactNumber" runat="server" Text="Contact Number for the Event"></asp:Label>
            <asp:TextBox ID="tbEventContactNumber" runat="server" CssClass="form-control" placeholder="8312 4311"></asp:TextBox>
        </div>
        <div class="col-sm-5 pb-3">
            <asp:Label ID="lbEventContactEmail" runat="server" Text="Contact Email for the event"></asp:Label>
            <asp:TextBox ID="tbEventContactEmail" runat="server" CssClass="form-control" placeholder="example@email.com"></asp:TextBox>
        </div>

        <div class="col-sm-2 pb-3">
            <asp:Label ID="lbMinAttendee" runat="server" Text="Minimum attendee"></asp:Label>
            <asp:TextBox ID="tbEventMinAttendee" runat="server" CssClass="form-control" value="0" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-sm-2 pb-3">
            <asp:Label ID="lbMaxAttendee" runat="server" Text="Maximum attendee"></asp:Label>
            <asp:TextBox ID="tbEventMaxAttendee" runat="server" CssClass="form-control" placeholder="50" TextMode="Number"></asp:TextBox>
        </div>

        <div class="col-sm-2 pb-3">
            <asp:Label ID="lbEventDate" runat="server" Text="Event Date"></asp:Label>
            <asp:TextBox ID="tbEventDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-sm-2 pb-3">
            <asp:Label ID="lbEventTime" runat="server" Text="Event Time"></asp:Label>
            <asp:TextBox ID="tbEventTime" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
        </div>
        <div class="col-sm-2 pb-3">
            <asp:Label ID="lbEventDurationHours" runat="server" Text="Event Duration (Hours)"></asp:Label>
            <asp:TextBox ID="tbEventDurationHours" runat="server" CssClass="form-control" placeholder="01 Hours"></asp:TextBox>
        </div>
        <div class="col-sm-2 pb-3">
            <asp:Label ID="lbEventDurationMinutes" runat="server" Text="Event Duration (Minutes)"></asp:Label>
            <asp:TextBox ID="tbEventDurationMinutes" runat="server" CssClass="form-control" placeholder="00 Minutes"></asp:TextBox>
        </div>


        <div class="col-md-12 pb-3">
            <asp:Label ID="lbEventDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="tbEventDescription" runat="server" CssClass="form-control" placeholder="Description of event" MaxLength="512" TextMode="MultiLine" Rows="10"></asp:TextBox>
        </div>
        <div class="col-md-12 pb-3">
        <asp:Label ID="lbEventImage" runat="server" Text="Event Image"></asp:Label>
            <div class="custom-file">
            
            <label class="custom-file-label" for="customFile">Choose file</label>
            <asp:FileUpload ID="fuImage" CssClass="custom-file-input" runat="server" />
        </div>
            </div>
        
        <div class="col-md-12 ">
            <asp:Button CssClass="btn btn-primary btn-lg float-right" ID="btnSubmit" runat="server" Text="Create Event" OnClick="btnSubmit_Click" />
        </div>
        <br />
        <br />
    </div>
    <br />

</asp:Content>
