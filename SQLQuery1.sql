CREATE TABLE Svirac (
	sviracID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	imePrezime NVARCHAR(50) NOT NULL,
	instrument NVARCHAR(50) NOT NULl,
)

INSERT INTO Svirac (imePrezime,instrument) VALUES ('Stefan Brdar','Klavijatura')

CREATE TABLE Instrument (
	instrumentID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	naziv NVARCHAR(50) NOT NULL,
)

CREATE TABLE Svirke (
	svirkaID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	lokacija NVARCHAR(50) NOT NULL,
	datum DATETIME NOT NULL,
)


INSERT INTO Svirke (lokacija,datum) VALUES ('Kula','2023-03-04')
INSERT INTO Svirke (lokacija,datum) VALUES ('Kafanica','2023-03-04') 
INSERT INTO Svirke (lokacija,datum) VALUES ('Prica','2023-03-04') 
INSERT INTO Svirke (lokacija,datum) VALUES ('Ex Caffe','2023-09-21') 
INSERT INTO Svirke (lokacija,datum) VALUES ('Kafanica','2023-05-03') 
INSERT INTO Svirke (lokacija,datum) VALUES ('Pub podrum','2023-02-14') 

SELECT lokacija, datum
FROM Svirke
ORDER BY datum ASC

INSERT INTO Instrument (naziv) VALUES ('Gitara')
INSERT INTO Instrument (naziv) VALUES ('Bubnjevi')
INSERT INTO Instrument (naziv) VALUES ('Kontrabas')
INSERT INTO Instrument (naziv) VALUES ('Klavijatura')
INSERT INTO Instrument (naziv) VALUES ('Truba')

SELECT *
FROM Instrument
