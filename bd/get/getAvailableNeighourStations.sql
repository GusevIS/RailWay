SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAvailableNeighourStations
	@station varchar(20)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT st1.station_name AS [depart station], st2.station_name AS [arrival station], run.distance AS distance FROM run_between_stations run JOIN station st1 ON st1.station_id = run.first_station_id JOIN station st2 ON run.second_station_id = st2.station_id
	WHERE st1.station_name = @station
END
GO
