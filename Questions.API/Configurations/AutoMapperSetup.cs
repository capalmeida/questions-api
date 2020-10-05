using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Questions.Services.AutoMapper;

namespace Questions.API.Configurations
{
    /// <summary>
    /// AutoMapperSetup
    /// </summary>
    public static class AutoMapperSetup
    {
        /// <summary>
        /// AddAutoMapperSetup
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));

            AutoMapperConfig.RegisterMappings();
        }
    }
}