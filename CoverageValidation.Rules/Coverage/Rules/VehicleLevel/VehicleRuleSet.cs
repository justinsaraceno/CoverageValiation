using CoverageValidation.Model;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage.Rules;
using CoverageValidation.Rules.Coverage.Rules.Derived;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage
{
    public class CoverageVehicleRuleSet : BaseRuleSet<VehicleCoverageRulesContainer>
    {
        public CoverageVehicleRuleSet()
        {
            AddRule<Coverage001>();


        }

    }
}
