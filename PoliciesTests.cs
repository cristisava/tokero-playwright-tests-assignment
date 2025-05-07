using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using static TokeroPlaywrightTests.PoliciesPage;
using static TokeroPlaywrightTests.Utilities.HelperMethods;

namespace TokeroPlaywrightTests
{
    [TestClass]
    public class PolicyPageTests : PageTest
    {
        [TestMethod]
        public async Task PolicyPage_AssertVisibilityOfOptions()
        {
            #region
            var container = Page.Locator(".blazor-element");
            #endregion

            // reach the policies page
            await GoToPage(Page);

            // accept cookies
            await AcceptCookies(Page);

            await Expect(Page).ToHaveURLAsync(PoliciesURLEnglish);

            // assert visibility of entities
            foreach (var linkText in ExpectedLinksEN)
            {
                await Expect(container.GetByRole(AriaRole.Link, new() { Name = linkText, Exact = true }))
                    .ToBeVisibleAsync();
            }
        }

        [TestMethod]
        public async Task PolicyPage_VerifyRomanianTranslationsOfOptions()
        {
            #region
            var container = Page.Locator(".blazor-element");
            #endregion

            // reach the policies page
            await GoToPage(Page);

            // accept cookies
            await AcceptCookies(Page);

            await ChangeLanguage(Page, romanian);

            await Expect(Page).ToHaveURLAsync(PoliciesURLRomanian);

            // assert visibility of entities
            foreach (var linkText in ExpectedLinksRO)
            {
                await Expect(container.GetByRole(AriaRole.Link, new() { Name = linkText, Exact = true }))
                    .ToBeVisibleAsync();
            }
        }

        [TestMethod]
        public async Task PolicyPage_NavigationChecksForPoliciesEN()
        {
            #region
            var container = Page.Locator(".blazor-element");
            #endregion

            // reach the policies page
            await GoToPage(Page);

            // accept cookies
            await AcceptCookies(Page);

            await Expect(Page).ToHaveURLAsync(PoliciesURLEnglish);

            // assert correct navigation to each policy
            foreach (var pair in LinksAndHeadersEN)
            {
                var linkText = pair.Key;
                var expectedHeading = pair.Value;

                var link = container.GetByRole(AriaRole.Link, new() { Name = linkText, Exact = true });

                await Expect(link).ToBeVisibleAsync();
                await link.ClickAsync();

                await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = expectedHeading, Exact = true })).ToBeVisibleAsync();

                await GoToPage(Page);
            }
        }

        [TestMethod]
        public async Task PolicyPage_NavigationChecksForPoliciesRO()
        {
            #region
            var container = Page.Locator(".blazor-element");
            #endregion

            // reach the policies page
            await GoToPage(Page);

            // accept cookies
            await AcceptCookies(Page);

            // assert correct navigation to each policy
            foreach (var pair in LinksAndHeadersRO)
            {
                var linkText = pair.Key;
                var expectedHeading = pair.Value;

                var link = container.GetByRole(AriaRole.Link, new() { Name = linkText, Exact = true });

                await ChangeLanguage(Page, romanian);
                await Expect(Page).ToHaveURLAsync(PoliciesURLRomanian);

                await Expect(link).ToBeVisibleAsync();
                await link.ClickAsync();

                await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = expectedHeading, Exact = true })).ToBeVisibleAsync();

                await GoToPage(Page);

                //to add to documentation that the html is not friendly for UI testing
            }
        }
    }
}