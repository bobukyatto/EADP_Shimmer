using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;

namespace Shimmer
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                btnCreateEvent.Visible = false;
            }

            

            System.Data.DataView dv = (DataView)eventDataSource.Select(DataSourceSelectArguments.Empty);
            int numEvents = (dv.Count + 1); //find another way if theres time


            if (IsPostBack)
            {
                if (ddlSort.SelectedValue == "Ended")
                {
                    eventDataSource.SelectCommand = "SELECT * FROM Event INNER JOIN Account ON Event.eventOrganizedBy = Account.Id WHERE ([eventStatus] = 0) ORDER BY eventStartDateTime";
                }
                else if (ddlSort.SelectedValue == "Upcoming")
                {
                    eventDataSource.SelectCommand = "SELECT * FROM Event INNER JOIN Account ON Event.eventOrganizedBy = Account.Id WHERE  ([eventStatus] = @eventStatus) ORDER BY eventStartDateTime";
                }
                else if (ddlSort.SelectedValue=="Duration (Short)")
                {
                    eventDataSource.SelectCommand = "SELECT * FROM Event INNER JOIN Account ON Event.eventOrganizedBy = Account.Id WHERE  ([eventStatus] = @eventStatus) ORDER BY eventDuration";
                }
                else if (ddlSort.SelectedValue == "Duration (Long)")
                {
                    eventDataSource.SelectCommand = "SELECT * FROM Event INNER JOIN Account ON Event.eventOrganizedBy = Account.Id WHERE  ([eventStatus] = @eventStatus) ORDER BY eventDuration DESC";
                }

                eventRepeater.DataBind();
            
            }
            
        }



        



        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("addevent.aspx");
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSort.SelectedIndex == 1)
            {
                
            }
        }
    }
}