A working proof-of-concept of how to test a Blazor application using Playwright.

THDW:

1. Use a `Startup` class in the Blazor App
2. Create a `BuildTestHost` Method in test base class that references `Startup`
3. Configure TestHost to use specific URLS - can't bind to normal one for some reason?
4. Write `IHostBuilder` extension method to overwrite normal services with mocked test ones
5. ??
6. Profit

References:

[Scott Hanselman's Blog](https://www.hanselman.com/blog/updating-to-net-8-updating-to-ihostbuilder-and-running-playwright-tests-within-nunit-headless-or-headed-on-any-os)

[Open Dotnet Issue](https://github.com/microsoft/playwright-dotnet/issues/2369)

[Repo from Community Standup](https://github.com/MackinnonBuck/blazor-playwright-example/tree/main)

[Video from Community Standup](https://www.youtube.com/watch?v=lJa3YlUliEs)

[Daniel Donbavand Blog Post](https://danieldonbavand.com/2022/06/13/using-playwright-with-the-webapplicationfactory-to-test-a-blazor-application/)

[The Article I originally used to get an MVC app working](https://www.innovensa.co.uk/blog/in-memory-automated-ui-testing-aspnetcore)

[Another article I didn't find until I already had a working solution](https://asp.net-hacker.rocks/2023/03/08/play-with-playwright.html)
