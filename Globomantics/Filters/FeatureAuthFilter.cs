using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : IAuthorizationFilter
    {
        private readonly IFeatureService _featureService;
        private readonly string _featureName;

        public FeatureAuthFilter(IFeatureService featureService, string featureName)
        {
            this._featureService = featureService;
            _featureName = featureName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_featureService.IsFeatureActive(_featureName))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
