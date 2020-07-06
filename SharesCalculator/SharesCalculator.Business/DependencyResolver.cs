using Microsoft.Extensions.DependencyInjection;

namespace SharesCalculator.Business
{
    public static class DependencyResolver
    {
        /// <summary>
        /// // Registers dependencies
        /// </summary>
        /// <param name="services"></param>
        public static void LoadDependencies(IServiceCollection services)
        {
            // Registers dependencies in data layer
            SharesCalculator.Data.DependencyResolver.LoadDependencies(services);

            services.AddTransient<IShareSaleBusiness, ShareSaleBusiness>();


        }

    }
}
