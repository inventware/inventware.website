using IAS.Data.Core2.Repositories;
using Inventware.Data.Core2.DbInteractions;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Inventware.Data.Core2.Repositories
{
    public class TextBlockRepository : RepositoryBase<TextBlock, Guid>, ITextBlockRepository
    {
        public TextBlockRepository(SiteDbContext siteContext) : base(siteContext) { }


        public TextBlock GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public TextBlock GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }
    }
}
