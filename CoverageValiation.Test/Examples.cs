using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model;
using CoverageValidation.Rules;
using CoverageValidation.Rules.ExistRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoverageValiation.Test
{
    [TestClass]
    public class Examples
    {
        [TestMethod]
        public void GetCoverageSet()
        {
            List<RuleBase> Rules = new List<RuleBase>();

            Rules.Add(RuleFactory.GetRuleCoverage1());
            Rules.Add(RuleFactory.GetRuleCoverage2());
            Rules.Add(RuleFactory.GetRuleCoverage007());
            Rules.Add(new CoverageAIsCarriedAndCoverageBIsCarriedAndCoverageAIsGreaterThanCoverageB());
            Rules.Add(RuleFactory.GetRuleCoverage045());
            Rules.Add(new Coverage13());

            foreach (var ruleBase in Rules)
            {
                Console.WriteLine(ruleBase);
                //ruleBase.Build(new CoverageValidationRequest()).Execute();
            }

            // 1) 
            // Show filtering the rules for big six.
            //filter for state
            //var RulesForOhio = Rules.Select(c=> c.IncludedState)
            //Start with CompanyCode




            //  2) 
            // Determine the construction method using reflection. We dosn't want to have list out each rule. Use an attribute or namespace and create automatically.

            // 3) 
            // Show how this will work in a multi thread environment. 
            // All the rules should be singleton. Exist in memory at all times.
            // then Filter them based on big six and that has to be threadsafe.
            // then the individual executable rule must be separated from the rule definitino. 

        }

        [TestMethod]
        public void GetCoverageSetdasdf()
        {
            var t = new CoverageIsCarried().SetCoverage("BI");
            Console.WriteLine(t);

        }

        //        "PD coverages DO Not match for each active vehicle
        //AND
        //Vehicle.VehicleTypeCode <> 06, 21, 25-29


        //"




    }
}
