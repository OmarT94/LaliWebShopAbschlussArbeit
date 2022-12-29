using Lali.Business.Repository;
using Lali.Business.Repository.Kontrakte;
using Lali.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnection")));
builder.Services.AddScoped<IArtikelRepository, ArtikelRepository>();
builder.Services.AddScoped<IWarenkorbRepository, WarenkorbRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IKategorieRepository, KategorieRepository>();
builder.Services.AddScoped<IArtikelRepository, ArtikelRepository>();
builder.Services.AddCors(o => o.AddPolicy("LaliWebShop", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));



var app = builder.Build();

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

app.UseHttpsRedirection();
app.UseCors("LaliWebShop");
app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();




