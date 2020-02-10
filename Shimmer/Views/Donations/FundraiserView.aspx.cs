using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.Donations
{
    public partial class FundraiserView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["id"].ToString();
            lblID.Text = id;
            Fundraiser fdR = new Fundraiser();
            Fundraiser fdRList = fdR.GetFdById(id);
            lblName.Text = fdRList.name;
            lblOrgBy.Text = fdRList.organisedBy;
            lblDesc.Text = fdRList.description;
            lblDonGoal.Text = fdRList.donationGoal.ToString();
            lblCategory.Text = fdRList.category;
        }
    }
}