using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;
using System.Net.Http;
using DFI.Infrastructure.Persistence.helpers;
using DFI.Application.Exceptions;
using DFI.Application.Wrappers;

namespace DFI.Infrastructure.Persistence.Services
{
    public class PKICertificateService : IPKICertificateService
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;
        private readonly ILogger<PKICertificateService> _logger;
        public PKICertificateService(HttpClient client,
                                     IConfiguration configuration,
                                     ILogger<PKICertificateService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ResponseVM> Pkcs10Enroll(CertificatePkcs10EnrollRequest certificatePkcs10EnrollRequest)
        {
            _logger.LogInformation($"Create Certificate in Pkcs10Enroll with Certificate_Request: {certificatePkcs10EnrollRequest.certificate_request}");
            var EJBCASetting = GetEJBCASettings();
            var Url = $"{EJBCASetting.URL}/v1/certificate/pkcs10enroll";
            var data = new JsonContent(certificatePkcs10EnrollRequest);
            var response = await _client.PostAsync(Url, data);
            _logger.LogInformation($"Response CPkcs10Enroll in PKICertificateService : {response}");
            if (response.IsSuccessStatusCode)
            {
                return new ResponseVM()
                {
                    Data = await response.ReadContentAs<CertificatePkcs10EnrollResponse>()
                };
            }
            else
            {
                var result = await response.ReadContentAs<ErrorResponse>();
               return new ResponseVM()
                {
                    Data = result,
                    StatusCode = response.StatusCode,
                    Error = result.error_message
                };
            }
        }

        public async Task<ResponseVM> RevokeSpecifiedCertificate(RevokeSpecifiedCertificateRequest revokeSpecifiedCertificateRequest)
        {
            _logger.LogInformation($"Revoke Specified Certificate in Revoke with IssuerDn: {revokeSpecifiedCertificateRequest.issuerDn}");
            var EJBCASetting = GetEJBCASettings();
            var Url = $"{EJBCASetting.URL}/v1/certificate/{revokeSpecifiedCertificateRequest.issuerDn}/{revokeSpecifiedCertificateRequest.certificateSerialNumber}/revoke?reason={revokeSpecifiedCertificateRequest.reason}&date={revokeSpecifiedCertificateRequest.date.ToString()}&invalidity_date={revokeSpecifiedCertificateRequest.invalidityDate.ToString()}";
            var response = await _client.PutAsync(Url, null);
            //TODO: Handle in case Error
            _logger.LogInformation($"Response Revoke Specified Certificate  in PKICertificateService : {response}");
            if (response.IsSuccessStatusCode)
            {
                return new ResponseVM()
                {
                    Data = await response.ReadContentAs<RevokeSpecifiedCertificateResponse>()
                };
            }
            else
            {
                var result = await response.ReadContentAs<ErrorResponse>();
                return new ResponseVM()
                {
                    Data = result,
                    StatusCode = response.StatusCode,
                    Error = result.error_message
                };
            }
        }


        public async Task<ResponseVM> SearchCertificateConfirmed(SearchCertificateConfirmedRequest searchCertificateConfirmedRequest)
        {
            _logger.LogInformation($"Search Certificate Confirmed with Max_Number_Of_Results: {searchCertificateConfirmedRequest.max_number_of_results}");
            var EJBCASetting = GetEJBCASettings();
            var Url = $"{EJBCASetting.URL}/v1/certificate/search";
            var data = new JsonContent(searchCertificateConfirmedRequest);
            var response = await _client.PostAsync(Url, data);
            _logger.LogInformation($"Response Search Certificate Confirmed  in PKICertificateService : {response}");
            if (response.IsSuccessStatusCode)
            {
                return new ResponseVM()
                {
                    Data = await response.ReadContentAs<SearchCertificateConfirmedResponse>()
                };
            }
            else
            {
                var result = await response.ReadContentAs<ErrorResponse>();
                return new ResponseVM()
                {
                    Data = result,
                    StatusCode = response.StatusCode,
                    Error = result.error_message
                };
            }
        }

        private EJBCASetting GetEJBCASettings()
        {
            EJBCASetting eJBCASetting = new EJBCASetting();
            eJBCASetting.URL = _configuration["ApiSettings:EJBCASettings:URL"];
            return eJBCASetting;
        }
    }
}
