SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addTrainPost
	@train_id int,
	@title varchar(20),
	@experience int
AS
BEGIN
	SET NOCOUNT ON;

    INSERT train_posts VALUES (@title, @experience, @train_id, 0)
END
GO
