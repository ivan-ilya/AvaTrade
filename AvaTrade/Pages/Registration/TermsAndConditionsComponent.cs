using OpenQA.Selenium;

namespace AvaTrade.Pages.Registration;

public class TermsAndConditionsComponent: BasePage
{
    IWebElement CitizenTermsAndConditionsToggle => _driver.FindElement(By.CssSelector("input[name='NoUsaCitizenship']"));
    IWebElement TermsAndConditionsToggle => _driver.FindElement(By.CssSelector("input[name='TermsAndConditions"));
    IWebElement MailingsToggle => _driver.FindElement(By.CssSelector("input[name='WhatsAppConesnt']"));

    public FinalisationPage TermsAndConditionsAgreement()
    {
        Wait();
        TermsAndConditionsToggle.Click();
        SubmitButton.Click();
        return new FinalisationPage(_driver);
    }
    internal TermsAndConditionsComponent(IWebDriver driver) : base(driver) { }
}
