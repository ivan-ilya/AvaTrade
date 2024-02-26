using AvaTrade.Extensions;
using AvaTrade.Models.Registration;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AvaTrade.Pages.Registration;

public class RegistrationPage: BasePage
{

    #region CommonElements
    IWebElement ChatButton => _driver.FindElement(By.CssSelector("button.chat-icon"));
    IWebElement CloseButton => _driver.FindElement(By.CssSelector("button.close-icon "));
    IWebElement WhyIsThisRequiredToggle => _driver.FindElement(By.CssSelector(".ava-expandable-info-blob"));
    IWebElement Iframe => _driver.FindElement(By.CssSelector("[data-qa='iframe-empty-popup__container']"));
    #endregion

    #region PersonalDetailsElements

    public const string CurrencyLocator = ".v-select__selection--comma";
    private IWebElement FirstName => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[name='FirstName']"))); //_driver.FindElement(By.CssSelector("input[name='FirstName']"));
    IWebElement LastName => _driver.FindElement(By.CssSelector("input[name='LastName']"));
    IWebElement DayOfBirth => _driver.FindElement(By.CssSelector("input[name='date-of-birth-day']"));
    IWebElement MonthOfBirth => _driver.FindElement(By.CssSelector("input[name='date-of-birth-month']"));
    IWebElement YearOfBirth => _driver.FindElement(By.CssSelector("input[name='date-of-birth-year']"));
    IWebElement DatePicker => _driver.FindElement(By.CssSelector(".icon notranslate calendar-icon v-icon--link theme--light"));
    IWebElement Country => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".v-select__selections>input[name='Country']")));
    IWebElement City => _driver.FindElement(By.CssSelector("input[name='City']"));
    IWebElement StreetName => _driver.FindElement(By.CssSelector("input[name='Street']"));
    IWebElement Number => _driver.FindElement(By.CssSelector("input[name='BuildingNumber']"));
    IWebElement Apartment => _driver.FindElement(By.CssSelector("input[name='Flat']"));
    IWebElement PostalCode => _driver.FindElement(By.CssSelector("input[name='ZipCode']"));
    IWebElement PhoneCode => _driver.FindElement(By.CssSelector("input#country-input"));
    IWebElement PhoneNumber => _driver.FindElement(By.CssSelector("input[name='Phone']"));
    IWebElement Currency => _driver.FindElement(By.CssSelector(CurrencyLocator));
    #endregion

    #region PersonalDetailsMethods
    public FinancialDetailsComponent FillThePersonalDetailsData(RegistrationPersonalDetails personalData)
    {
        SwitchToIframe();
        FirstName.SendKeys(personalData.FirstName);
        LastName.SendKeys(personalData.LastName);
        FillTheBirthDate(personalData.DayOfBirth,personalData.MonthOfBirth,personalData.YearOfBirth);
        Country.SendKeys(personalData.Country);
        Country.SendKeys(Keys.Enter);
        City.SendKeys(personalData.City);
        StreetName.SendKeys(personalData.StreetName);
        Number.SendKeys(personalData.Number);
        Apartment.SendKeys(personalData.Apartment);
        PostalCode.SendKeys(personalData.PostalCode);
        Wait();
        PhoneNumber.SendKeys(personalData.PhoneNumber);
        SelectCurrency();
        SubmitButton.Click();

        return new FinancialDetailsComponent(_driver);
    }
    public void FillTheBirthDate(string day, string month, string year)
    {
        DayOfBirth.SendKeys(day);
        MonthOfBirth.SendKeys(month);
        YearOfBirth.SendKeys(year);
    }
    private void SelectCurrency()
    {
        IsElementEnabledCssSelector(CurrencyLocator);
        WebElementExtension.ClickWithJavaScript(Currency, _driver);
        Country.SendKeys(Keys.Enter);
    }

    #endregion

    private void SwitchToIframe()
    {
        _driver.SwitchTo().Frame(0);
    }

    private void SwitchToDefaultContent()
    {
        _driver.SwitchTo().DefaultContent();
    }

    internal RegistrationPage(IWebDriver driver) : base(driver)
    {
        WaitForRedirectionToRegisterPage();
        IsElementEnabledCssSelector("[data-qa='iframe__wrapper']");
    }
}

