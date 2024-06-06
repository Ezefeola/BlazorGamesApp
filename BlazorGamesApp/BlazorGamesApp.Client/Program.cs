using BlazorGamesApp.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(HttpClient => new HttpClient
{
    BaseAddress =  new Uri(builder.HostEnvironment.BaseAddress),
}); 
builder.Services.AddScoped<IGameService, ClientGameService>();

await builder.Build().RunAsync();
