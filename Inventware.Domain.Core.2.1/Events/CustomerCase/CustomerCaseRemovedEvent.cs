using IAS.Domain.Core2.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventware.Domain.Core2.Events.CustomerCase
{
    public class CustomerCaseRemovedEvent: Event
    {
        public CustomerCaseRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }


        public Guid Id { get; private set; }
    }
}
