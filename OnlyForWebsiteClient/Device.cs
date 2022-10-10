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
    private Standard.device.Software _Software = Standard.device.Software.Unknown;
    private IJSObjectReference JSObject { get; set; } = null!;
    public override Standard.device.Software Software => _Software;
    public Device(IJSRuntime jSRuntime):base(Network.Online) => _ = TaskDevice(jSRuntime);
    private async Task TaskDevice(IJSRuntime jSRuntime)
    {
        JSObject = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/OnlyForWebsiteClient/Device.js");
        var UA = await JSObject.InvokeAsync<string>("GetUA");
        if (UA.ToLower().Contains(" firefox/"))
            _Software = Standard.device.Software.Firefox;
        else if (UA.ToLower().Contains(" opr/"))
            _Software = Standard.device.Software.Oprea;
        else if (UA.ToLower().Contains(" edg/"))
            _Software = Standard.device.Software.Edge;
        else if (UA.ToLower().Contains(" chrome/"))
            _Software = Standard.device.Software.Chrome;
        else if (UA.ToLower().Contains(" safari/"))
            _Software = Standard.device.Software.Safari;
        if (await JSObject.InvokeAsync<bool>("GetNetwork", this.DotNetObjectRef = DotNetObjectReference.Create(this)))
            this.Online();
        else
            this.Offline();
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
}
