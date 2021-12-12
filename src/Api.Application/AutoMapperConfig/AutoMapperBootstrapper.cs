using Microsoft.Extensions.DependencyInjection;

namespace Api.Application.AutoMapperConfig
{
    public static class AutoMapperBootstrapper
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
