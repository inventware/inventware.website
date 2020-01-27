using IAS.Domain.Core2.Contracts;
using Inventware.Domain.Core2.Entities;
using System;
using System.Threading.Tasks;


namespace Inventware.Domain.Core2.Repositories
{
    public interface ICustomerCaseRepository : IRepository<CustomerCase, Guid>
    {
        Task<CustomerCase> GetById(Guid id);

        Task<CustomerCase> GetByTitle(string title);

        Task<CustomerCase> GetAnotherIdAndSameTitlesync(Guid id, string title);
    }
}
