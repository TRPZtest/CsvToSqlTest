using CsvHelper;
using CsvToSqlTest.Db.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Services.ReadDrivesCsvService
{
    public class ReadCsvService
    {
        private string _path;
        public ReadCsvService(ConfigurationData configuration)
        {
            _path = configuration.FilePath;
        }
        public List<RideRecord> ReadDriveRecords()
        {
            using var fileStream = File.OpenRead(_path);
            using var reader = new StreamReader(fileStream);

            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);

            var records =  csv.GetRecords<RideRecord>().ToList();

            return records;
        }
    }
}
