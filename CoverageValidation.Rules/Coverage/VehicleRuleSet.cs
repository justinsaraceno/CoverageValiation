
using Geico.Applications.Foundation.Rules;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage.Rules;

namespace CoverageValidation.Rules.Coverage
{
    public class CoverageVehicleRuleSet : BaseRuleSet<VehicleCoverageRulesContainer>
    {
        public CoverageVehicleRuleSet()
        {
            AddRule<Coverage001InLine>();


        }

    }
}
