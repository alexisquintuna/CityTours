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

--populate default data
CREATE TABLE landmarks (
	landmark_id int IDENTITY(1000,1) NOT NULL,
	name varchar(200) NOT NULL,
	description varchar(240) NOT NULL,
	category varchar(50) NOT NULL,
	latitude varchar(50) NOT NULL,
	longitude varchar(50) NOT NULL,
	address varchar(200) NOT NULL,
	link varchar(200) NOT NULL
	CONSTRAINT PK_landmark PRIMARY KEY (landmark_id)
)
	

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--test landmark data 
INSERT INTO landmarks (name, description, category, latitude, longitude, address, link)
VALUES
('Ohio Stadium', 'American football stadium in Columbus, Ohio, on the campus of The Ohio State University. Common nicknames include "the Horseshoe", "the Shoe", and "the House That Harley Built".', 'Sports', '40.000999996', '-83.018499926', '411 Woody Hayes Dr., Columbus, OH 43210', 'https://ohiostatebuckeyes.com/sports/m-footbl/facilities/ohio-stadium/'),
('Columbus Museum of Art', 'An art museum in downtown Columbus, Ohio. The museum collects and exhibits American and European modern and contemporary art, folk art, glass art, and photography.', 'Culture', '39.964384', '-82.987770', '480 E Broad St., Columbus, OH 43215', 'https://www.columbusmuseum.org/'),
('Ohio Theatre', 'A performing arts center and former movie palace on Capitol Square in Downtown Columbus, Ohio.', 'Culture', '39.983334', '-82.983330', '39 E State St., Columbus, OH 43215', 'https://www.capa.com/venues/detail/ohio-theatre'),
('North Market', 'A 145-year-old vibrant public market made up of Ohio''s best independent merchants, farmers, and makers.', 'Food', '39.9602', '-82.9990', '59 Spruce St., Columbus, OH 43215', 'https://northmarket.org')


GO
