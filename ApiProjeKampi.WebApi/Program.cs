using System.Reflection;
using ApiProjeKampi.WebApi.Context;
using DotNetEnv;
using ApiProjeKampi.WebApi.Entities;
using ApiProjeKampi.WebApi.ValidationRules;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// .env yükle (varsa)
try { Env.Load(); } catch { /* yoksa sorun değil */ }



// Add services to the container.
builder.Services.AddDbContext<ApiContext>();// constructer kullandığımı bildirdim.
builder.Services.AddScoped<IValidator<Product>, ProductValidator>(); // ProductValidator sınıfını IValidator<Product> arayüzü ile ilişkilendiriyorum. Böylece DI container bu arayüzü kullanarak ProductValidator sınıfının bir örneğini sağlayacak.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // kullanacağımı belirttim ve assembly ile gerekli automapper kurallarını git ve bul.
builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Sadece HTTP kullanıyoruz

app.UseAuthorization();

app.MapControllers();

app.Run();

