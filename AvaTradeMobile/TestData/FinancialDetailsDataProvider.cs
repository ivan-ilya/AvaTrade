using AvaTradeMobile.Models;

namespace AvaTradeMobile.TestData;

public static class FinancialDetailsDataProvider
{
    public static FinancialDetails FinancialDetails => new()
    {
        OccupationOrBusiness = "Accountancy",
        EmploymentStatus = "Retired",
        SourceOfTradeFunds = "Savings",
        EstimatedAnnualIncome = "More than 5 million"
    };
}
