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
	trip_pic varchar(8000) NOT NULL,
	user_id int FOREIGN KEY REFERENCES users(user_id) NOT NULL
	CONSTRAINT PK_trip PRIMARY KEY (trip_id)
)

--populate default data
CREATE TABLE landmarks (
	landmark_id int IDENTITY(1000,1) NOT NULL,
	name varchar(2000) NOT NULL,
	description nvarchar(4000),
	category varchar(500),
	latitude varchar(500) NOT NULL,
	longitude varchar(500) NOT NULL,
	address nvarchar(2000),
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
('Ohio Theatre', 'A performing arts center and former movie palace on Capitol Square in Downtown Columbus, Ohio.', 'Culture', '39.9602', '-82.9991', '39 E State St., Columbus, OH 43215', 'https://www.capa.com/venues/detail/ohio-theatre', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a2/Ohio_Theatre_01.jpg/1920px-Ohio_Theatre_01.jpg'),
('North Market', 'A 145-year-old vibrant public market made up of Ohio''s best independent merchants, farmers, and makers.', 'Food', '39.9720', '-83.0043', '59 Spruce St., Columbus, OH 43215', 'https://northmarket.org', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/North_Market.jpg/1920px-North_Market.jpg'),
('St. Mark''s Basilica', 'Certainly Venice''s best-known church, and one of the most easily recognized in the world, St. Mark''s Basilica (Basilica di San Marco) was originally the Doge''s private chapel, decorated with Byzantine art treasures that are part of the booty brought back by Venetian ships after the fall of Constantinople.', 'Culture', '45.4346', '12.3397', 'P.za San Marco, 328, 30100 Venezia VE, Italy', 'https://en.wikipedia.org/wiki/St_Mark%27s_Basilica', 'admin', 'https://cdn4.tuscanynowandmore.com/storage/app/media/discover-italy/st-mark-church-venice.jpg'),
('Ca'' Pesaro and Galleria d''Arte Moderna', 'One of Italy''s finest collections of modern art, it contains works by important 19th- and 20th-century painters and sculptors including Gustav Klimt, Marc Chagall, and Auguste Rodin. Highlights include decorative arts of the 20th century such as works in glass made by Carlo Scarpa in the 1930s and 1940s and rare furniture pieces by the cabinetmaker Carlo Bugatti.', 'Culture', '45.441063', '12.3316317', 'Santa Croce, 2076, 30135 Venezia VE, Italy', 'https://capesaro.visitmuve.it/en/home/', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/Ca%27Pesaro_di_Baldassarre_Longhena_facciata_sul_Canal_Grande.jpg/1200px-Ca%27Pesaro_di_Baldassarre_Longhena_facciata_sul_Canal_Grande.jpg'),
('Petra', 'Petra, originally known to its inhabitants as Raqmu or Raqēmō, is an historic and archaeological city in southern Jordan. It is adjacent to the mountain of Jabal Al-Madbah, in a basin surrounded by mountains forming the eastern flank of the Arabah valley running from the Dead Sea to the Gulf of Aqaba. The area around Petra has been inhabited from as early as 7000 BC, and the Nabataeans might have settled in what would become the capital city of their kingdom as early as the 4th century BC.', 'Ruins', '30.328611', '35.441944', '28 Wadi Mousa - Jordan', 'https://www.visitpetra.jo/', 'admin', 'https://upload.wikimedia.org/wikipedia/commons/e/ed/Al_khazneh.jpg');

INSERT INTO trips (trip_name, trip_pic, user_id)
VALUES
('Columbus, Ohio', 'https://www.tripsavvy.com/thmb/TUQILX_szsrEgZQ2Qi2oO-m2u-A=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/columbus--ohio-cityscape-825663918-04cfd5792b5d45a89b11ef0cd074d443.jpg', 2),
('Venice, Italy', 'http://t3.gstatic.com/licensed-image?q=tbn:ANd9GcQbBnCskxBFqrgATeglMFdHbIiVHJhd_ZfyX5tPBGmPK-5IJEWVRqo8QNaHbfEWrDXg', 2),
('2024 Vacation Ideas', 'https://m.media-amazon.com/images/M/MV5BODVmYjU4NGYtZWUyMC00ZWQyLWI1M2ItYjc5Nzk0NzYyZDUxXkEyXkFqcGdeQXVyMzczODMzOTg@._V1_FMjpg_UX1000_.jpg', 2),
('10th Anniversary', 'https://shebuystravel.com/wp-content/uploads/2022/06/two-champagne-flutes-anniversary-trip.jpg', 2);

INSERT INTO trip_landmark (trip_id, landmark_id)
VALUES
(1, 1000),
(1, 1001),
(1, 1002),
(2, 1004),
(2, 1005),
(3, 1006),
(4, 1004),
(4, 1005);


GO