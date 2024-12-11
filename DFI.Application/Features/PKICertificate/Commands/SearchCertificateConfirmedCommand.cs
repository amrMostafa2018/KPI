using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.ViewModel;

namespace DFI.Application.Features.PKICertificate.Commands
{
    public class SearchCertificateConfirmedCommand : IRequest<Response<SearchCertificateConfirmedResponse>>
    {
        public SearchCertificateConfirmedRequest searchCertificateConfirmedRequest { get; set; }
    }

    public class SearchCertificateConfirmedCommandHandler : IRequestHandler<SearchCertificateConfirmedCommand, Response<SearchCertificateConfirmedResponse>>
    {
        private readonly IPKICertificateService _pKICertificateService;
        private readonly IMapper _mapper;

        public SearchCertificateConfirmedCommandHandler(IPKICertificateService pKICertificateService)
        {
            _pKICertificateService = pKICertificateService;
        }

        public async Task<Response<SearchCertificateConfirmedResponse>> Handle(SearchCertificateConfirmedCommand request, CancellationToken cancellationToken)
        {
            return new Response<SearchCertificateConfirmedResponse>
            {
                Data = await _pKICertificateService.SearchCertificateConfirmed(request.searchCertificateConfirmedRequest)
            };
        }
    }
}
