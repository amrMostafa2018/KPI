using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;

namespace DFI.Application.Features.PKICertificate.Commands
{
    public class SearchCertificateConfirmedCommand : IRequest<ResponseVM>
    {
        public SearchCertificateConfirmedRequest searchCertificateConfirmedRequest { get; set; }
    }

    public class SearchCertificateConfirmedCommandHandler : IRequestHandler<SearchCertificateConfirmedCommand, ResponseVM>
    {
        private readonly IPKICertificateService _pKICertificateService;
        private readonly IMapper _mapper;

        public SearchCertificateConfirmedCommandHandler(IPKICertificateService pKICertificateService)
        {
            _pKICertificateService = pKICertificateService;
        }

        public async Task<ResponseVM> Handle(SearchCertificateConfirmedCommand request, CancellationToken cancellationToken)
        {
            return await _pKICertificateService.SearchCertificateConfirmed(request.searchCertificateConfirmedRequest);
        }
    }
}
