SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getSalaryFromToExp
(	
	@expFrom int,
	@expTo int
)
RETURNS TABLE 
AS
RETURN 
(
	(SELECT salary, [work exp] FROM getSalaryFromExp(@expFrom) AS salaryFrom)
	INTERSECT
    (SELECT salary, [work exp] FROM getSalaryToExp(@expTo) AS salaryFrom)
)
GO
