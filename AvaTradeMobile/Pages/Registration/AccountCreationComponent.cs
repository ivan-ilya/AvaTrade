using AvaTradeMobile.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;

namespace AvaTradeMobile.Pages.Registration;

public class AccountCreationComponent: BasePage
{
    int rnd = new Random().Next(123, 999999);
    private IWebElement CountrySelector => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='input-126']"));
    private IWebElement CountryField => _driver.FindElement(By.CssSelector("android.widget.EditText"));
    private IWebElement EmailField => _driver.FindElement(By.XPath("//android.view.View[@resource-id='question-6_246']"));
    private IWebElement EmailTextField => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='input-134']"));
    private IWebElement PasswordField => _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-7_36']"));

    private IWebElement CreateMyAccountButton => _driver.FindElement(By.XPath("//android.widget.Button[@text='Create My Account']"));

    private IWebElement Captcha => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//android.widget.CheckBox[@text='Verify you are human']")));

    public PersonalDetailsComponent CreateAccount(CredentialsModel account)
    {
        // CaptchaSelection();
        SelectCountry(account.Country);
        EnterCredentials(account.Email, account.Password);
        CreateAccountAction();
        return new PersonalDetailsComponent(_driver);
    }

    public void EnterCredentials( string email, string password)
    {
       _driver.HideKeyboard();
       EmailField.Click();
       EmailTextField.SendKeys($"{rnd}{email}");
       _driver.HideKeyboard();
       PasswordField.Click();
       PasswordField.SendKeys(password);
    }

    public void SelectCountry(string country)
    {
        CountrySelector.Click();
        CountryField.SendKeys(country);
        _driver.PressKeyCode(AndroidKeyCode.Enter);
    }

    public void CreateAccountAction()
    {
        CreateMyAccountButton.Click();
    }

    private void CaptchaSelection()
    {
        try
        {
            bool isEnabled = IsElementEnabled("//android.widget.CheckBox[@text='Verify you are human']", count:2);

            if (isEnabled) Captcha.Click();
        }
        catch (NoSuchElementException) { }
    }

    public AccountCreationComponent(AndroidDriver driver) : base(driver) { }

}