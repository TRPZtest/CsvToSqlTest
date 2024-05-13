﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Db.Entities
{
    public class Ride
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("tpep_pickup_datetime")]
        public DateTime TpepPickupDatetime { get; set; }

        [Column("tpep_dropoff_datetime")]
        public DateTime TpepDropoffDatetime { get; set; }

        [Column("passenger_count")]
        public int PassengerCount { get; set; }

        [Column("trip_distance")]
        public float TripDistance { get; set; }

        [Column("store_and_fwd_flag")]
        public string? StoreAndFwdFlag { get; set; }

        [Column("PULocationID")]
        public int PULocationID { get; set; }

        [Column("DOLocationID")]
        public int DOLocationID { get; set; }

        [Column("fare_amount")]
        public float FareAmount { get; set; }

        [Column("tip_amount")]
        public float TipAmount { get; set; }
    }
}
