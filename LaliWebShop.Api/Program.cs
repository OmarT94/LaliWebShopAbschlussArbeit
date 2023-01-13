using Lali.Business.Repository;
using Lali.Business.Repository.Kontrakte;
using Lali.DataAccess;
using Lali.DataAccess.Data;
using LaliWebShop.Api.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Stripe;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LaliWebShop.Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Bitte überbringen und danach zeichne im Feld",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
});
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection")));
builder.Services.AddIdentity<ApplicationBenutzer, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ShopDbContext>();
var apiSetting = builder.Configuration.GetSection("APISettings");
builder.Services.Configure<APISettings>(apiSetting);

var APISettings = apiSetting.Get<APISettings>();
var key = Encoding.ASCII.GetBytes(APISettings.SecretKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = APISettings.ValidAudience,
        ValidIssuer = APISettings.ValidIssuer,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<IArtikelRepository, ArtikelRepository>();
builder.Services.AddScoped<IWarenkorbRepository, WarenkorbRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IKategorieRepository, KategorieRepository>();
builder.Services.AddScoped<IArtikelRepository, ArtikelRepository>();
builder.Services.AddScoped<IBestellungRepository, BestellungRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddCors(o => o.AddPolicy("LaliWebShop", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["ApiKey"];

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(policy => policy.WithOrigins("https://localhost:7122", "https://localhost:7122")
//.AllowAnyMethod()
//.WithHeaders(HeaderNames.ContentType)
//    );
//var timeoutPolicy = policy.TimeoutAsync<HttpResponseMessage>(
//    TimeSpan.FromSeconds(10));
//var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
//    TimeSpan.FromSeconds(30));

//builder.Services.AddHttpClient("PollyDynamic")
//    .AddPolicyHandler(httpRequestMessage =>
//        httpRequestMessage.Method == HttpMethod.Get ? timeoutPolicy : longTimeoutPolicy);


app.UseHttpsRedirection();
app.UseCors("LaliWebShop");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();




