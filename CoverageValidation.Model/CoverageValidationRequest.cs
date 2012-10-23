using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Model
{
    public class CoverageValidationRequest
    {
        public List<VehicleFact> VehicleFacts { get; set;  }
        public List<CoverageLevelFact> PolicyCoverages { get; set; }

    }

    public class VehicleFact
    {
        public int VehicleId { get; set; }
        public List<CoverageLevelFact> Coverages { get; set; }
    }

    public class CoverageLevelFact : IComparable
    {
        public string CoverageMnemonic { get; set; }
        public string LimitMnemonic { get; set; }
        public string DeductibleMnemonic { get; set; }
        public bool IsCarried { get; set; }

        public int CompareTo(object obj)
        {
            //var limit = (VehicleLimitAndDeductibleBase)obj;

            //var thisLimitValue = GetValue();
            //var thatLimitValue = limit.GetValue();

            //// TR - This condition is to push the empty limits to bottom.
            //if (thisLimitValue == 0)
            //    return -1;
            //if (thatLimitValue == 0)
            //    return 1;

            //var result = thisLimitValue.CompareTo(thatLimitValue);

            ////var result = GetValue().CompareTo(limit.GetValue());
            //if (result == 0 && LimitContainsPerPersonAndPerOccurrence)
            //{
            //    // Need to check the second value
            //    result = GetPerOccuranceValue().CompareTo(limit.GetPerOccuranceValue());
            //}

            //return result;

            return 1;

        }

    }


}
