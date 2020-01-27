using Inventware.Domain.Core2.Enums;
using System;


namespace Inventware.Domain.Core2.Entities
{
    public class Logo : Image
    {
        // IMPORTANTE: Usado SOMENTE pelo EF
        protected Logo() : base(Guid.Empty, string.Empty, string.Empty, DateTime.Now,
            Guid.Empty, DateTime.Now, Guid.Empty, false, false)
        { }

        internal Logo(Guid id, string title, string path, EImageType imageType, Customer customer, DateTime? 
            createdOn, Guid? createdByApplicationUserId, DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId, 
            bool isDeleted, bool isActive)
        : base(id, title, path, createdOn, createdByApplicationUserId, lastUpdated, lastUpdatedByApplicationUserId,
              isDeleted, isActive)
        {
            base.ImageType = Enums.EImageType.LOGOTIPO;
            CustomerId = customer.Id;
            Customer = customer;
        }


        public Guid CustomerId { get; protected set; }

        public Customer Customer { get; protected set; }


        // Métodos
        public void UnableLogo()
        {
            base.IsActive = false;
        }
    }
}
