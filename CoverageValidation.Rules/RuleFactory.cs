using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CoverageValidation.Rules.CompareRules;
using CoverageValidation.Rules.CompoundRules;
using CoverageValidation.Rules.ExistRules;
using CoverageValidation.Rules.VehicleRules;

namespace CoverageValidation.Rules
{
    public class RuleFactory
    {
        [RuleAttribute]
        public RuleBase GetRuleCoverage1()
        {
            return new IfCoverageAExistsThenCcverageBMustExist()
                .SetMnemonicForCoverageA("BI")
                .SetMnemonicForCoverageB("PD")
                .ExcludeStates("OH", "AK");
        }

        [RuleAttribute]
        public RuleBase GetRuleCoverage2()
        {
            return new CoverageMustBeGreaterThanCoverageB()
                .SetCoverageA("BI")
                .SetCoverageB("PD")
                .ExcludeStates("OH", "AK");
        }

        [RuleAttribute]
        public RuleBase GetThisNewRule()
        {
            return new CoverageAIsCarriedAndCoverageBIsCarriedAndCoverageAIsGreaterThanCoverageB();
        }

        [RuleAttribute]
        public static RuleBase GetRuleCoverage045()
        {
            return new Coverage045().ExcludeVehicle("21", "25", "26", "27", "28", "29");
        }

        public static List<RuleBase> GetAllRules()
        {
            var result = new List<RuleBase>();

            GetFactoryRules(result);
            GetClassRules(result);

            return result;

        }

        private static void GetFactoryRules(List<RuleBase> result)
        {
            var methods = typeof(RuleFactory).GetMethods();
            var t = new RuleFactory();

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(RuleAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {

                    object o = method.Invoke(t, null);
                    if (o is RuleBase)
                    {
                        result.Add(o as RuleBase);
                    }
                }
            }
        }

        private static void GetClassRules(List<RuleBase> result)
        {
            var typesWithMyAttribute =
             (from assembly in AppDomain.CurrentDomain.GetAssemblies()
              from type in assembly.GetTypes()
              let attributes = type.GetCustomAttributes(typeof(RuleAttribute), true)
              where attributes != null && attributes.Length > 0
              select new { Type = type, Attributes = attributes.Cast<RuleAttribute>() })
               .ToList();

            foreach (var t in typesWithMyAttribute)
            {
                ConstructorInfo constructor = t.Type.GetConstructor(Type.EmptyTypes);
                object ruleObject = constructor.Invoke(new object[] { });

                result.Add(ruleObject as RuleBase);
            }
        }

    }
}
