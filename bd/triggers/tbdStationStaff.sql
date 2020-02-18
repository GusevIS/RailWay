SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbdStationStaff
   ON station_staff
   INSTEAD OF DELETE
AS 
BEGIN

	SET NOCOUNT ON;

    UPDATE station_staff
	SET fired = 1
	WHERE (SELECT station_staff_id FROM deleted) = station_staff_id;
END
GO
