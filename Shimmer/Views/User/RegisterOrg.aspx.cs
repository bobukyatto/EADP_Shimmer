using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class RegisterOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            bool result;
            LblMsg.Text = String.Empty;


            if (String.IsNullOrEmpty(TbNameOrg.Text))
            {
                LblMsg.Text += "Organization name is required" + "<br/>";
            }
            if (TbEmailOrg.Text == "")
            {
                LblMsg.Text += "Organization Email is required!" + "<br/>";
            }
            if (!TbEmailOrg.Text.Contains("@"))
            {
                LblMsg.Text += "Not a valid email" + "<br/>";
            }
            if (TbPhoneOrg.Text == "")
            {
                LblMsg.Text += "Phone Number is required!" + "<br/>";
            }
            if (TbPassOrg.Text == "")
            {
                LblMsg.Text += "Password is required!" + "<br/>";
            }
            if (TbPassOrg.Text != TbRePassOrg.Text)
            {
                LblMsg.Text += "Password does not match!" + "<br/>";
            }

            if (String.IsNullOrEmpty(LblMsg.Text))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }

        protected void BtnRegisterOrg_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Account acc = new Account(TbNameOrg.Text, TbEmailOrg.Text, TbPassOrg.Text, TbPhoneOrg.Text, "Org");
                int result = acc.AddAccount();
                if (result == 1)
                {
                    LblMsg.Text = "User added successfully!";
                    LblMsg.ForeColor = Color.Green;
                }
                else
                {
                    LblMsg.Text = "Error in adding new user!";
                    LblMsg.ForeColor = Color.Red;
                }
            }
        }
    }
}