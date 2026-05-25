CREATE DATABASE parqueadero;

USE parqueadero;

CREATE TABLE Vehiculos (

    Id INT PRIMARY KEY AUTO_INCREMENT,

    Placa VARCHAR(20) NOT NULL,

    Tipo VARCHAR(20) NOT NULL,

    FechaIngreso DATETIME NOT NULL,

    FechaSalida DATETIME NULL,

    TotalMinutos INT NULL,

    ValorPagado DECIMAL(10,2) NULL

);