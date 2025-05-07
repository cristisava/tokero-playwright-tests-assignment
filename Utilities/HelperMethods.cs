using Microsoft.Playwright;
using static TokeroPlaywrightTests.PoliciesPage;

namespace TokeroPlaywrightTests.Utilities
{
    public class HelperMethods
    {
        public static async Task GoToPage(IPage page)
        {
            await page.GotoAsync("https://tokero.dev/en/policies");
        }

        public static async Task ReachPolicyOrRule(IPage page, string policyOrRuleName)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = policyOrRuleName, Exact = true }).ClickAsync();
        }

        public static async Task AcceptCookies(IPage page)
        {
            await page.GetByRole(AriaRole.Button, new() { Name = "Accept all cookies" }).ClickAsync();
        }

        public static async Task WaitInSeconds(int seconds)
        {
            await Task.Delay(seconds * 1000);
        }

        public static async Task WaitForElementByClass(IPage page, string elementClass)
        {
            await page.Locator(elementClass).WaitForAsync(new() { State = WaitForSelectorState.Visible });
        }
        public static async Task ChangeLanguage(IPage page, string language)
        {
            await page.ClickAsync(".languageSwitcher_topDropdownToggle__QXn26");
            await WaitForElementByClass(page, LanguagesContainer);
            await page.GetByRole(AriaRole.Button, new() { Name = language }).ClickAsync(); ;
        }
    }
}