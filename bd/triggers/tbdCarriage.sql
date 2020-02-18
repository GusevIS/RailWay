SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tbdCarriage
   ON railWay_carriage
   INSTEAD OF DELETE
AS 
BEGIN
	SET NOCOUNT ON;

    UPDATE railWay_carriage
	SET deleted = 1
	WHERE (SELECT carriage_id FROM deleted) = carriage_id;

END
GO
