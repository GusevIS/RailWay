USE railWay_db2
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbiRoutePart
   ON [dbo].route_part
   INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @arrive_time datetime;
	DECLARE @depart_time datetime;
	DECLARE @route_time real;
	DECLARE @last_arrival_time datetime;
	SET @arrive_time = (SELECT arrival_date FROM inserted);
	SET @depart_time = (SELECT departure_date FROM inserted);
	SET @route_time = (SELECT run.distance FROM run_between_stations run JOIN inserted ins ON run.run_id = ins.run_id)
						/ (SELECT tr.train_speed FROM train tr JOIN inserted ins ON tr.train_id = ins.train_id) * 60;
	SET @last_arrival_time = (SELECT DISTINCT MAX(arrival_date) FROM route_part rp JOIN train tr ON tr.train_id = rp.train_id 
								JOIN run_between_stations run ON run.second_station_id = tr.current_station_id
								WHERE tr.train_id = (SELECT train_id FROM inserted));
	
	IF ((SELECT run_id FROM inserted) IN(
		SELECT run.run_id FROM train tr LEFT JOIN run_between_stations run ON run.first_station_id = tr.current_station_id JOIN inserted ins ON ins.train_id = tr.train_id) 
		AND (@route_time <= DATEDIFF(minute, @depart_time, @arrive_time))
		AND ((@last_arrival_time <= @depart_time) 
			OR (@last_arrival_time IS NULL))
		)
		INSERT route_part(train_id, run_id, arrival_date, departure_date, route_type) SELECT train_id, run_id, arrival_date, departure_date, route_type FROM inserted;
	ELSE
		PRINT 'INSERT FAILED';
END
GO
