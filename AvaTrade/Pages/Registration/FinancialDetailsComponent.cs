using AvaTrade.Models.Registration;
using OpenQA.Selenium;

namespace AvaTrade.Pages.Registration;

public class FinancialDetailsComponent: BasePage
{
    private TradingExperienceComponent _tradingExperience;
    private string OccupationOrBusinessSelector = "input[data-automation='OccupationOrBusiness']";
    IWebElement OccupationOrBusiness => _driver.FindElement(By.CssSelector(OccupationOrBusinessSelector));
    IWebElement EmploymentStatus => _driver.FindElement(By.CssSelector("input[data-automation='EmploymentStatus']"));
    IWebElement SourceOfTradeFunds => _driver.FindElement(By.CssSelector("input[data-automation='SourceOfTradeFunds']"));
    IWebElement EstimatedAnnualIncome => _driver.FindElement(By.CssSelector("input[data-automation='EstimatedAnnualIncome']"));
    IWebElement SavingsAndInvestments => _driver.FindElement(By.CssSelector("input[data-automation='SavingsAndInvestments']"));
    IWebElement AmountIntendInvestingEveryYear => _driver.FindElement(By.CssSelector("input[data-automation='AmountIntendInvestingEveryYear']"));

    public TermsAndConditionsComponent FinancialDetailsQuestionnaire(string country, RegistrationFinancialDetails financialDetails, TradingExperienceAndKnowledge experience = default)
    {
        OccupationOrBusiness.SendKeys(financialDetails.OccupationOrBusiness);
        EmploymentStatus.SendKeys(financialDetails.EmploymentStatus);
        SourceOfTradeFunds.SendKeys(financialDetails.SourceOfTradeFunds);
        EstimatedAnnualIncome.SendKeys(financialDetails.EstimatedAnnualIncome);
        SavingsAndInvestments.SendKeys(financialDetails.SavingsAndInvestments);
        AmountIntendInvestingEveryYear.SendKeys(financialDetails.AmountIntendInvestingEveryYear);
        SubmitButton.Click();
        if(country == "France") _tradingExperience.TradingExperienceData(experience);

        return new TermsAndConditionsComponent(_driver);
    }

    internal FinancialDetailsComponent(IWebDriver driver) : base(driver) { }
}
