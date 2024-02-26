using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile.Pages.Registration;

public class FinalisationPage : BasePage
{
    internal string FinalisationText => _driver.FindElement(By.CssSelector("div.card-content--text")).Text;
    internal readonly string FinalisationTextOriginal = "Your account will be ready in a few seconds";
    internal FinalisationPage(AndroidDriver driver) : base(driver)
    {
    }
}
