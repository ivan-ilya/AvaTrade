using AvaTradeMobile.Models;
using AvaTradeMobile.Pages;
using AvaTradeMobile.TestData;

namespace AvaTradeMobile.Tests;

public class Tests: BaseFixture
{
    private HomePage _homePage;
    private CredentialsModel _accountData;
    private PersonalDetails _personalDetails;
    private AddressDetails _addressDetails;
    private FinancialDetails _financialDetails;
    private InvestmentDetails _investmentDetails;

    [SetUp]
    public void SetUpMethod()
    {
        _homePage = new HomePage(Driver);
        _accountData = CredentialsDataProvider.AfghanistanCredentials;
        _personalDetails = PersonalDetailsDataProvider.AfghanPersonalDetails;
        _addressDetails = AddressDetailsDataProvider.AfghanAddressDetails;
        _financialDetails = FinancialDetailsDataProvider.FinancialDetails;
        _investmentDetails = InvestmentsDetailsDataProvider.InvestmentDetails;
    }

    [Test]
    public void AfghanUserCanCreateTheAccount()
    {
        var createAccountPage = _homePage.CreateAccountClick();
        var personalDetails = createAccountPage.CreateAccount(_accountData);
        var addressDetails = personalDetails.FillThePersonalDetailsData(_personalDetails);
        var financialDetails = addressDetails.FillTheAddress(_addressDetails);
        var investmentsDetails = financialDetails.FinancialDetailsQuestionnaire(_financialDetails);
        var termsAndConditions = investmentsDetails.InvestmentsDetailsQuestionnaire(_investmentDetails);
        var finalisationPage = termsAndConditions.TermsAndConditionsAgreement();

      Assert.That(finalisationPage.FinalisationText, Is.EqualTo(finalisationPage.FinalisationTextOriginal));
    }
}
