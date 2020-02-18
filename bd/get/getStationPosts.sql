SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getStationPosts
	@station varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @station_id int;
	SET @station_id = (SELECT station_id FROM station WHERE station_name = @station);
    SELECT station_post_id, post_title AS [post], required_work_experience AS [work experience], station_id FROM station_posts WHERE station_id = @station_id AND deleted = 0;
END
GO
