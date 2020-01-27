using AutoMapper;
using Inventware.Application.Core2.DTOs;
using Inventware.Domain.Core2.Entities;


namespace Inventware.Application.Core2.Mapping
{
    public class WebSiteFromDomainToDtoProfile : Profile
    {
        public WebSiteFromDomainToDtoProfile()
        {
            CreateMap<TextBlock, TextBlockDTO>();
            CreateMap<Banner, BannerDTO>();
        }
    }
}
