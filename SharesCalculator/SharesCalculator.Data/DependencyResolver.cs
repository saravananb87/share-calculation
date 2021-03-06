﻿using Microsoft.Extensions.DependencyInjection;

namespace SharesCalculator.Data
{
    /// <summary>
    /// Registers dependencies
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Registers dependencies in data layer
        /// </summary>
        /// <param name="services"></param>
        public static void LoadDependencies(IServiceCollection services)
        {
            services.AddSingleton<IShareData, ShareData>();
            
        }

    }
}
