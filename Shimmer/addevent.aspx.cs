using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;

namespace Shimmer
{
    public partial class addevent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Event eventobj = new Event();

            if (inputValidate())
            {
                // check if name + date for duplicate later
                eventobj.OrganizedBy = 0;
                eventobj.Name = tbEventName.Text;
                eventobj.Image = "default.jpg";
                eventobj.Description = tbEventDescription.Text;
                eventobj.Location = tbEventLocation.Text;
                eventobj.PostalCode = tbEventPostalCode.Text;
                eventobj.Status = 1; // 0 for deactivated, 1 for open event, 2 for closed event
                eventobj.Category = 1;
                eventobj.Charges = 1;
                eventobj.ContactName = tbEventContactName.Text;
                eventobj.ContactEmail = tbEventContactEmail.Text;
                eventobj.ContactNumber = tbEventContactNumber.Text;
                eventobj.StartDateTime = tbEventDate.Text +" "+ tbEventTime.Text;
                eventobj.Duration = tbEventDurationHours.Text + ":" + tbEventDurationMinutes.Text;
                eventobj.MinimumAttendee = int.Parse(tbEventMinAttendee.Text);
                eventobj.MaximumAttendee = int.Parse(tbEventMaxAttendee.Text);
                eventobj.Certification = 0;

                string[] acceptFileExtension = { "png", "jpg", "jpeg" };
                string ext = System.IO.Path.GetExtension(fuImage.PostedFile.FileName);
                bool isValidFile = false;
                for (int i = 0; i < acceptFileExtension.Length; i++)
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
                    string randomFileName = Path.ChangeExtension(Path.GetRandomFileName(), ext);
                    string ImageLocation = Server.MapPath("~//image//" + randomFileName);
                    fuImage.PostedFile.SaveAs(ImageLocation);
                    eventobj.Image = randomFileName.ToString();
                }


                eventobj.AddEvent();

                Response.Redirect("events.aspx");
            }



           

            //s
        }
    }
}