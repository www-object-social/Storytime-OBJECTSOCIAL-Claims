using Shared;
using Standart.device;
namespace OnlyForMAUIClient;
class Device : DoNotUseThisFile_Device
{
    public override Software Software =>
#if ANDROID
        Standart.device.Software.Android;
#elif WINDOWS
        Standart.device.Software.Microsoft;
#elif MACCATALYST
        Standart.device.Software.Mac;
#else
        Standart.device.Software.iOS;
#endif
}
