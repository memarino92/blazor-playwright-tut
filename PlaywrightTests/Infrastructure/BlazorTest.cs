using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Playwright.NUnit;
using BlazorApp;
using PlaywrightTests.Infrastructure;

public class BlazorTest : PageTest
{
    private IHost? _host;
    protected Uri RootUri { get; private set; } = default!;

    [SetUp]
    public async Task SetUpWebApplication()
    {
        string[] args = new string[1];
        args[0] = "--urls=http://localhost:5678/";

        _host = BuildTestHost2(args);

        await _host.StartAsync();

        RootUri = new(_host.Services.GetRequiredService<IServer>().Features
            .GetRequiredFeature<IServerAddressesFeature>()
            .Addresses.Single());
    }

    public static IHost BuildWebHost(string[]? args = default)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStaticWebAssets();
                builder.UseStartup<Startup>();
                //builder.UseUrls("http://localhost:5432/");
            })
            .Build();

    public static IHost BuildTestHost(string[]? args = default)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStaticWebAssets();
                builder.UseStartup<TestStartup>();
                builder.UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "BlazorApp", "wwwroot"));
                //builder.UseUrls("http://localhost:5432/");
            })
            .Build();

    public static IHost BuildTestHost2(string[]? args = default)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStaticWebAssets();
                builder.UseStartup<Startup>();
                //builder.UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "BlazorApp", "wwwroot"));
                //builder.UseUrls("http://localhost:5432/");
            })
            .ConfigureTestConfiguration()
            .Build();

    [TearDown]
    public async Task TearDownWebApplication()
    {
        if (_host is not null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }
    }
}
