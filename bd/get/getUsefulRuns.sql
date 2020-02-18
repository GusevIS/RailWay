SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getUsefulRuns
	
AS
BEGIN
	SET NOCOUNT ON;

    SELECT s.station_name AS [departure st], s2.station_name AS [arrival st], COUNT(run.run_id) AS [count routes]
	FROM station s JOIN run_between_stations run ON run.first_station_id = s.station_id
	JOIN station s2 ON s2.station_id = run.second_station_id
	JOIN route_part rp ON rp.run_id = run.run_id WHERE rp.departure_date >= DATEADD(month, -1, GETDATE()) AND rp.departure_date <= GETDATE()
	GROUP BY s.station_name, s2.station_name
	HAVING COUNT(run.run_id) > 0
END
GO
