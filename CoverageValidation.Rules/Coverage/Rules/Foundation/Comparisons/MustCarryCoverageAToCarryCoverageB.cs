using System;
using System.Collections.Generic;
using CoverageValidation.Model.Resource.Validation;
using model = CoverageValidation.Model.Resource;
using CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class MustCarryCoverageAToCarryCoverageB : CompareTwoCoveragesBase
    {
        public MustCarryCoverageAToCarryCoverageB(string coverageAMnemonic, string coverageBMnemonic)
            : base(coverageAMnemonic, coverageBMnemonic)
        {
            fact1 = new CoverageIsNotCarried(coverageAMnemonic);
            fact2 = new CoverageIsCarried(coverageBMnemonic);
        }

        public override string ToString()
        {
            return string.Format("{0} is needed to carry {1}.  {0} is missing on Vehicle Info", CoverageAMnemonic, CoverageBMnemonic);
        }

        public override bool Compare(CoverageRulesContainer fact)
        {
            return base.Compare((a, b) => fact1.Comparer()(fact) && fact2.Comparer()(fact));
        }
    }
}
