using System;
using ConfigCat.Client;
using ConfigCat.Client.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CPMG3.API.Extensions
{
    public static class ConfigCatExtension
    {
        public static void AddConfigCat(this IServiceCollection services, string apiKey)
        {
            services.AddSingleton<IConfigCatClient>(new ConfigCatClient(new LazyLoadConfiguration
            {
                ApiKey = apiKey
            }));
        }
    }
}
