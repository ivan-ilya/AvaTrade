using OpenQA.Selenium;

namespace AvaTrade.Extensions;

internal static class WebElementExtension
{
    internal static void ClickWithJavaScript(IWebElement element, IWebDriver driver, int timeout = 0)
    {
        var js = (IJavaScriptExecutor)driver;
        js.ExecuteScript($"await new Promise(r => setTimeout(r, {timeout}));arguments[0].click();", element);
    }

    internal static void ScrollToView(IWebElement element, IWebDriver driver, int timeout = 0)
    {
        var js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);    }

}
