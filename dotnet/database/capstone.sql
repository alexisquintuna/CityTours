USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE trips (
	trip_id int IDENTITY(1,1) NOT NULL,
	trip_name varchar(500) NOT NULL,
	user_id int FOREIGN KEY REFERENCES users(user_id) NOT NULL
	CONSTRAINT PK_trip PRIMARY KEY (trip_id)
)

--populate default data
CREATE TABLE landmarks (
	landmark_id int IDENTITY(1000,1) NOT NULL,
	name varchar(2000) NOT NULL,
	description varchar(2400),
	category varchar(500),
	latitude varchar(500) NOT NULL,
	longitude varchar(500) NOT NULL,
	address varchar(2000),
	link varchar(2000),
	added_by varchar(5) NOT NULL,
	photo varchar(2000)
	CONSTRAINT PK_landmark PRIMARY KEY (landmark_id)
)

CREATE TABLE trip_landmark (
	trip_id int FOREIGN KEY REFERENCES trips(trip_id) NOT NULL,
	landmark_id int FOREIGN KEY REFERENCES landmarks(landmark_id) NOT NULL
	CONSTRAINT PK_trip_landmark PRIMARY KEY (landmark_id, trip_id)
)
	

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--test landmark data 
INSERT INTO landmarks (name, description, category, latitude, longitude, address, link, added_by, photo)
VALUES
('Ohio Stadium', 'American football stadium in Columbus, Ohio, on the campus of The Ohio State University. Common nicknames include "the Horseshoe", "the Shoe", and "the House That Harley Built".', 'Sports', '40.000999996', '-83.018499926', '411 Woody Hayes Dr., Columbus, OH 43210', 'https://ohiostatebuckeyes.com/sports/m-footbl/facilities/ohio-stadium/', 'admin','https://wallpaperaccess.com/full/8148958.jpg'),
('Columbus Museum of Art', 'An art museum in downtown Columbus, Ohio. The museum collects and exhibits American and European modern and contemporary art, folk art, glass art, and photography.', 'Culture', '39.964384', '-82.987770', '480 E Broad St., Columbus, OH 43215', 'https://www.columbusmuseum.org/', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Columbus_Museum_of_Art_06.jpg/1280px-Columbus_Museum_of_Art_06.jpg'),
('Ohio Theatre', 'A performing arts center and former movie palace on Capitol Square in Downtown Columbus, Ohio.', 'Culture', '39.983334', '-82.983330', '39 E State St., Columbus, OH 43215', 'https://www.capa.com/venues/detail/ohio-theatre', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a2/Ohio_Theatre_01.jpg/1920px-Ohio_Theatre_01.jpg'),
('North Market', 'A 145-year-old vibrant public market made up of Ohio''s best independent merchants, farmers, and makers.', 'Food', '39.9602', '-82.9990', '59 Spruce St., Columbus, OH 43215', 'https://northmarket.org', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/North_Market.jpg/1920px-North_Market.jpg');

INSERT INTO trips (trip_name, user_id)
VALUES
('YOURE A TRIP', 2),
('U2 R A TRIP', 2),
('U R LESS FUN BUT STILL A TRIP', 2),
('Aint he a trip?', 2),
('He isnt', 2);

INSERT INTO trip_landmark (trip_id, landmark_id)
VALUES
(1, 1000),
(1, 1001),
(1, 1002);


GO