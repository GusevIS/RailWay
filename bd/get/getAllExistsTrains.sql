SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAllExistsTrains

AS
BEGIN
	SET NOCOUNT ON;

    SELECT t.train_id AS [#train], t.train_speed AS [speed], t.ticket_price_km AS [price per km], s.station_name AS [station], tp.type_name AS [type]
	FROM train t JOIN station s On t.current_station_id = s.station_id JOIN train_type tp On tp.train_type_id = t.train_type_id
	WHERE deleted = 0
END
GO
