using System;
using System.Collections.Generic;


namespace Inventware.Domain.Core2.Entities
{
    public class CustomerImage : Image
    {
        // IMPORTANTE: Usado SOMENTE pelo EF
        protected CustomerImage() 
            : base(Guid.Empty, string.Empty, string.Empty, DateTime.Now, Guid.Empty, DateTime.Now, Guid.Empty, 
                  false, false)
        { }


        internal CustomerImage(Guid id, string title, string path, Customer customer, DateTime? createdOn, 
            Guid? createdByApplicationUserId, DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId,
            bool isDeleted, bool isActive, ICollection<Image> images, ICollection<TextBlock> textBlocks)
        : base(id, title, path, createdOn, createdByApplicationUserId, lastUpdated, lastUpdatedByApplicationUserId, 
              isDeleted, isActive)
        {
            base.ImageType = Enums.EImageType.CASE_DE_CLIENTE;
            CustomerId = customer.Id;
            Customer = customer;
        }


        public Guid CustomerId { get; protected set; }

        public Customer Customer { get; protected set; }
    }
}
