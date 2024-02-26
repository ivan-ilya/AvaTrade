using AvaTradeMobile.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace AvaTradeMobile.Pages;

public class BasePage: BaseFixture
{
    protected readonly AndroidDriver _driver;
    protected readonly WebDriverWait _wait;
    private static int GlobalTimeout => Convert.ToInt32(ConfigurationHelper.Config["ImplicitWaitTimeout"]);
    public IEnumerable<IWebElement> GetElements(By locator) => _driver.FindElements(locator);
    internal IWebElement SubmitButton => _driver.FindElement(By.XPath("//android.widget.Button[@text='Continue']"));


    protected BasePage(AndroidDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(GlobalTimeout));
    }

    protected bool IsElementEnabled(string element, int time = 3000, int count = 5)
    {
        bool enabled = false;
        while (count >= 0 & !enabled)
        {
            try
            {
                enabled =_driver.FindElement(By.XPath(element)).Enabled;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Thread.Sleep(time);
            count--;
        }
        return enabled;
    }

    protected void IsElementEnabledCssSelector(string element, int time = 3000)
    {
        int count = 0;
        bool enabled = false;
        while (count<=5 & !enabled)
        {
            try
            {
                enabled =_driver.FindElement(By.CssSelector(element)).Enabled;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Thread.Sleep(time);
            count++;
        }
    }

    protected void WaitForRedirectionToRegisterPage()
    {
        Thread.Sleep(9000);
        WaitForUrlContaining("avatrade.com/trade");
    }

    protected void WaitForUrlContaining(string word)
    {
        WaitForCondition(() => UrlContains(word), $"Url contains '{word}'", $"There is no URL containing '{word}'. Instead we have this URL: {_driver.Url}");
    }

    protected void WaitForCondition(Func<bool> condition, string actionDescription, string timeoutMessage)
    {
        Console.WriteLine($"Wait until {actionDescription}", false);

        try
        {
            _wait.Until(_ => condition());
            Console.WriteLine(actionDescription, false);
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail($"TimeoutException: {timeoutMessage}");
        }
    }

    private bool UrlContains(string word)
    {
        try
        {
            return _driver.Url.Contains(word);
        }
        catch (WebDriverException)
        {
            return false;
        }
    }
    public void Open(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void RedirectBack()
    {
        _driver.Navigate().Back();
    }

    public void Close()
    {
        _driver.Close();
    }
}
