using IAS.Data.Core2.Repositories;
using Inventware.Data.Core2.DbInteractions;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Inventware.Data.Core2.Repositories
{
    public class ImageRepository : RepositoryBase<Image, Guid>, IImageRepository
    {
        public ImageRepository(SiteDbContext siteContext) : base(siteContext) { }


        public Image GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }
    }
}
