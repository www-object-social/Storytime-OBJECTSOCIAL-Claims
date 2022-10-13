using Microsoft.AspNetCore.ResponseCompression;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddCors();
builder.Services.AddHealthChecks();    
var app = builder.Build();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();
else
    app.UseHsts();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapHealthChecks("/os-and-claims-healthchecks");
app.UseRouting();
app.MapHub<Backstage.Backstage>("/os-and-claims-backstage");
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();