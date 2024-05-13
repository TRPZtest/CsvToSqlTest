using CsvHelper.Configuration.Attributes;
using CsvToSqlTest.Db.Entities;
using CsvToSqlTest.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Services.ReadDrivesCsvService
{
    public class RideRecord
    {
        [Name("tpep_pickup_datetime")]
        public DateTime TpepPickupDatetime { get; set; }

        [Name("tpep_dropoff_datetime")]
        public DateTime TpepDropoffDatetime { get; set; }

        [Name("passenger_count")]
        [Default(0)]
        public int PassengerCount { get; set; }

        [Name("trip_distance")]
        public float TripDistance { get; set; }

        [Name("store_and_fwd_flag")]
        public string? StoreAndFwdFlag { get; set; }

        [Name("PULocationID")]
        public int PULocationID { get; set; }

        [Name("DOLocationID")]
        public int DOLocationID { get; set; }

        [Name("fare_amount")]
        public float FareAmount { get; set; }

        [Name("tip_amount")]
        public float TipAmount { get; set; }

        public Ride ToDriveEntity()
        {
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var entity = new Ride()
            {
                TpepPickupDatetime = TimeZoneInfo.ConvertTimeToUtc(TpepPickupDatetime, est),
                TpepDropoffDatetime = TimeZoneInfo.ConvertTimeToUtc(TpepDropoffDatetime, est),
                PassengerCount = PassengerCount,
                TripDistance = TripDistance,
                StoreAndFwdFlag = StoreAndFwdFlag.Trim().MapYesNo(),
                PULocationID = PULocationID,
                DOLocationID = DOLocationID,
                FareAmount = FareAmount,
                TipAmount = TipAmount
            };
            return entity;
        }
    }
}
