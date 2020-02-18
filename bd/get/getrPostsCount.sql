SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getTrPostsCount
	@post varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT train_post_id FROM train_posts WHERE post_title = @post AND deleted = 0;
END
GO
