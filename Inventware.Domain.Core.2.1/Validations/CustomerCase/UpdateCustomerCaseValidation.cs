using Inventware.Domain.Core2.Commands.CustomerCase;


namespace Inventware.Domain.Core2.Validations.CustomerCase
{
    public class UpdateCustomerCaseValidation : CustomerCaseValidation<UpdatedCustomerCaseCommand>
    {
        public UpdateCustomerCaseValidation()
        {
            ValidateId();
            ValidateTitle();
            ValidateCustomerId();
            ValidateCreatedByApplicationUserId();
            ValidateLastUpdated();
            ValidateLastUpdatedByApplicationUserId();
        }
    }
}
