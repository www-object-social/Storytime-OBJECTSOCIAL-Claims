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
}
