using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons
{
    public class CoverageIsCarried
    {
        public string Mnemonic { get; private set; }

        public CoverageIsCarried(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public Func<List<model.Coverage>, bool> Comparer()
        {
            return (a) => (GetCoverage(a, Mnemonic).Equals(null));

            //need to figure out what is carried means and put it here

            
        }
        public override string ToString()
        {
            return string.Format("Coverage {0} is carried.", Mnemonic);
        }

        private model.Coverage GetCoverage(List<model.Coverage> a, string b)
        {
            throw new NotImplementedException();
        }

      
    }
}
