using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public abstract class SingleCompareBase 
    {
        public string CoverageMnemonic { get; private set; }

        protected SingleCompareBase(string coverageMnemonic)
        {
            CoverageMnemonic = coverageMnemonic;
        }

        public abstract override string ToString();

        public abstract Func<List<model.Coverage>, bool> Comparer();

    }
}
