using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;

using R5T.D0091;
using R5T.D1001;
using R5T.D1001.A001;using R5T.T0064;


namespace R5T.I0091_1001
{[ServiceImplementationMarker]
    public abstract class ApplicationConfigurerBase : IApplicationConfigurer,IServiceImplementation
    {
        protected IServiceX ServiceX { get; }


        public ApplicationConfigurerBase(
            IServiceX serviceX)
        {
            this.ServiceX = serviceX;
        }

        public async Task ConfigureApplication(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine($"In {nameof(ApplicationConfigurerBase)}.{nameof(ConfigureApplication)}.");

            await this.ServiceX.RunX();

            // Services.
            var serviceZActionAggregation = Instances.ServiceAction.AddServiceZActionAggregation();

            await this.ConfigureApplication(applicationBuilder,
                serviceZActionAggregation);
        }

        protected abstract Task ConfigureApplication(IApplicationBuilder applicationBuilder,
            IServiceZActionAggregation serviceZActionAggregation);
    }
}
