using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model.Resource;
using CoverageValidation.Model.Resource.Validation;
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

            ruleInput.Coverages = new List<Coverage>();

            CoverageType bi = new CoverageType("000001", "Policy", "BI", "Bodily Injury");
            CoverageType pd = new CoverageType("000002", "Policy", "PD", "Property Damage");
            Limit l = new Limit("0001", 100000, 300000, "Notsurewhat the desc is", false);
            ruleInput.Coverages.Add(new Coverage(bi, l, null, 1));
            ruleInput.Coverages.Add(new Coverage(pd, l, null, 1));
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

            var ruleInput = new CoverageValidationRequest();
            var ruleOutput = new CoverageValidationResponse();

            ruleInput.Coverages = new List<Coverage>();

            CoverageType bi = new CoverageType("000001", "Policy", "BI", "Bodily Injury");
            Limit l = new Limit("0001", 100000, 300000, "Notsurewhat the desc is", false);
            ruleInput.Coverages.Add(new Coverage(bi, l, null, 1));
            var facts = new CoverageRulesContainer(ruleInput, ruleOutput);
            var controller = new FakeRuleSet<CoverageRulesContainer>();

            //Act
            var result = comparer.Compare(facts);

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
