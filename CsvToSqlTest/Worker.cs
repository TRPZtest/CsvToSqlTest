using CsvToSqlTest.Services.AddRecordsService;
using CsvToSqlTest.Services.DuplicateService;
using CsvToSqlTest.Services.ReadDrivesCsvService;

namespace CsvToSqlTest
{
    public class Worker : BackgroundService
    {
        private readonly AddRecordsService _addRecordsService;
        private readonly CsvService _csvService;
        private readonly DuplicateService _duplicateService;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, AddRecordsService addRecordsService, CsvService readCsvService, DuplicateService duplicateService)
        {
            _addRecordsService = addRecordsService;
            _csvService = readCsvService;
            _duplicateService = duplicateService; 
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var records = _csvService.ReadDriveRecords();

            await _addRecordsService.AddRecodsToDb(records);

            _logger.LogInformation($"{records.Count()} records added");

            var duplicates = await _duplicateService.DeleteAndGetDuplicateRides();

            _logger.LogInformation($"{duplicates.Count()} duplicates was found");

            _csvService.WriteDriveRecords(records);

            _logger.LogInformation($"Duplicates was written to Duplicates.csv");

            System.Environment.Exit(0);
        }
    }
}
