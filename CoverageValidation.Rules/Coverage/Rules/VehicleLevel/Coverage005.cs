using CoverageValidation.Model.Resource.Validation;
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

        protected override void Then(CoverageRulesContainer fact)
        {
            throw new System.NotImplementedException();
        }

        public override bool Evaluate(CoverageRulesContainer fact)
        {
            var rRIsCarried = RR.Comparer()(fact);
            var comprehensiveIsNotCarried = !COMP.Comparer()(fact);

            if (rRIsCarried && comprehensiveIsNotCarried)
            {
                return true;
            }
            return false;
        }
    }
}
