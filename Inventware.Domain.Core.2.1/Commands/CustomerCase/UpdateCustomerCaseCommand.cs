using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Validations.CustomerCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventware.Domain.Core2.Commands.CustomerCase
{
    public class UpdatedCustomerCaseCommand : CustomerCaseCommand
    {
        public UpdatedCustomerCaseCommand(Guid id, string title, Guid customerId, ICollection<CustomerImage> images, 
            ICollection<TextBlock> textBlocks, Guid? lastUpdatedByApplicationUserId, bool isDeleted, bool isActive)
        {
            this.Id = id;
            this.Title = title;
            this.CustomerId = customerId;
            this.Images = images;
            this.TextBlocks = textBlocks;
            this.LastUpdated = DateTime.Now;
            this.LastUpdatedByApplicationUserId = lastUpdatedByApplicationUserId.GetValueOrDefault();
            this.IsDeleted = isDeleted;
            this.IsActive = isActive;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCaseValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}