using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;

namespace DFI.Application.Interfaces
{
    public interface IPKICertificateService
    {
        public Task<ResponseVM> Pkcs10Enroll(CertificatePkcs10EnrollRequest certificatePkcs10EnrollRequest);
        public Task<ResponseVM> RevokeSpecifiedCertificate(RevokeSpecifiedCertificateRequest revokeSpecifiedCertificateRequest);
        public Task<ResponseVM> SearchCertificateConfirmed(SearchCertificateConfirmedRequest searchCertificateConfirmedRequest);

    }
}
