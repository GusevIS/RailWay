SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addStationStaff
	 @name varchar(20),
     @salary real,
     @exp int,
     @edu varchar(20),
     @post int
AS
BEGIN
	SET NOCOUNT ON;
	IF ((SELECT required_work_experience FROM station_posts WHERE @post = station_post_id) <= @exp)
		INSERT station_staff VALUES (@name, @salary, @exp, @edu, @post, 0);
END
GO
