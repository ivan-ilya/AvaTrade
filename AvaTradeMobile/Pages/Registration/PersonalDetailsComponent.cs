using AvaTradeMobile.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile.Pages.Registration;

public class PersonalDetailsComponent: BasePage
{
    internal PersonalDetailsComponent(AndroidDriver driver) : base(driver)
    {
        _driver.FindElement(By.XPath("//android.widget.ProgressBar[@text='25.0']"));
    }

    #region PersonalDetailsElements
    IWebElement FirstName => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-1_247']"));
    IWebElement LastName => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_248']"));
    IWebElement DayOfBirth => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='date-day']"));
    IWebElement MonthOfBirth => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='date-month']"));
    IWebElement YearOfBirth => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='date-year']"));
    IWebElement PhoneNumber => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='phone-number-input']"));
    #endregion

    #region PersonalDetailsMethods
    public AddressComponent FillThePersonalDetailsData(PersonalDetails personalDetails)
    {
       FirstName.SendKeys(personalDetails.FirstName);
       LastName.SendKeys(personalDetails.LastName);
       FillTheBirthDate(personalDetails.DayOfBirth, personalDetails.MonthOfBirth, personalDetails.YearOfBirth);
       PhoneNumber.SendKeys(personalDetails.PhoneNumber);
       SubmitButton.Click();
       return new AddressComponent(_driver);
    }
    public void FillTheBirthDate(string day, string month, string year)
    {
        MonthOfBirth.SendKeys(month);
        DayOfBirth.SendKeys(day);
        YearOfBirth.Click();
        YearOfBirth.SendKeys(year);
        _driver.HideKeyboard();
    }
    #endregion
}

