SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getTrPostsCount
	@post varchar(20),
	@train_id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT train_post_id AS [#post] FROM train_posts WHERE post_title = @post AND @train_id = train_id AND deleted = 0;
END
GO
