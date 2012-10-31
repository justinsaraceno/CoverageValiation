using System;
using System.Collections.Generic;
using System.Linq;
using model = CoverageValidation.Model.Resource;


namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class AnyAreCarried : CompareCoverageToListBase
    {
        public AnyAreCarried(params string[] mnemonics)
            : base(mnemonics)
        {}

        public override Func<List<model.Coverage>, bool> Comparer()
        {
            return (a) => CoverageMnemonics.Select(coverageMnemonic => GetCoverage(a, coverageMnemonic)).Any(r => r != null);
        }
        public override string ToString()
        {
            return "this is the two string of AnyAreCarried Comparer";
        }

        private object GetCoverage(List<model.Coverage> a, string b)
        {
            throw new NotImplementedException();
        }

      
    }
}
