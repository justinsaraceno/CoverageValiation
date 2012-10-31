using System;
using System.Collections.Generic;
using model = CoverageValidation.Model.Resource;

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
        public abstract Func<List<model.Coverage>, bool> Comparer();
        public abstract string ToString();
    }
}