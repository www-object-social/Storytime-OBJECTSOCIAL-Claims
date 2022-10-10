using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public abstract class DoNotUseThisFile_Device:IDevice
{
    public string ISO639_1 => System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToUpper();
    public abstract Standard.device.Software Software { get; }
    private Standard.device.Network _Network;
    public Standard.device.Network Network { 
        get => _Network;
        private set {
            if (_Network == value) return;
           _Network = value;
            this.ActionNetworkChange?.Invoke();
        }
    }
    public virtual void Offline() => this.Network = Standard.device.Network.Offline;
    public virtual void Online() => this.Network = Standard.device.Network.Online;
    private Action ActionNetworkChange = null!;
    public event Action NetworkChange
    {
        add => ActionNetworkChange += value;
        remove => ActionNetworkChange -= value;
    }
    public DoNotUseThisFile_Device(Standard.device.Network network) => _Network = network;
}
