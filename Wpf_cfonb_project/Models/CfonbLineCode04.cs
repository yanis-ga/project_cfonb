using System;

namespace Wpf_cfonb_project.Models
{
    public class CfonbLineCode04 : CfonbLineBase
    {
        //public string RegistrationCode { get; set; }
        //public string BankCode { get; set; }
        //public string InternalOperationCode { get; set; }
        //public string BankCodeOpenAccount { get; set; }
        //public string IsoCurrencyCode { get; set; }
        public int MovementBalanceDecimalNumbers { get; set; }
        //public string AccountNumber { get; set; }
        public string InterbankOperationCode { get; set; }
        public DateTime? DateRecognitionOperation { get; set; } // (JJMMAA)
        public string RejectionReasonCode { get; set; }
        public DateTime? ValueDate {  get; set; } //(JJMMAA)
        public string Label { get; set; }
        public string EntryNumber { get; set; }
        public string ExemptionIndexAccount { get; set; }
        public string UnavailabilityIndex {  get; set; }
        public decimal AmountMovement { get; set; }




    }
}
