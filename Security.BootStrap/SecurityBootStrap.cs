using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Domain.Models;

namespace Security.BootStrap
{
    public static class SecurityBootStrap
    {
        public static void WireUP(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<SecurityContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(ConnectionString);
            }, ServiceLifetime.Scoped);


        }
    }
}