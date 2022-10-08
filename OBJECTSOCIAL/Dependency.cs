using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBJECTSOCIAL
{
    public static class Dependency
    {
        public static void OBJECTSOCIAL(this IServiceCollection services,Shared.terminal.Software software) {
            services.AddScoped(x => new Shared.Terminal
            {
                Entrance = Shared.terminal.Entrance.Business,
                Software = software
            });
        }
    }
}
