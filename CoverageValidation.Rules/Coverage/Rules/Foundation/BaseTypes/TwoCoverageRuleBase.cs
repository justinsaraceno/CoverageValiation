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
            return comparer.Compare(fact);
        }
        public override string ToString()
        {
            return comparer.ToString();
        }
    }
}
