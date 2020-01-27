using IAS.Domain.Core2.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventware.Domain.Core2.Events.CustomerCase
{
    public class CustomerCaseUpdatedEvent: Event
    {
        public CustomerCaseUpdatedEvent(Guid id, string title, Guid customerId, string customerName)
        {
            Id = id;
            Title = title;
            CustomerId = customerId;
            CustomerName = customerName;
            AggregateId = id;
        }


        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public Guid CustomerId { get; private set; }

        public string CustomerName { get; private set; }
    }
}
