using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.Donations
{
    public partial class CreateFundraiser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Fundraiser newFR = new Fundraiser();
                newFR.name = TB_Name.Text;
                newFR.description = TB_Desc.Text;
                newFR.donationGoal = Convert.ToDouble(TB_DGoal.Text);
                newFR.category = DDL_Category.SelectedValue;

                newFR.insertFundraiser(newFR);

                Lbl_success.Text = "New Fundraiser created!";
            }
            catch
            {
                Lbl_err.Text = "Error";
            }

        }

        protected void btnDonations_Click(object sender, EventArgs e)
        {
            Response.Redirect("Donations.aspx");
        }
    }
}