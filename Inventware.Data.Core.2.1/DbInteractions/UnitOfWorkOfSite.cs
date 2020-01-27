using IAS.Data.Core2.UnitOfWork;
using Inventware.Domain.Core2.UnitOfWork;


namespace Inventware.Data.Core2.DbInteractions
{
    public class UnitOfWorkOfSite : UnitOfWorkBase<SiteDbContext>, IUnitOfWorkForSite
    {
        public UnitOfWorkOfSite(SiteDbContext context) : base(context) { }
    }
}
