using AvaTrade.Models.Registration;

namespace AvaTrade.TestData;

public class TradingExperienceDataProvider
{
    public static TradingExperienceAndKnowledge GetTradingExperienceData => new()
    {
        NumOfTimesTradedinForexCfds = "26-50",
        WhatWasTheAverageSizeOfTrades = "25,000-50,000",
        TradingWithLeverageApplies = "It may increase profits or losses",
        TradingWithLeverageMaximumPosition = "$50,000",
        OpenPositionAutomaticallyClose = "The market is moving in favor of my position",
        WhyTradeWithUs = "Intraday trading"
    };
}
