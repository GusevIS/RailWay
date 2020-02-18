SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAvgExp
	@expFrom int = null,
	@expTo int = null
AS
BEGIN
	SET NOCOUNT ON;

    IF (@expFrom IS NULL AND @expTo IS NOT NULL)
		SELECT AVG(salary) AS salary FROM getSalaryToExp(@expTo)
	ELSE IF (@expFrom IS NOT NULL AND @expTo IS NOT NULL)
		SELECT AVG(salary) AS salary FROM getSalaryFromToExp(@expFrom, @expTo)
	ELSE IF (@expFrom IS NOT NULL AND @expTo IS NULL)
		SELECT AVG(salary) AS salary FROM getSalaryFromExp(@expFrom)
END
GO
