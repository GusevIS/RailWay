SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE deleteCarriage
	@carriage_id int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE railWay_carriage WHERE carriage_id = @carriage_id
END
GO
