SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addStationPost
	@station varchar(20),
	@title varchar(20),
	@experience int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @station_id int;
	SET @station_id = (SELECT station_id FROM station WHERE @station = station_name);
    INSERT station_posts VALUES (@title, @experience, @station_id, 0);
END
GO
