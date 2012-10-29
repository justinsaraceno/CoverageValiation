using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;
using CoverageValidation.Rules.CompareRules;
using CoverageValidation.Rules.ExistRules;

namespace CoverageValidation.Rules.VehicleRules
{
    public class Coverage045 : VehicleRuleBase
    {
        private CoverageIsCarried UMBIIsCarried;
        private CoverageIsNotCarried UMBIStackedIsNotCarried;

        private List<Tuple<VehicleFact, RuleBase, RuleBase>> rules = new List<Tuple<VehicleFact, RuleBase, RuleBase>>();

        public Coverage045()
        {
            UMBIIsCarried = new CoverageIsCarried().SetCoverage("UMBI");
            UMBIStackedIsNotCarried = new CoverageIsNotCarried().SetCoverage("UMBI+Stacked");
        }

        public override string ToString()
        {
            return String.Format("For each vehicle {0} and {1}", UMBIIsCarried, UMBIStackedIsNotCarried) + base.ToString();
        }
        public override RuleBase Execute()
        {
            foreach (var rule in rules)
            {
                
                IsValid = rule.Item2.Execute().IsValid && rule.Item3.Execute().IsValid;
                if (IsValid)
                {
                    Errors.Add(rule.Item1.VehicleId,
                    String.Format("Vehicle {0} has coverage error : {1} and {2}", rule.Item1.VehicleId, UMBIIsCarried, UMBIStackedIsNotCarried));
                }

            }
            return this;
        }

        public override RuleBase Build(Model.CoverageValidationRequest request)
        {
            foreach (var vehicle in request.VehicleFacts)
            {
                rules.Add(new Tuple<VehicleFact, RuleBase, RuleBase>(vehicle, UMBIIsCarried.Build(request),UMBIStackedIsNotCarried.Build(request)));
            }

            return this;
        }
    }
}
