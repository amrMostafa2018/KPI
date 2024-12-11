using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;
using System.Net.Http;
using DFI.Infrastructure.Persistence.helpers;
using DFI.Application.Exceptions;
using System.Security.Cryptography.X509Certificates;
using System;


namespace DFI.Infrastructure.Persistence.Services
{
    public class PKICertificateService : IPKICertificateService
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;
        private readonly ILogger<PKICertificateService> _logger;
        public PKICertificateService(
            HttpClient client,
            IConfiguration configuration,
            ILogger<PKICertificateService> logger
            )
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<CertificatePkcs10EnrollResponse> Pkcs10Enroll(CertificatePkcs10EnrollRequest certificatePkcs10EnrollRequest)
        {

            //try
            //{
            //    // Path to the .p12 (or .pfx) certificate file
            //    string certificatePath = @"197.168.1.67:443\SuperAdmin.p12";
            //    // Password for the certificate file
            //    string certificatePassword = "foo123";

            //    // Load the certificate
            //    X509Certificate2 certificate = new X509Certificate2(certificatePath, certificatePassword);

            //    // Create a HttpClientHandler and attach the certificate
            //    var handler = new HttpClientHandler();
            //    handler.ClientCertificates.Add(certificate);

            //    // Optional: Ignore SSL errors for development purposes (not recommended for production)
            //    //handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            //    var data = new JsonContent(certificatePkcs10EnrollRequest);
            //    // Create HttpClient with the handler
            //    using (var client = new HttpClient(handler))
            //    {
            //        // Make a request
            //        var response = await client.PostAsync("https://197.168.1.67/ejbca/ejbca-rest-api/v1/certificate/pkcs10enroll", data);
            //        //HttpResponseMessage response = client.PostAsync("https://197.168.1.67/ejbca/ejbca-rest-api/v1/certificate/pkcs10enroll", data).Result;

            //        // Read and display the response
            //        Console.WriteLine($"Response status: {response.StatusCode}");
            //        Console.WriteLine($"Response content: {response.Content.ReadAsStringAsync().Result}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}



            // X509Certificate2 certificate = new X509Certificate2(@"C:\Users\amr.mostafa\Downloads\PKI\PKI\SuperAdmin.p12", "foo123", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            ////var certificate = new X509Certificate2(@"D:\SuperAdmin.p12", "foo123");
            //var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(certificate);
            //var EJBCASetting = GetEJBCASettings();
            //var Url = $"{EJBCASetting.URL}/v1/certificate/pkcs10enroll";
            //var data = new JsonContent(certificatePkcs10EnrollRequest);
            //using (var httpClient = new HttpClient(handler))
            //{
            //    using (var response = await httpClient.PostAsync(Url, data))
            //    {
            //        var returnValue = await response.Content.ReadAsStringAsync();
            //        // Console.WriteLine(returnValue);
            //    }
            //}


            _logger.LogInformation($"Create Certificate in Pkcs10Enroll with Certificate_Request: {certificatePkcs10EnrollRequest.Certificate_Request}");
            var EJBCASetting = GetEJBCASettings();
            var Url = $"{EJBCASetting.URL}/v1/certificate/pkcs10enroll";
            var data = new JsonContent(certificatePkcs10EnrollRequest);
            var response = await _client.PostAsync(Url, data);
            //TODO: Handle in case Error
            _logger.LogInformation($"Response CPkcs10Enroll in PKICertificateService : {response}");
            var returnedData = await response.ReadContentAs<CertificatePkcs10EnrollResponse>();
            return returnedData;

            return null;

        }

        public async Task<RevokeSpecifiedCertificateResponse> RevokeSpecifiedCertificate(RevokeSpecifiedCertificateRequest revokeSpecifiedCertificateRequest)
        {
            _logger.LogInformation($"Revoke Specified Certificate in Revoke with IssuerDn: {revokeSpecifiedCertificateRequest.IssuerDn}");
            var EJBCASetting = GetEJBCASettings();
            var Url = $"{EJBCASetting.URL}/v1/certificate/{revokeSpecifiedCertificateRequest.IssuerDn}/{revokeSpecifiedCertificateRequest.CertificateSerialNumber}/revoke?reason={revokeSpecifiedCertificateRequest.Reason}&date={revokeSpecifiedCertificateRequest.Date.ToString()}&invalidity_date={revokeSpecifiedCertificateRequest.InvalidityDate.ToString()}";
            var response = await _client.PutAsync(Url, null);
            //TODO: Handle in case Error
            _logger.LogInformation($"Response Revoke Specified Certificate  in PKICertificateService : {response}");
            var returnedData = await response.ReadContentAs<RevokeSpecifiedCertificateResponse>();
            return returnedData;
        }


        public async Task<SearchCertificateConfirmedResponse> SearchCertificateConfirmed(SearchCertificateConfirmedRequest searchCertificateConfirmedRequest)
        {
            _logger.LogInformation($"Search Certificate Confirmed with Max_Number_Of_Results: {searchCertificateConfirmedRequest.Max_Number_Of_Results}");
            var EJBCASetting = GetEJBCASettings();
            var Url = $"{EJBCASetting.URL}/v1/certificate/search";
            var data = new JsonContent(searchCertificateConfirmedRequest);
            var response = await _client.PostAsync(Url, data);
            //TODO: Handle in case Error
            _logger.LogInformation($"Response Search Certificate Confirmed  in PKICertificateService : {response}");
            var returnedData = await response.ReadContentAs<SearchCertificateConfirmedResponse>();
            return returnedData;
        }

        private EJBCASetting GetEJBCASettings()
        {
            EJBCASetting eJBCASetting = new EJBCASetting();
            eJBCASetting.URL = _configuration["ApiSettings:EJBCASettings:URL"];
            return eJBCASetting;
        }


    }
}
