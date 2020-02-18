SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE addCarriageRoute
	@carriage_id int,
	@route_part_id int
AS
BEGIN
	SET NOCOUNT ON;

    INSERT carriage_route VALUES (@carriage_id, @route_part_id)
END
GO
