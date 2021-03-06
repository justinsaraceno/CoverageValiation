﻿using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules.Derived
{
    [Rule("Coverage002")]
    public class Coverage002 : VehicleTwoCoverageRuleBase
    {
        public Coverage002()
            : base(new MustCarryCoverageAToCarryCoverageB("PD","BI"))
        {
            IncludedStates.AddRange(new[] { "FL"});
            ExcludedVehicle.AddRange(new[] { "04" });
        }
    }
}
