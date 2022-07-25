namespace AcceptingOrders.HostBuilders
{
    public static class OthersServices
    {
        public static IHostBuilder AddOthersServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddControllersWithViews();
            });
        }
    }
}