SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE deleteCarriageType
	@deleteType varchar(20)
AS
BEGIN

	SET NOCOUNT ON;
	DELETE carriage_type WHERE carriage_type.type_name = @deleteType
END
GO
