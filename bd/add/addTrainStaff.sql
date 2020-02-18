SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addTrainStaff
	 @name varchar(20),
     @salary real,
     @exp int,
     @edu varchar(20),
     @post int
AS
BEGIN
	SET NOCOUNT ON;

    IF ((SELECT required_work_experience FROM train_posts WHERE @post = train_post_id) <= @exp)
		INSERT train_staff VALUES (@name, @salary, @exp, @edu, @post, 0);
END
GO
