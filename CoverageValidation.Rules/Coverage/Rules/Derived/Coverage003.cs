using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules.Derived
{
    [Rule("Coverage003")]
    public class Coverage003 : CoverageRuleBase
    {
        private readonly CompareTwoCoveragesBase BINOtCarriedAndCOLIsNotCared = new CoverageAIsCarriedAndCoverageBIsNotCarried("BI", @"SLBI/PD");
        private readonly CompareCoverageToListBase AnyOfTHeFollowingAreCarried = new AnyAreCarried("MED", "UM","UMPD", "UMBIEC",@"SLUM/PD");

        public Coverage003()
        {
            ExcludedStates.AddRange(new[] { "NJ"});
            //Would need Basic Contract include
        }
        
        //Will need some way to remember what happens from the Evaluate to the Then
        //Most likely the evaluate will set up the return message. 
        protected override void Then(Model.CoverageRulesContainer fact)
        {
            throw new System.NotImplementedException();
        }

        public override bool Evaluate(Model.CoverageRulesContainer fact)
        {
            var coverageA = GetCoverage(fact, BINOtCarriedAndCOLIsNotCared.CoverageAMnemonic);
            var coverageB = GetCoverage(fact, BINOtCarriedAndCOLIsNotCared.CoverageBMnemonic);
            var bINOtCarriedAndCOLIsNotCared = BINOtCarriedAndCOLIsNotCared.Comparer()(coverageA, coverageB);

            var anyOfTHeFollowingAreCarried = AnyOfTHeFollowingAreCarried.Comparer()(fact.Request.PolicyCoverages);

            if (bINOtCarriedAndCOLIsNotCared && anyOfTHeFollowingAreCarried)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", BINOtCarriedAndCOLIsNotCared, AnyOfTHeFollowingAreCarried);
        }
    }
}
