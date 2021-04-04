using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Infrastructure.Data;
using Truck.Infrastructure.Repositories;

namespace Truck.IntegrationTests.Data
{
    public abstract class BaseTruckRepoTest
    {
        protected TruckContext _dbContext;

        protected static DbContextOptions<TruckContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<TruckContext>();
            builder.UseInMemoryDatabase("cleanarchitecture")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected TruckRepository GetRepository()
        {
            var options = CreateNewContextOptions();

            _dbContext = new TruckContext(options);
            return new TruckRepository(_dbContext);
        }
    }
}
