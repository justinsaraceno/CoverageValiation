using System.Collections.Generic;

namespace CoverageValidation.Model.Resource.Validation
{
    public class CoverageValidationRequest
    {
        public List<Coverage> Coverages { get; set; }
        public List<DriverInfo> Drivers { get; set; }
        public List<VehicleInfo> Vehicles { get; set; }
        public string RiskState { get; set; }

    }
}
