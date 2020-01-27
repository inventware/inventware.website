using AutoMapper;
using Inventware.Application.Core2.DTOs;
using Inventware.Domain.Core2.Entities;


namespace Inventware.Application.Core2.Mapping
{
    public class WebSiteFromDtoToDomainProfile : Profile
    {
        public WebSiteFromDtoToDomainProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TextBlockDTO, TextBlock>();
            CreateMap<BannerDTO, Banner>();
        }
    }
}
