using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.ExistRules
{
    public class AreAnyCarried : RuleBase
    {
        private List<string> coverageMnemonics = new List<string>();
        private List<RuleBase> rules;

        private AreAnyCarried()
        {
            //Force use of create
        }

        public AreAnyCarried Create(params string[] mnemonics)
        {
            var rule = new AreAnyCarried();
            rule.coverageMnemonics.AddRange(mnemonics);
            return rule;

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
            return "One of the following is covered " + String.Join(",", coverageMnemonics);
            //TODO Add the list of coverages. 
        }

        public override RuleBase Build(Model.CoverageRulesContainer request)
        {
            rules = new List<RuleBase>();
            foreach (var coverageMnemonic in coverageMnemonics)
            {
                var rule = new CoverageIsCarried().SetCoverage(coverageMnemonic).Build(request);
                rules.Add(rule);
            }
            return this;
        }
    }
}
