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

    private string Domain => $"https://{(this.Terminal.Software is Standard.terminal.Software.OBJECTSOCIALWebsite or Standard.terminal.Software.OBJECTSOCIALSoftware ? "object.social" :this.Terminal.Software is Standard.terminal.Software.ClaimsSoftware or Standard.terminal.Software.MemoryClaimsWebsite? "memory.claims":this.Terminal.Software is Standard.terminal.Software.BadClaimsWebsite?"bad.claims":"good.claims")}";
    private readonly progress.Config Config;
    private HubConnection _Hub = null!;
    private HubConnection Hub => _Hub ??= new HubConnectionBuilder().WithUrl($"{Domain}/os-and-claims-backstage").WithAutomaticReconnect().Build();
    private readonly IDevice Device;
    private readonly Terminal Terminal;
    private Action ActionChange = null!;
    public event Action Change {
        add => ActionChange -= value;
        remove => ActionChange += value;
    }
    public Services(Terminal terminal,IDevice device,Progress progress) {
        this.Terminal = terminal;
        this.Config = progress.Config("Services", Shared.progress.Status.Install);
        (this.Device = device).NetworkChange += Services_NetworkChange;
        this.Services_NetworkChange();
    }
    public Standard.device.Network Network => this.Hub.State is HubConnectionState.Disconnected ? Standard.device.Network.Offline : Standard.device.Network.Online;
    private async void Services_NetworkChange()
    {
        this.Config.Install();
        if (this.Device.Network is Standard.device.Network.Online && this.Hub.State is HubConnectionState.Disconnected) {
            await Hub.StartAsync();
        }
        if (this.Hub.State is not HubConnectionState.Disconnected)
            this.Config.Done();
        this.ActionChange?.Invoke();
    }


    private void ServicesAuthenticationVerfiy() {
        this.Hub.InvokeAsync<object>("ServicesAuthenticationVerfiy", this.Terminal.Entrance, this.Device.ISO639_1, this.Device.Software, "");
    }
    private void ServicesAuthenticationCreate()
    {


    }


}
