USE railWay_db2
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER taiRoutePart 
   ON route_part 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	UPDATE train
		SET current_station_id = (SELECT run.second_station_id FROM run_between_stations run JOIN inserted ins ON ins.run_id = run.run_id)
			WHERE train.train_id = (SELECT train_id FROM inserted);

	DECLARE @route_distance real;
	SET @route_distance = (SELECT run.distance FROM inserted ins JOIN run_between_stations run ON ins.run_id = run.run_id);

END
GO