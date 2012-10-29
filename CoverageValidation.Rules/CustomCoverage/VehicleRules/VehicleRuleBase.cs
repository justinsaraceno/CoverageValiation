using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Rules.VehicleRules
{
    public abstract class VehicleRuleBase : RuleBase
    {
        protected List<string> excludedVehicles = new List<string>(); 

        protected Dictionary<int,string> Errors = new Dictionary<int, string>();
        public override string ToString()
        {
            return " For Vehicles Not in " + String.Join(",", excludedVehicles);
        }
        public VehicleRuleBase ExcludeVehicle(params string[] vehicleType)
        {
            excludedVehicles.AddRange(vehicleType);
            return this;
        }
    }
}
