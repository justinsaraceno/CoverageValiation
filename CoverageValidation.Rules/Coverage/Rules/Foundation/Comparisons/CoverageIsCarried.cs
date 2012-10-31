using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageIsCarried : SingleCompareBase
    {
        public CoverageIsCarried(string mnemonic)
            : base(mnemonic)
        {
        }

        public override Func<List<model.Coverage>, bool> Comparer()
        {
            //need to figure out what is carried means and put it here
            return (a) => (GetCoverage(a, CoverageMnemonic).Equals(null));
        }
        public override string ToString()
        {
            return string.Format("Coverage {0} is carried.", CoverageMnemonic);
        }

        private model.Coverage GetCoverage(List<model.Coverage> a, string b)
        {
            throw new NotImplementedException();
        }

      
    }
}
