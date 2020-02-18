SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE buyTicket
	@ticket_id int,
	@passport int
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @passenger_id int;
	SET @passenger_id = (SELECT passenger_id FROM passenger WHERE passport = @passport);

	IF (GETDATE() < (SELECT departure_date FROM ticket t JOIN carriage_route cr ON t.carriage_route_id = cr.carriage_route_id
											JOIN route_part rp ON rp.route_part_id = cr.route_part_id
											WHERE t.ticket_id = @ticket_id))
	BEGIN
		UPDATE ticket 
			SET passenger_id = @passenger_id
			WHERE ticket_id = @ticket_id;
	END
END
GO
