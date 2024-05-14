using CsvToSqlTest.Db.Entities;
using CsvToSqlTest.Services.ReadDrivesCsvService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Helpers
{
    public static class DriveRecordHelpers
    {
        public static string MapYesNo(this string s)
        {
            if (s == "N")
                return "No";

            if (s == "Y")
                return "Yes";
            if (String.IsNullOrEmpty(s))
                return null;

            else throw new ArgumentException($"Value: {s} must be Y or N or empty"); 
        }

        public static RideRecord RideEntityToRecord(this Ride  entity)
        {
            var record = new RideRecord()
            {
                TpepPickupDatetime = entity.TpepPickupDatetime,
                TpepDropoffDatetime = entity.TpepDropoffDatetime,
                PassengerCount = entity.PassengerCount,
                TripDistance = entity.TripDistance,
                StoreAndFwdFlag = entity.StoreAndFwdFlag,
                PULocationID = entity.PULocationID,
                DOLocationID = entity.DOLocationID,
                FareAmount = entity.FareAmount,
                TipAmount = entity.TipAmount
            };
            return record;
        }
    }
}
