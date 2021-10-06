using System.Collections.Generic;

namespace InRule.Entities
{
    public class RuleUser
    {
        public int Id { get; set; }
        public List<RuleUserGroup> Groups { get; set; }
    }
}
