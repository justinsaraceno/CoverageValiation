﻿using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model.Resource.Validation;
using Geico.Applications.Foundation.Rules;



namespace CoverageValidation.Rules.Coverage.Rules
{
    [Rule("Coverage001")]
    public class Coverage001InLine : BaseRule<VehicleCoverageRulesContainer>
    {
        //Must have PD carried to carry BI
        // Bodily Injury Coverage (BI) is carried AND Property Damage Coverage is NOT carried  "   


        /*This shows the issue at the the entire package is too big to execute on. 
         * There are rules that run on just the vehicle with collection of coverages and some that run on the entire policy.
         * Therefore there must be a difference. and they should be executed as such.  
         * So I can see the entire container executing the same rule set for each vehicle.
        */


        protected override bool If(VehicleCoverageRulesContainer fact)
        {
            //get the first coverage
            var coveragePD = GetCoverage(fact.Request.Coverages, "PD");
            //get the second coverage
            var coverageBI = GetCoverage(fact.Request.Coverages, "BI");

            //determine if the result
            return (IsCarried(coverageBI) && !IsCarried(coveragePD));
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
           fact.Response.Messages.Add(new Message(){MessageId = this.Name,Description = string.Format(CoverageValidationMessages.Coverage001,fact.Request.Vehicle)});
        }
    }
}
