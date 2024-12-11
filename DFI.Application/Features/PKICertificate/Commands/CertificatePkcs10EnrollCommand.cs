using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;

namespace DFI.Application.Features.PKICertificate.Commands
{
    public class CertificatePkcs10EnrollCommand : IRequest<Response<CertificatePkcs10EnrollResponse>>
    {
        public CertificatePkcs10EnrollRequest certificatePkcs10EnrollRequest { get; set; }
    }

    public class CertificatePkcs10EnrollCommandHandler : IRequestHandler<CertificatePkcs10EnrollCommand, Response<CertificatePkcs10EnrollResponse>>
    {
        private readonly IPKICertificateService _pKICertificateService;
        private readonly IMapper _mapper;

        public CertificatePkcs10EnrollCommandHandler(IPKICertificateService pKICertificateService)
        {
            _pKICertificateService = pKICertificateService;
        }

        public async Task<Response<CertificatePkcs10EnrollResponse>> Handle(CertificatePkcs10EnrollCommand request, CancellationToken cancellationToken)
        {
            return new Response<CertificatePkcs10EnrollResponse>
            {
                Data = await _pKICertificateService.Pkcs10Enroll(request.certificatePkcs10EnrollRequest)
            };
        }
    }
}
