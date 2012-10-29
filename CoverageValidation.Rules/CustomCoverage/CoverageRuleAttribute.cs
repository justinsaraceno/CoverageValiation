using System;


namespace CoverageValidation.Rules
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CoverageRuleAttribute : Attribute
    {
        public override string ToString()
        {
            return "Is Rule";
        }
    }
}
