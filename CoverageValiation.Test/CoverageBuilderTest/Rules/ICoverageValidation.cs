using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValiation.Test.CoverageBuilderTest
{
    public interface ICoverageValidation
    {
        void Excute();
        void Build(CoverageRuleBase rule, CoverageValidationRequest request);
    }
}
