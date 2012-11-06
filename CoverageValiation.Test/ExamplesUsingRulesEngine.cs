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

        [TestMethod]
        public void Coverage001PositiveTestViaEntireContainer()
        {
            //Arrange
            var fact = GetExampleCoverageRulesContainer();

            //Act
            RuleManager.Execute(fact);

            //Assert. Shouldn't be any broken rules. 
            Assert.AreEqual(fact.Response.Messages.Count(), 0);

        }

        [TestMethod]
        public void Coverage001NegativeTestViaEntireContainer()
        {
            //Arrange
            var fact = GetExampleCoverageRulesContainer();

            //remove PD
            fact.Request.Coverages.RemoveAll(c => c.CoverageType.Mnemonic == "PD");
            //Act
            RuleManager.Execute(fact);

            //Assert. Only this rule should be broken  
            Assert.AreEqual(fact.Response.Messages.Count(), 1);
            Assert.AreEqual(fact.Response.Messages[0].MessageId, "Coverage001");
            //if (fact.Response.Messages.Count() > 0)
            //{
            //    foreach (var message in fact.Response.Messages)
            //    {
            //        Console.WriteLine(message.Description);
            //    }
            //}
        }



        private CoverageRulesContainer GetExampleCoverageRulesContainer()
        {
            var ruleInput = new CoverageValidationRequest();
            var ruleOutput = new CoverageValidationResponse();
            ruleInput.Coverages = new List<Coverage>();
            ruleInput.Vehicles = new List<VehicleInfo>();
            ruleInput.Drivers = new List<DriverInfo>();
            ruleOutput.Messages = new List<Message>();

            //Add coverages
            CoverageType bi = new CoverageType("000001", "Policy", "BI", "Bodily Injury");
            CoverageType pd = new CoverageType("000002", "Policy", "PD", "Property Damage");
            Limit l = new Limit("0001", 100000, 300000, "Notsurewhat the desc is", false);
            ruleInput.Coverages.Add(new Coverage(bi, l, null, 1));
            ruleInput.Coverages.Add(new Coverage(pd, l, null, 1));

            //Add Vehicle
            ruleInput.Vehicles.Add(new VehicleInfo { Id = 1, ModelMake = "Honda", ModelName = "Acura", ModelYear = "2011", VehicleTypeCode = "01" });

            //Add Driver
            ruleInput.Drivers.Add(new DriverInfo { HasDui = false });


            return new CoverageRulesContainer(ruleInput, ruleOutput);

        }


        private VehicleCoverageRulesContainer GetExampleVehicleCoverageRulesContainer()
        {
            var ruleInput = new VehicleCoverageRequest();
            var ruleOutput = new VehicleCoverageResponse();
            ruleInput.Coverages = new List<Coverage>();
            ruleInput.Drivers = new List<DriverInfo>();
            ruleOutput.Messages = new List<Message>();

            //Add coverages
            CoverageType bi = new CoverageType("000001", "Policy", "BI", "Bodily Injury");
            CoverageType pd = new CoverageType("000002", "Policy", "PD", "Property Damage");
            Limit l = new Limit("0001", 100000, 300000, "Notsurewhat the desc is", false);
            ruleInput.Coverages.Add(new Coverage(bi, l, null, 1));
            ruleInput.Coverages.Add(new Coverage(pd, l, null, 1));


            ruleInput.Vehicle = new VehicleInfo
                                    {
                                        Id = 1,
                                        ModelMake = "Honda",
                                        ModelName = "Acura",
                                        ModelYear = "2011",
                                        VehicleTypeCode = "01"
                                    };


            //Add Driver
            ruleInput.Drivers.Add(new DriverInfo { HasDui = false });


            return new VehicleCoverageRulesContainer(ruleInput, ruleOutput);

        }

        //[TestMethod]
        //public void GetEntireSetAndTest()
        //{
        //    var ruleset = new CoverageRuleSet();

        //    //foreach (var rule in ruleset.Rules)
        //    //{
        //    //    Console.WriteLine(rule);
        //    //}

        //}


        //You can test an individual Rule. 
        [TestMethod]
        public void Coverage001PositiveTest()
        {
            var fact = GetExampleVehicleCoverageRulesContainer();
            var controller = new FakeRuleSet<VehicleCoverageRulesContainer>();

            controller.AddRule<Coverage001InLine>();

            //Act
            controller.Execute(fact);

            //Assert
            Assert.AreEqual(fact.Response.Messages.Count(), 0);
        }

        [TestMethod]
        public void Coverage001NegativeTest()
        {
            var fact = GetExampleVehicleCoverageRulesContainer();
            var controller = new FakeRuleSet<VehicleCoverageRulesContainer>();

            controller.AddRule<Coverage001InLine>();

            //remove PD
            fact.Request.Coverages.RemoveAll(c => c.CoverageType.Mnemonic == "PD");

            //Act
            controller.Execute(fact);

            //Assert
            Assert.AreEqual(fact.Response.Messages.Count(), 1);
            Assert.AreEqual(fact.Response.Messages[0].MessageId, "Coverage001");
        }
        //Test a single vocab Item
        //[TestMethod]
        //public void TestCoverageAIsCarriedAndCoverageBIsNotCarriedForBiAndPD()
        //{
        //    //Arrange 
        //    var comparer = new MustCarryCoverageAToCarryCoverageB("BI", "PD");

        //    var ruleInput = new CoverageValidationRequest();
        //    var ruleOutput = new CoverageValidationResponse();

        //    ruleInput.Coverages = new List<Coverage>();

        //    CoverageType bi = new CoverageType("000001", "Policy", "BI", "Bodily Injury");
        //    Limit l = new Limit("0001", 100000, 300000, "Notsurewhat the desc is", false);
        //    ruleInput.Coverages.Add(new Coverage(bi, l, null, 1));
        //    var facts = new CoverageRulesContainer(ruleInput, ruleOutput);
        //    var controller = new FakeRuleSet<CoverageRulesContainer>();

        //    //Act
        //    var result = comparer.Compare(facts);

        //    //Assert
        //    Assert.IsTrue(result);

        //}

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
