using System;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules
{
    [Rule("Coverage002")]
    public class Coverage0021 : CoverageAIsCarriedAndCoverageBIsNotCarried
    {
        public Coverage0021()
            : base("PD", "BI")
        {
          
            //This one is too complicated. Need the BA To split it into simplier rules.

            
            //  IncludedStates.AddRange(new[] { "FL"});
        }
    }
}
