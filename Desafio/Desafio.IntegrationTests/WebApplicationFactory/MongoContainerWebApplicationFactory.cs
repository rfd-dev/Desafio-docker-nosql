using Desafio.Application.Context;
using Desafio.Commons.Options;
using Desafio.WebAPI.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MongoDb;

namespace Desafio.IntegrationTests.WebApplicationFactory
{
    public class MongoContainerWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>, IAsyncLifetime where TProgram : class 
    {
        private readonly MongoDbContainer _mongoDbContainer = new MongoDbBuilder()
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(IMongoDbContext));

                if(dbContextDescriptor is not null)
                {
                    services.Remove(dbContextDescriptor);
                }

                var mongoDbContext = new MongoDbContext(_mongoDbContainer.GetConnectionString(), "DesafioDB");
                services.AddSingleton<IMongoDbContext>(mongoDbContext);

                DbSeedingUtilities.SeedDbForTests(mongoDbContext);
            });

            builder.UseEnvironment("Development");
        }

        public async Task InitializeAsync() => await _mongoDbContainer.StartAsync();

        public new async Task DisposeAsync() => await _mongoDbContainer.DisposeAsync();
    }
}
