global using Hangfire;
using BooksLibrary.Infra.CrossCutting.Integrations.Options;
using BooksLibrary.Infra.CrossCutting.IoT;
using BooksLibrary.WorkerService;
using BooksLibrary.WorkerService.Configurations;
using Hangfire.Dashboard.Management.v2;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.Services.Configure<GoogleApiSettings>(builder.Configuration.GetSection(nameof(GoogleApiSettings)));

builder.Services.AddHangfire(configuration =>
{
    configuration
    .UseManagementPages(typeof(Program).Assembly)
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHangfireServer(x => x.SchedulePollingInterval = TimeSpan.FromSeconds(5));

builder.Services.AddDatabaseConfiguration(builder.Configuration);

NativeInjectorBootstrapper.RegisterWorkerServices(builder.Services);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<GoogleApiSettings>>().Value);

builder.Services.AddDatabaseConfiguration(builder.Configuration);

var app = builder.Build();
DatabaseConfig.CreateDatabaseIfNotExists(app);
await app.RunAsync();
