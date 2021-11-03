using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D1001;
using R5T.T0063;


namespace R5T.I0091_1001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ApplicationConfigurerBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddApplicationConfigurer<TApplicationConfigurer>(this IServiceCollection services,
            IServiceAction<IServiceX> serviceXAction)
            where TApplicationConfigurer : ApplicationConfigurerBase
        {
            services.AddSingleton<TApplicationConfigurer>()
                .Run(serviceXAction)
                ;

            return services;
        }
    }
}
