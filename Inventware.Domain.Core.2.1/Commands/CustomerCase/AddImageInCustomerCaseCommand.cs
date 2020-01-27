using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Validations.CustomerCase;
using System;
using System.Collections.Generic;


namespace Inventware.Domain.Core2.Commands.CustomerCase
{
    public class AddImageInTheCustomerCaseCommand : CustomerCaseCommand
    {
        public AddImageInTheCustomerCaseCommand(Guid id, Image imageToInsert, ICollection<CustomerImage> images)
        {
            this.Id = id;
            this.Images = images;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddImageInTheCustomerCaseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
