using CoverageValidation.Model;
using CoverageValidation.Rules.Coverage.Rules;
using CoverageValidation.Rules.Coverage.Rules.Derived;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage
{
    public class CoverageRuleSet : BaseRuleSet<CoverageValidationRequest>
    {
        public CoverageRuleSet()
        {
            AddRule<Coverage001>();
            AddRule<Coverage002>();

                
            //AddRule<CoverageIsCarried>(new CoverageIsCarried("UM"), "Coverage002");
            //AddRule<CoverageIsCarried>(new CoverageIsCarried("UMP"), "Coverage003");
            //AddRule<CoverageIsCarried>(new CoverageIsCarried("PD"), "Coverage002");

        }

    }
}
