SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getExistsCarriageTypes

AS
BEGIN

	SET NOCOUNT ON;

	SELECT carriage_type.type_name AS [type] FROM carriage_type
END
GO
