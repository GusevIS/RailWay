SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE registerNewPassenger
	@passport int,
	@passenger_name varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT passenger VALUES (@passport, @passenger_name)
END
GO
