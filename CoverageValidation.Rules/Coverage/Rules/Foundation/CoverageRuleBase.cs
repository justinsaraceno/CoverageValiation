using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules
{
    public abstract class CoverageRuleBase : BaseRule<CoverageValidationRequest>
    {
        public List<string> IncludedStates = new List<string>();
        public List<string> ExcludedStates = new List<string>();

        protected Boolean RuleApplies(CoverageValidationRequest fact)
        {
            // If vehicle type is explicitly included or not in the excluded list this rule applies.
            return (IncludedStates.Contains(fact.RiskState) || !ExcludedStates.Contains(fact.RiskState));
        }


        public CoverageLevelFact GetCoverage(CoverageValidationRequest fact, string p)
        {
            throw new NotImplementedException();
        }



    }
}
