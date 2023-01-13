using Lali.Business.Repository;
using Lali.Business.Repository.Kontrakte;
using Lali.DataAccess.Data;
using LaliWebShop.Server.Data;
using LaliWebShop.Server.Service;
using LaliWebShop.Server.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<ShopDbContext>();
builder.Services.AddScoped<IKategorieRepository,KategorieRepository>();
builder.Services.AddScoped<IArtikelRepository,ArtikelRepository>();
builder.Services.AddScoped<IBestellungRepository, BestellungRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["ApiKey"];


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
SeedDatabase();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}