SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getSalaryFromExp
(	
	@exp int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT salary, work_experience AS [work exp] FROM station_staff ss WHERE work_experience >= @exp
	UNION
	SELECT salary, work_experience AS [work exp] FROM train_staff ss WHERE work_experience >= @exp
)
GO
