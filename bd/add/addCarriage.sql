SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addCarriage
	@wearout real,
	@total_mileage real,
	@carriage_type varchar(20),
	@station_name varchar(20),
	@repair_price real,
	@place_count int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @station_id int;
	SET @station_id = (SELECT station_id FROM station WHERE station_name = @station_name);
	DECLARE @type_id int;
	SET @type_id = (SELECT carriage_type_id FROM carriage_type WHERE type_name = @carriage_type);

	INSERT railWay_carriage VALUES (@wearout, @total_mileage, @type_id, @repair_price, @station_id);

	DECLARE @inserted_places int;
	DECLARE @inserted_id int;
	SET @inserted_id = (SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]);
	SET @inserted_places = 0;
	WHILE @inserted_places < @place_count
	BEGIN
		INSERT carriage_place VALUES (@inserted_id);
		SET @inserted_places = @inserted_places + 1;
	END
END
GO
