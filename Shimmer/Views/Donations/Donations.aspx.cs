using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.Donations
{
    public partial class Donations : System.Web.UI.Page
    {
        List<Fundraiser> fdList;
        DataSet DSFr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Fundraiser fdR = new Fundraiser();
            fdList = fdR.GetAllFd();
            DSFr = fdR.GetDSFundraiser();

            // using gridview to bind to the list of Fundraiser objects
            GvDonation.Visible = true;
            GvDonation.DataSource = fdList;
            GvDonation.DataBind();

            RptDonations.DataSource = DSFr;
            RptDonations.DataBind();
        }

        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RptDonations.ItemCommand += new RepeaterCommandEventHandler(RptDonations_ItemCommand);
        }

        protected void RptDonations_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "LearnMore":
                    Session["DonationId"] = e.CommandArgument;
                    Response.Redirect("FundraiserView.aspx");
                    break;
            }
        }

        protected void lbCreateFdr_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateFundraiser.aspx");
        }

        protected void GvDonation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GvDonation.SelectedRow;
            Session["DonationId"] = row.Cells[0].Text;
            Response.Redirect("ManageFundraiser.aspx");
        }
    }
}