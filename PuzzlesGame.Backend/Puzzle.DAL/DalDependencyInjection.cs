using Microsoft.Extensions.DependencyInjection;
using Puzzle.DAL.Interfaces;
using Puzzle.DAL.Repositories;

namespace Puzzle.DAL
{
    public static class DalDependencyInjection
    {
        public static void RegisterDalDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IResultRepository, ResultRepository>()
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
