using Microsoft.JSInterop;
using Standard.device;
using Standard.terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
namespace OnlyForWebsiteClient;
class Device : Shared.DoNotUseThisFile_Device, IAsyncDisposable
{
    private DotNetObjectReference<Device> DotNetObjectRef = null!;

    private IJSObjectReference JSObject { get; set; } = null!;
    public override Standard.device.Software Software { get; set; }
    public Device(IJSRuntime jSRuntime):base(Network.Online) => _ = TaskDevice(jSRuntime).ConfigureAwait(true);
    private async Task TaskDevice(IJSRuntime jSRuntime)
    {
        JSObject = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/OnlyForWebsiteClient/Device.js");
    
        
        var UA = await JSObject.InvokeAsync<string>("GetUA");
        if (UA.ToLower().Contains(" firefox/"))
            Software = Standard.device.Software.Firefox;
        else if (UA.ToLower().Contains(" opr/"))
            Software = Standard.device.Software.Oprea;
        else if (UA.ToLower().Contains(" edg/"))
            Software = Standard.device.Software.Edge;
        else if (UA.ToLower().Contains(" chrome/"))
            Software = Standard.device.Software.Chrome;
        else if (UA.ToLower().Contains(" safari/"))
            Software = Standard.device.Software.Safari;
        else
            Software = Standard.device.Software.Unknown;
        if (await JSObject.InvokeAsync<bool>("GetNetwork", this.DotNetObjectRef = DotNetObjectReference.Create(this)))
            this.Online();
        else
            this.Offline();
        this.OK();
    }
    [JSInvokable]
    public override void Online() => base.Online();
    [JSInvokable]
    public override void Offline() => base.Offline();
    public async ValueTask DisposeAsync()
    {
        await JSObject.DisposeAsync();
        DotNetObjectRef.Dispose();
    }

    public override async void Console(string message)
    {
        await JSObject.InvokeVoidAsync("Console",message);
    }
}
