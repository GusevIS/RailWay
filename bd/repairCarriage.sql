SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE repairCarriage 
	@carriage_id int,
	@month datetime,
	@expended real
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @wearout real;
    SET @wearout = (SELECT car.wearout FROM railWay_carriage car WHERE car.carriage_id = @carriage_id);

	DECLARE @repair_price real;
    SET @repair_price = (SELECT car.repair_price_per_percent FROM railWay_carriage car WHERE car.carriage_id = @carriage_id);

	DECLARE @repaired real;
	SET @repaired = @expended / @repair_price;
	IF (@repaired <= @wearout)
	BEGIN
		UPDATE railWay_carriage SET wearout = wearout - @repaired WHERE carriage_id = @carriage_id;
		INSERT carriage_expenses VALUES (CAST(@month AS date), @expended, 'carriage was repaired' + CAST(@repaired AS varchar(3)), @carriage_id);
	END
END
GO
