using AvaTrade.Models.Registration;

namespace AvaTrade.TestData;

public static class PersonalDetailDataProvider
{
    public static RegistrationPersonalDetails GetAfghanistanPersonalDetails => new()
    {
        FirstName = "Abdula",
        LastName = "Hakimi",
        DayOfBirth = "01",
        MonthOfBirth = "01",
        YearOfBirth = "1999",
        Country = "Afghanistan",
        City = "Kabul",
        StreetName = "Ahmed Nizammudin",
        Number = "11",
        Apartment = "Unit city",
        PostalCode = "1001",
        PhoneNumber = "123456789",
        Currency = Currencies.Currency["USD"]
    };

    public static RegistrationPersonalDetails GetFrancePersonalDetails => new()
    {
        FirstName = "Fransua",
        LastName = "Ramini",
        DayOfBirth = "01",
        MonthOfBirth = "01",
        YearOfBirth = "1999",
        Country = "France",
        City = "Paris",
        StreetName = "Saint Germain",
        Number = "11",
        Apartment = "Unit city",
        PostalCode = "1001",
        PhoneNumber = "987654321",
        Currency = Currencies.Currency["EUR"]
    };
}
