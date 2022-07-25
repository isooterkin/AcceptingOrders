using AcceptingOrders.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AcceptingOrders.HostBuilders
{
    public static class DatabaseInitialization
    {
        public static IHost AddDatabaseInitialization(this IHost host)
        {
            using IServiceScope serviceScope = host.Services.CreateScope();
            AcceptingOrdersDbContext context = serviceScope.ServiceProvider.GetRequiredService<AcceptingOrdersDbContext>();

            try
            {
                context.Database.Migrate();

                if (context.Order.Any()) return host;

                // Тестовые данные...
            }
            catch (Exception Exception)
            {
                serviceScope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(Exception, "Ошибка при заполнении базы данных.");
            }

            return host;
        }
    }
}
