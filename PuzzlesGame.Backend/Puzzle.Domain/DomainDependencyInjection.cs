using Microsoft.Extensions.DependencyInjection;
using Puzzle.Domain.Services;

namespace Puzzle.Domain
{
    public static class DomainDependencyInjection
    {
        public static void RegisterDomainDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IResultService, ResultService>()
                .AddScoped<IUserService, UserService>();
        }
    }
}
