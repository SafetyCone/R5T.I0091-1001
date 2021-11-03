using System;

using Microsoft.AspNetCore.Builder;

using R5T.D1001.I001;


namespace R5T.I0091_1001
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplicationConfigurer<TApplicationConfigurer>(this IApplicationBuilder applicationBuilder)
            where TApplicationConfigurer : ApplicationConfigurerBase
        {
            SyncOverAsyncHelper.ExecuteSynchronously(async () =>
            {
                // Services.
                // Level 0.
                var serviceXAction = Instances.ServiceAction.AddServiceXAction();

                var applicationConfigurerAction = Instances.ServiceAction.AddApplicationConfigurerAction<TApplicationConfigurer>(
                    serviceXAction)
                    ;

                using var applicationConfigurerServiceProvider = Instances.ServiceOperator.GetServiceInstance(
                    applicationConfigurerAction,
                    out TApplicationConfigurer applicationConfigurer);

                await applicationConfigurer.ConfigureApplication(applicationBuilder);
            });

            return applicationBuilder;
        }
    }
}
