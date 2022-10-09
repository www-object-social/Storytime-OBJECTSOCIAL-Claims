using BadClaimsWebsite.Client;
using Claims;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlyForWebsiteClient;
using Shared;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("main");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.Claims(Shared.terminal.Software.BadClaimsWebsite);
builder.Services.Shared();
builder.Services.OnlyForWebsiteClient()
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();