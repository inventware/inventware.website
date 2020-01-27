using IAS.Domain.Core2.Contracts;
using IAS.Domain.Core2.Entities;
using Inventware.Domain.Core2.Value_Objects;
using System;
using System.Collections.Generic;


namespace Inventware.Domain.Core2.Entities
{
    public class Customer : EntityBase<Guid>, IEntity<Guid>
    {
        // IMPORTANTE: Usado SOMENTE pelo EF
        protected Customer()
            : base(Guid.Empty, null, DateTime.MinValue, Guid.Empty, DateTime.MinValue, Guid.Empty, false, false) { }


        internal Customer(Guid? id, string name, Location location, DateTime createdOn, Guid createdByApplicationUserId,
            DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId, bool isDeleted, bool isActive)
        : base(id.GetValueOrDefault(), null, createdOn, createdByApplicationUserId, lastUpdated,
            lastUpdatedByApplicationUserId, isDeleted, isActive)
        {
            Name = name;
            Location = location;
        }


        public string Name { get; protected set; }

        public Location Location { get; protected set; }

        public ICollection<Logo> Logos { get; protected set; }

        public ICollection<CustomerCase> CustomerCases { get; protected set; }


        // Métodos
        public void AddLogo(string imagePath)
        {
            //Logos.Add(new Logo(this, imagePath, true));
            throw new NotImplementedException();
        }


        public void AddCustomerCase(string title)
        {
            //CustomerCases.Add(new CustomerCase(this, title));
            throw new NotImplementedException();
        }

        public void UnableLogo(string imagePath)
        {
            //var logo = Logos.Where(field => field.ImagePath.Equals(imagePath)).FirstOrDefault();
            //logo.UnableLogo();
            throw new NotImplementedException();
        }
    }
}
