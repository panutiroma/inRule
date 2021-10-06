using InRule.Entities;
using InRule.Enums;
using System.Collections.Generic;

namespace InRule.Rules
{
    public class Rule19 : RuleBase
    {
        public ApplicationCover ExistingSignedOffCover { get; set; }
        public decimal MaxCoverLimitAmount { get; set; }
        public bool IsRiskApplicable { get; set; }

        private void PreSet()
        {
            BusinessRuleId = 1068;
            RuleCategory = "Cover";
            RuleType = "ReferralRule";
            ReferralReason = "Cover Limit for Yacht Liability Cover";
            MinimumSignOffLevel = "As set up in ReferralRulesLimitTable";
            EntryType = "";
            QuoteType = "";
            SkipReferral = true;
            UserValidGroup = 0;
            HasExistingSignedOffReferral = false;
            ExistingSignedOffCover = null;
            ExistingSignedOffReferralBusinessRuleId = 0;
            SkipReferralIfSignedOffPreviously = true;
            ConversionRate = 1;
            MaxCoverLimitAmount = 0;
            IsRiskApplicable = false;
        }

        public List<ReferralResult> Start(ReferralAuthorization referralAuthorization, string minimumSignOffLevel) // ReferralUserGroup.UwDeputyUnderwriter.ToString()
        {
            var referralResult = new List<ReferralResult>();

            PreSet();

            ExistingSignedOffReferralBusinessRuleId = BusinessRuleId;
            QuoteType = referralAuthorization.Application.QuoteType;
            EntryType = referralAuthorization.Application.EntryType;

            // indication
            if (referralAuthorization.ApplicationType == "Indication")
            {
                SkipReferralIfSignedOffPreviously = false;
            }

            // has Risk with vesselCategory as Yachts
            foreach (var applicationRisk in referralAuthorization.Application.ApplicationRisks)
            {
                if (applicationRisk.VesselCategory == "YAT")
                {
                    IsRiskApplicable = true;
                }
            }


            if (IsRiskApplicable)
            {
                foreach (var applicationCover in referralAuthorization.Application.ApplicationCovers)
                {
                    SkipReferral = true;
                    UserValidGroup = 0;
                    MaxCoverLimitAmount = 0;
                    HasExistingSignedOffReferral = true;

                    // get MaxCoverLimitAmount for each Cover
                    foreach (var coverLimit in applicationCover.CoverLimits)
                    foreach (var coverLimitTag in coverLimit.Tags)
                    {
                            if (coverLimitTag.Currency != null && coverLimitTag.Currency != referralAuthorization.Application.BaseCurrencyForRules)
                            {
                                // convert to BaseCurrencyForRules
                                foreach (var exchangeRate in referralAuthorization.Application.CurrencyExchangeRates)
                                {
                                    if (exchangeRate.FromCurrency = coverLimitTag.Currency && exchangeRate.ToCurrency = referralAuthorization.Application.BaseCurrencyForRules)
                                    {
                                        ConversionRate = exchangeRate.Rate;
                                    }
                                }
                                if (MaxCoverLimitAmount <= (coverLimitTag.Value * ConversionRate))
                                {
                                    MaxCoverLimitAmount = coverLimitTag.Value * ConversionRate;
                                }
                            }
                            else
                            {
                                MaxCoverLimitAmount = (MaxCoverLimitAmount <= coverLimitTag.Value) ? coverLimitTag.Value : MaxCoverLimitAmount;
                            }
                    }

                    /// todo: SetMinimumSignOffLevel
                    MinimumSignOffLevel = minimumSignOffLevel;



                    //  TO CHANGE HERE  !!!!!
                    if (SkipReferralIfSignedOffPreviously == true)
                    {
                        foreach (var SignedOffReferral in referralAuthorization.Application.ExistingSignedOffReferrals)
                        if(BusinessRuleId == ExistingSignedOffReferralBusinessRuleId)
                        {
                            if (SignedOffReferral.ApplicationCoverId == applicationCover.Id)
                            {
                                    foreach (var userGroup in SignedOffReferral.SignedOffbyUser.Groups)
                                    {
                                        if (LookupReferralRulesLimitTable_ReferralCoverLimitYacht(userGroup.Id, MaxCoverLimitAmount) != string.Empty)
                                        {
                                            HasExistingSignedOffReferral = true;
                                        }
                                    }
                            }
                        }
                    }


                    if (HasExistingSignedOffReferral == false)
                    {

                    }
                }
            }

            return referralResult;
        }
    }
}
