SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getUsefulRoutes
	
AS
BEGIN
	SET NOCOUNT ON;

    SELECT rp.route_part_id, COUNT(t.passenger_id) AS [passengers], COUNT(t.ticket_id) AS [places]
	FROM route_part rp JOIN carriage_route cr ON cr.route_part_id = rp.route_part_id 
	JOIN ticket t ON t.carriage_route_id = cr.carriage_route_id WHERE departure_date <= GETDATE()
	GROUP BY rp.route_part_id
	HAVING CONVERT(real, COUNT(t.passenger_id)) / CONVERT(real, (SELECT COUNT(*) FROM route_part rp JOIN carriage_route cr ON cr.route_part_id = rp.route_part_id
	JOIN ticket t ON t.carriage_route_id = cr.carriage_route_id WHERE departure_date <= GETDATE())) > 0.0000005

END
GO
