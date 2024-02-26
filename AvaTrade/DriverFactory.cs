using ApiTests.Helpers;
using AvaTrade.Helpers;
using OpenQA.Selenium;

namespace AutomationTests;

public class DriverFactory
{
    private static readonly AsyncLocal<IWebDriver> Drivers = new();
    private static readonly object LockObj = new();
    public static IWebDriver GetChromeDriver()
    {
        if (Drivers.Value == null)
        {
            lock (LockObj)
            {
                var driver = DriverManager.GetChromeDriver();
                Drivers.Value = driver;
            }
        }

        return Drivers.Value;
    }

    public static void CloseChromeDriver()
    {
        if (Drivers.Value != null)
        {
            Drivers.Value.Quit();
            Drivers.Value.Dispose();
            Drivers.Value = null;
        }
    }
}
