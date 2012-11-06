using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Model.Resource;

namespace CoverageValidation.Rules.Coverage
{
  public static class RuleManager
    {

      public static void Execute(CoverageRulesContainer fact)
      {
          //First execute the policy level rules.
          var ruleset = new CoverageRuleSet();
          ruleset.Execute(fact);

          //Execute the vehicle rules. 
          ExecuteVehicleRules(fact);

      }

      private static void ExecuteVehicleRules(CoverageRulesContainer fact)
      {
          //Since all the coverages come in a single list they need to be put into groups since they are evaluated per vehicle.
          var coveragesByVehicle = new Dictionary<VehicleInfo, List<Model.Resource.Coverage>>();

          foreach (var vehicle in fact.Request.Vehicles)
          {
              var coverages = fact.Request.Coverages.Where(c => c.VehicleId == vehicle.Id).ToList();
              coveragesByVehicle.Add(vehicle, coverages);
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
                  Vehicle = item.Key
              };

              var response = new VehicleCoverageResponse();
              var container = new VehicleCoverageRulesContainer(request, response);

              ruleset.Execute(container);

              //Need to put the results back into the original container
              fact.Response.Messages.AddRange(container.Response.Messages);

          }
      }

    }
}
