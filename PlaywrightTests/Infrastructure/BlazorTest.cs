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

    private const string _url = "http://localhost:5432/";
    protected Uri RootUri { get; private set; } = default!;

    [SetUp]
    public async Task SetUpWebApplication()
    {
        _host = BuildTestHost();

        await _host.StartAsync();

        RootUri = new(_url);
    }

    public static IHost BuildTestHost(string[]? args = default)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStaticWebAssets();
                builder.UseStartup<Startup>();
                builder.UseUrls(_url);
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
