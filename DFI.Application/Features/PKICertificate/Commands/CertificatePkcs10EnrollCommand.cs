using DFI.Application.DTOs.PKICertificate;

namespace DFI.Application.Features.PKICertificate.Commands
{
    public class CertificatePkcs10EnrollCommand : IRequest<ResponseVM>
    {
        public CertificatePkcs10EnrollRequest certificatePkcs10EnrollRequest { get; set; }
    }

    public class CertificatePkcs10EnrollCommandHandler : IRequestHandler<CertificatePkcs10EnrollCommand, ResponseVM>
    {
        private readonly IPKICertificateService _pKICertificateService;
        private readonly IMapper _mapper;

        public CertificatePkcs10EnrollCommandHandler(IPKICertificateService pKICertificateService)
        {
            _pKICertificateService = pKICertificateService;
        }

        public async Task<ResponseVM> Handle(CertificatePkcs10EnrollCommand request, CancellationToken cancellationToken)
        {
           return await _pKICertificateService.Pkcs10Enroll(request.certificatePkcs10EnrollRequest);
        }
    }
}
