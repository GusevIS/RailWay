SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAllRoutes

AS
BEGIN
	SET NOCOUNT ON;

    SELECT v.route_part_id AS [route part ID], v.train_id AS [#train], COUNT(DISTINCT v.carriage_id) AS [carriage count], COUNT(DISTINCT tick.ticket_id) AS [number of seats], v.[departure station], v.[arrival station], v.departure_date AS [departure date], v.arrival_date AS [arrival date]
	FROM viewRoutesData v
	LEFT JOIN ticket tick ON tick.carriage_route_id = v.carriage_route_id
	WHERE GETDATE() <= v.departure_date
	GROUP BY v.route_part_id, v.train_id, v.[departure station], v.[arrival station], v.departure_date, v.arrival_date
	ORDER BY [departure date]
END
GO
