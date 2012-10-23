using System.Text;
using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    [TestClass]
    public class WhenIsGreaterThanIsCalled :GivenACoverageRuleBuilder
    {
        private CoverageRuleBase originalRuleBase;
        private CoverageRuleBase returnedBuilder;


        [TestMethod]
        public void ThenAIsGreaterThanRuleIsCreated()
        {
            Assert.AreEqual(returnedBuilder.Validator.GetType().Name, originalRuleBase.Validator.GetType().Name);
        }

        [TestMethod]
        public void ThenAThenCoverageIsAdded()
        {
            Assert.AreEqual(returnedBuilder.PredicateCoverageMnemonic, originalRuleBase.PredicateCoverageMnemonic);
        }
        protected override void When()
        {
            originalRuleBase = new CoverageRuleBase();
            originalRuleBase.TargetCoverageMnemonic = "BI";
            originalRuleBase.PredicateCoverageMnemonic = "PD";
            originalRuleBase.Validator = new GreaterThanCompare();

            returnedBuilder = ruleBuilder.IfCoverage("BI").IsGreaterThan().ThisCoverage("PD").rule;
        }
    }
}
