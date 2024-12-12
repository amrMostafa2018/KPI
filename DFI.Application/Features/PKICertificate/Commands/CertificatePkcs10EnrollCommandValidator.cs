using DFI.Application.Features.PKICertificate.Commands;

namespace DFI.Application.Features.Positions.Commands.CreatePosition
{
    public class CertificatePkcs10EnrollCommandValidator : AbstractValidator<CertificatePkcs10EnrollCommand>
    {
        public CertificatePkcs10EnrollCommandValidator()
        {

            RuleFor(p => p.certificatePkcs10EnrollRequest.certificate_request)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.certificate_profile_name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.end_entity_profile_name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.certificate_authority_name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.username)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

    }
}