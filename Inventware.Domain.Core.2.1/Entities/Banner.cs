using IAS.Domain.Core2.Contracts;
using IAS.Domain.Core2.Entities;
using System;


namespace Inventware.Domain.Core2.Entities
{
    public class Banner : EntityBase<Guid>, IEntity<Guid>
    {
        /// IMPORTANTE: Usado SOMENTE pelo EF
        protected Banner()
            : base(Guid.Empty, null, DateTime.MinValue, Guid.Empty, DateTime.MinValue, Guid.Empty, false, false) { }


        /// <summary>
        /// - Parâmetros consistidos pela Factory que os cria, não sendo necessário novas consistências redundantemente, 
        /// por isto o modificador de acesso tipo 'internal' (BLINDAGEM).
        internal Banner(Guid? id, byte order, string filePath, DateTime createdOn, Guid createdByApplicationUserId, 
            DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId, bool isDeleted, bool isActive)
        : base(id.GetValueOrDefault(), null, createdOn, createdByApplicationUserId, lastUpdated,
            lastUpdatedByApplicationUserId, isDeleted, isActive)
        {
            Order = order;
            FilePath = filePath;
        }


        public byte Order { get; protected set; }

        public string FilePath { get; protected set; }
    }
}
