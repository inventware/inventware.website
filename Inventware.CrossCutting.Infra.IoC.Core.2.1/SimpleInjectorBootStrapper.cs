using AutoMapper;
using IAS.Domain.Core2.UnitOfWork;
using Inventware.Data.Core2.DbInteractions;
using Inventware.Domain.Core2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Inventware.CrossCutting.Infra.IoC.Core2
{
    public class SimpleInjectorBootStrapper
    {
        public SimpleInjectorBootStrapper()
        {
        }

        public IConfigurationRoot Configuration { get; }


        public static void RegisterServices(IServiceCollection services)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// INTERFACE LAYER

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// APPLICATION LAYER
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            //services.AddScoped<IBannerAppService, BannerAppService>();
            //services.AddScoped<IBlockAppService, BlockAppService>();


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// DOMAIN LAYER
            services.AddScoped<ITextBlockService, TextBlockService>();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            // DATA LAYER
            // Entity Framework Core
            //services.AddScoped<SiteDbContext>(_ => new SiteDbContext(Configuration.GetConnectionString("ArborixConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWorkOfSite>();
            //services.AddScoped<IBlockRepository, BlockRepository>();
        }
    }
}
