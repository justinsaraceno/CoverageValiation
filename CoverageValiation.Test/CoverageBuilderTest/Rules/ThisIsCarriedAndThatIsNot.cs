using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    public class ThisIsCarriedAndThatIsNot : CompareBase, ICoverageValidation
    {
        private readonly Func<CoverageLevelFact, CoverageLevelFact, bool> comparer = (a, b) => a.IsCarried || !b.IsCarried;

        public void Excute()
        {
            IsValid = comparer(TargetCoverage, PredicateCoverage);
            if (!IsValid)
            {
                Message = ToString();
            }
        }

        public void Build(CoverageRuleBase rule, CoverageValidationRequest criteria)
        {
            Rule = rule;
            TargetCoverage = GetCoverage(criteria.PolicyCoverages, rule.TargetCoverageMnemonic);
            PredicateCoverage = GetCoverage(criteria.PolicyCoverages, rule.PredicateCoverageMnemonic);
        }

        public override string ToString()
        {
            return string.Format("Coverage '{0}' is carried but '{1}' is not", Rule.TargetCoverageMnemonic, Rule.PredicateCoverageMnemonic);
        }
    }
}
