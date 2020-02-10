using Shimmer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shimmer.BLL
{
    public class Donation
    {
        public int donationid { get; set; }
        public string donationBy { get; set; }
        public string donationTo { get; set; }

        public string creditType { get; set; }
        public double donationAmount { get; set; }
        public string fundraiserId { get; set; }

        public Donation()
        {

        }

        public Donation(string dnBy, string dnTo, string credtype, double donAmt, string fdrId)
        {
            this.donationid = 0;
            this.donationBy = dnBy;
            this.donationTo = dnTo;
            this.creditType = credtype;
            this.donationAmount = donAmt;
            this.fundraiserId = fdrId;
        }

        public List<Donation> GetAllDn()
        {
            DonationDAO dao = new DonationDAO();
            return dao.SelectAll();
        }

        public int insertDonation(Donation dn)
        {
            DonationDAO dao = new DonationDAO();
            return dao.Insert(dn);
        }
    }
}