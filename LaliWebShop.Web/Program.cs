using Blazored.LocalStorage;
using LaliWebShop.Web;
using LaliWebShop.Web.Services;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl"))});

builder.Services.AddScoped<IArtikelService, ArtikelService>();
builder.Services.AddScoped<IWarenkorbService, WarenkorbService>();
builder.Services.AddScoped<IBestellungService, BestellungService>();
builder.Services.AddScoped<IBezahlungMethodeService, BezahlungMethodeService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
await builder.Build().RunAsync();
