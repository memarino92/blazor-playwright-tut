
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlaywrightTests.Access;
using BlazorApp.Access;


namespace PlaywrightTests.Infrastructure
{
    public static class TestConfiguration
    {
        /// <summary>
        /// Name for overriding default "production" environment.
        /// </summary>
        public const string AspnetcoreEnvironmentAutomatedTesting = "Development";

        /// <summary>
        /// Set the override of web host configuration.
        /// </summary>
        public static IHostBuilder ConfigureTestConfiguration(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Using AddSingleton instead of TryAddSingleton to explicitly overwrite the injected instances
                services.AddSingleton<IExampleService, TestService>();
            });
            return builder;
        }
    }
}
