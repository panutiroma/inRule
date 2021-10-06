using System.Collections.Generic;

namespace InRule.Entities
{
    public class CoverLimit
    {
        public decimal Value { get; set; }
        public string Currency { get; set; }
        public List<CoverLimitTag> Tags { get; set; }
    }
}
