using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;
using Twilio;
using Twilio.Rest.Api.V2010.Account;



namespace Shimmer
{
    public partial class editevent : System.Web.UI.Page
    {
        int currentUserId;
        string ini_location;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                Response.Redirect("/Views/User/Login.aspx");
            }
            else
            {
                currentUserId = int.Parse(Session["userId"].ToString());
            }

            string eventid = Request.QueryString["eventid"];
            if (eventid != null)
            {
                Event eventobj = new Event().GetEventById(int.Parse(eventid));
                if (eventobj is null) // todo check if owner or admin
                {
                    Response.Redirect("events.aspx");
                }
                else if (eventobj.OrganizedBy != currentUserId && Session["userType"].ToString() != "Admin")
                {
                    Response.Redirect("events.aspx");
                }
                if (!IsPostBack)
                {
                    if (String.IsNullOrEmpty(eventobj.Image))
                    {
                        imgEventImage.ImageUrl = "../../Public/Image/default.jpg";
                    }
                    else
                    {

                        imgEventImage.ImageUrl = "../../Public/Image/Uploads/" + eventobj.Image;
                    }
                    ini_location = eventobj.Location;
                    tbEventName.Text = eventobj.Name;
                    tbEventLocation.Text = eventobj.Location;
                    tbEventPostalCode.Text = eventobj.PostalCode;
                    tbEventContactName.Text = eventobj.ContactName;
                    tbEventContactNumber.Text = eventobj.ContactNumber;
                    tbEventContactEmail.Text = eventobj.ContactEmail;
                    tbEventMinAttendee.Text = eventobj.MinimumAttendee.ToString();
                    tbEventMaxAttendee.Text = eventobj.MaximumAttendee.ToString();
                    tbEventDate.Text = Convert.ToDateTime(eventobj.StartDateTime).ToString("yyyy-MM-dd");
                    tbEventTime.Text = Convert.ToDateTime(eventobj.StartDateTime).ToString("HH:MM");

                    string[] hourMinutesArray = eventobj.Duration.Split(':');
                    tbEventDurationHours.Text = hourMinutesArray[0];
                    tbEventDurationMinutes.Text = hourMinutesArray[1];
                    tbEventDescription.Text = eventobj.Description;
                }
                
            }
            else
            {
                Response.Redirect("events.aspx");
            }
        }


        private bool inputValidate()
        {
            bool result;
            if (String.IsNullOrEmpty(tbEventName.Text))
            {
                lbMessage.Text += "Name is required!" + "<br/>";
            }
            if (String.IsNullOrEmpty(tbEventDescription.Text))
            {
                lbMessage.Text += "Description is required!" + "<br/>";
            }
            if (String.IsNullOrEmpty(tbEventLocation.Text))
            {
                lbMessage.Text += "Event location is required!" + "<br/>";
            }
            if (String.IsNullOrEmpty(tbEventPostalCode.Text))
            {
                lbMessage.Text += "Postal code is required!" + "<br/>";
            }
            if (String.IsNullOrEmpty(tbEventContactName.Text))
            {
                lbMessage.Text += "Please enter the name of the person in charge" + "<br/>";
            }

            bool minAttenResult = int.TryParse(tbEventMinAttendee.Text, out int minAtten);
            bool maxAttenResult = int.TryParse(tbEventMaxAttendee.Text, out int maxAtten);

            if (minAttenResult && maxAttenResult)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int eventid = int.Parse(Request.QueryString["eventid"]);
            Event eventobj = new Event().GetEventById(eventid);

            if (inputValidate())
            {
                // check if name + date for duplicate later
                eventobj.Name = tbEventName.Text;
                eventobj.Description = tbEventDescription.Text;
                eventobj.Location = tbEventLocation.Text;
                eventobj.PostalCode = tbEventPostalCode.Text;
                eventobj.ContactName = tbEventContactName.Text;
                eventobj.ContactEmail = tbEventContactEmail.Text;
                eventobj.ContactNumber = tbEventContactNumber.Text;
                eventobj.StartDateTime = tbEventDate.Text + " " + tbEventTime.Text;
                eventobj.Duration = tbEventDurationHours.Text +":"+tbEventDurationMinutes.Text;
                eventobj.MinimumAttendee = int.Parse(tbEventMinAttendee.Text);
                eventobj.MaximumAttendee = int.Parse(tbEventMaxAttendee.Text);

                
                string[] acceptFileExtension = { "png", "jpg", "jpeg" };
                string ext = System.IO.Path.GetExtension(fuImage.PostedFile.FileName);
                bool isValidFile = false;
                for (int i =0; i< acceptFileExtension.Length; i++)
                {
                    if (ext == "." + acceptFileExtension[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile)
                {
                    //empty for now
                }
                else
                {
                    string randomFileName = Path.ChangeExtension(Path.GetRandomFileName(),ext);
                    string ImageLocation = Server.MapPath("~//Public//Image//Uploads//" + randomFileName);
                    fuImage.PostedFile.SaveAs(ImageLocation);
                    eventobj.Image = randomFileName.ToString();
                }


                if (eventobj.UpdateEvent() == 1)
                {
                    // if location is changed
                    if (tbEventLocation.Text != ini_location)
                    {
                        string smsBody;
                        foreach(var attendee in eventobj.getEventAttendees(eventid))
                        {
                            smsBody = "Hello, "+attendee.FullName+". The event " + eventobj.Name + " has changed location to " + eventobj.Location + ".";
                            sendSmsLocationChanged(attendee.Phone, smsBody);
                        }
                    }
                    Response.Redirect("/Views/Event/viewevent.aspx?eventid="+eventid);
                }

                Response.Redirect("events.aspx");

            }
        }

        public void sendSmsLocationChanged(string phoneNumber, string smsBody)
        {
            const string accountSid = "ACe72638c17a7822825bd6660b4f2ae178";
            const string authToken = "f0c353c4d1c5fc54";
            const string authTokenSplit = "c3009e3fb0444d40";

            TwilioClient.Init(accountSid, authToken+authTokenSplit);

            var message = MessageResource.Create(
                body: smsBody,
                from: new Twilio.Types.PhoneNumber("+12017333913"),
                to: new Twilio.Types.PhoneNumber("+65"+phoneNumber)
            );


        } 
    }
}