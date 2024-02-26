using AvaTrade.Helpers;
using AvaTrade.Models.Registration;
using AvaTrade.Pages;
using AvaTrade.Popups;
using AvaTrade.TestData;
using NUnit.Framework;

namespace AvaTrade;

public class RegistrationTests: BaseFixture
{
    private string BaseUrl;
    private HomePage _homePage;
    private RegistryPopup _registryPopup;
    private CredentialsModel _credentials;
    private RegistrationPersonalDetails _personalDetailsFrance;
    private RegistrationPersonalDetails _personalDetailsAfghanistan;
    private RegistrationFinancialDetails _financialDetails;
    private TradingExperienceAndKnowledge _tradingExperience;

    [SetUp]
    public void SetUpMethod()
    {
        _homePage = new HomePage(Driver);
        BaseUrl = ConfigurationHelper.Config["BaseUrl"];
        _credentials = CredentialsDataProvider.GetCorrectCredentials();
        _personalDetailsFrance = PersonalDetailDataProvider.GetFrancePersonalDetails;
        _personalDetailsAfghanistan = PersonalDetailDataProvider.GetAfghanistanPersonalDetails;
        _financialDetails = FinancialDetailDataProvider.FinancialDetails;
        _tradingExperience = TradingExperienceDataProvider.GetTradingExperienceData;

    }

    [Test]
    public void AfghanUserCanRegisterInTheSystem()
    {
        _homePage.Open(BaseUrl);
        _homePage.AcceptCookies();

        var registryPopup = _homePage.OpenTheRegistryPopup();
        var registrationPage = registryPopup.SignUp(_credentials);
        var financialDetails = registrationPage.FillThePersonalDetailsData(_personalDetailsAfghanistan);
        var termsAndConditions = financialDetails.FinancialDetailsQuestionnaire(_personalDetailsAfghanistan.Country, _financialDetails);
        var finalisationPage = termsAndConditions.TermsAndConditionsAgreement();
        var finalizationText = finalisationPage.FinalisationRegistration();

       Assert.That(finalizationText, Is.EqualTo(finalisationPage.FinalisationTextOriginal));
    }

    [Test]
    public void FrenchUserCanRegisterInTheSystem()
    {
        _homePage.Open(BaseUrl);
        _homePage.AcceptCookies();

        var registryPopup = _homePage.OpenTheRegistryPopup();
        var registrationPage = registryPopup.SignUp(_credentials);
        var financialDetails = registrationPage.FillThePersonalDetailsData(_personalDetailsFrance);
        var termsAndConditions = financialDetails.FinancialDetailsQuestionnaire(_personalDetailsFrance.Country, _financialDetails, _tradingExperience);
        var finalisationPage = termsAndConditions.TermsAndConditionsAgreement();
        var finalizationText = finalisationPage.FinalisationRegistration();

        Assert.That(finalizationText, Is.EqualTo(finalisationPage.FinalisationTextOriginal));
    }
}
