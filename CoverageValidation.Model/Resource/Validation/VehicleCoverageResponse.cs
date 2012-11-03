using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoverageValidation.Model.Resource.Validation
{
    //Need to use the common messaging framework on the validation mistakes.
    public class VehicleCoverageResponse
    {
        public List<Message> Messages { get; set; }

        public VehicleCoverageResponse()
        {
            Messages = new List<Message>();
        }
    }
}
