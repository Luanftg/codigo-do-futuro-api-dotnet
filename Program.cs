using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Entity;
using cdf_api_integrador.Repositories.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// builder.Services.AddScoped<IRepository<Campanha>,>();
builder.Services.AddScoped<IRepositoryUser<Usuario>,UserRepositoryEntity>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Radar API - Código do Futuro",
        Description = "Integração com a aplicação Radar",
        Contact = new OpenApiContact { Name = "Luan Fonseca", Email = "luanftgimenez@gmail.com" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
