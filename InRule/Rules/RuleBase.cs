namespace InRule.Rules
{
    public class RuleBase
    {
        public int BusinessRuleId { get; set; }
        public string RuleCategory { get; set; }
        public string RuleType { get; set; }
        public string ReferralReason { get; set; }
        public string MinimumSignOffLevel { get; set; }
        public string EntryType { get; set; }
        public string QuoteType { get; set; }
        public bool SkipReferral { get; set; }
        public decimal UserValidGroup { get; set; }
        public bool HasExistingSignedOffReferral { get; set; }
        public int ExistingSignedOffReferralBusinessRuleId { get; set; }
        public bool SkipReferralIfSignedOffPreviously { get; set; }
        public decimal ConversionRate { get; set; }

        protected string LookupReferralRulesLimitTable_ReferralCoverLimitYacht(int userGroupId, decimal maxCoverLimitAmount)
        {
            switch (userGroupId)
            {
                case 8: return (maxCoverLimitAmount <= 0) ? "UW Assistant" : string.Empty;
                case 6: return (maxCoverLimitAmount <= 0) ? "UW Secretary" : string.Empty;
                case 11: return (maxCoverLimitAmount <= 500000000) ? "UW Deputy Underwriter" : string.Empty;
                case 13: return (maxCoverLimitAmount <= 500000000) ? "UW Underwriter" : string.Empty;
                case 16: return (maxCoverLimitAmount <= 999999999999) ? "UW Deputy Manager" : string.Empty;
                case 18: return (maxCoverLimitAmount <= 999999999999) ? "UW Manager" : string.Empty;
                case 20: return (maxCoverLimitAmount <= 999999999999) ? "UW Head of Underwriting" : string.Empty;
                case 21: return (maxCoverLimitAmount <= 999999999999) ? "UW Director" : string.Empty;
                default: return string.Empty;
            }
        }
    }
}
