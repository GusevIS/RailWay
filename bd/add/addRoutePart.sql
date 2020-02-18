SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addRoutePart
	@train_id int,
	@arrival_station varchar(20),
	@departure_station varchar(20),
	@arrival_date datetime,
	@departure_date datetime,
	@route_type varchar(20)
AS
BEGIN

	SET NOCOUNT ON;

    INSERT route_part VALUES (@train_id,
							(SELECT run.run_id FROM run_between_stations run JOIN station st1 ON st1.station_id = run.first_station_id JOIN station st2 ON st2.station_id = run.second_station_id
								WHERE st1.station_name = @departure_station AND st2.station_name = @arrival_station),
								@arrival_date,
								@departure_date,
								@route_type)
END
GO
