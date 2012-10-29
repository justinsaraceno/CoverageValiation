using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules
{
    public abstract class VehicleRuleBase : CoverageRuleBase
    {
        public List<string> IncludedVehicle = new List<string>();
        public List<string> ExcludedVehicle = new List<string>();

        protected Boolean RuleApplies(VehicleFact fact)
        {
            // If vehicle type is explicitly included or not in the excluded list this rule applies.
            return (IncludedVehicle.Contains(fact.VehicleType) || !ExcludedVehicle.Contains(fact.VehicleType));
        }

    }
}
