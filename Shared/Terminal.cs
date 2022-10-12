using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shared;
public class Terminal
{
    public Standard.terminal.Entrance Entrance { get; init; }
    public Standard.terminal.Software Software { get; init; }
    public bool IsPreview { get; init; }
}
