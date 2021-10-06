namespace InRule.Entities
{
    public class ApplicationCover
    {
        public int Id { get; set; }
        public bool IsCustom { get; set; }
        public bool RenewalCustomCoverWordingsAreSameAsSuperseded { get; set; }
        public bool RenewalSupersededPolicyCoversWereNotCustom { get; set; }
        public bool RenewalHaveAddedNewCover { get; set; }
        public string CoverShortCode { get; set; }
        public string CoverName { get; set; }
        public decimal BrokerCommissionRate { get; set; }
        public bool IsNonPoolableCover { get; set; }

        //to do: create entities
        //public CoverSections CoverSections { get; set; }
        public List<CoverLimit> CoverLimits { get; set; }
        //public ReinsurancePatterns ReinsurancePatterns { get; set; }
    }
}
