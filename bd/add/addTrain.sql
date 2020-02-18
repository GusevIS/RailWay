SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addTrain
	@train_type varchar(20),
	@speed real,
	@price real,
	@station varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT train VALUES ((SELECT train_type_id FROM train_type t WHERE t.type_name = @train_type),
						@speed, @price,
						(SELECT station_id FROM station s WHERE s.station_name = @station))
END
GO
