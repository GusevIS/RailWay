USE master
go
CREATE DATABASE railWay_db2
GO

USE railWay_db2

CREATE TABLE carriage_type
  (carriage_type_id int PRIMARY KEY NOT NULL IDENTITY,
  type_name varchar(20) NOT NULL UNIQUE,
  price_coefficient real DEFAULT 1,
  CHECK (price_coefficient = 0);

CREATE TABLE railWay_carriage
  (carriage_id int PRIMARY KEY NOT NULL IDENTITY,
  wearout real NOT NULL,
  mileage_total real NOT NULL,
  carriage_type_id int references carriage_type(carriage_type_id) NOT NULL,
  repair_price_per_percent real NOT NULL,
  deleted bit NOT NULL,
  CHECK (wearout <= 100 AND wearout >= 0 AND mileage_total >= 0));

CREATE TABLE carriage_place
  (place_id int PRIMARY KEY NOT NULL IDENTITY,
  carriage_id int references railWay_carriage(carriage_id) NOT    
    NULL);

CREATE TABLE train_type
  (train_type_id int PRIMARY KEY NOT NULL IDENTITY,
  type_name varchar(20) NOT NULL UNIQUE);

CREATE TABLE train
  (train_id int PRIMARY KEY NOT NULL IDENTITY,
  train_type_id int references train_type(train_type_id) NOT NULL,
  train_speed real NOT NULL,
  ticket_price_km real NOT NULL,
  deleted bit NOT NULL,
  CHECK (train_speed <= 500 AND train_speed >= 0)
  );

CREATE TABLE train_posts
  (train_post_id int PRIMARY KEY NOT NULL IDENTITY,
  post_title varchar(20) NOT NULL,
  required_work_experience int NULL,
  train_id int references train(train_id) NOT NULL,
  deleted bit NOT NULL DEFAULT 0);

CREATE TABLE train_staff
  (train_staff_id int PRIMARY KEY NOT NULL IDENTITY,
  staff_name varchar(20) NOT NULL,
  salary real NOT NULL,
  work_experience int NOT NULL,
  education varchar(20) NOT NULL,
  train_post_id int references train_posts(train_post_id) NULL,
  fired bit NOT NULL DEFAULT 0);

CREATE TABLE station
  (station_id int PRIMARY KEY NOT NULL IDENTITY,
  station_name varchar(20) NOT NULL UNIQUE);

CREATE TABLE run_between_stations
  (run_id int PRIMARY KEY NOT NULL IDENTITY,
  first_station_id int references station(station_id) NOT NULL,
  second_station_id int references station(station_id) NOT NULL,
  distance real NOT NULL,
  CHECK (distance <= 20000 AND distance >= 0));

CREATE TABLE route_part
  (route_part_id int PRIMARY KEY NOT NULL IDENTITY,
  train_id int references train(train_id),
  run_id int references run_between_stations(run_id) NOT NULL,
  arrival_date datetime NOT NULL,
  departure_date datetime NOT NULL,
  route_type varchar(20) DEFAULT 'DEFAULT',
  CHECK (arrival_date > departure_date));

CREATE TABLE station_posts
  (station_post_id int PRIMARY KEY NOT NULL IDENTITY,
  post_title varchar(20) NOT NULL,
  required_work_experience int NULL,
  station_id int references station(station_id) NOT NULL,
  deleted bit NOT NULL DEFAULT 0);

CREATE TABLE station_staff
  (station_staff_id int PRIMARY KEY NOT NULL IDENTITY,
  staff_name varchar(20) NOT NULL,
  salary realNOT NULL,
  work_experience int NOT NULL,
  education varchar(20) NOT NULL,
  station_post_id int references                       
  station_posts(station_post_id) NULL,
  fired bit NOT NULL DEFAULT 0);

CREATE TABLE station_expenses
  (station_exp_id int PRIMARY KEY NOT NULL IDENTITY,
  month_date date NOT NULL,
  amount real NOT NULL,
  comments varchar(30) NULL,
  station_id int references station(station_id) NOT NULL);

CREATE TABLE carriage_expenses
  (carriage_exp_id int PRIMARY KEY NOT NULL IDENTITY,
  month_date date NOT NULL,
  amount real NOT NULL,
  comments varchar(30) NULL,
  carriage_id int references railWay_carriage(carriage_id) NOT 
    NULL);

CREATE TABLE passenger
  (passenger_id int PRIMARY KEY NOT NULL IDENTITY,
  passport int NOT NULL UNIQUE,
  passenger_name varchar(20) NOT NULL);

CREATE TABLE carriage_route
  (carriage_route_id int PRIMARY KEY NOT NULL IDENTITY,
  carriage_id int references railWay_carriage(carriage_id) NOT NULL,
  route_part_id int references route_part(route_part_id) NOT NULL);

CREATE TABLE ticket
  (ticket_id int PRIMARY KEY NOT NULL IDENTITY,
  carriage_route_id int references carriage_route(carriage_route_id)  NOT NULL,
  place_id int references carriage_place(place_id)  NOT NULL,
  passenger_id int references passenger(passenger_id) NULL,
  ticket_cost real NOT NULL);

ALTER TABLE train
ADD current_station_id int references station(station_id) NOT NULL;

ALTER TABLE railWay_carriage
ADD current_station_id int references station(station_id) NOT NULL;