SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE addNewCarriageType
	@type_name varchar(20),
	@price_coefficient real
AS
BEGIN
	SET NOCOUNT ON;
	INSERT Carriage_type VALUES (@type_name, @price_coefficient)
END
GO
