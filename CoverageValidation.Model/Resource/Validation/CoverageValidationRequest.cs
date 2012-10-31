using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Model.Resource.Validation
{
    public class CoverageValidationRequest
    {
        public List<Coverage> Coverages { get; set; }
        public List<DriverInfo> Drivers { get; set; }
        public string RiskState { get; set; }

    }
}
