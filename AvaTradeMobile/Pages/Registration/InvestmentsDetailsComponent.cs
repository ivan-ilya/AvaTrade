using AvaTradeMobile.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile.Pages.Registration;

public class InvestmentsDetailsComponent: BasePage
{
    IWebElement SavingsAndInvestments => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-1_89']"));
    IWebElement AmountIntendInvestingEveryYear => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_90']"));

    public TermsAndConditionsComponent InvestmentsDetailsQuestionnaire( InvestmentDetails details)
    {
        SavingsAndInvestments.SendKeys(details.SavingsAndInvestments);
        AmountIntendInvestingEveryYear.SendKeys(details.AmountIntendInvestingEveryYear);
        SubmitButton.Click();
        return new TermsAndConditionsComponent(_driver);
    }

    internal InvestmentsDetailsComponent(AndroidDriver driver) : base(driver) { }

}
