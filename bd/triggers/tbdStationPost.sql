SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbdStationPost
   ON station_posts
   INSTEAD OF DELETE
AS 
BEGIN
	SET NOCOUNT ON;

    UPDATE station_posts
	SET deleted = 1
	WHERE (SELECT station_post_id FROM deleted) = station_post_id;

	UPDATE station_staff
	SET fired = 1
	WHERE (SELECT station_post_id FROM deleted) = station_post_id;
END
GO
