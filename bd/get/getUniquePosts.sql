SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getUniquePosts

AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT post_title AS [post] FROM train_posts
	UNION
	SELECT DISTINCT post_title AS [post] FROM station_posts
END
GO
