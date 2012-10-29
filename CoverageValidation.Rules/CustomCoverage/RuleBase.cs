using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules
{
    public abstract class RuleBase
    {
        public List<string> IncludedStates = new List<string>();
        public List<string> ExcludedStates = new List<string>();
        public bool IsValid { get; set; }
        public string Message{ get; set; }

        public override string ToString()
        {
            throw new NotImplementedException("Must implement in derived classes");
        }

        public RuleBase ExcludeStates(params string[] states)
        {
            ExcludedStates.AddRange(states);
            return this;
        }
        public RuleBase IncludeStates(params string[] states)
        {
            IncludedStates.AddRange(states);
            return this;
        }

        public abstract RuleBase Execute();

        public abstract RuleBase Build(CoverageValidationRequest request);

        protected CoverageLevelFact GetCoverage(CoverageValidationRequest request, string mnemonic)
        {
            //This is where the work really comes in.  At this point we have just the metadata for the rule.
            //The effort here is to get the Coverage and the selected value and all the quirkds associated with taht.
            return request.PolicyCoverages.First(c => c.CoverageMnemonic == mnemonic);
        }
    }
}
