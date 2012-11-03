using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model.Resource;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;
using CoverageValidation.Rules.Coverage.Rules.Derived;


namespace CoverageValidation.Rules.Coverage.Rules
{
    [Rule("VehicleRUleSet")]
    public class VehicleRule : BaseRule<CoverageRulesContainer>
    {
        //Must have PD carried to carry BI
        // Bodily Injury Coverage (BI) is carried AND Property Damage Coverage is NOT carried  "   


        /*This shows the issue at the the entire package is too big to execute on. 
         * There are rules that run on just the vehicle with collection of coverages and some that run on the entire policy.
         * Therefore there must be a difference. and they should be executed as such.  
         * So I can see the entire container executing the same rule set for each vehicle.
        */


        protected override bool If(CoverageRulesContainer fact)
        {
            //Since all the coverages come in a single list they need to be put into groups since they are evaluated per vehicle.
            var coveragesByVehicle = new Dictionary<VehicleInfo, List<Model.Resource.Coverage>>();

            foreach (var vehicle in fact.Request.Vehicles)
            {
                var coverages = fact.Request.Coverages.Where(c => c.VehicleId == vehicle.Id).ToList();
                coveragesByVehicle.Add(vehicle,coverages);
            }

            var ruleset = new CoverageVehicleRuleSet();

            //Now loop through all then vehicles and validate the coverages
            foreach (var item in coveragesByVehicle)
            {
                var request = new VehicleCoverageRequest()
                                  {
                                      Coverages = item.Value,
                                      Drivers = fact.Request.Drivers,
                                      RiskState = fact.Request.RiskState,
                                      Vehicles = item.Key
                                  };

                var response = new VehicleCoverageResponse();
                var container = new VehicleCoverageRulesContainer(request, response);

                ruleset.Execute(container);

                fact.Response.Messages.AddRange(container.Response.Messages);

            }
            
            return fact.Response.Messages.Any();

        }

        protected override void Then(CoverageRulesContainer fact)
        {
        }
    }
}
