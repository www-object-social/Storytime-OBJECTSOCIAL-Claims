using Claims;
using GoodClaimsWebsite.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("main");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.Claims(Shared.terminal.Software.GoodClaimsWebsite);
builder.Services.Shared();
builder.Services.OnlyForWebsiteClient()
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();