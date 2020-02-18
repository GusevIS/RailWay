SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION getSalaries
(	
	@st bit = 0,
	@tr bit = 0
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT salary FROM train_staff WHERE fired = 0 AND @tr = 1
	UNION ALL
	SELECT salary FROM station_staff WHERE fired = 0 AND @st = 1
)
GO
