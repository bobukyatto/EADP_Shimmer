using Shimmer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shimmer.BLL
{
    public class Account
    {
        //Define class properties
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }

        //Default contructor
        public Account()
        {

        }
        //Define a constructor to initialize all the properties
        public Account(string fullname, string email, string password, string phoneno, string usertype)
        {
            FullName = fullname;
            Email = email;
            Password = password;
            Phone = phoneno;
            UserType = usertype;
        }

        public int AddAccount()
        {
            AccountDAO dao = new AccountDAO();
            int result = dao.Insert(this);
            return result;
        }

        public string CheckPassword(string password)
        {
            AccountDAO dao = new AccountDAO();
            return dao.CheckPassword(password);
        }
    }
}