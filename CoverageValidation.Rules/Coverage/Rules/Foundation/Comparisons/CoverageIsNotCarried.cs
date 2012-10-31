using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons.BaseTypes;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageIsNotCarried : SingleCoverageVocabBase
    {
        public CoverageIsNotCarried(string mnemonic)
            : base(mnemonic)
        {
        }

        public override Func<CoverageRulesContainer, bool> Comparer()
        {
            //need to figure out what is carried means and put it here
            return (a) =>
            {
                var coverage = GetCoverage(a.Request.Coverages, CoverageMnemonic);
                return (coverage == null);
            };
        }
        public override string ToString()
        {
            return string.Format("Coverage {0} is not carried.", CoverageMnemonic);
        }

        

      
    }
}
