using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Wpf_cfonb_project.Models;

namespace Wpf_cfonb_project.Services
{
    public class CfonbParserService
    {
        public CfonbLineCode01 Header { get; private set; }
        public List<CfonbLineCode04> Movements { get; private set; } = new List<CfonbLineCode04>();
        public List<CfonbLineCode05> Complements { get; private set; } = new List<CfonbLineCode05>();
        public CfonbLineCode07 Footer { get; private set; }


        public void ParseFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Length < 120)
                    continue; // Ignore les lignes incorrectes

                string lineCode = line.Substring(0, 2);

                switch (lineCode)
                {
                    case "01":
                        Header = ParseLine01(line);
                        break;

                    case "04":
                        Movements.Add(ParseLine04(line));
                        break;

                    case "05":
                        Complements.Add(ParseLine05(line));
                        break;

                    case "07":
                        Footer = ParseLine07(line);
                        break;
                }
            }
        }

        private CfonbLineCode01 ParseLine01(string line)
        {
            return new CfonbLineCode01
            {
                RegistrationCode = line.Substring(0, 2),
                BankCode = line.Substring(2, 5),
                BankCodeOpenAccount = line.Substring(7, 5),
                IsoCurrencyCode = line.Substring(12, 4),
                OldBalanceDecimalNumbers = ParseInt(line.Substring(18, 1)), // parsing in int
                AccountNumber = line.Substring(20, 11).Trim(),
                OldDateBalance = ParseDate(line.Substring(33, 6)),
                OldAmountBalance = ParseAmount(line.Substring(94, 14))
            };
        }

        private CfonbLineCode04 ParseLine04(string line)
        {
            return new CfonbLineCode04
            {
                RegistrationCode = line.Substring(0, 2),
                BankCode = line.Substring(2, 5),
                InternalOperationCode = line.Substring(7, 2),
                BankCodeOpenAccount = line.Substring(9, 5),
                IsoCurrencyCode = line.Substring(14, 4),
                MovementBalanceDecimalNumbers = ParseInt(line.Substring(18, 1)),
                AccountNumber = line.Substring(20, 11).Trim(),
                InterbankOperationCode = line.Substring(31, 4).Trim(),
                DateRecognitionOperation = ParseDate(line.Substring(35, 6)),
                RejectionReasonCode = line.Substring(41, 2).Trim(),
                ValueDate = ParseDate(line.Substring(43, 6)),
                Label = line.Substring(49, 24).Trim(),
                EntryNumber = line.Substring(73, 7).Trim(),
                ExemptionIndexAccount = line.Substring(80, 1).Trim(),
                UnavailabilityIndex = line.Substring(81, 1).Trim(),
                AmountMovement = ParseAmount(line.Substring(80, 14)),
            };
        }

        private CfonbLineCode05 ParseLine05(string line)
        {
            return new CfonbLineCode05
            {
                RegistrationCode = line.Substring(0, 2),
                BankCode = line.Substring(2, 5),
                InternalOperationCode = line.Substring(7, 2),
                BankCodeOpenAccount = line.Substring(9, 5),
                IsoCurrencyCode = line.Substring(14, 4),
                MovementBalanceDecimalNumbers = line.Substring(18, 1),
                AccountNumber = line.Substring(20, 11).Trim(),
                InterbankOperationCode = line.Substring(31, 4).Trim(),
                DateRecognitionOperation = ParseDate(line.Substring(35, 6)),
                QualifyingZone = line.Substring(41, 2).Trim(),
                AdditionalInformation = line.Substring(43, 35).Trim()
            };
        }

        private CfonbLineCode07 ParseLine07(string line)
        {
            return new CfonbLineCode07
            {
                RegistrationCode = line.Substring(0, 2),
                BankCode = line.Substring(2, 5),
                BankCodeOpenAccount = line.Substring(7, 5),
                IsoCurrencyCode = line.Substring(12, 4),
                MovementBalanceDecimalNumbers = line.Substring(18, 1),
                AccountNumber = line.Substring(20, 11).Trim(),
                NewDateBalance = ParseDate(line.Substring(33, 6)),
                NewAmountBalance = ParseAmount(line.Substring(94, 14))
            };
        }

        private DateTime? ParseDate(string dateString)
        {
            if (DateTime.TryParseExact(dateString, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return date;
            return null;
        }

        private decimal ParseAmount(string amountStr)
        {
            if (string.IsNullOrWhiteSpace(amountStr))
                return 0;

            // Supprime tout caractère non numérique sauf les signes + et -
            string numeric = new string(amountStr.Where(c => char.IsDigit(c) || c == '+' || c == '-').ToArray());

            if (decimal.TryParse(numeric, out decimal amount))
            {
                return amount / 100; // Divisé par 100 car CFONB donne des centimes
            }

            return 0; // Valeur par défaut si parsing impossible
        }

        private int ParseInt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            string numeric = new string(str.Where(char.IsDigit).ToArray());

            if (int.TryParse(numeric, out int result))
                return result;

            return 0;
        }
    }
}
