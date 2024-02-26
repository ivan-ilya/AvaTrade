using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace AvaTradeMobile;

public class DriverFactory
{
    private AndroidDriver _driver;
    public static AndroidDriver BuildAndroidDriver()
    {
        var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/wd/hub");
        var driverOptions = new AppiumOptions() {
            AutomationName = AutomationName.AndroidUIAutomator2,
            PlatformName = "Android",
            DeviceName = "emulator-5554",
        };

        driverOptions.AddAdditionalAppiumOption("appPackage", "com.avatrade.mobile");
        driverOptions.AddAdditionalAppiumOption("appActivity", "com.devexperts.dxmarket.client.SplashscreenActivity");
        driverOptions.AddAdditionalAppiumOption("noReset", true);
        driverOptions.AddAdditionalAppiumOption("appium:ignoreHiddenApiPolicyError", true);
        return new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
    }
}
