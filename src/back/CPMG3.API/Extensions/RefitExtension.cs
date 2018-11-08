using System;
using CPMG3.API.Handlers;
using CPMG3.API.Service;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CPMG3.API.Extensions
{
    public static class RefitExtension
    {
        public static void AddRefit(this IServiceCollection services)
        {
            services.AddSingleton(new GitHeadersHandler());

            services.AddRefitClient<IGithubAPIService>().ConfigurePrimaryHttpMessageHandler<GitHeadersHandler>()
                   // .AddTypedClient<GitHeadersHandler>()
                    .ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri(ApplicationConstants.Services.API_BASE_ADDRESS);
                    });
        }
    }
}
