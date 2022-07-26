﻿using AcceptingOrders.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace AcceptingOrders.Data.Context
{
    public class AcceptingOrdersDbContext : DbContext
    {
        public AcceptingOrdersDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<OrderModel> Order { get; set; }
    }
}