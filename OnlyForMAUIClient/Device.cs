using Shared;
using Standard.device;
namespace OnlyForMAUIClient;
class Device : DoNotUseThisFile_Device
{
    public override Standard.device.Software Software =>
#if ANDROID
        Standard.device.Software.Android;
#elif WINDOWS
        Standard.device.Software.Microsoft;
#elif MACCATALYST
        Standard.device.Software.Mac;
#else
        Standard.device.Software.iOS;
#endif
}
