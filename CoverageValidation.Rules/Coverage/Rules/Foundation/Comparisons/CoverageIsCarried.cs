using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageIsCarried
    {
        public string Mnemonic { get; private set; }

        public CoverageIsCarried(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public Func<List<Model.CoverageLevelFact>, bool> Comparer()
        {
            return (a) => (GetCoverage(a, Mnemonic).IsCarried);
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        private CoverageLevelFact GetCoverage(List<Model.CoverageLevelFact> a, string b)
        {
            throw new NotImplementedException();
        }

      
    }
}
