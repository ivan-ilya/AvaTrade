using AvaTradeMobile.Models;

namespace AvaTradeMobile.TestData;

public static class CredentialsDataProvider
{
    public static CredentialsModel AfghanistanCredentials => new()
    {
        Email = "test@test.com",
        Password = "Qasdfa@s123",
        Country = "Afghanistan"
    };
}
