using DFI.Application.Interfaces;
using DFI.Infrastructure.Persistence.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

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
         }).ConfigurePrimaryHttpMessageHandler(() =>
         {
             var handler = new HttpClientHandler();

             // Load the client certificate
             var clientCertPath = @"C:\Azure\KPI\DFI.WebApi\Certificate\SuperAdmin.p12";
             var clientCertPassword = "foo123";
             var clientCertificate = new X509Certificate2(clientCertPath, clientCertPassword);

             handler.ClientCertificates.Add(clientCertificate);

             // Optional: Load CA certificate and configure validation
             var caCertPath = @"C:\Azure\KPI\DFI.WebApi\Certificate\ManagementCA.pem";
             var caCertificate = new X509Certificate2(caCertPath);

             handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
             {
                 chain.ChainPolicy.ExtraStore.Add(caCertificate);
                 chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                 chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

                 // Validate the chain
                 return chain.Build(cert);
             };

             return handler;
         });
    }

}
