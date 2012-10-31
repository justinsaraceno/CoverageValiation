using System;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageAIsCarriedAndCoverageBIsNotCarried : CompareTwoCoveragesBase
    {
        public CoverageAIsCarriedAndCoverageBIsNotCarried(string coverageAMnemonic, string coverageBMnemonic)
            : base(coverageAMnemonic, coverageBMnemonic) { }

        public override string ToString()
        {
            return string.Format("If coverage '{0}' exists than coverage '{1}' must exist",
                     CoverageAMnemonic,
                     CoverageBMnemonic);
        }

        public override Func<model.Coverage, model.Coverage, bool> Comparer()
        {
            var aIsCarried = new CoverageIsCarried()
            return (a, b) => a.IsCarried() && !b.IsCarried;
        }
    }
}
