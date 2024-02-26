using AvaTrade.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AvaTrade.Pages;

public class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly WebDriverWait _wait;
    private static int GlobalTimeout => Convert.ToInt32(ConfigurationHelper.Config["ImplicitWaitTimeout"]);
    public IEnumerable<IWebElement> GetElements(By locator) => _driver.FindElements(locator);
    internal IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button.v-btn"));

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(GlobalTimeout));
    }

    protected void IsElementEnabled(string element, int time = 3000)
    {
        int count = 0;
        bool enabled = false;
        while (count<=5 & !enabled)
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
            count++;
        }
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

    protected void Wait(int time = 3000)
    {
        Thread.Sleep(time);
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
