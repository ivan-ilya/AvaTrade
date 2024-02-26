using AvaTrade.Models.Registration;
using AvaTrade.Pages;
using AvaTrade.Pages.Registration;
using OpenQA.Selenium;

namespace AvaTrade.Popups;

public class RegistryPopup: BasePage
{
    private IWebElement EmailTextField => _driver.FindElement(By.Id("input-email"));
    private IWebElement PasswordTextField => _driver.FindElement(By.Id("input-password"));
    private IWebElement LoginButton => _driver.FindElement(By.Id("btn_ga_real_main menu_cfd"));
    private IWebElement PartnerCodeTextField => _driver.FindElement(By.CssSelector("a.forgot-password"));
    private IWebElement SignUpTab => _driver.FindElement(By.XPath("//div[contains(text(),'Sign Up')]"));
    private IWebElement GoogleLink => _driver.FindElement(By.CssSelector(""));
    private IWebElement FacebookLink => _driver.FindElement(By.CssSelector(""));
    private IWebElement AppleLink => _driver.FindElement(By.CssSelector(""));

    public RegistryPopup(IWebDriver driver) : base(driver) { }
    public RegistrationPage SignUp(CredentialsModel credentials)
    {
        SignUpTab.Click();
        EnterCredentials(credentials.Email, credentials.Password);
        Login();
        return new RegistrationPage(_driver);
    }
    public void ClickTheSignUp()
    {
        IsElementEnabled("//div[text()='Sign Up']");
        SignUpTab.Click();
    }

    public void EnterCredentials(string email, string password)
    {
        int rnd = new Random().Next(123, 999999);
        EmailTextField.SendKeys($"{rnd}{email}");
        PasswordTextField.SendKeys(password);//Qasdfa@s123
    }

    public void Login()
    {
       var enabled = _driver.FindElement(By.Id("btn_ga_real_main menu_cfd")).Enabled;
       if (enabled) LoginButton.Click();
    }
}
