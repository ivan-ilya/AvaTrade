using ApiTests.Enumerations;
using AvaTrade.Enumerations;
using AvaTrade.Helpers;

namespace ApiTests.Helpers;

public static class DeviceManager
{
    public static Device GetDeviceType()
    {
        var device = ConfigurationHelper.Config["DeviceType"];
        return device switch
        {
            "desktop" => Device.Desktop,
            "mobile" => Device.Mobile,
            _ => throw new Exception("Please specify valid device type in config file or as environment variable.")
        };
    }
    public static string GetMobileDevice()
    {
        var mobileDevice = ConfigurationHelper.Config["MobileDevice"];

        if (!string.IsNullOrEmpty(mobileDevice))
        {
            return mobileDevice;
        }

        throw new Exception("Please specify valid mobile device in config file or as environment variable.");
    }
    public static string GetMobileDevice(string deviceType)
    {
        var iosDevice = ConfigurationHelper.Config["IOSMobileDevice"];
        var googleDevice = ConfigurationHelper.Config["GoogleMobileDevice"];
        return (deviceType == MobileDevice.Google.ToString() ? googleDevice : iosDevice)!;
    }
}
