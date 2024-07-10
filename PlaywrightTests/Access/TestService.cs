using BlazorApp.Access;

namespace PlaywrightTests.Access;

internal class TestService : IExampleService
{
    public string GetMessage() => "This is a test message";
}
