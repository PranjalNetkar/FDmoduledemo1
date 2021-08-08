using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FDmoduledemo1.Models
{
    public enum period
    {
        Years, Months
    }
    public enum N
    {
        monthly, quarterly, Halfyearly, Years
    }
    public class RD
    {
        [Key]
        public int RdId { get; set; }
        [Display(Name = "Investing Money")]
        [Range(1000, 100000), Required(ErrorMessage = "Enter the amount as per our bank instructions")]
        public double RdInvMon { get; set; }

        [Display(Name = "RD Period(In Months only)")]
        [Range(1, 1200), Required(ErrorMessage = "You can create fd from 1 month to max 10 years")]
        public double Time { get; set; }

        public period Period { get; set; }
        [Display(Name = "Compounding Frequency")]
        public N n { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public AccountUser AccountUser { get; set; }
        [Display(Name = "Maturity Amount ")]
        public Double FdMAmount { get; set; }
        [Display(Name = "Interested Amount")]
        public Double FdInMoney { get; set; }
    }
}
