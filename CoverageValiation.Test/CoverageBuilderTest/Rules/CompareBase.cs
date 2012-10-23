using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    public abstract class CompareBase
    {
        protected CoverageRuleBase Rule;
        protected CoverageLevelFact TargetCoverage { get; set; }
        protected CoverageLevelFact PredicateCoverage { get; set; }
        protected bool IsValid { get; set; }
        protected string Message { get; set; }

        protected  CoverageLevelFact GetCoverage(List<CoverageLevelFact> coverages, string mnemonic)
        {
            //This is where the work really comes in.  At this point we have just the metadata for the rule.
            //The effort here is to get the Coverage and the selected value and all the quirkds associated with taht.
           return coverages.First(c => c.CoverageMnemonic == mnemonic);
        }

    }
}
