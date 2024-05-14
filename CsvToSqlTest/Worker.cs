using CsvToSqlTest.Services.AddRecordsService;
using CsvToSqlTest.Services.DuplicateService;
using CsvToSqlTest.Services.ReadDrivesCsvService;

namespace CsvToSqlTest
{
    public class Worker : BackgroundService
    {
        private readonly AddRecordsService _addRecordsService;
        private readonly ReadCsvService _readCsvService;
        private readonly DuplicateService _duplicateService;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, AddRecordsService addRecordsService, ReadCsvService readCsvService, DuplicateService duplicateService)
        {
            _addRecordsService = addRecordsService;
            _readCsvService = readCsvService;
            _duplicateService = duplicateService; 
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var records = _readCsvService.ReadDriveRecords();

            await _addRecordsService.AddRecodsToDb(records);

            _logger.LogInformation($"{records.Count()} records added");

            var duplicates = await _duplicateService.RemoveAndGetDuplicateRides();

            _logger.LogInformation($"{duplicates.Count()} duplicates was found");

            System.Environment.Exit(0);
        }
    }
}
