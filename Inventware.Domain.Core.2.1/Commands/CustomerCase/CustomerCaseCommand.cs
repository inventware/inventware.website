using IAS.Domain.Core2.Commands;
using Inventware.Domain.Core2.Entities;
using System;
using System.Collections.Generic;


namespace Inventware.Domain.Core2.Commands.CustomerCase
{
    public abstract class CustomerCaseCommand : Command
    {

        public string Title { get; protected set; }

        public Guid CustomerId { get; protected set; }

        public ICollection<CustomerImage> Images { get; protected set; }

        public ICollection<TextBlock> TextBlocks { get; protected set; }
    }
}
