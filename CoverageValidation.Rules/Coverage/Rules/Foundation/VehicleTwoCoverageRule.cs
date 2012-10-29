using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public class VehicleTwoCoverageRule : VehicleRuleBase
    {
        private CompareTwoCoveragesBase comparer;

        //This is probable some object with more data in it. 
        protected List<string> Messages = new List<string>();

        protected VehicleTwoCoverageRule(CompareTwoCoveragesBase comparer)
        {
            this.comparer = comparer;
        }

        protected override bool If(CoverageValidationRequest fact)
        {
            if (!base.RuleApplies(fact)) return false;

            var IsValid = false;
            foreach (var vehicleFact in fact.VehicleFacts)
            {
                if (!base.RuleApplies(fact)) continue;

                //Should really be a vehicle rule set
                var coverageA = GetCoverage(fact, comparer.CoverageAMnemonic);
                var coverageB = GetCoverage(fact, comparer.CoverageAMnemonic);

                if (!comparer.Comparer()(coverageA, coverageB))
                {
                   //Add to the message list or some kind of object to store to eventually add to the result.
                    Messages.Add("There is an issue");
                }
            }

            return IsValid;
        }

        protected override void Then(CoverageValidationRequest fact)
        {
            //Take the messages and move them to the result object using the comparer again
            foreach (var message in Messages)
            {
                
            }
            
            

        }

    }
}
