using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Rules.CompareRules;
using CoverageValidation.Rules.ExistRules;

namespace CoverageValidation.Rules
{
    [RuleAttribute]
    public class Coverage007 : RuleBase
    {
        private RuleBase NoneAreCarried;
        private RuleBase TOWIsCarried;
        private RuleBase ERSIsCarried;

        public Coverage007()
        {
            NoneAreCarried = new NoneAreCarried().AddCoverage("BI", "PD", "COMP", "Coll");
            TOWIsCarried = new CoverageIsCarried().SetCoverage("TOW");
            ERSIsCarried = new CoverageIsNotCarried().SetCoverage("UMBI+Stacked");

        }

        public override string ToString()
        {
            return String.Format("{0} and {1} and {2}", NoneAreCarried, TOWIsCarried, ERSIsCarried);
        }
        public override RuleBase Execute()
        {
            IsValid = NoneAreCarried.Execute().IsValid && TOWIsCarried.Execute().IsValid && ERSIsCarried.Execute().IsValid;

            if (!IsValid)
                Message = String.Format("{0} and {1} and {2}", NoneAreCarried, TOWIsCarried,
                                        ERSIsCarried);
            return this;
        }

        public override RuleBase Build(Model.CoverageValidationRequest request)
        {
            NoneAreCarried.Build(request);
            TOWIsCarried.Build(request);
            ERSIsCarried.Build(request);

            return this;
        }
    }
}
