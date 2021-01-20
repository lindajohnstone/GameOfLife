using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var app = serviceProvider.GetService<MyApplication>();
                app.Run();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .AddTransient<MyApplication>()
                    .AddTransient<UniverseGenerator>()
                    .AddTransient<GameController>()
                    .AddTransient<IReader, FileReader>()
                    .AddTransient<IOutput, ConsoleOutput>()
                    .AddTransient<IInput, ConsoleInput>()
                    .AddSingleton<Universe>();
        }
    }
}
