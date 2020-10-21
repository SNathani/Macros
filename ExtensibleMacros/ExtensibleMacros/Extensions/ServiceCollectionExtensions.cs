using Microsoft.Extensions.DependencyInjection;

namespace ExtensibleMacros
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds support for macros - $(Name[#Arguments])
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMacros(this IServiceCollection services)
        {
            services.AddSingleton<IMacroService, MacroService>();
            return services;
        }
    }
}
