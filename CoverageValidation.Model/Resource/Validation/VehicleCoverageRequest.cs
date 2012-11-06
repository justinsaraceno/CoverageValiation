using System.Collections.Generic;

namespace CoverageValidation.Model.Resource.Validation
{
    public class VehicleCoverageRequest
    {
        public List<Coverage> Coverages { get; set; }
        public List<DriverInfo> Drivers { get; set; }
        public VehicleInfo Vehicle { get; set; }
        public string RiskState { get; set; }
        public CoverageValidationRequest Parent { get; set; }

    }
}
