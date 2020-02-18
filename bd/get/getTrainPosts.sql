SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getTrainPosts
	@train_id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT train_post_id, post_title AS [post], required_work_experience AS [work experience], train_id FROM train_posts WHERE train_id = @train_id AND deleted = 0
END
GO
