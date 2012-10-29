using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public class TwoCoverageRule : CoverageRuleBase
    {
        private readonly CompareTwoCoveragesBase comparer;

        protected TwoCoverageRule(CompareTwoCoveragesBase comparer)
        {
            this.comparer = comparer;
        }

        protected override bool If(CoverageValidationRequest fact)
        {
            var coverageA = GetCoverage(fact, comparer.CoverageAMnemonic);
            var coverageB = GetCoverage(fact, comparer.CoverageBMnemonic);

            return comparer.Comparer()(coverageA, coverageB);
        }

        protected override void Then(CoverageValidationRequest fact)
        {
            //Add this to the message list that will be in the response object
            comparer.ToString();
        }

    }
}
