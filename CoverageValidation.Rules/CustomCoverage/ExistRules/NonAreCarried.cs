using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.ExistRules
{
    public class NoneAreCarried : RuleBase
    {
        private List<string> coverageMnemonics = new List<string>();
        private List<RuleBase> rules;

        public NoneAreCarried AddCoverage(params string[] coverageMnemonics)
        {
            this.coverageMnemonics.AddRange(coverageMnemonics);
            return this;
        }

        public override RuleBase Execute()
        {
            foreach (var rule in rules)
            {
                IsValid = rule.Execute().IsValid;
                if (IsValid)
                {
                    Message = ToString();
                    break;
                }
            }
            return this;
        }

        public override string ToString()
        {
            return "None of the following is carried " + String.Join(",", coverageMnemonics);
            //TODO Add the list of coverages. 
        }

        public override RuleBase Build(CoverageValidationRequest request)
        {
            rules = new List<RuleBase>();
            foreach (var coverageMnemonic in coverageMnemonics)
            {
                var rule = new CoverageIsNotCarried().SetCoverage(coverageMnemonic).Build(request);
                rules.Add(rule);
            }
            return this;
        }
    }
}
