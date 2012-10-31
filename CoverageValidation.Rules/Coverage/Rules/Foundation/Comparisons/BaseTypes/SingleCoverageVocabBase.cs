using System;
using System.Collections.Generic;
using CoverageValidation.Model.Resource.Validation;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons.BaseTypes
{
    public abstract class SingleCoverageVocabBase : VocabBase
    {
        public string CoverageMnemonic { get; private set; }

        protected SingleCoverageVocabBase(string coverageMnemonic)
        {
            CoverageMnemonic = coverageMnemonic;
        }
    }
}
