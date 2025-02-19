using BooksLibrary.Application.Interfaces;
using BooksLibrary.Infra.CrossCutting.Integrations.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BooksLibrary.Infra.CrossCutting.IoT
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            
            services.AddSingleton<IBooksApiService, BooksApiService>();
        }
    }
}
