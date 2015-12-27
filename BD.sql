--PROCEDIMIENTO ALMACENADO QUE CREA LA BASE DE DATOS JUNTO A UN PAR DE REGISTROS PARA HACER USO DE LA BD
--CONSEJO: PRIMERO CAMBIEN LA CONEXION EN EL ARCHIVO LINQ PARA EVITAR PROBLEMAS DE RELACION CON LA BASE DE DATOS 
CREATE PROCEDURE Peliteca
AS
BEGIN 
	IF NOT EXISTS (SELECT database_id FROM sys.databases WHERE name = 'Peliteca')--PREGUNTA SI NO HAY UNA BASE DE DATOS YA CREADA CON EL MISMO NOMBRE
	BEGIN 
	EXEC('CREATE DATABASE Peliteca')--CREAMOS LA BD
	
	EXEC('CREATE TABLE Peliteca.dbo.Usuarios(
		nomUser NVARCHAR(10),
		passUser NVARCHAR(15)
		CONSTRAINT pkUser PRIMARY KEY (nomUser)
		)'
	)

	INSERT INTO Peliteca.dbo.Usuarios (nomUser, passUser) VALUES ('omar','gonzalez');

	EXEC('CREATE TABLE Peliteca.dbo.Generos(
		idGen SMALLINT IDENTITY (1,1),
		genero NVARCHAR(25)
		CONSTRAINT pkGenero PRIMARY KEY (idGen)
		)'
	)
	
	INSERT INTO Peliteca.dbo.Generos (genero) values ('Drama'),('Ciencia Ficcion')

	EXEC('CREATE TABLE Peliteca.dbo.Paises(
		idPais SMALLINT IDENTITY (1,1),
		pais NVARCHAR(35)
		CONSTRAINT pkPais PRIMARY KEY (idPais)
		)'
	)

	INSERT INTO Peliteca.dbo.Paises (pais) VALUES ('Afganistán'),('Albania'),('Alemania'),('Andorra'),('Angola'),('Antigua y Barbuda'),('Arabia Saudí'),('Argelia'),('Argentina'),('Armenia'),('Aruba'),('Australia'),('Austria'),('Azerbaiyán'),('Bahamas'),('Bangladesh'),('Barbados'),('Bélgica'),('Belice'),('Benín'),('Bermudas'),('Bielorrusia'),('Bolivia'),('Bosnia y Hercegovina'),('Botsuana'),('Brasil'),('Brunéi'),('Bulgaria'),('Burkina Faso'),('Bután'),('Cabo Verde'),('Camboya'),('Camerún'),('Canadá'),('Chad'),('Chile'),('China'),('Chipre'),('Colombia'),('Congo'),('Corea del Norte'),('Corea del Sur'),('Costa de Marfil'),('Costa Rica'),('Croacia'),('Cuba'),('Dinamarca'),('Ecuador'),('Egipto'),('El Salvador'),('Emiratos Árabes Unidos'),('Eslovaquia'),('Eslovenia'),('España'),('Estados Unidos'),('Estonia'),('Etiopía'),('Filipinas'),('Finlandia'),('Fiyi'),('Francia'),('Gabón'),('Gambia'),('Georgia'),('Ghana'),('Grecia'),('Guam'),('Guatemala'),('Guinea'),('Guinea Ecuatorial'),('Guyana'),('Haití'),('Honduras'),('Hungría'),('India'),('Indonesia'),('Irán'),('Iraq'),('Irlanda'),('Islandia'),('Islas Caimán'),('Islas Cocos'),('Islas Cook'),('Islas Feroe'),('Islas Marshall'),('Islas Salomón'),('Israel'),('Italia'),('Jamaica'),('Japón'),('Jordania'),('Kazajistán'),('Kenia'),('Kuwait'),('Laos'),('Lesoto'),('Letonia'),('Líbano'),('Liberia'),('Libia'),('Liechtenstein'),('Lituania'),('Luxemburgo'),('Macedonia'),('Madagascar'),('Malasia'),('Malaui'),('Maldivas'),('Malí'),('Malta'),('Marruecos'),('Mauricio'),('Mauritania'),('Mexico'),('Moldavia'),('Mónaco'),('Mongolia'),('Montenegro'),('Mozambique'),('Namibia'),('Nauru'),('Nepal'),('Nicaragua'),('Nigeria'),('Noruega'),('Nueva Caledonia'),('Nueva Zelanda'),('Omán'),('Países Bajos'),('Pakistán'),('Panamá'),('Papúa-Nueva Guinea'),('Paraguay'),('Perú'),('Polinesia Francesa'),('Polonia'),('Portugal'),('Puerto Rico'),('Qatar'),('Inglaterra'),('República Centroafricana'),('República Checa'),('República Democrática del Congo'),('República Dominicana'),('Ruanda'),('Rumania'),('Rusia'),('Samoa'),('Samoa Americana'),('San Marino'),('Santo Tomé y Príncipe'),('Senegal'),('Serbia'),('Seychelles'),('Sierra Leona'),('Singapur'),('Siria'),('Somalia'),('Sri Lanka'),('Suazilandia'),('Sudáfrica'),('Sudán'),('Suecia'),('Suiza'),('Surinam'),('Tailandia'),('Taiwán'),('Tanzania'),('Togo'),('Tonga'),('Trinidad y Tobago'),('Túnez'),('Turkmenistán'),('Turquía'),('Tuvalu'),('Ucrania'),('Uganda'),('Uruguay'),('Uzbekistán'),('Vanuatu'),('Venezuela'),('Vietnam'),('Yemen'),('Yibuti'),('Zambia'),('Zimbabue')

	EXEC('CREATE TABLE Peliteca.dbo.Actores(
		idActor SMALLINT IDENTITY(1,1),
		nomActor NVARCHAR(20),
		apeActor NVARCHAR(20),
		idPais SMALLINT,
		sexo BIT,
		fecNac SMALLDATETIME
		CONSTRAINT pkActor PRIMARY KEY (idActor),
		CONSTRAINT fkActorPais FOREIGN KEY (idPais) REFERENCES Paises (idPais)
		)'
	)

	INSERT INTO Peliteca.dbo.Actores (nomActor, apeActor, idPais, sexo, fecNac) VALUES ('Willem', 'Dafoe', 1, 1, '22/07/1955'),('Shanyn', 'Leigh', 1, 0, '22/07/1955');

	EXEC('CREATE TABLE Peliteca.dbo.Directores(
		idDirec SMALLINT IDENTITY (1,1),
		nomDirec NVARCHAR(20),
		apeDirec NVARCHAR(20),
		idPais SMALLINT,
		fecNac SMALLDATETIME
		CONSTRAINT pkDirec PRIMARY KEY (idDirec),
		CONSTRAINT fkDirecPais FOREIGN KEY (idPais) REFERENCES Paises (idPais)
		)'
	)

	INSERT INTO Peliteca.dbo.Directores (nomDirec, apeDirec, idPais, fecNac) VALUES ('Abel', 'Ferrara', 1, '19/07/1951')

	EXEC('CREATE TABLE Peliteca.dbo.Peliculas(
		idPeli INT IDENTITY (1,1),
		titulo NVARCHAR(50),
		idDirec SMALLINT,
		anio SMALLINT,
		idGen SMALLINT,
		duracion TINYINT,
		foto IMAGE
		CONSTRAINT pkPeli PRIMARY KEY (idPeli),
		CONSTRAINT fkPeliDirec FOREIGN KEY (idDirec) REFERENCES Directores (idDirec),
		CONSTRAINT fkPeliGenero FOREIGN KEY (idGen) REFERENCES Generos (idGen)
		)'
	)

	INSERT INTO Peliteca.dbo.Peliculas (titulo, idDirec, anio, idGen, duracion,  foto) VALUES ('4:44 Ultimo dia en la tierra', 1, 2014, 1, 105, null)

	EXEC('CREATE TABLE Peliteca.dbo.PeliActor(
		idPeli INT,
		idActor SMALLINT
		CONSTRAINT pkPeliActor PRIMARY KEY (idPeli, idActor),
		CONSTRAINT fkPeliActor FOREIGN KEY (idPeli) REFERENCES Peliculas (idPeli),
		CONSTRAINT fkActorPeli FOREIGN KEY (idActor) REFERENCES Actores (idActor)
		)'
	)

	INSERT INTO Peliteca.dbo.PeliActor (idPeli, idActor) VALUES (1,1),(1,2);

	EXEC('CREATE TABLE Peliteca.dbo.PeliPais(
		idPeli INT,
		idPais SMALLINT
		CONSTRAINT pkPeliPais PRIMARY KEY (idPeli, idPais),
		CONSTRAINT fkPeliPais FOREIGN KEY (idPeli) REFERENCES Peliculas (idPeli),
		CONSTRAINT fkPaisPeli FOREIGN KEY (idPais) REFERENCES Paises (idPais)
		)'
	)
	
	INSERT INTO Peliteca.dbo.PeliPais (idPeli, idPais) VALUES (1,15);
	
	END
ELSE
	BEGIN
		EXEC('DROP DATABASE Peliteca')--ELIMINAMOS LA BD
		EXEC Peliteca;
	END	
END		
