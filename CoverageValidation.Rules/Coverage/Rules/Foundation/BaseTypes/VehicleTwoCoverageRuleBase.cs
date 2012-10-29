using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;

namespace CoverageValidation.Rules.Coverage.Rules.Foundation
{
    public class VehicleTwoCoverageRuleBase : VehicleRuleBase
    {
        private CompareTwoCoveragesBase comparer;

        //This is probable some object with more data in it. 
        protected List<string> Messages = new List<string>();

        protected VehicleTwoCoverageRuleBase(CompareTwoCoveragesBase comparer)
        {
            this.comparer = comparer;
        }


        protected override void Then(CoverageRulesContainer fact)
        {
            //Take the messages and move them to the result object using the comparer again
            foreach (var message in Messages)
            {
                
            }
        }
        public override string ToString()
        {
            return comparer.ToString();
        }

        public override bool Evaluate(CoverageRulesContainer fact)
        {
            var ruleIsTrue = false;
            foreach (var vehicleFact in fact.Request.VehicleFacts)
            {
                if (!base.RuleApplies(fact)) continue;

                //Should really be a vehicle rule set
                var coverageA = GetCoverage(fact, comparer.CoverageAMnemonic);
                var coverageB = GetCoverage(fact, comparer.CoverageAMnemonic);

                if (!comparer.Comparer()(coverageA, coverageB))
                {
                    //Add to the message list or some kind of object to store to eventually add to the result.
                    ruleIsTrue = true;
                    Messages.Add("There is an issue");
                }
            }

            return ruleIsTrue;
        }
    }
}
