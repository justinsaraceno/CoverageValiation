using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage;
using CoverageValidation.Rules.Coverage.Rules;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoverageValiation.Test
{
    [TestClass]
    public class ExamplesUsingRulesEngine
    {

        //You can test the entire set
        [TestMethod]
        public void GetEntireSetAndTest()
        {
            var ruleset = new CoverageRuleSet();

            foreach (var rule in ruleset.Rules)
            {
                Console.WriteLine(rule);
            }
        }


        //You can test an individual Rule. 
        [TestMethod]
        public void Coverage001Test()
        {
            //Arrange
            var ruleInput = new CoverageValidationRequest();
            var ruleOutput = new CoverageValidationResponse();

            ruleInput.PolicyCoverages = new List<CoverageLevelFact>();
            var biCoverage = new CoverageLevelFact() { CoverageMnemonic = "BI", LimitMnemonic = "100/300" };
            var pdCoverage = new CoverageLevelFact() { CoverageMnemonic = "PD", LimitMnemonic = "200/300" };

            ruleInput.PolicyCoverages.Add(biCoverage);
            ruleInput.PolicyCoverages.Add(pdCoverage);


            var facts = new CoverageRulesContainer(ruleInput, ruleOutput);

            var controller = new FakeRuleSet<CoverageRulesContainer>();
            controller.AddRule<Coverage001>();

            //Act
            controller.Execute(facts);

            Console.WriteLine(new Coverage001());


            //Assert
            // ruleOutput.PolicyState.Should().Be(PolicyState.NonIssued);
        }


        //Test a single vocab Item
        [TestMethod]
        public void TestCoverageAIsCarriedAndCoverageBIsNotCarriedForBiAndPD()
        {
            //Arrange 
            var comparer = new CoverageAIsCarriedAndCoverageBIsNotCarried("BI", "PD");
            var biCoverage = new CoverageLevelFact() { CoverageMnemonic = "BI", LimitMnemonic = "100/300", IsCarried = true };
            var pdCoverage = new CoverageLevelFact() { CoverageMnemonic = "PD", LimitMnemonic = "200/300", IsCarried = false };

            //Act
            var result = comparer.Comparer()(biCoverage, pdCoverage);

            //Assert
            Assert.IsTrue(result);

        }

        public class FakeRuleSet<TFacts> : BaseRuleSet<TFacts> where TFacts : class
        {
            /// <summary>
            /// Adds a rule to the rule set
            /// </summary>
            /// <typeparam name="TRule">
            /// The rule type
            /// </typeparam>
            public new void AddRule<TRule>() where TRule : BaseRule<TFacts>
            {
                base.AddRule<TRule>();
            }
        }


    }
}
