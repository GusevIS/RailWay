SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getRoutesFreeSeats
	@show_free_seats bit,
	@departure_date date = NULL,
	@departure_station varchar(20) = NULL,
	@arrival_station varchar(20) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @min_free_seats int;
	IF (@show_free_seats = 0)
		SET @min_free_seats = -1;
	ELSE
		SET @min_free_seats = 0;

    SELECT v.route_part_id AS [route part ID], v.train_id AS [#train], COUNT(DISTINCT v.carriage_id) AS [carriage count], COUNT(DISTINCT tick.ticket_id) AS [number of free seats], v.[departure station], v.[arrival station], v.departure_date AS [departure date], v.arrival_date AS [arrival date]
	FROM viewRoutesData v
	LEFT JOIN ticket tick ON tick.carriage_route_id = v.carriage_route_id
	WHERE tick.passenger_id IS NULL AND v.route_type = 'DEFAULT' AND v.departure_date >= GETDATE() AND (CONVERT(date, v.departure_date) = @departure_date OR @departure_date IS NULL)
	AND (v.[departure station] = @departure_station OR @departure_station IS NULL) AND (v.[arrival station] = @arrival_station OR @arrival_station IS NULL)
	GROUP BY v.route_part_id, v.train_id, v.[departure station], v.[arrival station], v.departure_date, v.arrival_date
	HAVING COUNT(DISTINCT tick.ticket_id) > @min_free_seats
	ORDER BY [departure date]
END
GO
