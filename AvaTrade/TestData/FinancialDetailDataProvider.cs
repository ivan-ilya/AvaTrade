using AvaTrade.Models.Registration;

namespace AvaTrade.TestData;

public static class FinancialDetailDataProvider
{
    public static RegistrationFinancialDetails FinancialDetails => new()
    {
        OccupationOrBusiness = "Accountancy",
        EmploymentStatus = "Employed",
        SourceOfTradeFunds = "Employment",
        EstimatedAnnualIncome ="100,000-499,999",
        SavingsAndInvestments = "50,000-99,999",
        AmountIntendInvestingEveryYear = "1-5 million"
    };
}
