using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage;

namespace CoverageValidation.Web.Controllers
{
    public class CoverageValidationController : ApiController
    {

        // POST api/coveragevalidation
        public CoverageValidation.Model.Resource.Validation.CoverageValidationResponse Post(CoverageValidation.Model.Resource.Validation.CoverageValidationRequest request)
        {
            var ruleOutput = new CoverageValidationResponse();
            var container = new CoverageRulesContainer(request, ruleOutput);
            RuleManager.Execute(container);
            return container.Response;
        }
    }
}
