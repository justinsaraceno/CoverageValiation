using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules.Derived
{
    [Rule("Coverage005")]
    public class Coverage005 : VehicleRuleBase
    {
        private readonly CoverageIsCarried RR = new CoverageIsCarried("RR");
        private readonly CoverageIsCarried COMP = new CoverageIsCarried("COMP");

        public Coverage005()
        {
            IncludedVehicle.AddRange(new[] { "01", "05" });
        }

        protected override bool If(Model.CoverageValidationRequest fact)
        {
            if (!base.RuleApplies(fact))
                return false;

            var rRIsCarried = RR.Comparer()(fact.PolicyCoverages);
            var comprehensiveIsNotCarried = !COMP.Comparer()(fact.PolicyCoverages);

            if (rRIsCarried && comprehensiveIsNotCarried)
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
