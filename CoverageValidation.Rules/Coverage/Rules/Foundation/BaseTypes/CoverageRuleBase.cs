using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model.Resource.Validation;
using Geico.Applications.Foundation.Rules;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules
{
    public abstract class CoverageRuleBase : BaseRule<CoverageRulesContainer>
    {
        protected internal List<string> IncludedStates = new List<string>();
        protected internal List<string> ExcludedStates = new List<string>();

        protected Boolean RuleApplies(CoverageRulesContainer fact)
        {
            // If vehicle type is explicitly included or not in the excluded list this rule applies.
            return (IncludedStates.Contains(fact.Request.RiskState) || !ExcludedStates.Contains(fact.Request.RiskState));
        }

        public abstract bool Evaluate(CoverageRulesContainer fact);

        public model.Coverage GetCoverage(CoverageRulesContainer fact, string mnemonic)
        {
            return fact.Request.PolicyCoverages.First(c => c.CoverageMnemonic == mnemonic);
        }

        protected override bool If(CoverageRulesContainer fact)
        {
            if (!RuleApplies(fact))
                return false;

            return Evaluate(fact);

        }

        protected override void Then(CoverageRulesContainer fact)
        {
            fact.Response.Messages.Add(new Message() { MessageId = this.GetType().Name, Description = ToString() });
        }
    }
}
