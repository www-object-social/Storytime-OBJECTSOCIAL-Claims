using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace Backstage;
public class Backstage:Hub
{
    [EnableCors("signalr-core")]
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}