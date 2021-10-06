using System;
using System.Collections.Generic;

namespace InRule.Entities
{
    public class ApplicationBase
    {
        public bool IsRenewal { get; set; }
        public List<ApplicationCover> ApplicationCovers { get; set; }
        public bool BrokerCommissionIncreased { get; set; }
        public List<ApplicationRisk> ApplicationRisks { get; set; }
        public string QuoteType { get; set; }
        public string EntryType { get; set; }
        public string MemberAssuredType { get; set; }
        public string DistributionChannel { get; set; }
        //public ApplicationMember ApplicationMember { get; set; }
        public List<ReferralResult> ExistingSignedOffReferrals { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime SystemDate { get; set; }
        //public InstalmentPattern InstalmentPattern { get; set; }
        public string BaseCurrencyForRules { get; set; }
        //public Premium ApplicationPremium { get; set; }
        public List<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }
        public bool CoversAddedRemovedAfterApproval { get; set; }
        public bool RisksAddedRemovedAfterApproval { get; set; }
        public bool PremiumEditedAfterApproval { get; set; }
        public string TemplateRiskType { get; set; }

    }
}
