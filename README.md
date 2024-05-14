Hi!



```sql
use test

drop table  dbo.Rides

CREATE TABLE dbo.Rides
(
	Id INT PRIMARY KEY IDENTITY,
	tpep_pickup_datetime DateTime NOT NULL,
	tpep_dropoff_datetime DateTime NOT NULL,
	passenger_count INT NOT NULL,
	trip_distance DECIMAL(5,2) NOT NULL,
	store_and_fwd_flag VARCHAR(3),
	PULocationID INT NOT NULL,
	DOLocationID INT NOT NULL,
	fare_amount DECIMAL(5,2) NOT NULL,
	tip_amount DECIMAL(5,2) NOT NULL,
	time_spent_traveling AS DATEDIFF(MINUTE, tpep_pickup_datetime, tpep_dropoff_datetime) PERSISTED 
	
)

-- Find out which `PULocationId` (Pick-up location ID) has the highest tip_amount on average.
CREATE INDEX IX_PULocationID_TipAmount ON dbo.Rides (PULocationID, tip_amount);

-- Find the top 100 longest fares in terms of `trip_distance`
CREATE INDEX IX_TripDistance ON dbo.Rides (trip_distance);

-- Index for travel time calculated and stored column
CREATE INDEX IX_time_spent_traveling ON dbo.Rides (time_spent_traveling);

-- Search, where part of the conditions is `PULocationId`.
CREATE INDEX IX_PULocationID ON dbo.Rides (PULocationID);

```
