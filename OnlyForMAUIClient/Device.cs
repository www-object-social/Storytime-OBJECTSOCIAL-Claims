using Shared;
using Standard.device;
namespace OnlyForMAUIClient;
class Device : DoNotUseThisFile_Device
{
    public Device() : base(Microsoft.Maui.Networking.Connectivity.NetworkAccess is NetworkAccess.Internet ? Standard.device.Network.Online : Standard.device.Network.Offline) => Microsoft.Maui.Networking.Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess is NetworkAccess.Internet)
            this.Online();
        else
            this.Offline();
        this.OK();
    }

    public override void Console(object message)
    {
      
    }

    public override Standard.device.Software Software { get=>
#if ANDROID
        Standard.device.Software.Android;
#elif WINDOWS
        Standard.device.Software.Microsoft;
#elif MACCATALYST
        Standard.device.Software.Mac;
#else
        Standard.device.Software.iOS;
#endif

        set { } }
}
