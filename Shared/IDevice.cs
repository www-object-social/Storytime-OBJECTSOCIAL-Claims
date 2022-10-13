using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;
public interface IDevice
{
    public string ISO639_1 { get; }
    public Standard.device.Software Software { get; }
    public event Action NetworkChange;
    public event Action Ready;
    public bool IsReady { get; set; }
    public Standard.device.Network Network { get; }
    public void Console(object message);
}
