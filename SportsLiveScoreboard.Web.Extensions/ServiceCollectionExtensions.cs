using System;
using Microsoft.Extensions.DependencyInjection;

namespace SportsLiveScoreboard.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServicesFromModule(this IServiceCollection services,
            IServicesModule module)
        {
            module.Register(services);
            return services;
        }

        public static IServiceCollection RegisterServicesFromModule<T>(this IServiceCollection services)
            where T : IServicesModule
        {
            IServicesModule module = Activator.CreateInstance<T>();
            module.Register(services);
            return services;
        }
    }

    public interface IServicesModule
    {
        void Register(IServiceCollection services);
    }
}