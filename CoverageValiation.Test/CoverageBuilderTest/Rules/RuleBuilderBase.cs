using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest.Rules
{
    public class RuleBuilderBase
    {
        public CoverageRuleBase rule { get; set; }

        public CoverageRuleBase BuildRule(CoverageValidationRequest criteria)
        {
            return rule;
        }
    }
}
