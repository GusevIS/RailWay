SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getExistsStations

AS
BEGIN

	SET NOCOUNT ON;

	SELECT station.station_name AS station FROM station
END
GO
