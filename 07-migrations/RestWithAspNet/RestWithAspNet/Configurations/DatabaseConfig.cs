using Microsoft.EntityFrameworkCore;
using RestWithAspNet.Model.Context;

namespace RestWithAspNet.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration["PGSQLConnection:PGSQLConectionString"];
            if (String.IsNullOrEmpty(conectionString))
            {
                throw new ArgumentNullException("Conection 'PGSQLConectionString' string not found");
            }
            services.AddDbContext<PGSQLContext>(options => options.UseNpgsql(conectionString));
            return services;
        }
    }
}
