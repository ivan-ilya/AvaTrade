using AvaTrade.Models.Registration;

namespace AvaTrade.TestData;

public static class CredentialsDataProvider
{
    public static CredentialsModel GetCorrectCredentials() => new()
    {
        Email = "test@test.com",
        Password = "Qasdfa@s123"
    };
}
