using AvaTradeMobile.Models;

namespace AvaTradeMobile.TestData;

public static class AddressDetailsDataProvider
{
    public static AddressDetails AfghanAddressDetails => new()
    {
        City = "Kabul",
        StreetName = "Mahmud Nabil",
        Number = "22",
        Apartment = "Unit Block",
        PostalCode = "09111"
    };
}
