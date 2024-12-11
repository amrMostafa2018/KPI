using DFI.Application.Interfaces;
using DFI.Infrastructure.Persistence.Services;
using System.Net.Http.Headers;

namespace DFI.WebApi.Configurations;

public static class HttpClientConfig
{
    public static void AddHttpClientConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHttpClient<IPKICertificateService, PKICertificateService>(c =>
         {
             c.BaseAddress = new Uri(configuration["ApiSettings:EJBCASettings:URL"]);
             c.Timeout = TimeSpan.FromMinutes(3);
             c.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
         });
    }

}
