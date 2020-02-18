SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAvailableTrains 
	@station varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT t.train_id AS [#train], t.train_speed AS speed FROM train t JOIN station s ON t.current_station_id = s.station_id WHERE s.station_name = @station
END
GO
