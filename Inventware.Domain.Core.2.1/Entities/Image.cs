using IAS.Domain.Core2.Contracts;
using IAS.Domain.Core2.Entities;
using Inventware.Domain.Core2.Enums;
using System;


namespace Inventware.Domain.Core2.Entities
{
    public abstract class Image : EntityBase<Guid>, IEntity<Guid>
    {
        protected Image(Guid id, string title, string path, DateTime? createdOn, Guid? createdByApplicationUserId, 
            DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId, bool isDeleted, bool isActive)
        : base(Guid.Empty, null, DateTime.MinValue, Guid.Empty, DateTime.MinValue, Guid.Empty, false, false)
        {
            Title = title;
            Path = path;
        }

        public string Title { get; protected set; }

        public string Path { get; protected set; }

        public EImageType ImageType { get; protected set; }
    }
}
