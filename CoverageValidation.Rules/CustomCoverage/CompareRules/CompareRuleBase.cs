using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.CompareRules
{
    public abstract class CompareRuleBase : RuleBase
    {
        protected string CoverageAMnemonic;
        protected string CoverageBMnemonic;
        
        protected CoverageLevelFact CoverageAFact;
        protected CoverageLevelFact CoverageBFact;
        
        protected Func<CoverageLevelFact, CoverageLevelFact, bool> comparer;

        public override RuleBase Execute()
        {
            IsValid = comparer(CoverageAFact, CoverageBFact);
            Message = ToString();
            return this;
        }

        public CompareRuleBase SetCoverageA(string coverageAMnemonic)
        {
            CoverageAMnemonic = coverageAMnemonic;
            return this;
        }

        public CompareRuleBase SetCoverageB(string coverageAMnemonic)
        {
            CoverageBMnemonic = coverageAMnemonic;
            return this;
        }

        public override RuleBase Build(CoverageRulesContainer request)
        {
            CoverageAFact = GetCoverage(request, CoverageAMnemonic);
            CoverageBFact = GetCoverage(request, CoverageBMnemonic);

            return this;
        }


    }
}
