SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAllExistsCarriages
	@wearout real
AS
BEGIN
	SET NOCOUNT ON;
	SELECT car.carriage_id AS [#carriage], car.wearout AS wearout, car.mileage_total AS mileage, ct.price_coefficient AS [price coefficient], ct.type_name AS [type],
	s.station_name AS station, COUNT(*) AS [number of seats], car.repair_price_per_percent AS [repair price per %]
	FROM railWay_carriage car JOIN station s ON  s.station_id = car.current_station_id JOIN carriage_type ct ON ct.carriage_type_id = car.carriage_type_id LEFT JOIN carriage_place pl ON pl.carriage_id = car.carriage_id
	WHERE car.wearout >= @wearout AND deleted = 0
	GROUP BY car.carriage_id, car.wearout, car.mileage_total, ct.price_coefficient, ct.type_name, s.station_name, car.repair_price_per_percent
	ORDER BY car.carriage_id
    END
GO
