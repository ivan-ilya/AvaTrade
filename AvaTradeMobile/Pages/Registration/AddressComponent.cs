using AvaTradeMobile.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile.Pages.Registration;

public class AddressComponent: BasePage
{
    IWebElement City => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-3_3']"));
    IWebElement StreetName => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-4_94']"));
    IWebElement Number => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-5_95']"));
    IWebElement Apartment => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-6_96']"));
    IWebElement PostalCode => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-7_5']"));
    IWebElement Currency => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-9_189']"));

    public  FinancialDetailsComponent FillTheAddress(AddressDetails addressDetails)
    {
        City.SendKeys(addressDetails.City);
        StreetName.SendKeys(addressDetails.StreetName);
        Number.SendKeys(addressDetails.Number);
        Apartment.SendKeys(addressDetails.Apartment);
        PostalCode.SendKeys(addressDetails.PostalCode);
        SubmitButton.Click();
        return new FinancialDetailsComponent(_driver);
    }

    internal AddressComponent(AndroidDriver driver) : base(driver) {}
}
