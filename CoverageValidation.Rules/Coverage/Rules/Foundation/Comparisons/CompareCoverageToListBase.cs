using System;
using System.Collections.Generic;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public abstract class CompareCoverageToListBase
    {
        protected CompareCoverageToListBase(params string[] mnemonics)
        {
            CoverageMnemonics = new List<string>();
            CoverageMnemonics.AddRange(mnemonics);

        }
        protected List<string> CoverageMnemonics { get; private set; }
        public abstract Func<List<CoverageLevelFact>, bool> Comparer();
        public abstract string ToString();
    }
}