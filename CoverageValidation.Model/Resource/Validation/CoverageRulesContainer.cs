
namespace CoverageValidation.Model.Resource.Validation
{
    public class CoverageRulesContainer 
    {
        public CoverageValidationRequest Request;
        public CoverageValidationResponse Response;

        public CoverageRulesContainer(CoverageValidationRequest request, CoverageValidationResponse response)
        {
            this.Request = request;
            this.Response = response;
        }
    }
}
