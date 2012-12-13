using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model.Resource.Validation;
using Geico.Applications.Foundation.Rules;



namespace CoverageValidation.Rules.Coverage.Rules
{
    [Rule("Coverage004InLine")]
    public class Coverage004InLine : BaseRule<VehicleCoverageRulesContainer>
    {
        //Must have BI and PD

        /* "Bodily Injury Coverage (BI)is NOT carried  AND
            Property Damage Coverage is carried  
            AND
            Vehicle.VehicleTypeCode <> Motorcycle and
            Vehicle.RiskStateCode= FL "
        */

        protected override bool If(VehicleCoverageRulesContainer fact)
        {
            if (IsCarried(GetCoverage(fact.Request.Coverages, "BI"))) return false;

            if (IsCarried(GetCoverage(fact.Request.Coverages, "SLBI/PD"))) return false;

            if (IsAnyCarried(fact.Request.Coverages, new[] { "MED", "UM", "UMPD", "UMBIEC", "SLUM/PD", "UIMSTK", "UIM+", "UIM", "PLUM" }))


                //short on vehicle type.
                if (fact.Request.RiskState == "NJ" || fact.Request.Parent.PolicyFacts.policySymbolCode != "BAS") return false;

            //get the first coverage
            var coveragePD = GetCoverage(fact.Request.Coverages, "SLBI/PD");
            //get the second coverage
            var coverageBI = GetCoverage(fact.Request.Coverages, "BI");

            //determine if the result
            var coverageMet = (!IsCarried(coveragePD) && !IsCarried(coverageBI));

            return coverageMet;



        }

        private bool IsAnyCarried(IEnumerable<Model.Resource.Coverage> list, IEnumerable<string> p)
        {
            return list.Any(c => p.Any(d => d == c.CoverageType.Mnemonic));
        }

        private bool IsCarried(Model.Resource.Coverage coverage)
        {
            //This is probable not that simple either. 
            return (coverage != null);
        }

        private Model.Resource.Coverage GetCoverage(List<Model.Resource.Coverage> coverages, string mnemonic)
        {
            //THis function actually won't be that simple. There is the concept of mnemonic generalziation and some state specific issues.
            return coverages.FirstOrDefault(c => c.CoverageType.Mnemonic == mnemonic);
        }

        protected override void Then(VehicleCoverageRulesContainer fact)
        {
            fact.Response.Messages.Add(new Message() { MessageId = this.Name, Description = string.Format(CoverageValidationMessages.ResourceManager.GetString(this.Name), fact.Request.Vehicle) });
        }
    }
}
