using FluentValidation;
using IAS.Domain.Core2.Validations;
using Inventware.Domain.Core2.Commands.CustomerCase;
using System;


namespace Inventware.Domain.Core2.Validations.CustomerCase
{
    public abstract class CustomerCaseValidation<TCmd> : ValidationBase<TCmd>
        where TCmd : CustomerCaseCommand
    {
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("O campo título deve ser preenchido.")
                .Length(3, 120).WithMessage("O campo Título deve ter entre 3 e 128 caracteres.");
        }

        protected void ValidateCustomerId()
        {
            RuleFor(c => c.CustomerId)
                .NotNull().WithMessage("O cliente vinculado a este case (Id) não pode ser nula.")
                .NotEqual(Guid.Empty).WithMessage("O cliente vinculado a este case (Id) não pode estar vazio.");
        }
    }
}
