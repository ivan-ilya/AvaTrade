using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace AvaTrade.Helpers;

public static class DriverManager
{
    public static IWebDriver GetChromeDriver()
    {
        var options = new ChromeOptions();

        if (Debugger.IsAttached)
        {
            options.AddArguments("--auto-open-devtools-for-tabs");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
        }
        else
        {
            if (ConfigurationHelper.Config["HeadlessMode"] == "true")
            {
                options.AddArgument("--headless");
                options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36");
            }

            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
        }

        options.AddArgument("--accept-lang=en-US");

        return new ChromeDriver(ChromeDriverService.CreateDefaultService(),
            options, TimeSpan.FromMinutes(2));
    }
    public static IWebDriver GetChromeDriverWithMobileView(string mobileDevice)
    {
        var options = new ChromeOptions();

        if (Debugger.IsAttached)
        {
            options.AddArguments("--auto-open-devtools-for-tabs");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
            options.EnableMobileEmulation(mobileDevice);
        }
        else
        {
            if (ConfigurationHelper.Config["HeadlessMode"] == "true")
            {
                options.AddArgument("--headless");
            }

            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
            options.EnableMobileEmulation(mobileDevice);
        }

        return new ChromeDriver(options);
    }

    public static IWebDriver GetFireFoxDriver()
    {
        throw new WebDriverException("Firefox driver is not implemented yet");
    }

    public static IWebDriver GetEdgeDriver()
    {
        throw new WebDriverException("Edge driver is not implemented yet");
    }

    public static IWebDriver GetSafariDriver()
    {
        throw new WebDriverException("Safari driver is not implemented yet");
    }
}
