namespace InRule.Entities
{
    public class ReferralResult
    {
        public int BusinessRuleId { get; set; }
        public string RuleType { get; set; }
        public string RuleCategory { get; set; }
        public string ReferralReason { get; set; }
        public string RoleToSignOff { get; set; }
        public ApplicationBase Application { get; set; }
        public bool SkipReferralIfSignedOffPreviously { get; set; }
        public bool SkipReferralIfAlreadyExists { get; set; }
        public int ApplicationCoverId { get; set; }
        public ApplicationRisk ApplicationRisk { get; set; }
        public int ApplicationRiskId { get; set; }
        public RuleUser SignedOffbyUser { get; set; }
        public string RuleControlData { get; set; }
    }
}
