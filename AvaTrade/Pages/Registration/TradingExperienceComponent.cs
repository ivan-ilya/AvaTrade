using AvaTrade.Extensions;
using AvaTrade.Models.Registration;
using OpenQA.Selenium;

namespace AvaTrade.Pages.Registration;

internal class TradingExperienceComponent: BasePage
{
    IWebElement ExperienceYes => _driver.FindElement(By.XPath("//span[contains(text(),'Yes')]"));
    IWebElement ExperienceNo => _driver.FindElement(By.XPath("//span[contains(text(),'No')]"));
    IWebElement NumOfTimesTradedinForexCfds => _driver.FindElement(By.CssSelector("input[data-automation='NumOfTimesTradedinForexCfds']"));
    IWebElement WhatWasTheAverageSizeOfTrades => _driver.FindElement(By.CssSelector("input[data-automation='WhatWasTheAverageSizeOfTrades']"));
    IWebElement TradingWithLeverageApplies => _driver.FindElement(By.CssSelector("input[data-automation='TradingWithLeverageApplies']"));
    IWebElement TradingWithLeverageMaximumPosition => _driver.FindElement(By.CssSelector("input[data-automation='TradingWithLeverageMaximumPosition']"));
    IWebElement OpenPositionAutomaticallyClose => _driver.FindElement(By.CssSelector("input[data-automation='OpenPositionAutomaticallyClose']"));
    IWebElement WhyTradeWithUs => _driver.FindElement(By.CssSelector("input[data-automation='WhyTradeWithUs']"));
    IWebElement Checkbox => _driver.FindElement(By.CssSelector("input[name='ForexBettingRiskDeclaration']"));
    IWebElement ContinueButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
    internal TradingExperienceComponent(IWebDriver driver) : base(driver) { }

    public void TradingExperienceData(TradingExperienceAndKnowledge tradingData, bool experience = true)
    {
        (experience ? ExperienceYes : ExperienceNo).Click();
        NumOfTimesTradedinForexCfds.SendKeys(tradingData.NumOfTimesTradedinForexCfds);
        WhatWasTheAverageSizeOfTrades.SendKeys(tradingData.WhatWasTheAverageSizeOfTrades);
        TradingWithLeverageApplies.SendKeys(tradingData.TradingWithLeverageApplies);
        TradingWithLeverageMaximumPosition.SendKeys(tradingData.TradingWithLeverageMaximumPosition);
        OpenPositionAutomaticallyClose.SendKeys(tradingData.OpenPositionAutomaticallyClose);
        WhyTradeWithUs.SendKeys(tradingData.WhyTradeWithUs);
        WhyTradeWithUs.SendKeys(Keys.Enter);
        WebElementExtension.ClickWithJavaScript(Checkbox, _driver);
        ContinueButton.Click();
    }
}
