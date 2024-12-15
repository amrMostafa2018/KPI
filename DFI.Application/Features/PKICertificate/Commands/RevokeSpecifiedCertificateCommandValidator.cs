using DFI.Application.Features.PKICertificate.Commands;

namespace DFI.Application.Features.Positions.Commands.CreatePosition
{
    public class RevokeSpecifiedCertificateCommandValidator : AbstractValidator<RevokeSpecifiedCertificateCommand>
    {
        public RevokeSpecifiedCertificateCommandValidator()
        {

            RuleFor(p => p.revokeSpecifiedCertificateRequest.issuerDn)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.certificateSerialNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.reason)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.invalidityDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

         
        }

    }
}