using System.Collections.Generic;

namespace InRule.Entities
{
    public class ReferralAuthorization
    {
        public string ApplicationType { get; set; }
        public ApplicationBase Application { get; set; }
        public ApplicationBase Superseded { get; set; }
        public RuleUser AuthorizationUser { get; set; }
        public List<ReferralResult> Referrals { get; set; }

    }
}
