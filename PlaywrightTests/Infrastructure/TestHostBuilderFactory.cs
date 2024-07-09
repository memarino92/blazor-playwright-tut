using Microsoft.Extensions.Hosting;
    
public class TestHostBuilderFactory<TStartup> : HostBuilder
{
    public TestHostBuilderFactory(string environment, Action<IHostBuilder> webhostConfiguration)
    {

    }
}