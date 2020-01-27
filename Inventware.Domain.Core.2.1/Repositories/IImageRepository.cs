using IAS.Domain.Core2.Contracts;
using Inventware.Domain.Core2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventware.Domain.Core2.Repositories
{
    public interface IImageRepository: IRepository<Image, Guid>
    {
        Image GetById(Guid id);
    }
}
