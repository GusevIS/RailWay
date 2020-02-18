SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getPostSalary
(
	@post varchar(20)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT salary FROM train_posts tp JOIN train_staff ts ON ts.train_post_id = tp.train_post_id WHERE tp.post_title = @post
	UNION
	SELECT salary FROM station_posts sp JOIN station_staff ss ON ss.station_post_id = sp.station_post_id WHERE sp.post_title = @post
)
GO
