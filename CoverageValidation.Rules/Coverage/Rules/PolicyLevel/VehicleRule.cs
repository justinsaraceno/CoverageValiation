using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model.Resource;
using CoverageValidation.Model.Resource.Validation;
using Geico.Applications.Foundation.Rules;



namespace CoverageValidation.Rules.Coverage.Rules
{
    [Rule("Coverage030")]
    public class Coverage030 : BaseRule<CoverageRulesContainer>
    {
        // MED coverage limits must be the same on all vehicles

        /* "MED Limits DO Not match for each active vehicle
                AND
            Vehicle.VehicleTypeCode <> 06, 21, 25-29"   
         */

        protected override bool If(CoverageRulesContainer fact)
        {

            var medCoverages = fact.Request.Coverages.Where(f => f.CoverageType.Mnemonic == "MED").ToList();

            //Find all coverages for vehicles in the rule 
            //Vehicle.VehicleTypeCode <> 06, 21, 25-29"  

            var excludedTypes = new[] { "06", "21", "25", "26", "27", "28", "29" };

            //get only these vehicle types
            var vehicles = fact.Request.Vehicles.Where(c => !excludedTypes.Contains(c.VehicleTypeCode)).ToList();


            //Remove the coverages that on vehicles not excluded. 
            medCoverages.RemoveAll(c => !vehicles.Exists(d => d.Id == c.VehicleId));

            //Do the comparison. 
            var medLimit = medCoverages[0].Limit;
            foreach (var medCoverage in medCoverages)
            {
                if (medLimit.Equals(medCoverage.Limit))
                    medLimit = medCoverage.Limit;
                else
                {
                    return true;
                }
            }
            return false;
        }

        protected override void Then(CoverageRulesContainer fact)
        {
            fact.Response.Messages.Add(new Message() { MessageId = this.Name, Description = string.Format(CoverageValidationMessages.ResourceManager.GetString(this.Name), fact.Request.RiskState) });
        }
    }
}
