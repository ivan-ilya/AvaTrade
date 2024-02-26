using AvaTradeMobile.Models;

namespace AvaTradeMobile.TestData;

public static class PersonalDetailsDataProvider
{
    public static PersonalDetails AfghanPersonalDetails => new()
    {
        FirstName = "Muhamed",
        LastName = "Ali",
        PhoneNumber = "1234578",
        DayOfBirth = "09",
        MonthOfBirth = "09",
        YearOfBirth = "1999"
    };
}
