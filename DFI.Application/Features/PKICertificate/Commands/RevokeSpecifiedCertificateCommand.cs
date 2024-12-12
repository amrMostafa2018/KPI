using DFI.Application.DTOs.PKICertificate;

namespace DFI.Application.Features.PKICertificate.Commands
{
    public class RevokeSpecifiedCertificateCommand : IRequest<ResponseVM>
    {
        public RevokeSpecifiedCertificateRequest revokeSpecifiedCertificateRequest { get; set; }
    }

    public class RevokeSpecifiedCertificateCommandHandler : IRequestHandler<RevokeSpecifiedCertificateCommand, ResponseVM>
    {
        private readonly IPKICertificateService _pKICertificateService;
        private readonly IMapper _mapper;

        public RevokeSpecifiedCertificateCommandHandler(IPKICertificateService pKICertificateService)
        {
            _pKICertificateService = pKICertificateService;
        }

        public async Task<ResponseVM> Handle(RevokeSpecifiedCertificateCommand request, CancellationToken cancellationToken)
        {
            return await _pKICertificateService.RevokeSpecifiedCertificate(request.revokeSpecifiedCertificateRequest);
        }
    }
}
