using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;

namespace Shimmer
{
    public partial class editevent : System.Web.UI.Page
    {
        int currentUserId;

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

                System.Diagnostics.Debug.WriteLine("eventobj name: "+eventobj.Name);
                System.Diagnostics.Debug.WriteLine("tbname :"+tbEventName.Text);
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
                    Response.Redirect("../index.aspx");
                }

                Response.Redirect("events.aspx");

            }
        }
    }
}