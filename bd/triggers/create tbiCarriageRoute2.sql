USE railWay_db2
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbiCarriageRoute
   ON carriage_route
   INSTEAD OF INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @depart_time datetime;
	DECLARE @last_arrival_time datetime;

	SET @depart_time = (SELECT departure_date FROM inserted ins JOIN route_part rp ON rp.route_part_id = ins.route_part_id);
	SET @last_arrival_time = (SELECT DISTINCT MAX(arrival_date) FROM inserted ins JOIN railWay_carriage car ON car.carriage_id = ins.carriage_id
								JOIN carriage_route car_r ON car.carriage_id = car_r.carriage_id
								JOIN route_part r_p ON r_p.route_part_id = car_r.route_part_id
								JOIN run_between_stations run ON run.second_station_id = car.current_station_id);
PRINT @last_arrival_time;
	IF (GETDATE() < (SELECT departure_date FROM inserted ins JOIN route_part rp ON rp.route_part_id = ins.route_part_id))
	BEGIN

		IF (((SELECT run_id FROM inserted ins JOIN route_part rp ON rp.route_part_id = ins.route_part_id) IN (
			SELECT run.run_id FROM railWay_carriage car LEFT JOIN run_between_stations run ON run.first_station_id = car.current_station_id JOIN inserted ins ON ins.carriage_id = car.carriage_id)) 
			AND ((@last_arrival_time <= @depart_time)       
			OR (@last_arrival_time IS NULL))
		)
		INSERT carriage_route(carriage_id, route_part_id) SELECT carriage_id, route_part_id FROM inserted;
		ELSE 
			PRINT 'INSERT FAILED';
	END;
	ELSE
	PRINT 'ROUTE ALREADY IS ACTION/COMPLETED';

END
GO
