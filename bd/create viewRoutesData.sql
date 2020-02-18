CREATE VIEW viewRoutesData AS
SELECT r_p.route_part_id, r_p.train_id, r_p.run_id, r_p.departure_date, r_p.arrival_date, r_p.route_type, run.first_station_id, run.second_station_id, run.distance, 
st1.station_name AS [departure station], st2.station_name AS [arrival station], c_r.carriage_route_id, car.carriage_id, car.carriage_type_id, car.mileage_total, car.repair_price_per_percent, car.wearout
FROM route_part r_p 
	JOIN run_between_stations run ON r_p.run_id = run.run_id
	JOIN station st1 ON st1.station_id = run.first_station_id JOIN station st2 ON st2.station_id = run.second_station_id
	LEFT JOIN carriage_route c_r ON c_r.route_part_id = r_p.route_part_id
	LEFT JOIN railWay_carriage car ON car.carriage_id = c_r.carriage_id