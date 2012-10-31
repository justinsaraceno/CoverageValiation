using System;
using model = CoverageValidation.Model.Resource;
using CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageAIsCarriedAndCoverageBIsNotCarried : CompareTwoCoveragesBase
    {
        private CoverageIsCarried coverageAIsCarried;
        private CoverageIsCarried coverageBIsCarried;

        public CoverageAIsCarriedAndCoverageBIsNotCarried(string coverageAMnemonic, string coverageBMnemonic)
            : base(coverageAMnemonic, coverageBMnemonic)
        {
            coverageAIsCarried = new CoverageIsCarried(coverageAMnemonic);
            coverageBIsCarried = new CoverageIsCarried(coverageBMnemonic);
        }

        public override string ToString()
        {
            return string.Format("{0} and {1}", coverageAIsCarried, coverageBIsCarried);
        }

        public override Func<model.Coverage, model.Coverage, bool> Comparer()
        {
            // var aIsCarried = new CoverageIsCarried();
            return (a, b) => a.IsCarried() && !b.IsCarried();
        }
    }
}
