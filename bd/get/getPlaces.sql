SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getPlaces
	@route_part_id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT t.ticket_id AS [#ticket], t.place_id AS [#place], ct.type_name AS class
	FROM route_part rp JOIN carriage_route cr ON rp.route_part_id = cr.route_part_id
	JOIN ticket t ON cr.carriage_route_id = t.carriage_route_id
	JOIN railWay_carriage car ON car.carriage_id = cr.carriage_id
	JOIN carriage_type ct ON ct.carriage_type_id = car.carriage_type_id
	WHERE rp.route_part_id = @route_part_id AND t.passenger_id IS NULL

END
GO
