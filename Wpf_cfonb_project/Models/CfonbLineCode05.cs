using System;

namespace Wpf_cfonb_project.Models
{
    public class CfonbLineCode05 : CfonbLineBase
    {
        //public string RegistrationCode { get; set; }
        //public string BankCode { get; set; }
        //public string InternalOperationCode { get; set; }
        //public string BankCodeOpenAccount { get; set; }
        //public string IsoCurrencyCode { get; set; }
        public string MovementBalanceDecimalNumbers { get; set; }
        //public string AccountNumber { get; set; }
        public string InterbankOperationCode { get; set; }
        public DateTime? DateRecognitionOperation { get; set; } // (JJMMAA)
        public string QualifyingZone { get; set; }
        public string AdditionalInformation { get; set; }

    }
}
