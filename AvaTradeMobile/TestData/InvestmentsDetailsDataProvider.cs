using AvaTradeMobile.Models;

namespace AvaTradeMobile.TestData;

public static class InvestmentsDetailsDataProvider
{
    public static InvestmentDetails InvestmentDetails => new()
    {
        SavingsAndInvestments = "50,000-99,999",
        AmountIntendInvestingEveryYear = "1-5 million"
    };
}
