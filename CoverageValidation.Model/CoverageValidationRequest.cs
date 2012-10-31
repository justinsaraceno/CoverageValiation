using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model.Resource;

namespace CoverageValidation.Model
{
    public class VehicleFact
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public List<Coverage> Coverages { get; set; }

    }
}
