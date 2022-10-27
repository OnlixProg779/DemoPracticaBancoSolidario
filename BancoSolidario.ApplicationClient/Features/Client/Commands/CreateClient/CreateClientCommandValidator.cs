using FluentValidation;

namespace BancoSolidario.ApplicationClient.Features.Client.Commands.CreatePlanAhorro
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(client => client.Cedula)
                .NotEmpty().WithMessage("El campo cedula no puede estar vacio")
                .Length(10,10).WithMessage("La cedula debe estar compuesta por 10 digitos")
                .Matches("^[0-9]+$").WithMessage("Le campo cedula solo puede contener numeros");

            RuleFor(client => client.Nombre)
                .NotEmpty().WithMessage("El campo nombre no puede estar vacio")
                .Length(2, 50).WithMessage("{ PropertyName} tiene { TotalLength} letras.Debe tener una longitud entre { MinLength} y { MaxLength} letras.");
        }
    }
}
