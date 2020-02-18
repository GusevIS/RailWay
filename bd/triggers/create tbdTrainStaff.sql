SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbdTrainStaff
   ON train_staff
   INSTEAD OF DELETE
AS 
BEGIN

	SET NOCOUNT ON;

    UPDATE train_staff
	SET fired = 1
	WHERE (SELECT train_staff_id FROM deleted) = train_staff_id;
END
GO
