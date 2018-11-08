using System;
using System.Threading.Tasks;
using ConfigCat.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CPMG3.API.Filter
{
	public class FeatureToggleFilterAttribute : ActionFilterAttribute
    {
        private string _toggleName;

        public FeatureToggleFilterAttribute(string toggleName)
        {
            _toggleName = toggleName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IConfigCatClient configCatClient = context.HttpContext.RequestServices.GetService(typeof(IConfigCatClient)) as IConfigCatClient;

            if (configCatClient != null && !configCatClient.GetValue("exibirOpcaoDeExcluir", false))
            {
                context.Result = new NotFoundResult();
            }
        }

    }
}
