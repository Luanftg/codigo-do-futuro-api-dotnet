using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Entity;
using cdf_api_integrador.Repositories.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Campanha>,CampainRepositoryEntity>();
builder.Services.AddScoped<IRepositoryUser<Usuario>,UserRepositoryEntity>();
builder.Services.AddScoped<IRepository<Produto>,ProductRepositoryEntity>();
builder.Services.AddScoped<IRepository<Loja>,StoreRepositoryEntity>();
builder.Services.AddScoped<IRepository<Cliente>,ClientRepositoryEntity>();
builder.Services.AddScoped<IRepository<Endereco>,AddressRepositoryEntity>();
builder.Services.AddScoped<IRepository<Pedido>,OrderRepositoryEntity>();
builder.Services.AddScoped<IRepository<PedidoProduto>,OrderProductRepositoryEntity>();
builder.Services.AddScoped<IRepository<PosicoesProduto>,PositionProductRepositoryEntity>();

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

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT como no exemplo: Bearer {SEU_TOKEN}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// }
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
