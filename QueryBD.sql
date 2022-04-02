USE master
GO

CREATE DATABASE BD_Registros --Creación de BD (Tamaño por defecto)
GO
USE BD_Registros --Uso de la BD
GO

--Creación de tablas
CREATE TABLE Clientes --Tabla clientes
(
	IDCliente int IDENTITY(1,1) PRIMARY KEY, --Código de cada registro o llave primaria
	Nombres varchar(25),
	Apellidos varchar(25),
	Telefono int
)

--Registros de prueba
INSERT INTO Clientes VALUES ('Fernando', 'Bonilla', 76581452)
INSERT INTO Clientes VALUES ('Gerardo', 'Palacios', 76789422)
INSERT INTO Clientes VALUES ('Anthony', 'Ortega', 68451478)

--Procedimientos almacenados

--Procedimiento para insertar registros
CREATE PROCEDURE insertar_registros
@Name varchar(25),
@LastName varchar(25),
@Telefono int
AS
	INSERT INTO Clientes VALUES (@Name, @LastName, @Telefono)

--Procedimiento para modificar datos
CREATE PROCEDURE modificar_registro @ID int, @Name varchar(25), @LastName varchar(25), @Telefono int 
AS
UPDATE Clientes SET Nombres=@Name, Apellidos=@LastName, Telefono=@Telefono WHERE IDCliente=@ID

--Ejecución de prueba para el procedimiento almacenado
EXEC insertar_registros 'Damián', 'Morales', 74859612

SELECT * FROM Clientes

exec modificar_registro 5, 'Vladimir', 'Putin', 74203020

SELECT * FROM Clientes