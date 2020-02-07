using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;

namespace Shimmer
{
    public partial class viewevent : System.Web.UI.Page
    {
        //declare public vars
        string eventid;
        Event eventobj;
        int currentUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // google maps api
            string APIKeyPart1 = "AIzaSyCWLbnx9H1I-";
            string APIKeyPart2 = "HnwzHh9kbL8PyZvYGJydiQ";
            if (Session["userId"] is null)
            {
                
            }
            else
            {
                currentUserId = int.Parse(Session["userId"].ToString());
            }

            btnLeaveEvent.Visible = false;
            eventid = Request.QueryString["eventid"];
            if (eventid != null)
            {
                eventobj = new Event().GetEventById(int.Parse(eventid));
                if (eventobj is null || eventobj.Status != 1) // check if event obj is present with the status of 1
                {
                    Response.Redirect("events.aspx");
                }
                lbBreadcrumbCurrent.Text = eventobj.Name;
                lbEventName.Text = eventobj.Name;
                lbEventDescription.Text = eventobj.Description;
                //lbEventMinAttendee.Text = (eventobj.MinimumAttendee).ToString();
                lbEventOrganizedBy.Text = (eventobj.OrganizedBy).ToString();
                lbEventDate.Text = Convert.ToDateTime(eventobj.StartDateTime).ToString("dddd, dd MMMM yyyy");
                lbEventTime.Text = Convert.ToDateTime(eventobj.StartDateTime).ToString("hh:mm tt");

                string[] hourMinutesArray = eventobj.Duration.Split(':');

                if (hourMinutesArray[0] == "00")
                {
                    lbEventDuration.Text = hourMinutesArray[1] + " Minutes";
                }
                else if (hourMinutesArray[1] == "00")
                {
                    lbEventDuration.Text = hourMinutesArray[0] + " Hours";
                }
                else
                {
                    lbEventDuration.Text = hourMinutesArray[0] + " Hours and " + hourMinutesArray[1] + " Minutes";
                }

                hlEventLocation.Text = eventobj.Location;
                hlEventLocation.NavigateUrl = "https://www.google.com/maps/search/?api=1&query=" + eventobj.Location;
                imgbtnEventMap.ImageUrl = "https://maps.googleapis.com/maps/api/staticmap?center="+"Singapore "+eventobj.Location+"&zoom=17&size=600x300&key="+APIKeyPart1+APIKeyPart2;

                if (String.IsNullOrEmpty(eventobj.Image) )
                {
                    imgEventImage.ImageUrl = "../../Public/Image/default.jpg";
                }
                else
                {

                    imgEventImage.ImageUrl = "../../Public/Image/Uploads/" + eventobj.Image;
                }

                
                int confirmedAttendee = 0;
                List<Event.eventAssociation> eventAssociationList = eventobj.GetAllEventAssociationById(int.Parse(eventid));
                //todo create list of users to display  .done

                for (int i = 0; i< eventAssociationList.Count; i++)
                {
                    
                    if (eventAssociationList[i].Status == 1)
                    {
                        confirmedAttendee += 1;
                    }
                    if (Session["userId"] is null)
                    {

                    }
                    else
                    {
                        if (eventAssociationList[i].UserId == currentUserId && eventAssociationList[i].Status >= 0)// todo change this to current user .done
                        {
                            btnJoinEvent.Visible = false;
                            btnLeaveEvent.Visible = true;
                        }
                    }
                    

                }

                lbEventConfirmedAttendee.Text = " "+confirmedAttendee.ToString();


            }
            else
            {
                Response.Redirect("events.aspx");
            }
        }

        protected void imgbtnEventMap_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.google.com/maps/search/?api=1&query="+eventobj.Location);
        }

        protected void btnJoinEvent_Click(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                Response.Redirect("Login.aspx");
            }
            //check if user had already joined
            List<Event.eventAssociation> eventAssociationList = eventobj.GetAllEventAssociationById(int.Parse(eventid));
            for (int i = 0; i < eventAssociationList.Count; i++)
            {

                if (eventAssociationList[i].UserId == currentUserId)
                {
                    eventobj.UserReJoinEvent(int.Parse(eventid), currentUserId);
                    Response.Redirect("events.aspx");
                }

                


            }

            if (eventobj.UserJoinEvent(int.Parse(eventid), currentUserId) == 1)
            {
                //success, todo have some popup
                Response.Redirect("events.aspx");
            }
            else
            {
                //fail
            }

            // if empty list 
            if (!eventAssociationList.Any())
            {
                
            }

            
        }

        protected void btnLeaveEvent_Click(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                Response.Redirect("Login.aspx");
            }
            //todo change 1 to current user
            eventobj.UserLeaveEvent(int.Parse(eventid), currentUserId);
            Response.Redirect("events.aspx");
        }
    }
}