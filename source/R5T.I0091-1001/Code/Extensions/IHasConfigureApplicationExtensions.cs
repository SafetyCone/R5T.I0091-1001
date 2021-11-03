using System;

using R5T.T0074;

using R5T.I0091_1001;


namespace System
{
    public static class IHasConfigureServicesExtensions
    {
        public static TApplicationBuilder UseApplicationConfigurer<TApplicationConfigurer, TApplicationBuilder>(this TApplicationBuilder servicesBuilder)
            where TApplicationBuilder : IHasConfigureApplication<TApplicationBuilder>
            where TApplicationConfigurer : ApplicationConfigurerBase
        {
            servicesBuilder.ConfigureApplication(applicationBuilder =>
            {
                applicationBuilder.UseApplicationConfigurer<TApplicationConfigurer>();
            });

            return servicesBuilder;
        }
    }
}
