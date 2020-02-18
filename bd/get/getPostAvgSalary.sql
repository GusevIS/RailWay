SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getPostAvgSalary
	@post varchar(20)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT AVG(salary) AS salary FROM getPostSalary(@post) AS postSalary
END
GO
