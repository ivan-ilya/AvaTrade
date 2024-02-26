using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile.Pages.Registration;

public class TermsAndConditionsComponent: BasePage
{
    IWebElement CitizenTermsAndConditionsToggle => _driver.FindElement(By.CssSelector("input[name='NoUsaCitizenship']"));
    IWebElement TermsAndConditionsToggle => _driver.FindElement(By.XPath("//android.view.View[@resource-id='question-2_21']/android.view.View"));
    IWebElement MailingsToggle => _driver.FindElement(By.CssSelector("input[name='WhatsAppConesnt']"));
    IWebElement PercentageNumber100 => _driver.FindElement(By.CssSelector("//div[contains(text(),'100%')]"));
    IWebElement FinishButton => _driver.FindElement(By.XPath("/android.widget.Button[@text='Finish']"));

    public FinalisationPage TermsAndConditionsAgreement()
    {
        TermsAndConditionsToggle.Click();
        FinishButton.Click();
        return new FinalisationPage(_driver);
    }

    internal TermsAndConditionsComponent(AndroidDriver driver) : base(driver) { }
}
