using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class AnyAreCarried : CompareCoverageToListBase
    {
        public AnyAreCarried(params string[] mnemonics)
            : base(mnemonics)
        {}

        public override Func<List<Model.CoverageLevelFact>, bool> Comparer()
        {
            return (a) => CoverageMnemonics.Select(coverageMnemonic => GetCoverage(a, coverageMnemonic)).Any(r => r != null);
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        private object GetCoverage(List<Model.CoverageLevelFact> a, string b)
        {
            throw new NotImplementedException();
        }

      
    }
}
