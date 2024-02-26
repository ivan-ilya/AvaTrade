using AvaTradeMobile.Helpers;
using OpenQA.Selenium.Appium.Android;

namespace AvaTradeMobile;

public class BaseFixture
{
    protected AndroidDriver Driver { get; set; }
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
    private AndroidDriver InitializeDriver()
    {
        return DriverFactory.BuildAndroidDriver();
    }
    [TearDown]
    public async Task TearDown()
    {
        Driver?.Quit();
    }
}
