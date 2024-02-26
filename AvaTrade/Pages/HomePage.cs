using AvaTrade.Popups;
using OpenQA.Selenium;

namespace AvaTrade.Pages;

public class HomePage: BasePage
{
    private static string loginSelector = "//span[contains(text(),'Login')]";
    private IWebElement Login => _driver.FindElement(By.XPath(loginSelector));
    private IWebElement AcceptCookiesSelector => _driver.FindElement(By.CssSelector("a#ava_allow_all_c"));
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    public RegistryPopup OpenTheRegistryPopup()
     {
         IsElementEnabled(loginSelector);
         Login.Click();
         return new RegistryPopup(_driver);
     }

    public void AcceptCookies()
    {
        try
        {
            if (AcceptCookiesSelector.Enabled) AcceptCookiesSelector.Click();
        }
        catch (NoSuchElementException) { }
    }
}
