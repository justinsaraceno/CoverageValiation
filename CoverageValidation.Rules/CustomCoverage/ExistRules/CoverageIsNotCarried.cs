using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.ExistRules
{
    public class CoverageIsNotCarried : RuleBase
    {
        protected string coverageMnemonic;
        protected Model.Coverage coverageFact;

        protected Func<Model.Coverage, bool> comparer = a => !a.IsCarried;

        public override string ToString()
        {
            return string.Format("Coverage {0} is not Carried", coverageMnemonic);
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

        public CoverageIsNotCarried SetCoverage(string coverageMnemonic)
        {
            //Get the coverage as set it. 
            this.coverageMnemonic = coverageMnemonic;
            return this;
        }

        public override RuleBase Build(CoverageRulesContainer request)
        {
            coverageFact = GetCoverage(request, coverageMnemonic);
            return this;
        }
    }
}
