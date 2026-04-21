using ApiClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.IoC
{
    public static class ServiceCollectionExtention
    {
        public static void AddApiClientService(this IServiceCollection services,Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider=>
            {
                var options=provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new ApiClientService(options);
            });
        }
    }
}
