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
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }

        //Default contructor
        public Account()
        {

        }

        public Account(string fullname, string email, string password, string phoneno, string usertype)
        {
            FullName = fullname;
            Email = email;
            Password = password;
            Phone = phoneno;
            UserType = usertype;
        }

        public Account(int id,string fullname, string email, string password, string phoneno, string usertype)
        {
            Id = id;
            FullName = fullname;
            Email = email;
            Password = password;
            Phone = phoneno;
            UserType = usertype;
        }

        //For updating User info
        public Account(string fullname, string email, string phoneno, string password)
        {
            FullName = fullname;
            Email = email;
            Phone = phoneno;
            Password = password;
        }

        public int AddAccount()
        {
            AccountDAO dao = new AccountDAO();
            int result = dao.Insert(this);
            return result;
        }

        public Account CheckPassword(string password)
        {
            AccountDAO dao = new AccountDAO();
            return dao.CheckPassword(password);
        }

        public List<Account> GetAllAccount()
        {
            AccountDAO dao = new AccountDAO();
            return dao.SelectAll();
        }

        public Account GetAccountById(int id)
        {
            AccountDAO dao = new AccountDAO();
            return dao.SelectById(id);
        }

        public int UpdateAccount(string id, string fullname, string email, string phone, string password)
        {
            AccountDAO dao = new AccountDAO();
            int result = dao.UpdateAccount(id, fullname, email, phone, password);
            //int result = dao.UpdateAccount(this);
            return result;
        }

        //public int DeleteAccount(int? id)
        //{
        //    AccountDAO dao = new AccountDAO();
        //    return dao.DeleteAccount(int id);
        //}
    }
}