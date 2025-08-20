using System;

namespace Wpf_cfonb_project.Models
{
    public class CfonbLineCode01 : CfonbLineBase
    {
        //public string RegistrationCode { get; set; }
        //public string BankCode { get; set; }
        //public string BankCodeOpenAccount { get; set; }
        //public string IsoCurrencyCode { get; set; }
        public int OldBalanceDecimalNumbers { get; set; }
        //public string AccountNumber { get; set; }
        public DateTime? OldDateBalance { get; set; }
        public decimal OldAmountBalance { get; set; }
    }
}
