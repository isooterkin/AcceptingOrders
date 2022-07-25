using AcceptingOrders.HostBuilders;

namespace AcceptingOrders
{
    public class Program
    {
        public static void Main(string[] arguments) => Host
            .CreateDefaultBuilder(arguments)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .AddDatabaseServices("PGSQL")
            .AddOthersServices()
            .Build()
            .Run();
    }
}