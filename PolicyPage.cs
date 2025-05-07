using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TokeroPlaywrightTests.Utilities;
using static TokeroPlaywrightTests.Utilities.HelperMethods;

namespace TokeroPlaywrightTests
{
    public class PoliciesPage : HelperMethods
    {
        #region Page elements

        public const string PoliciesPagePath = "policies/";
        public const string PoliciesURLEnglish = "https://tokero.dev/en/policies/";
        public const string PoliciesURLRomanian = "https://tokero.dev/ro/policies/";

        public const string LanguagesContainer = ".languageSwitcher_dropdownMenu__V4WhN";

        public const string english = "en flag EN";
        public const string romanian = "ro flag RO";
        public const string deutch = "de flag DE";
        public const string french = "fr flag FR";
        public const string italian = "it flag IT";
        public const string polish = "pl flag PL";
        public const string portuguese = "pt flag PT";
        public const string turkish = "tr flag TR";

        public const string TermsAndConditionsLinkNameEN = "Terms and Conditions";
        public const string PrivacyLinkNameEN = "Privacy";
        public const string FeesLinkNameEN = "Fees";
        public const string CookiesLinkNameEN = "Cookies";
        public const string KYCLinkNameEN = "KYC";
        public const string ReferralsLinkNameEN = "Referrals";
        public const string RequestAnsweringProccesingLinkNameEN = "Request answering/processing times";
        public const string MinimumsAndOptionsLinkNameEN = "Minimums and options";
        public const string GDPRLinkNameEN = "GDPR";
        public const string CountriesListForAMLRiskLinkNameEN = "Countries list for AML risk assessment";

        public const string TermsAndConditionsLinkNameRO = "Termeni și condiții";
        public const string PrivacyLinkNameRO = "Confidențialitate";
        public const string FeesLinkNameRO = "Taxe";
        public const string CookiesLinkNameRO = "Cookies";
        public const string KYCLinkNameRO = "KYC";
        public const string ReferralsLinkNameRO = "Afiliere";
        public const string RequestAnsweringProccesingLinkNameRO = "Timpi de răspuns/procesare a cererilor";
        public const string MinimumsAndOptionsLinkNameRO = "Minime și opțiuni";
        public const string GDPRLinkNameRO = "GDPR";
        public const string CountriesListForAMLRiskLinkNameRO = "Lista țărilor în analiza riscului de tip AML";

        public const string TermsOfServiceHeaderEN = "Terms of Service";
        public const string PrivacyPolicyHeaderEN = "Privacy Policy";
        public const string FeesAndTimingsHeaderEN = "Fees and timings";
        public const string CookiesPolicyHeaderEN = "Cookies Policy";
        public const string KYCAndAMLPolicyHeaderEN = "KYC and AML policy";
        public const string TokeroAffiliateHeaderEN = "TOKERO Affiliate Heroes Program";
        public const string RequestAnsweringProccesingHeaderEN = "Request answering/processing times";
        public const string MinimumsAndOptionsHeaderEN = "Minimums and options";
        public const string GDPRHeaderEN = "RIGHTS OF DATA SUBJECTS WITH REGARD TO THE PROCESSING OF PERSONAL DATA UNDER EU REGULATION 2016/679";
        public const string CountriesListHeaderEN = "AML Country Status";

        public const string TermsOfServiceHeaderRO = "Termeni și condiții de utilizare";
        public const string PrivacyPolicyHeaderRO = "Politica de confidențialitate";
        public const string FeesAndTimingsHeaderRO = "Taxe și durate";
        public const string CookiesPolicyHeaderRO = "Politica de cookies";
        public const string KYCAndAMLPolicyHeaderRO = "Politica KYC și AML";
        public const string TokeroAffiliateHeaderRO = "TOKERO Affiliate Heroes Program";
        public const string RequestAnsweringProccesingHeaderRO = "Timpi de răspuns/procesare a cererilor";
        public const string MinimumsAndOptionsHeaderRO = "Minime și opțiuni";
        public const string GDPRHeaderRO = "DREPTURILE PERSOANELOR VIZATE DE PRELUCRĂRILE DE DATE CU CARACTER PERSONAL CONFORM REGULAMENTULUI UE 679/2016";
        public const string CountriesListHeaderRO = "Statutul țării - AML";
        #endregion

        #region
        public static readonly List<string> ExpectedLinksRO = new()
        {
                TermsAndConditionsLinkNameRO,
                PrivacyLinkNameRO,
                FeesLinkNameRO,
                CookiesLinkNameRO,
                KYCLinkNameRO,
                ReferralsLinkNameRO,
                RequestAnsweringProccesingLinkNameRO,
                MinimumsAndOptionsLinkNameRO,
                GDPRLinkNameRO,
                CountriesListForAMLRiskLinkNameRO
        };

        public static readonly List<string> ExpectedLinksEN = new()
        {
                TermsAndConditionsLinkNameEN,
                PrivacyLinkNameEN,
                FeesLinkNameEN,
                CookiesLinkNameEN,
                KYCLinkNameEN,
                ReferralsLinkNameEN,
                RequestAnsweringProccesingLinkNameEN,
                MinimumsAndOptionsLinkNameEN,
                GDPRLinkNameEN,
                CountriesListForAMLRiskLinkNameEN
        };

        public static readonly Dictionary<string, string> LinksAndHeadersEN = new()
        {
                { TermsAndConditionsLinkNameEN, TermsOfServiceHeaderEN },
                { PrivacyLinkNameEN, PrivacyPolicyHeaderEN },
                { FeesLinkNameEN, FeesAndTimingsHeaderEN },
                { CookiesLinkNameEN, CookiesPolicyHeaderEN },
                { KYCLinkNameEN, KYCAndAMLPolicyHeaderEN },
                { ReferralsLinkNameEN, TokeroAffiliateHeaderEN },
                { RequestAnsweringProccesingLinkNameEN, RequestAnsweringProccesingHeaderEN },
                { MinimumsAndOptionsLinkNameEN, MinimumsAndOptionsHeaderEN },
                { GDPRLinkNameEN, GDPRHeaderEN },
                { CountriesListForAMLRiskLinkNameEN, CountriesListHeaderEN }
        };

        public static readonly Dictionary<string, string> LinksAndHeadersRO = new()
        {
                { TermsAndConditionsLinkNameRO, TermsOfServiceHeaderRO },
                { PrivacyLinkNameRO, PrivacyPolicyHeaderRO },
                { FeesLinkNameRO, FeesAndTimingsHeaderRO },
                { CookiesLinkNameRO, CookiesPolicyHeaderRO },
                { KYCLinkNameRO, KYCAndAMLPolicyHeaderRO },
                { ReferralsLinkNameRO, TokeroAffiliateHeaderRO },
                { RequestAnsweringProccesingLinkNameRO, RequestAnsweringProccesingHeaderRO },
                { MinimumsAndOptionsLinkNameRO, MinimumsAndOptionsHeaderRO },
                { GDPRLinkNameRO, GDPRHeaderRO },
                { CountriesListForAMLRiskLinkNameRO, CountriesListHeaderRO }
        };
        #endregion
    }
}
