using IAS.Domain.Core2.Contracts;
using Inventware.Domain.Core2.Entities;
using System;


namespace Inventware.Domain.Core2.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Customer GetById(Guid id);
    }
}
