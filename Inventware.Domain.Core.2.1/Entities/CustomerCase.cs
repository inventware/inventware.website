using IAS.Domain.Core2.Entities;
using System;
using System.Collections.Generic;


namespace Inventware.Domain.Core2.Entities
{
    public class CustomerCase : EntityBase<Guid>
    {        
        // IMPORTANTE: Usado SOMENTE pelo EF
        protected CustomerCase()
            : base(Guid.Empty, null, DateTime.MinValue, Guid.Empty, DateTime.MinValue, Guid.Empty, false, false)
        {
            Images = new List<CustomerImage>();
            TextBlocks = new List<TextBlock>();
        }


        public CustomerCase (Guid? id, string title, Customer customer, DateTime createdOn, Guid 
            createdByApplicationUserId, DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId, 
            bool isDeleted, bool isActive, ICollection<CustomerImage> images, ICollection<TextBlock> textBlocks)
        : base(id.GetValueOrDefault(), null, createdOn, createdByApplicationUserId, lastUpdated,
            lastUpdatedByApplicationUserId, isDeleted, isActive)
        {
            Title = title;
            CustomerId = customer.Id;
            Customer = customer;
            Images = images == null ? new List<CustomerImage>() : images;
            TextBlocks = textBlocks == null ? new List<TextBlock>(): textBlocks;
        }


        public string Title { get; protected set; }

        public Guid CustomerId { get; protected set; }

        public Customer Customer { get; protected set; }

        private ICollection<CustomerImage> Images { get; set; }

        private ICollection<TextBlock> TextBlocks { get; set; }

        public void AddImage(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
