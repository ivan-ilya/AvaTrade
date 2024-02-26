using AvaTradeMobile.Pages.Registration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile.Pages;

public class HomePage: BasePage
{
    private IWebElement CreateAccountButton => _driver.FindElement(By.CssSelector("android.widget.Button"));
    public HomePage(AndroidDriver driver) : base(driver) { }
    public AccountCreationComponent CreateAccountClick()
    {
        CreateAccountButton.Click();
        return new AccountCreationComponent(_driver);
    }
}


