using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model.Resource.Validation;
using model = CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons.BaseTypes
{
 public abstract class VocabBase 
   {
       public abstract override string ToString();

       public abstract Func<CoverageRulesContainer, bool> Comparer();

       protected model.Coverage GetCoverage(List<model.Coverage> a, string mnemonic)
       {
           return a.FirstOrDefault(coverage => coverage.CoverageType.Mnemonic == mnemonic);
       }


   }
}
