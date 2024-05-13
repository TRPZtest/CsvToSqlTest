using CsvToSqlTest.Db;
using CsvToSqlTest.Db.Entities;
using CsvToSqlTest.Services.ReadDrivesCsvService;
using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Services.AddRecordsService
{
    public class AddRecordsService
    {
        private readonly AppDbContext _dbContext;

        public AddRecordsService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddRecodsToDb(IEnumerable<RideRecord> records)
        {
            var entities = records.Select(x => x.ToDriveEntity()).ToList();

      

            await _dbContext.BulkInsertAsync(entities);            
        }
    }
}