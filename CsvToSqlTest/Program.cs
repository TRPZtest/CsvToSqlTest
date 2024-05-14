using CsvToSqlTest;
using CsvToSqlTest.Db;
using CsvToSqlTest.Services.AddRecordsService;
using CsvToSqlTest.Services.DuplicateService;
using CsvToSqlTest.Services.ReadDrivesCsvService;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var configurationData = builder.Configuration.Get<ConfigurationData>();

builder.Services.AddHostedService<EtlWorker>();
builder.Services.AddSingleton<ConfigurationData>(configurationData);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configurationData.ConnectionString),  ServiceLifetime.Singleton);
builder.Services.AddSingleton<AddRecordsService>();
builder.Services.AddSingleton<CsvService>();
builder.Services.AddSingleton<DuplicateService>();

var host = builder.Build();
host.Run();
