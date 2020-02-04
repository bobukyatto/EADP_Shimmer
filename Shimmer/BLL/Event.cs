using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shimmer.DAL;

namespace Shimmer.BLL
{
    public class Event
    {

        public int OrganizedBy { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PostalCode { get; set; }
        public int Status { get; set; }
        public int Category { get; set; }
        public float Charges { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string StartDateTime { get; set; }
        public string Duration { get; set; }
        public int MinimumAttendee { get; set; }
        public int MaximumAttendee { get; set; }
        public int Certification { get; set; }
        public int Id { get; set; }

        //default constructor
        public Event()
        {

        }

        public Event(int organizedby, string name, string image, string description, string location, string postalcode, 
            int status, int category, float charges, string contactname, string contactemail, string contactnumber, string startdatetime, string duration, int minimumattendee, int maximumattendee, int certification, int id)
        {
            OrganizedBy = organizedby;
            Name = name;
            Image = image;
            Description = description;
            Location = location;
            PostalCode = postalcode;
            Status = status;
            Category = category;
            Charges = charges;
            ContactName = contactname;
            ContactEmail = contactemail;
            ContactNumber = contactnumber;
            StartDateTime = startdatetime;
            Duration = duration;
            MinimumAttendee = minimumattendee;
            MaximumAttendee = maximumattendee;
            Certification = certification;
            Id = id;
        }

        public int AddEvent()
        {
            EventDAO dao = new EventDAO();
            int result = dao.Insert(this);
            return result;
        }
        public Event GetEventById(int id)
        {
            EventDAO dao = new EventDAO();
            return dao.SelectById(id);
        }

        public List<Event> GetAllEvents()
        {
            EventDAO dao = new EventDAO();
            return dao.SelectAll();
        }
        public int UpdateEvent()
        {
            EventDAO dao = new EventDAO();
            int result = dao.Update(this);
            return result;
        }


        public class eventAssociation
        {
            public int EventId { get; set; }
            public int UserId { get; set; }
            public int GroupId { get; set; }
            public int Status { get; set; }
            public int StatusBy { get; set; }
            public string StatusReason { get; set; }
            public int Reminder { get; set; }

            public eventAssociation()
            {

            }

            public eventAssociation(int eventId, int userId, int groupId, int status, int statusBy, string statusReason, int reminder)
            {
                EventId = eventId;
                UserId = userId;
                GroupId = groupId;
                Status = status;
                StatusBy = statusBy;
                StatusReason = statusReason;
                Reminder = reminder;

            }
            
        }

        public int UserJoinEvent(int eventid, int userid)
        {
            EventDAO dao = new EventDAO();
            int result = dao.UserJoinEvent(eventid,userid);
            return result;
        }

        public int UserReJoinEvent(int eventid, int userid)
        {
            EventDAO dao = new EventDAO();
            int result = dao.UserReJoinEvent(eventid, userid);
            return result;
        }

        public int UserLeaveEvent(int eventid, int userid)
        {
            EventDAO dao = new EventDAO();
            int result = dao.UserLeaveEvent(eventid, userid);
            return result;
        }

        public List<Event.eventAssociation> GetAllEventAssociationById(int eventId)
        {
            EventDAO dao = new EventDAO();
            return dao.SelectEventAssociationByID(eventId);
        }

    }
}