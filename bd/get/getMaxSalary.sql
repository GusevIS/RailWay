SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getMaxSalary
	@station bit = 0,
	@train bit = 0
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT MAX(salary) AS salary FROM getSalaries(@station, @train) AS salaries
END
GO
