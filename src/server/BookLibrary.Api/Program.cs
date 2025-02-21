using BooksLibrary.Api;
using BooksLibrary.Domain.AutoMapper;
using BooksLibrary.Infra.CrossCutting.IoT;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

NativeInjectorBootstrapper.RegisterApiServices(builder.Services);

builder.Services.AddAutoMapper(typeof(AutoMapperProfileConfig));

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
DatabaseConfig.CreateDatabaseIfNotExists(app);

app.UseHttpsRedirection();


app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
