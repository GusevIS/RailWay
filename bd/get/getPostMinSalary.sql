SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getPostMinSalary
	@post varchar(20)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT MIN(salary) AS salary FROM getPostSalary(@post) AS postSalary
END
GO
