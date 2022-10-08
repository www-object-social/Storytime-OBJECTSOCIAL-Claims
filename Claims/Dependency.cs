using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public static class Dependency
    {
        public static void Claims(this IServiceCollection services,Shared.terminal.Software software) {
            services.AddScoped(x => new Shared.Terminal
            {
                Entrance = Shared.terminal.Entrance.Private,
                Software = software
            });
        }
    }
}
