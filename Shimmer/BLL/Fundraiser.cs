using Shimmer.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shimmer.BLL
{
    public class Fundraiser
    {
        public int id { get; set; }
        public string organisedBy { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public double donationGoal { get; set; }
        public string category { get; set; }

        public Fundraiser()
        {

        }

        public Fundraiser(string orgBy, string Name, string desc, double donGoal, string cat)
        {
            this.id = 0;
            this.organisedBy = orgBy;
            this.name = Name;
            this.description = desc;
            this.donationGoal = donGoal;
            this.category = cat;
        }

        public List<Fundraiser> GetAllFd()
        {
            FundraiserDAO dao = new FundraiserDAO();
            return dao.SelectAll();
        }

        public Fundraiser GetFdById(string id)
        {
            FundraiserDAO dao = new FundraiserDAO();
            return dao.SelectAllbyID(id);
        }

        public DataSet GetDSFundraiser()
        {
            FundraiserDAO dao = new FundraiserDAO();
            return dao.DSFundraisers();
        }

        public int insertFundraiser(Fundraiser fr)
        {
            FundraiserDAO dao = new FundraiserDAO();
            return dao.Insert(fr);
        }

        public int updateForFundraiser()
        {
            FundraiserDAO dao = new FundraiserDAO();
            int result = dao.Update(this);
            return result;
        }

        public int deleteForFundraiser(string id)
        {
            FundraiserDAO dao = new FundraiserDAO();
            return dao.DeleteFundraiser(id);
        }
    }
}