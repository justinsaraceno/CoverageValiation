using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CoverageValidation.Model;
using CoverageValidation.Rules;
using CoverageValidation.Rules.ExistRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoverageValiation.Test
{
    [TestClass]
    public class Examples
    {
            // 1) 
            // Show filtering the rules for big six.
            // filter for state
            // var RulesForOhio = Rules.Select(c=> c.IncludedState)
            // Start with CompanyCode


            //  2) 
            // Determine the construction method using reflection. We dosn't want to have list out each rule. Use an attribute or namespace and create automatically.

            // 3) 
            // Show how this will work in a multi thread environment. 
            // then Filter them based on big six and that has to be threadsafe.
            // then the individual executable rule must be separated from the rule definition.

            //4) Clean Design Document.

            //5) Rules must be versioned - Show how effective date will be handled. This is also called versioning

            //6) Make sure unlimited company is accounted.

        //7) What is the developer lookinga 

        //Need to look at Coverages Model to see how to use it



        [TestMethod]
        public void GetAllRules()
        {
            var Rules = new List<RuleBase>();

            var methods = typeof(RuleFactory).GetMethods();
            var t = new RuleFactory();

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(CoverageRuleAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {

                    object o = method.Invoke(t, null);
                    if (o is RuleBase)
                    {
                        Rules.Add(o as RuleBase);
                    }
                }

            }


            Rules.ForEach(Console.WriteLine);

        }


        [TestMethod]
        public void GetAllRulesFromFactory()
        {
            var Rules = RuleFactory.GetAllRules();
            Rules.ForEach(Console.WriteLine);

            foreach (var ruleBase in Rules)
            {
                Rules.ForEach(Console.WriteLine);
            }
        }

        [TestMethod]
        public void GetAllRulesFromTypes()
        {

            var typesWithMyAttribute =
                (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                 from type in assembly.GetTypes()
                 let attributes = type.GetCustomAttributes(typeof(CoverageRuleAttribute), true)
                 where attributes != null && attributes.Length > 0
                 select new { Type = type, Attributes = attributes.Cast<CoverageRuleAttribute>() })
                  .ToList();

            var Rules = new List<RuleBase>();

            foreach (var t in typesWithMyAttribute)
            {
                ConstructorInfo constructor = t.Type.GetConstructor(Type.EmptyTypes);
                object ruleObject = constructor.Invoke(new object[] { });

                Rules.Add(ruleObject as RuleBase);
            }

            Rules.ForEach(Console.WriteLine);


            //        var methodsWithAttributes =
            //(from assembly in AppDomain.CurrentDomain.GetAssemblies()
            // from type in assembly.GetTypes()
            // from method in type.GetMethods()
            // let attributes = method.GetCustomAttributes(typeof(CoverageRuleAttribute), true)
            // where attributes != null && attributes.Length > 0
            // select new
            // {
            //     Type = type,
            //     Method = method,
            //     Attributes = attributes.Cast<CoverageRuleAttribute>()
            // })
            //.ToList();

        }


        [TestMethod]
        public void GetCoverageSetdasdf()
        {
            var t = new CoverageIsCarried().SetCoverage("BI");
            Console.WriteLine(t);

        }

        //        "PD coverages DO Not match for each active vehicle
        //AND
        //Vehicle.VehicleTypeCode <> 06, 21, 25-29


        //"




    }
}
