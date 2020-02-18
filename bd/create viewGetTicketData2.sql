CREATE VIEW viewTicketData AS
SELECT car.carriage_id, car_rp.carriage_route_id, pl.place_id, (tr.ticket_price_km * car_type.price_coefficient * run.distance) AS ticket_cost FROM carriage_route car_rp 
JOIN railWay_carriage car ON car.carriage_id = car_rp.carriage_id
JOIN carriage_place pl ON pl.carriage_id = car.carriage_id
JOIN route_part rp ON rp.route_part_id = car_rp.route_part_id
JOIN train tr ON tr.train_id = rp.train_id
JOIN run_between_stations run ON run.run_id = rp.run_id
JOIN carriage_type car_type ON car.carriage_type_id = car_type.carriage_type_id
