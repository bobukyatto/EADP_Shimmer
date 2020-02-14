using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.Donations
{
    public partial class ManageFundraiser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Session["DonationId"].ToString();
                Fundraiser obj = new Fundraiser();
                Fundraiser fdR = obj.GetFdById(id);
                lblId.Text = id;
                lblOrgBy.Text = fdR.organisedBy.ToString();
                tbFdrName.Text = fdR.name.ToString();
                tbDesc.Text = fdR.description.ToString();
                tbDonGoal.Text = fdR.donationGoal.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                double donationGoal = Convert.ToDouble(tbDonGoal.Text);
                Fundraiser newFR = new Fundraiser(lblOrgBy.Text, tbFdrName.Text, tbDesc.Text, donationGoal, "0");
                newFR.id = Convert.ToInt32(lblId.Text);
                int result = newFR.updateForFundraiser();
                if (result == 1)
                {
                    lblSuccess.Text = "Fundraiser Updated";
                    Response.Redirect("Donations.aspx");
                }
                else
                {
                    lblError.Text = "Error";
                }
            }
            catch
            {
                lblError.Text = "Error";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Fundraiser newFR = new Fundraiser();
                int result = newFR.deleteForFundraiser(Session["DonationId"].ToString());
                lblSuccess.Text = "Fundraiser has been deleted successfully";
                btnReturn.Visible = false;
                Response.Redirect("Donations.aspx");
            }
            catch
            {
                lblError.Text = "Error";
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Donations.aspx");
        }
    }
}