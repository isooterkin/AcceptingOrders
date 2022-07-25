using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AcceptingOrders.Data.Context
{
    public class DesignAcceptingOrdersDbContextFactory : IDesignTimeDbContextFactory<AcceptingOrdersDbContext>
    {
        public AcceptingOrdersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AcceptingOrdersDbContext>();
            
            optionsBuilder.UseNpgsql();

            return new AcceptingOrdersDbContext(optionsBuilder.Options);
        }
    }
}