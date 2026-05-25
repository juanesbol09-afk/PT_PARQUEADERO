CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;
ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Vehiculos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Placa` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Tipo` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FechaIngreso` datetime(6) NOT NULL,
    `FechaSalida` datetime(6) NULL,
    CONSTRAINT `PK_Vehiculos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260525045712_Inicial', '9.0.0');

ALTER TABLE `Vehiculos` ADD `TotalMinutos` int NULL;

ALTER TABLE `Vehiculos` ADD `ValorPagado` decimal(65,30) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260525135233_AgregarCamposPago', '9.0.0');

COMMIT;

