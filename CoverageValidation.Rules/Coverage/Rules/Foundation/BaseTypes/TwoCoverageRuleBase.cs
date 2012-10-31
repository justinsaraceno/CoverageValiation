using CoverageValidation.Model.Resource.Validation;


namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public class TwoCoverageRuleBase : CoverageRuleBase
    {
        private readonly CompareTwoCoveragesBase comparer;

        protected TwoCoverageRuleBase(CompareTwoCoveragesBase comparer)
        {
            this.comparer = comparer;
        }

        public override bool Evaluate(CoverageRulesContainer fact)
        {
            var coverageA = GetCoverage(fact, comparer.CoverageAMnemonic);
            var coverageB = GetCoverage(fact, comparer.CoverageBMnemonic);

            return comparer.Comparer()(coverageA, coverageB);
        }
        public override string ToString()
        {
            return comparer.ToString();
        }
    }
}
