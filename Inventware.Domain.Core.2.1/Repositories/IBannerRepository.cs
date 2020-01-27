using IAS.Domain.Core2.Contracts;
using Inventware.Domain.Core2.Entities;
using System;
using System.Threading.Tasks;


namespace Inventware.Domain.Core2.Repositories
{
    public interface IBannerRepository : IRepository<Banner, Guid>
    {
        Task<CustomerCase> GetById(Guid id);
    }
}
