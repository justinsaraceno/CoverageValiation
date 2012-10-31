using System;
using System.Collections.Generic;
using CoverageValidation.Model;
using CoverageValidation.Model.Resource.Validation;


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

        protected override bool If(CoverageRulesContainer fact)
        {
            if (!this.RuleApplies(fact) || base.RuleApplies(fact)) 
                return false;

            return Evaluate(fact);
        }


    }
}
