using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Rules.CompareRules;
using CoverageValidation.Rules.ExistRules;
using CoverageValidation.Rules.VehicleRules;

namespace CoverageValidation.Rules
{
    public static class RuleFactory
    {
        public static RuleBase GetRuleCoverage1()
        {
            return new IfCoverageAExistsThenCcverageBMustExist()
                .SetCoverageA("BI")
                .SetCoverageB("PD")
                .ExcludeStates("OH", "AK");
        }

        public static RuleBase GetRuleCoverage2()
        {
            return new CoverageMustBeGreaterThanCoverageB()
                .SetCoverageA("BI")
                .SetCoverageB("PD")
                .ExcludeStates("OH", "AK");
        }

        public static RuleBase GetRuleCoverage50()
        {
            return new CoverageAIsCarriedAndCoverageBIsCarriedAndCoverageAIsGreaterThanCoverageB();
        }

        public static RuleBase GetRuleCoverage007()
        {
            return new Coverage007();
        }

        public static RuleBase GetRuleCoverage045()
        {
            return new Coverage045().ExcludeVehicle("21","25","26","27","28","29");
        }

    }
}
