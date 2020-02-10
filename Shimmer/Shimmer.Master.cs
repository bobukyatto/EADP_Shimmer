using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class Shimmer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] == null)
            {
                UserTable.Visible = false;
                Logout.Visible = false;
                UserProfile.Visible = false;

                //To hide Group in templete
                grp1.Visible = false;
                grp2.Visible = false;
                grp3.Visible = false;
                grp4.Visible = false;

                //To display user in templete
                SignUpTemp.Visible = true;
                SignInTemp.Visible = true;
                UserProfileTemp.Visible = false;

                //To hide add event in templete
                event2.Visible = false;
            }
            else
            {
                if (Session["userType"].ToString() == "Admin")
                {
                    UserTable.Visible = true;
                    SignIn.Visible = false;
                    Register.Visible = false;
                    Logout.Visible = true;
                    UserProfile.Visible = false;

                    //To display group in templete
                    grp1.Visible = true;
                    grp2.Visible = true;
                    grp3.Visible = true;
                    grp4.Visible = true;

                    //To hide user in templete
                    SignUpTemp.Visible = false;
                    SignInTemp.Visible = false;
                    UserProfileTemp.Visible = true;


                    //To display add event in templete
                    event2.Visible = true;
                }
                else
                {
                    UserTable.Visible = false;
                    SignIn.Visible = false;
                    Register.Visible = false;
                    Logout.Visible = true;
                    UserProfile.Visible = true;
                    //To display group in templete
                    grp1.Visible = true;
                    grp2.Visible = true;
                    grp3.Visible = true;
                    grp4.Visible = true;

                    //To hide user in templete
                    SignUpTemp.Visible = false;
                    SignInTemp.Visible = false;
                    UserProfileTemp.Visible = true;


                    //To display add event in templete
                    event2.Visible = true;
                }
            }
            
           
        }
        //protected void BtnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //    Response.Redirect("Views/index.aspx");
        //}
    }
}