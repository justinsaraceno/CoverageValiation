using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public abstract class CompareTwoCoveragesBase
    {
        public string CoverageAMnemonic { get; private set; }
        public string CoverageBMnemonic { get; private set; }

        protected SingleCompareBase fact1;
        protected SingleCompareBase fact2;

        protected CompareTwoCoveragesBase(string coverageAMnemonic, string coverageBMnemonic)
        {
            CoverageAMnemonic = coverageAMnemonic;
            CoverageBMnemonic = coverageBMnemonic;
        }

        public abstract override string ToString();
        public abstract bool Compare(CoverageRulesContainer coverages);
        
        protected bool Compare(Func<SingleCompareBase, SingleCompareBase, bool> comparison)
        {
            return comparison(fact1, fact2);
        }

    }
}
