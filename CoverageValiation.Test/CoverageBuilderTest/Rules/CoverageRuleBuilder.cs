using System;
using System.Linq;
using CoverageValiation.Test.CoverageBuilderTest.Rules;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    public class CoverageRuleBuilder : RuleBuilderBase
    {
        public CoverageRuleBuilder IfCoverage(string mnemonic)
        {
            if (rule == null)
                rule = new CoverageRuleBase();

            rule.TargetCoverageMnemonic = mnemonic;
            return this;
        }

        public CoverageRuleBuilder ThisCoverage(string mnemonic)
        {
            if (rule == null)
                throw new ApplicationException("Invalid Sequence");

            rule.PredicateCoverageMnemonic = mnemonic;
            return this;
        }

        public CoverageRuleBuilder IsGreaterThan()
        {
            if (rule == null)
                throw new ApplicationException("Invalid Sequence");

            rule.Validator = new GreaterThanCompare();
            return this;
        }

        internal CoverageRuleBuilder ThisIsCarriedAndThatIsNot(string targetCoverageMnemonic, string predicateCoverageMnemonic)
        {
            if (rule == null)
                rule = new CoverageRuleBase();

            rule.TargetCoverageMnemonic = targetCoverageMnemonic;
            rule.PredicateCoverageMnemonic = predicateCoverageMnemonic;
            rule.Validator = new ThisIsCarriedAndThatIsNot();
            return this;
        }
    }
}