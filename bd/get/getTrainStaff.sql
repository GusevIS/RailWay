USE railWay_db2
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getTrainStaff
	@train_id int
AS
BEGIN

	SET NOCOUNT ON;

    SELECT train_staff_id AS [#employee], staff_name AS [name], salary, work_experience AS [work experience], education, ts.train_post_id AS [#post], post_title AS [post]
	FROM train_staff ts JOIN train_posts tp ON tp.train_post_id = ts.train_post_id WHERE tp.train_id = @train_id AND ts.fired = 0;
END
GO
