using System;
using System.Collections.Generic;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    public class CoverageRuleBase
    {
        public string TargetCoverageMnemonic { get; set; }
        public string PredicateCoverageMnemonic { get; set; }
        public ICoverageValidation Validator { get; set; }
        public List<Func<CoverageLevelFact, bool>> Expressions { get; set; }


    }
}