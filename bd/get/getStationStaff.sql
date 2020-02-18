SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getStationStaff
	@station varchar(20)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @station_id int;
	SET @station_id = (SELECT station_id FROM station WHERE station_name = @station);
    SELECT station_staff_id AS [#employee], staff_name AS [name], salary, work_experience AS [work experience], education, ss.station_post_id AS [#post], post_title AS [post]
	FROM station_staff ss JOIN station_posts sp ON sp.station_post_id = ss.station_post_id WHERE sp.station_id = @station_id AND ss.fired = 0;
END
GO
