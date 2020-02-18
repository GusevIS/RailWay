SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE handOverTicket
	@ticket_id int
AS
BEGIN

	SET NOCOUNT ON;

    IF (GETDATE() < (SELECT departure_date FROM ticket t JOIN carriage_route cr ON cr.carriage_route_id = t.carriage_route_id
											JOIN route_part rp ON rp.route_part_id = cr.route_part_id
											WHERE t.ticket_id = @ticket_id))
	UPDATE ticket
		SET passenger_id = NULL
		WHERE ticket_id = @ticket_id;
END
GO
