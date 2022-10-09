using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class Dependency
    {
        public static void Shared(this IServiceCollection services) {
            //services.AddScoped<Terminal>()  
            //services.AddScoped<IDevice>()

        }
    }
}
