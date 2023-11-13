using Desafio.Application.Context;
using Desafio.Application.Repositories;
using Desafio.Application.Services;
using Desafio.Commons.Options;

namespace Desafio.WebAPI.Configuration
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbOptions>(
                    config.GetSection(MongoDbOptions.MongoDb));
            return services;
        }

        public static IServiceCollection ConfigureDI(
             this IServiceCollection services, IConfiguration config)
        {
            var mongoDbOptions = config
                .GetSection(MongoDbOptions.MongoDb)
                .Get<MongoDbOptions>() ?? throw new NullReferenceException("Configuração do Database não inicializada");
            services.AddSingleton<IMongoDbContext>(new MongoDbContext(mongoDbOptions.ConnectionString, mongoDbOptions.Database));
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaServices, PessoaServices>();

            return services;
        }

    }
}
