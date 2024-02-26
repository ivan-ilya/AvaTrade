using OpenQA.Selenium;

namespace AvaTrade.Pages.Registration;

public class FinalisationPage: BasePage
{
    private string FinalisationText => _driver.FindElement(By.ClassName("tour-popup_title__BY4W2")).Text;
    public readonly string FinalisationTextOriginal = "You Are All Set!";
    IWebElement CloseButtonFinalisation => _driver.FindElement(By.CssSelector("button#typ-close-icon"));

    public string FinalisationRegistration()
    {
        CloseButtonFinalisation.Click();
        return FinalisationText;
    }
    internal FinalisationPage(IWebDriver driver) : base(driver) { }
}
