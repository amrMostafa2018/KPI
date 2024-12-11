using DFI.Application.Features.PKICertificate.Commands;

namespace DFI.Application.Features.Positions.Commands.CreatePosition
{
    public class RevokeSpecifiedCertificateCommandValidator : AbstractValidator<RevokeSpecifiedCertificateCommand>
    {
        public RevokeSpecifiedCertificateCommandValidator()
        {

            RuleFor(p => p.revokeSpecifiedCertificateRequest.IssuerDn)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.CertificateSerialNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.Reason)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.revokeSpecifiedCertificateRequest.InvalidityDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

         
        }

    }
}