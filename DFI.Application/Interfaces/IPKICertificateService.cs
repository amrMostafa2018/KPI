using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;

namespace DFI.Application.Interfaces
{
    public interface IPKICertificateService
    {
        public Task<CertificatePkcs10EnrollResponse> Pkcs10Enroll(CertificatePkcs10EnrollRequest certificatePkcs10EnrollRequest);
        public Task<RevokeSpecifiedCertificateResponse> RevokeSpecifiedCertificate(RevokeSpecifiedCertificateRequest revokeSpecifiedCertificateRequest);
        public Task<SearchCertificateConfirmedResponse> SearchCertificateConfirmed(SearchCertificateConfirmedRequest searchCertificateConfirmedRequest);

    }
}
