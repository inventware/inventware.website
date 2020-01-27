using IAS.Data.Core2.Repositories;
using Inventware.Data.Core2.DbInteractions;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Inventware.Data.Core2.Repositories
{
    public class CustomerCaseRepository : RepositoryBase<CustomerCase,Guid>, ICustomerCaseRepository
    {
        public CustomerCaseRepository(SiteDbContext context) : base(context) { }


        public async Task<CustomerCase> GetById(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CustomerCase> GetByTitle(string title)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Title == title);
        }


        public async Task<CustomerCase> GetAnotherIdAndSameTitlesync(Guid id, string title)
        {
            return await DbSet
                .Where(field => field.Title.Equals(title) && field.Id != id &&
                    field.IsActive.Equals(true) && field.IsDeleted.Equals(false))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
