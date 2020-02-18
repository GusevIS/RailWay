SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAvgSalary
	@station bit = 0,
	@train bit = 0
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT AVG(salary) AS salary FROM getSalaries(@station, @train) AS salaries
END
GO
