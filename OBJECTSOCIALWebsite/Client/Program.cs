using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OBJECTSOCIAL;
using OBJECTSOCIALWebsite.Client;
using Shared;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("main");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.Shared();
builder.Services.OnlyForWebsiteClient()
builder.Services.OBJECTSOCIAL(Shared.terminal.Software.OBJECTSOCIALWebsite);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();