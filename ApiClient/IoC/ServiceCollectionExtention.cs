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
        //this method is for setting DI
        public static void AddApiClientService(this IServiceCollection services,Action<ApiClientOptions> options)
        {
            //takes base url and store it in options pattern
            services.Configure(options);
            //singleton if for creating one instence for entire prject
            /* 
             inject the ApiClientOptions into this instance
             */
            services.AddSingleton(provider=>
            {
                var options=provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new ApiClientService(options);
            });
        }
    }
}
