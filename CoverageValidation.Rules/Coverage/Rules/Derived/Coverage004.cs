using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules.Derived
{
    [Rule("Coverage004")]
    public class Coverage004 : CoverageRuleBase
    {
        private readonly CoverageIsCarried CB = new CoverageIsCarried("CB");
        private readonly CoverageIsCarried COMP = new CoverageIsCarried("COMP");
        private readonly CoverageIsCarried COMB = new CoverageIsCarried("COLL");

        protected override bool If(Model.CoverageValidationRequest fact)
        {
           if  (!base.RuleApplies(fact))
            return false;

            var CB_Radio_Car_Phone_coverage_is_carried = CB.Comparer()(fact.PolicyCoverages);
            var ComprehensiveIsNotCarried = !COMP.Comparer()(fact.PolicyCoverages);
            var Combined_AdditionalIsNotCarried = !COMB.Comparer()(fact.PolicyCoverages);

            if (CB_Radio_Car_Phone_coverage_is_carried && (ComprehensiveIsNotCarried || Combined_AdditionalIsNotCarried))
            {
                return true;
            }
            return false;
        }

        protected override void Then(Model.CoverageValidationRequest fact)
        {
            throw new System.NotImplementedException();
        }
    }
}
