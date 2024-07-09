using Microsoft.Extensions.FileProviders;
using BlazorApp.Components;
using BlazorApp.Access;
using PlaywrightTests.Access;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PlaywrightTests.Infrastructure;

public class TestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
        services.AddSingleton<IExampleService, TestService>();
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        // if (env.IsDevelopment())
        // {
        //     app.UseExceptionHandler("/Error");
        //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //     app.UseHsts();
        // }

        //var CurrentContentRootPath = env.ContentRootPath;

        //Console.WriteLine($"************************************************");
        //Console.WriteLine($"************************************************");
        //Console.WriteLine($"************************************************");
        //Console.WriteLine($"{CurrentContentRootPath}");
        //Console.WriteLine($"************************************************");
        //Console.WriteLine($"************************************************");
        //Console.WriteLine($"************************************************");

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();
        app.UseAntiforgery();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
        });
    }
}
