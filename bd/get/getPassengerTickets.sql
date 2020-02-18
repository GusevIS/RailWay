SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getPassengersTickets
	@passport int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT t.ticket_id AS [#ticket], st1.station_name AS [depart station], st2.station_name AS [arrival station], r_p.departure_date AS [depart time], r_p.arrival_date AS [arrival time],
	t.ticket_cost AS [ ticket cost], t.place_id AS place, car.carriage_id AS [#carriage], car_t.type_name AS [class]
	FROM passenger p JOIN ticket t ON t.passenger_id = p.passenger_id  
	JOIN carriage_route car_r ON car_r.carriage_route_id = t.carriage_route_id
	JOIN railWay_carriage car ON car.carriage_id = car_r.carriage_id
	JOIN carriage_type car_t ON car_t.carriage_type_id = car.carriage_type_id
	JOIN route_part r_p ON r_p.route_part_id = car_r.route_part_id JOIN run_between_stations run ON run.run_id = r_p.run_id
	JOIN station st1 ON run.first_station_id = st1.station_id
	JOIN station st2 ON run.second_station_id = st2.station_id WHERE p.passport = @passport
END
GO
