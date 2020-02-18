USE railWay_db2
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER taiCarriageRoute
   ON carriage_route
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

    IF ((SELECT route_type FROM inserted ins JOIN route_part rp ON rp.route_part_id = ins.route_part_id) = 'DEFAULT')
		INSERT ticket(carriage_route_id, place_id, ticket_cost) 
			SELECT ins.carriage_route_id, v.place_id, v.ticket_cost FROM railWay_carriage car JOIN inserted ins ON car.carriage_id = ins.carriage_id JOIN viewTicketData v ON v.carriage_route_id = ins.carriage_route_id;

	DECLARE @route_distance real;
	SET @route_distance = (SELECT run.distance FROM inserted ins JOIN route_part rp ON rp.route_part_id = ins.route_part_id
							JOIN run_between_stations run ON rp.run_id = run.run_id);

	UPDATE railWay_carriage
		SET mileage_total = mileage_total + @route_distance
			WHERE railWay_carriage.carriage_id = (SELECT carriage_id FROM inserted);
			
	UPDATE railWay_carriage
		SET wearout = wearout + @route_distance * 0.001
			WHERE railWay_carriage.carriage_id = (SELECT carriage_id FROM inserted);

	UPDATE railWay_carriage
		SET current_station_id = (SELECT run.second_station_id FROM run_between_stations run JOIN route_part rp ON rp.run_id = run.run_id JOIN inserted ins ON ins.route_part_id = rp.route_part_id)
			WHERE railWay_carriage.carriage_id = (SELECT carriage_id FROM inserted);
END
GO
