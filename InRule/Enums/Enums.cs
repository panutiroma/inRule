using System.ComponentModel;

namespace InRule.Enums
{
    public enum ReferralUserGroup
    {
        [Description("UW Assistant")]
        UwAssistant,

        [Description("UW Secretary")]
        UwSecretary,

        [Description("UW Deputy Underwriter")]
        UwDeputyUnderwriter,

        [Description("UW Underwriter")]
        UwUnderwriter,

        [Description("UW Deputy Manager")]
        UwDeputyManager,

        [Description("UW Manager")]
        UwManager,

        [Description("UW Head of Underwriting")]
        UwHeadOfUnderwriting,

        [Description("UW Director")]
        UwDirector,
    }
}
