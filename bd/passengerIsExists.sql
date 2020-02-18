SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION passengerIsExists
(
	@passport int,
	@passenger_name varchar(20)
)
RETURNS BIT
AS
BEGIN
	DECLARE @isExists BIT;
	IF (EXISTS (SELECT * FROM passenger WHERE passport = @passport AND passenger_name = @passenger_name))
		SET @isExists = 1;
	ELSE
		SET @isExists = 0;
		
	RETURN @isExists;
END
GO

