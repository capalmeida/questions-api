using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questions.Services.AutoMapper;
using Questions.Services.Data;

namespace Questions.API.Configurations
{
    /// <summary>
    /// Database Config
    /// </summary>
    public static class DatabaseConfiguration
    {
        /// <summary>
        /// Add Database Configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<QuestionsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LocalConnection")));
        }
    }
}