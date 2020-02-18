SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAvailableCarriages
	@route_part_id int
AS
BEGIN
	SET NOCOUNT ON;

	IF (GETDATE() < (SELECT departure_date FROM route_part WHERE route_part_id = @route_part_id))
	BEGIN
		SELECT car.carriage_id AS [#carriage], s.station_id AS [station], car.wearout AS wearout FROM railWay_carriage car JOIN station s ON s.station_id = car.current_station_id 
		JOIN run_between_stations run ON run.first_station_id = s.station_id
		JOIN route_part r_p ON r_p.run_id = run.run_id
		WHERE r_p.route_part_id = @route_part_id AND car.wearout <= 50 AND (r_p.departure_date >= (SELECT dbo.getLastArrivalDate(car.carriage_id)) OR (SELECT dbo.getLastArrivalDate(car.carriage_id)) IS NULL);
	END;
	ELSE
	PRINT 'ROUTE ALREADY IS ACTION/COMPLETED';
END
GO
