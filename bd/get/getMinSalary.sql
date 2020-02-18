SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getMinSalary
	@station bit = 0,
	@train bit = 0
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT MIN(salary) FROM getSalaries(@station, @train) AS salaries
END
GO
