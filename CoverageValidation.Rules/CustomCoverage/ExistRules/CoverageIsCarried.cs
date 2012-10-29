using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.ExistRules
{
    public class CoverageIsCarried : RuleBase
    {
        protected string coverageMnemonic;
        protected CoverageLevelFact coverageFact;

        protected Func<CoverageLevelFact, bool> comparer = a => a.IsCarried;

        public CoverageIsCarried()
        {

        }

        public override string ToString()
        {
            return string.Format("Coverage {0} is Carried", coverageMnemonic);
        }

        public override RuleBase Execute()
        {
            IsValid = comparer(coverageFact);
            if (IsValid)
            {
                Message = ToString();
            }
            return this;
        }

        public CoverageIsCarried SetCoverage(string coverageMnemonic)
        {
            //Get the coverage as set it. 
            this.coverageMnemonic = coverageMnemonic;
            return this;
        }

        public override RuleBase Build(CoverageValidationRequest request)
        {
            coverageFact = GetCoverage(request, coverageMnemonic);
            return this;
        }
    }
}
