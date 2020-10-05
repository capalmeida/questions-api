using Microsoft.Extensions.DependencyInjection;
using Questions.Services.Interfaces;
using Questions.Services.Services;

namespace Questions.API.Configurations
{
    /// <summary>
    /// DependencyInjection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// RegisterServices
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
        }
    }
}