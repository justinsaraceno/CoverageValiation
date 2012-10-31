using System;
using System.Collections.Generic;
using CoverageValidation.Model.Resource.Validation;
using model = CoverageValidation.Model.Resource;
using CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageAIsCarriedAndCoverageBIsNotCarried : CompareTwoCoveragesBase
    {
        public CoverageAIsCarriedAndCoverageBIsNotCarried(string coverageAMnemonic, string coverageBMnemonic)
            : base(coverageAMnemonic, coverageBMnemonic)
        {
            fact1 = new CoverageIsCarried(coverageAMnemonic);
            fact2 = new CoverageIsNotCarried(coverageBMnemonic);
        }

        public override string ToString()
        {
            return string.Format("{0} and {1}", fact1, fact2);
        }

        public override bool Compare(CoverageRulesContainer fact)
        {
            return base.Compare((a, b) => fact1.Comparer()(fact) && fact2.Comparer()(fact));
        }
    }
}
