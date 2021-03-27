using CastroProgetto.Domain.Repositories;
using CastroProgetto.Persistence.EntityConfiguration;
using CastroProgetto.Persistence.Migrations;
using CastroProgetto.Persistence.Options;
using CastroProgetto.Persistence.Repositories;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CastroProgetto.Persistence
{
    public static class IServiceCollectionExtension
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddFluentMigratorCore()
                .ConfigureRunner(runner =>
                    runner.AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(
                        // REMEMBER, MIGRATIONS MUST BE PUBLIC, IF NOT THEY'RE NOT APPLIED 
                        typeof(AddProductTable).Assembly
                        ).For.Migrations()
                )
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false)
                .GetRequiredService<IMigrationRunner>().MigrateUp();

            RepoDb.PostgreSqlBootstrap.Initialize();
            services.Configure<DbOptions>(options => options.ConnectionString = connectionString);
            Mappings.AddEntitiesMappings();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
