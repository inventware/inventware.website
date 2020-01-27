using Inventware.Domain.Core2.Commands.CustomerCase;


namespace Inventware.Domain.Core2.Validations.CustomerCase
{
    public class LogicalExclusionCustomerCaseValidation : CustomerCaseValidation<LogicalExclusionCustomerCaseCommand>
    {
        public LogicalExclusionCustomerCaseValidation()
        {
            ValidateId();
            ValidateLastUpdated();
            ValidateLastUpdatedByApplicationUserId();
        }
    }
}
