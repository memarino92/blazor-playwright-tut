using Microsoft.Playwright;
using BlazorApp;

namespace PlaywrightTests;

[TestFixture]
public class CounterPageTest : BlazorTest
{
    [Test]
    public async Task Count_Increments_WhenButtonIsClicked()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri, new() { WaitUntil = WaitUntilState.NetworkIdle });

        await Expect(Page.Locator("h1")).ToHaveTextAsync("Hello, world!");
        await Expect(Page.Locator("#message")).ToHaveTextAsync("This is a test message");
        await Expect(Page.Locator("#blazor-error-ui")).Not.ToBeVisibleAsync();
    }
}
