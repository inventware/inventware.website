using AutoMapper;


namespace Inventware.Application.Core2.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebSiteFromDomainToDtoProfile());
                cfg.AddProfile(new WebSiteFromDtoToDomainProfile());
            });
        }
    }
}
