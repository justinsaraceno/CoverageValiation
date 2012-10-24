using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Rules.CompareRules;
using CoverageValidation.Rules.ExistRules;

namespace CoverageValidation.Rules.CompoundRules
{
    [RuleAttribute]
    public class CoverageAIsCarriedAndCoverageBIsCarriedAndCoverageAIsGreaterThanCoverageB : RuleBase
    {
        private CoverageIsCarried CoverageAIsCarried;
        private CoverageIsCarried CoverageBIsCarried;
        private RuleBase CoverageAIsGreaterThanCoverageB;

        public CoverageAIsCarriedAndCoverageBIsCarriedAndCoverageAIsGreaterThanCoverageB()
        {
            CoverageAIsCarried = new CoverageIsCarried().SetCoverage("PD");
            CoverageBIsCarried = new CoverageIsCarried().SetCoverage("UMPDNonStacked");
            CoverageAIsGreaterThanCoverageB = new CoverageMustBeGreaterThanCoverageB().SetCoverageA("UMPDNonStacked").SetCoverageB("PD");
        }

        public override RuleBase Execute()
        {
            IsValid = CoverageAIsCarried.Execute().IsValid && CoverageBIsCarried.Execute().IsValid && CoverageAIsGreaterThanCoverageB.Execute().IsValid;

            if (!IsValid)
                Message = String.Format("{0} and {1} and {2}", CoverageAIsCarried, CoverageBIsCarried, CoverageBIsCarried);
            return this;
        }
        public override string ToString()
        {
            return String.Format("{0} and {1} and {2}", CoverageAIsCarried, CoverageBIsCarried, CoverageAIsGreaterThanCoverageB);
        }
        public override RuleBase Build(Model.CoverageValidationRequest request)
        {
            CoverageAIsCarried.Build(request);
            CoverageBIsCarried.Build(request);
            CoverageAIsGreaterThanCoverageB.Build(request);

            return this;
        }
    }
}
