using Microsoft.AspNetCore.ResponseCompression;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();
else
    app.UseHsts();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapHub<Backstage.Backstage>("/os-and-claims-backstage");
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
