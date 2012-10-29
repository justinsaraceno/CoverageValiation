using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Rules.CompareRules
{
    public class CoverageMustBeGreaterThanCoverageB : CompareRuleBase
    {
        public CoverageMustBeGreaterThanCoverageB()
        {
            comparer = (a, b) => a.CompareTo(b) == 1;
        }

        public override string ToString()
        {
            return string.Format("Coverage '{0}' must be greater than coverage '{1}'",
                                 CoverageAMnemonic,
                                 CoverageBMnemonic);
        }
    }
}
