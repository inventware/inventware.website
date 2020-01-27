using Inventware.Domain.Core2.Validations.CustomerCase;
using System;


namespace Inventware.Domain.Core2.Commands.CustomerCase
{
    public class LogicalExclusionCustomerCaseCommand : CustomerCaseCommand
    {
        public LogicalExclusionCustomerCaseCommand(Guid id, Guid lastUpdatedByApplicationUserId)
        {
            this.Id = id;
            this.LastUpdated = DateTime.Now;
            this.LastUpdatedByApplicationUserId = lastUpdatedByApplicationUserId;
            this.IsDeleted = true;
            this.IsActive = false;
        }


        public override bool IsValid()
        {
            ValidationResult = new LogicalExclusionCustomerCaseValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
