using IAS.Domain.Core2.Contracts;
using IAS.Domain.Core2.Entities;
using System;


namespace Inventware.Domain.Core2.Entities
{
    public class TextBlock : EntityBase<Guid>, IEntity<Guid>
    {
        // IMPORTANTE: Usado SOMENTE pelo EF
        protected TextBlock()
        : base(Guid.Empty, null, DateTime.MinValue, Guid.Empty, DateTime.MinValue, Guid.Empty, false, false) { }


        /// <summary>
        /// - Parâmetros consistidos pela Factory que os cria, não sendo necessário novas consistências redundantemente, 
        /// por isto o modificador de acesso tipo 'internal' (BLINDAGEM).
        /// </summary>
        public TextBlock(Guid? id, long? idOrigin, string name, string content, bool isVisible, Guid createdByApplicationUserId,
            DateTime createdOn, bool isActive, bool isDeleted, DateTime? lastUpdated, Guid? lastUpdatedByApplicationUserId)
        : base(id.GetValueOrDefault(), null, createdOn, createdByApplicationUserId, lastUpdated,
            lastUpdatedByApplicationUserId, isDeleted, isActive)
        {
            Name = name;
            Content = content;
            IsVisible = isVisible;
        }


        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public bool IsVisible { get; protected set; }
    }
}
