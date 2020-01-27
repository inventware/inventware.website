using IAS.Data.Core2.Repositories;
using Inventware.Data.Core2.DbInteractions;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventware.Data.Core2.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(SiteDbContext context) : base(context) {}


        public Customer GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }
    }
}
