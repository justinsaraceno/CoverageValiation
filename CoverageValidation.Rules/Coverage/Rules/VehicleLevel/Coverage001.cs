using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules
{
    [Rule("Coverage001")]
    public class Coverage001 : TwoCoverageRuleBase
    {
        public Coverage001() : base(new MustCarryCoverageAToCarryCoverageB("PD","BI")) {}
    }
}
