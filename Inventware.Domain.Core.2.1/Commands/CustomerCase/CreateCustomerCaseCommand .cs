using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Validations.CustomerCase;
using System;
using System.Collections.Generic;


namespace Inventware.Domain.Core2.Commands.CustomerCase
{
    public class CreateCustomerCaseCommand : CustomerCaseCommand
    {
        public CreateCustomerCaseCommand(string title, Guid customerId, ICollection<CustomerImage> images, 
            ICollection<TextBlock> textBlocks, Guid createdByApplicationUserId, bool isDeleted,  bool isActive)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.CustomerId = customerId;
            this.Images = images;
            this.TextBlocks = textBlocks;
            this.CreatedOn = DateTime.Now;
            this.CreatedByApplicationUserId = createdByApplicationUserId;
            this.IsDeleted = false;
            this.IsActive = true;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCustomerCaseValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
