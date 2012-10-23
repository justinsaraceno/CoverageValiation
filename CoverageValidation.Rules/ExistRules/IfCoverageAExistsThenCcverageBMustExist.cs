using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Rules.ExistRules
{
    public class IfCoverageAExistsThenCcverageBMustExist : ExistRuleBase
    {
        public IfCoverageAExistsThenCcverageBMustExist()
        {
           comparer =  (a, b) => a.IsCarried || !b.IsCarried;
        }

        public override string ToString()
        {
            return string.Format("If coverage '{0}' exists than coverage '{1}' must exist",
                                 CoverageAMnemonic,
                                 CoverageBMnemonic);
        }
    }
}
