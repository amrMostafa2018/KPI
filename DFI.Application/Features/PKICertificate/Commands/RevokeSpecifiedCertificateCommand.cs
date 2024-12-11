using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;

namespace DFI.Application.Features.PKICertificate.Commands
{
    public class RevokeSpecifiedCertificateCommand : IRequest<Response<RevokeSpecifiedCertificateResponse>>
    {
        public RevokeSpecifiedCertificateRequest revokeSpecifiedCertificateRequest { get; set; }
    }

    public class RevokeSpecifiedCertificateCommandHandler : IRequestHandler<RevokeSpecifiedCertificateCommand, Response<RevokeSpecifiedCertificateResponse>>
    {
        private readonly IPKICertificateService _pKICertificateService;
        private readonly IMapper _mapper;

        public RevokeSpecifiedCertificateCommandHandler(IPKICertificateService pKICertificateService)
        {
            _pKICertificateService = pKICertificateService;
        }

        public async Task<Response<RevokeSpecifiedCertificateResponse>> Handle(RevokeSpecifiedCertificateCommand request, CancellationToken cancellationToken)
        {
            return new Response<RevokeSpecifiedCertificateResponse>()
            {
                Data = await _pKICertificateService.RevokeSpecifiedCertificate(request.revokeSpecifiedCertificateRequest);
            };
        }
    }
}
