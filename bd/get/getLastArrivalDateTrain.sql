SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getLastArrivalDateTrain
(
	@train_id int
)
RETURNS datetime
AS
BEGIN
	DECLARE @last_arrival_time datetime;
	SET @last_arrival_time = (SELECT DISTINCT MAX(arrival_date) FROM train t
								JOIN route_part rp ON rp.train_id = t.train_id
								JOIN run_between_stations run ON run.second_station_id = t.current_station_id
								WHERE t.train_id = @train_id);

	RETURN @last_arrival_time
END
GO

