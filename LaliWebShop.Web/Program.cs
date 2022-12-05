using LaliWebShop.Web;
using LaliWebShop.Web.Services;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7229/") });

builder.Services.AddScoped<IArtikelService, ArtikelService>();
builder.Services.AddScoped<IWarenkorbService, WarenkorbService>();

await builder.Build().RunAsync();
