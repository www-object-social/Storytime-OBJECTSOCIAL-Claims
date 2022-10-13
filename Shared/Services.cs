using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;
class Services
{
    private bool IsPreview = true;
    private readonly progress.Config Config;
    private HubConnection _Hub = null!;
    private HubConnection Hub => _Hub ??= new HubConnectionBuilder().WithUrl("https://object.social/os-and-claims-backstage").WithAutomaticReconnect().Build();
    private readonly IDevice Device;
    public Services(IDevice device,Progress progress) {
        this.Config = progress.Config("Services", Shared.progress.Status.Install);
        (this.Device = device).NetworkChange += Services_NetworkChange;
        this.Services_NetworkChange();
    }
    public Standard.device.Network Network => this.Hub.State is HubConnectionState.Disconnected ? Standard.device.Network.Offline : Standard.device.Network.Online;
    private async void Services_NetworkChange()
    {
        this.Config.Install();
        if (this.Device.Network is Standard.device.Network.Online && this.Hub.State is HubConnectionState.Disconnected)
        {
            await Hub.StartAsync();
            if (this.Hub.State is HubConnectionState.Connected)
                Device.Console("Signalr Connected");
            else
                Device.Console("Signalr not Connected");
        }
        if (this.Hub.State is not HubConnectionState.Disconnected)
            this.Config.Done();
    }
    private void DeviceAuthentication() { }
   
}
