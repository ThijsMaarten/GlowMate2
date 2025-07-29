using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GlowMate2.Web.Client.Services;
using GlowMate2.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register services
builder.Services.AddSingleton<IAuthService, WebAuthService>();

await builder.Build().RunAsync();
