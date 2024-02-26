using AvaTradeMobile.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;

namespace AvaTradeMobile.Pages.Registration;

public class FinancialDetailsComponent: BasePage
{
    string rootTextElement => "android.widget.EditText";
    IWebElement OccupationOrBusiness => _driver.FindElement(By.XPath($"//{rootTextElement}[@resource-id='question-1_15']"));
    IWebElement EmploymentStatus => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//{rootTextElement}[@resource-id='question-2_91']")));
    IWebElement SourceOfTradeFunds => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//{rootTextElement}[@resource-id='question-3_18']")));
    IWebElement EstimatedAnnualIncome => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//{rootTextElement}[@resource-id='question-4_16']")));

    public InvestmentsDetailsComponent FinancialDetailsQuestionnaire(FinancialDetails financialdetails)
    {
        OccupationOrBusiness.SendKeys(financialdetails.OccupationOrBusiness);
        EmploymentStatus.SendKeys(financialdetails.EmploymentStatus);
        SourceOfTradeFunds.SendKeys(financialdetails.SourceOfTradeFunds);
        EstimatedAnnualIncome.SendKeys(financialdetails.EstimatedAnnualIncome);
        SubmitButton.Click();
        return new InvestmentsDetailsComponent(_driver);
    }

    internal FinancialDetailsComponent(AndroidDriver driver) : base(driver) {}
}
