USE [railWay_db2]
GO

/****** Object:  UserDefinedFunction [dbo].[getLastArrivalDate]    Script Date: 17.12.2019 1:38:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION getLastArrivalDate
(
	@carriage_id int
)
RETURNS datetime
AS
BEGIN
	DECLARE @last_arrival_time datetime;
	SET @last_arrival_time = (SELECT DISTINCT MAX(arrival_date) FROM railWay_carriage car
								JOIN carriage_route cr ON cr.carriage_id = car.carriage_id
								JOIN route_part rp ON rp.route_part_id = cr.route_part_id
								JOIN run_between_stations run ON run.second_station_id = car.current_station_id
								WHERE car.carriage_id = @carriage_id);

	RETURN @last_arrival_time
END
GO


