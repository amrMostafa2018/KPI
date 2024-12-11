using DFI.Application.Features.PKICertificate.Commands;

namespace DFI.Application.Features.Positions.Commands.CreatePosition
{
    public class CertificatePkcs10EnrollCommandValidator : AbstractValidator<CertificatePkcs10EnrollCommand>
    {
        public CertificatePkcs10EnrollCommandValidator()
        {

            RuleFor(p => p.certificatePkcs10EnrollRequest.Certificate_Request)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.Certificate_Profile_Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.End_Entity_Profile_Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.Certificate_Authority_Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.certificatePkcs10EnrollRequest.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

    }
}