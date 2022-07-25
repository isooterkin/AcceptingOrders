using AcceptingOrders.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AcceptingOrders.HostBuilders
{
    public static class DatabaseServices
    {
        public static IHostBuilder AddDatabaseServices(this IHostBuilder host, string connectionServer)
        {
            return host.ConfigureServices((context, serviceCollection) =>
            {
                string connectionString = context.Configuration.GetConnectionString(connectionServer);

                void configureDbContext(DbContextOptionsBuilder dbContextOptionsBuilder)
                {
                    dbContextOptionsBuilder.UseNpgsql(connectionString);
                }

                serviceCollection.AddDbContextPool<AcceptingOrdersDbContext>(configureDbContext);

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });
        }
    }
}