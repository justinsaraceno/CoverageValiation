
namespace CoverageValidation.Model.Resource.Validation
{
    public class VehicleCoverageRulesContainer 
    {
        public VehicleCoverageRequest Request;
        public VehicleCoverageResponse Response;

        public VehicleCoverageRulesContainer(VehicleCoverageRequest request, VehicleCoverageResponse response)
        {
            this.Request = request;
            this.Response = response;
        }
    }
}
