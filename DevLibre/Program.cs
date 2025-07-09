
using DevLibre.ExceptionHandler;
using DevLibre.Models;
using DevLibre.Persistance;
using DevLibre.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FreelanceTotalCostConfig>(
    builder.Configuration.GetSection("FreelanceTotalCostConfig")
    );

builder.Services.AddProblemDetails();

// Inmemory Database
// builder.Services.AddDbContext<DevLivreDbContext>(o => o.UseInMemoryDatabase("DevFreelaDb"));

// SQL Server Database
builder.Services.AddDbContext<DevLivreDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DevFreelaDb")));

// Singleton service se mantém o mesmo valor durante toda a execução da aplicação
builder.Services.AddSingleton<IConfigService, ConfigService>();

// Add custom exception handler
builder.Services.AddExceptionHandler<ApiExceptionHandle>();

// Scoped service é criado uma nova instância a cada requisição
// builder.Services.AddScoped<IConfigService, ConfigService>();

// Transient service é criado uma nova instância a cada injeção
// builder.Services.AddTransient<IConfigService, ConfigService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the root
});

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
