using System;

namespace Wpf_cfonb_project.Models
{
    public abstract class CfonbLineBase
    {
        public string RegistrationCode { get; set; }
        public string BankCode { get; set; }
        public string InternalOperationCode { get; set; }
        public string BankCodeOpenAccount { get; set; }
        public string IsoCurrencyCode { get; set; }
        public int MovementBalanceDecimalNumbers { get; set; }
        public string AccountNumber { get; set; }
    }
}
