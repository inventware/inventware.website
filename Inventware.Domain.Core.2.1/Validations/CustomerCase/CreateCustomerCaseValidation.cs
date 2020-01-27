using Inventware.Domain.Core2.Commands.CustomerCase;


namespace Inventware.Domain.Core2.Validations.CustomerCase
{
    public class CreateCustomerCaseValidation : CustomerCaseValidation<CreateCustomerCaseCommand>
    {
        public CreateCustomerCaseValidation()
        {
            ValidateTitle();
            ValidateCustomerId();
            ValidateCreatedByApplicationUserId();
            ValidateCreatedOn();
        }
    }
}
