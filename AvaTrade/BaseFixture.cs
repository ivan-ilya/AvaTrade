using ApiTests.Enumerations;
using ApiTests.Helpers;
using AutomationTests;
using AvaTrade.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AvaTrade;

public class BaseFixture
{
    protected IWebDriver Driver { get; set; }
    internal static int ImplicitWaitTimeout => Convert.ToInt32(ConfigurationHelper.Config["ImplicitWaitTimeout"]);

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        ConfigurationHelper.InitializeConfiguration();
    }
    [SetUp]
    public async Task SetUp()
    {
        Driver = InitializeDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeout);
    }
    private IWebDriver InitializeDriver()
    {
        var device = DeviceManager.GetDeviceType();
        var browser = BrowserManager.GetBrowser();
        var testName = TestContext.CurrentContext.Test.Name.ToLower();
        var mobileDevice = DeviceManager.GetMobileDevice();
        if (testName.Contains("mobile")) device = Device.Mobile;

        switch (device, browser)
        {
            case (Device.Desktop, Browser.Chrome):
                Driver = DriverFactory.GetChromeDriver();
                break;
            case (Device.Desktop, Browser.FireFox):
                Driver = DriverManager.GetFireFoxDriver();
                break;
            case (Device.Desktop, Browser.Edge):
                Driver = DriverManager.GetEdgeDriver();
                break;
            case (Device.Mobile, Browser.Chrome):
            case (Device.Mobile, Browser.FireFox):
            case (Device.Mobile, Browser.Edge):
                Driver = DriverManager.GetChromeDriverWithMobileView(mobileDevice);
                break;
        }
        return Driver;
    }
    [TearDown]
    public async Task TearDown()
    {
        Driver?.Quit();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        DriverFactory.CloseChromeDriver();
    }
}
