using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Rules.CompareRules;
using CoverageValidation.Rules.ExistRules;

namespace CoverageValidation.Rules.CompoundRules
{
     [CoverageRule]
    public class Coverage13  : RuleBase
    {
        private CoverageIsCarried BIIsCarried;
        private CoverageIsCarried PDIsCarried;

        private CoverageIsNotCarried UMBIIsNotCarried;
        private CoverageIsNotCarried UMPDIsNotCarried;

        public Coverage13()
        {
            BIIsCarried = new CoverageIsCarried().SetCoverage("BI");
            PDIsCarried = new CoverageIsCarried().SetCoverage("PD");

            UMBIIsNotCarried = new CoverageIsNotCarried().SetCoverage("UMPD");
            UMPDIsNotCarried = new CoverageIsNotCarried().SetCoverage("UMBI");

        }

        public override RuleBase Execute()
        {
            IsValid = BIIsCarried.Execute().IsValid && PDIsCarried.Execute().IsValid &&
                      (UMBIIsNotCarried.Execute().IsValid || UMPDIsNotCarried.Execute().IsValid);
                         

            if (!IsValid)
                Message = String.Format("{0} and {1} and ({2} or {3})", BIIsCarried, PDIsCarried, UMBIIsNotCarried, UMPDIsNotCarried);
            return this;
        }
        public override string ToString()
        {
            return String.Format("{0} and {1} and ({2} or {3})", BIIsCarried, PDIsCarried, UMBIIsNotCarried, UMPDIsNotCarried);
        }
        public override RuleBase Build(Model.CoverageValidationRequest request)
        {
            BIIsCarried.Build(request);
            PDIsCarried.Build(request);

            UMBIIsNotCarried.Build(request);
            UMPDIsNotCarried.Build(request);

            return this;
        }
    }
}
