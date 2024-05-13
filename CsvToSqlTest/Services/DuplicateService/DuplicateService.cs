using CsvToSqlTest.Db;
using CsvToSqlTest.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Services.DuplicateService
{
    public class DuplicateService
    {
        private readonly AppDbContext _dbContext;

        public DuplicateService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ride>> RemoveAndGetDuplicateRides()
        {
            var query = @"
                DELETE T OUTPUT DELETED.*
                FROM
                (
                SELECT *
                , DupRank = ROW_NUMBER() OVER (
                              PARTITION BY tpep_pickup_datetime, tpep_dropoff_datetime, passenger_count
                              ORDER BY (SELECT NULL)
                            )
                FROM Rides
                ) AS T
                WHERE DupRank > 1 
            "; // https://learn.microsoft.com/en-us/troubleshoot/sql/database-engine/development/remove-duplicate-rows-sql-server-tab
            var rides = await _dbContext.Rides.FromSqlRaw(query).ToListAsync();

            return rides;
        }
    }
}
