using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Model.Contexts;
using ToysAndGames.Services.Contracts;
using ToysAndGames.Services.Services;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace ToysAndGames.TestApi.Fixtures
{
    public class TestProductFixture : TestBedFixture
    {
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            services.AddScoped<IProductService, ProductService>();
                //.Configure<Options>(config => 
                  //  configuration?.GetSection("Options").Bind(config));

            services.AddDbContext<ToysAndGamesDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("t&gamesConnString"),
                    x => x.MigrationsAssembly("ToysAndGames.Model")));
        }

        protected override ValueTask DisposeAsyncCore()
            => new();

        [Obsolete]
        protected override IEnumerable<string> GetConfigurationFiles()
        {
            yield return "appsettings.json";
        }

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "appsettings.json", IsOptional = false };
        }
    }
}
