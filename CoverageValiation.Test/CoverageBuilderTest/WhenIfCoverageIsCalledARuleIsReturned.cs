using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    [TestClass]
    public class WhenIfCoverageIsCalled : GivenACoverageRuleBuilder
    {
        private CoverageRuleBase originalRuleBase;
        private CoverageRuleBase returnedBuilder;

        [TestMethod]
        public void ThenARuleIsReturned()
        {
            Assert.IsInstanceOfType(returnedBuilder, typeof(CoverageRuleBase));
        }

        [TestMethod]
        public void ThenARuleIsReturnedWithCoverageAdded()
        {
            Assert.AreEqual(returnedBuilder.TargetCoverageMnemonic, originalRuleBase.TargetCoverageMnemonic);
        }

        protected override void When()
        {
            originalRuleBase = new CoverageRuleBase();
            originalRuleBase.TargetCoverageMnemonic =  "BI" ;

            returnedBuilder = ruleBuilder.IfCoverage("BI").rule;
        }
    }


}
