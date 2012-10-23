using System;


namespace CoverageValidation.Rules
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RuleAttribute : Attribute
    {
        public override string ToString()
        {
            return "Is Rule";
        }
    }
}
