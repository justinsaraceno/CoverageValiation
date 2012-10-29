using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public abstract class CompareTwoCoveragesBase 
    {
        public string CoverageAMnemonic { get; private set; }
        public string CoverageBMnemonic { get; private set; }

        protected CompareTwoCoveragesBase(string coverageAMnemonic, string coverageBMnemonic)
        {
            CoverageAMnemonic = coverageAMnemonic;
            CoverageBMnemonic = coverageBMnemonic;
        }

        public abstract override string ToString();

        public abstract Func<CoverageLevelFact, CoverageLevelFact, bool> Comparer();

    }
}
