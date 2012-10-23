using System.Collections.Generic;
using CoverageValiation.Test.CoverageBuilderTest;
using CoverageValidation.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CoverageValidation.Model;

namespace CoverageValiation.Test
{
    
    
    /// <summary>
    ///This is a test class for Class1Test and is intended
    ///to contain all Class1Test Unit Tests
    ///</summary>
    [TestClass()]
    public abstract class GivenACoverageRuleBuilderAndSimpleRequest : GWT
    {
        private TestContext testContextInstance;
        protected CoverageRuleBuilder ruleBuilder;


        protected override void Given()
        {
            ruleBuilder = new CoverageRuleBuilder();
        }

        protected CoverageValidationRequest GetSimpleCoverageRequest()
        {
            var criteria = new CoverageValidationRequest();
            criteria.PolicyCoverages = new List<CoverageLevelFact>();
            criteria.PolicyCoverages.Add(new CoverageLevelFact() { CoverageMnemonic = "BI" });


            //criteria.VehicleFacts = new List<VehicleFact>();
            //criteria.VehicleFacts.Add(new VehicleFact());
            //criteria.VehicleFacts[0].Coverages = new List<CoverageLevelFact>();
            //criteria.VehicleFacts[0].Coverages.Add(new CoverageLevelFact() { CoverageMnemonic = "BI" });

            return criteria;
        }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    }

}
