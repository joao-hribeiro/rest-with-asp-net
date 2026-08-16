using EvolveDb;
using Npgsql;
using Serilog;
namespace RestWithAspNet.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment enviroment)
        {
            if (enviroment.IsDevelopment())
            {
                var conectionString = configuration["PGSQLConnection:PGSQLConnectionString"];
                if (String.IsNullOrEmpty(conectionString)) throw new ArgumentNullException("Connection string not found");
                try
                {
                    using var evolveConection = new NpgsqlConnection(conectionString);
                    var evolve = new Evolve(evolveConection, msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "database/migrations", "database/dataset" },
                        IsEraseDisabled = true
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occured while migrating the database");
                    throw;
                }
            }

            return services;
        }
    }
}
