using ApiTests.Enumerations;
using AvaTrade.Helpers;

namespace ApiTests.Helpers;

public static class BrowserManager
{
    public static Browser GetBrowser()
    {
        var browser = ConfigurationHelper.Config["Browser"];
        return browser switch
        {
            "chrome" => Browser.Chrome,
            "edge" => Browser.Edge,
            "firefox" => Browser.FireFox,
            "safari" => Browser.Safari,
            "mobile" => Browser.Mobile,
            _ => throw new Exception("Please specify the valid browser type in the config file or in the environment variable")
        };
    }
}
