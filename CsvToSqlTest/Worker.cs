using CsvToSqlTest.Services.AddRecordsService;
using CsvToSqlTest.Services.ReadDrivesCsvService;

namespace CsvToSqlTest
{
    public class Worker : BackgroundService
    {
        private readonly AddRecordsService _addRecordsService;
        private readonly ReadCsvService _readCsvService;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, AddRecordsService addRecordsService, ReadCsvService readCsvService)
        {
            _addRecordsService = addRecordsService;
            _readCsvService = readCsvService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var records = _readCsvService.ReadDriveRecords();

            await _addRecordsService.AddRecodsToDb(records);

            _logger.LogInformation($"{records.Count()} records added");

            System.Environment.Exit(0);
        }
    }
}
