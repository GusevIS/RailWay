SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getStPostsCount
	@post varchar(20),
	@station varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @station_id int;
	SET @station_id = (SELECT station_id FROM station WHERE @station = station_name);
    SELECT station_post_id AS [#post] FROM station_posts WHERE post_title = @post AND station_id = @station_id AND deleted = 0;
END
GO
