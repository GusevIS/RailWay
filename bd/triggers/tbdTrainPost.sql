SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbdTrainPost
   ON train_posts
   INSTEAD OF DELETE
AS 
BEGIN
	SET NOCOUNT ON;

    UPDATE train_posts
	SET deleted = 1
	WHERE (SELECT train_post_id FROM deleted) = train_post_id;

	UPDATE train_staff
	SET fired = 1
	WHERE (SELECT train_post_id FROM deleted) = train_post_id;
END
GO
