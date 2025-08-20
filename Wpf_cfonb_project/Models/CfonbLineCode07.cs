using System;

namespace Wpf_cfonb_project.Models
{
    public class CfonbLineCode07 : CfonbLineBase
    {
        //public string RegistrationCode { get; set; }
        //public string BankCode { get; set; }
        //public string BankCodeOpenAccount { get; set; }
        //public string IsoCurrencyCode { get; set; }
        public string MovementBalanceDecimalNumbers { get; set; }
        //public string AccountNumber { get; set; }
        public DateTime? NewDateBalance { get; set; } // (JJMMAA) 
        public decimal NewAmountBalance { get; set; }


    }
}
