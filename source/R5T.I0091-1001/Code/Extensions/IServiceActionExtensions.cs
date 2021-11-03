using System;

using R5T.D1001;
using R5T.T0062;
using R5T.T0063;


namespace R5T.I0091_1001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ApplicationConfigurerBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<TApplicationConfigurer> AddApplicationConfigurerAction<TApplicationConfigurer>(this IServiceAction _,
            IServiceAction<IServiceX> serviceXAction)
            where TApplicationConfigurer : ApplicationConfigurerBase
        {
            var serviceAction = _.New<TApplicationConfigurer>(services => services.AddApplicationConfigurer<TApplicationConfigurer>(
                serviceXAction));

            return serviceAction;
        }
    }
}
