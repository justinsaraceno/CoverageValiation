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
    [Rule("Coverage001")]
    public class Coverage001InLine : BaseRule<CoverageRulesContainer>
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
            Dictionary<VehicleInfo, List<Model.Resource.Coverage>>  coveragesByVehicle = new Dictionary<VehicleInfo, List<Model.Resource.Coverage>>();

            foreach (var vehicle in fact.Request.Vehicles)
            {
                var coverages = fact.Request.Coverages.Where(c => c.VehicleId == vehicle.Id).ToList();
                coveragesByVehicle.Add(vehicle,coverages);
            }

            //Now loop through all then vehicles and validate the coverages
            //I'm not sure this is accurate because it's actually executing on the entire. set and not just what it needs. 
            foreach (var item in coveragesByVehicle)
            {
                //get the first coverage
                var coveragePD = GetCoverage(item.Value, "PD");
                //get the second coverage
                var coverageBI = GetCoverage(item.Value, "BI");
                
                //determine if the result
                return (IsCarried(coveragePD) && !IsCarried(coverageBI));
            }

            return true;
        }

        private bool IsCarried(Model.Resource.Coverage coverage)
        {
            //THis is probable not that simple either. 
            return (coverage == null);
        }

        private Model.Resource.Coverage GetCoverage(List<Model.Resource.Coverage> coverages, string mnemonic)
        {
            //THis function actually won't be that simple. There is the concept of mnemonic generalziation and some state specific issues.
            return coverages.FirstOrDefault(c => c.CoverageType.Mnemonic == mnemonic);

        }

        protected override void Then(CoverageRulesContainer fact)
        {
            throw new System.NotImplementedException();
        }
    }
}
