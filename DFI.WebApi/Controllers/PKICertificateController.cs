using DFI.Application.DTOs.PKICertificate;
using DFI.Application.Features.PKICertificate.Commands;

namespace DFI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PKICertificateController : BaseApiController
    {
        [HttpPost("PKICertificate")]
        public async Task<IActionResult> PKICertificate([FromBody] CertificatePkcs10EnrollRequest request)
        {
            return Ok(await Mediator.Send(new CertificatePkcs10EnrollCommand() { certificatePkcs10EnrollRequest = request}));
        }

        [HttpPost("RevokeSpecifiedCertificate")]
        public async Task<IActionResult> RevokeSpecifiedCertificate([FromBody] RevokeSpecifiedCertificateRequest request)
        {
            return Ok(await Mediator.Send(new RevokeSpecifiedCertificateCommand() { revokeSpecifiedCertificateRequest = request }));
        }

        [HttpPost("SearchCertificateConfirmed")]
        public async Task<IActionResult> SearchCertificateConfirmed([FromBody] SearchCertificateConfirmedRequest request)
        {
            return Ok(await Mediator.Send(new SearchCertificateConfirmedCommand() { searchCertificateConfirmedRequest = request }));
        }
    }
}
