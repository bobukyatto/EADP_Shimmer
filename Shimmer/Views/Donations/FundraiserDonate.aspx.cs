using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.Donations
{
    public partial class FundraiserDonate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["donationId"].ToString();
            lblID.Text = id;
            Fundraiser fdR = new Fundraiser();
            Fundraiser fdRList = fdR.GetFdById(id);
            lblFdrName.Text = fdRList.name;
            lblOrgBy.Text = fdRList.organisedBy;
            lblDesc.Text = fdRList.description;
            lblDonGoal.Text = fdRList.donationGoal.ToString();
            lblCategory.Text = fdRList.category;
        }


        private Boolean validate()
        {
            if (ddlCreditType.SelectedValue != "-1")
            {
                if(Convert.ToInt32(tbDonAmt.Text) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Donations.aspx");
        }

        protected void btnDonate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate() == true){                
                            Donation newDN = new Donation();
                            newDN.donationBy = lblUserId.Text;
                            newDN.donationTo = lblOrgBy.Text;
                            newDN.donationAmount = Convert.ToDouble(tbDonAmt.Text);
                            newDN.creditType = ddlCreditType.SelectedItem.Text;
                            newDN.fundraiserId = Session["DonationId"].ToString();

                            newDN.insertDonation(newDN);

                            lblSuccess.Text = "Donation Success!";
                
                    }
                    else
                    {
                        lblError.Text = "Error in validation";
                    }
            }
            catch (Exception c)
            {
                lblError.Text = "Exception Error" + c;
            }
        }
    }
}