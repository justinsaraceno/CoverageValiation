using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    public class GreaterThanCompare : CompareBase, ICoverageValidation
    {
        private readonly Func<CoverageLevelFact, CoverageLevelFact, bool> comparer = (a, b) => a.CompareTo(b) == 1;

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
        }

        public override string ToString()
        {
            return string.Format("Coverage '{0}' is greater than '{1}'", Rule.TargetCoverageMnemonic, Rule.PredicateCoverageMnemonic);
        }
    }
}
