CREATE DATABASE `TANKS` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE TANKS;
CREATE TABLE IF NOT EXISTS `Jugador` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `usuario` VARCHAR(45),
  `clave` VARCHAR(45),
  `nombre` VARCHAR(45),
  `apepat` VARCHAR(45),
  `apemat` VARCHAR(45),
  `nivel` INT
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Partida` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `jugador` VARCHAR(45),
  `contricante` VARCHAR(45),
  `ganador` VARCHAR(45)
) ENGINE = InnoDB;

insert into partida (jugador, contricante) values ('niconi','pablo');
insert into movimiento (partida,jugador) values (10, 'niconi');
insert into movimiento (partida,jugador) values (10, 'pablo'); 

select * from movimiento;

select * from Partida;

CREATE TABLE IF NOT EXISTS `Movimiento` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `partida` int not null,
  `jugador` VARCHAR(45),
  `x` INT,
  `y` INT,
  `direccion` CHAR,
  `bala` boolean,
  `vida` int
) ENGINE = InnoDB;

drop table movimiento;

CREATE TABLE IF NOT EXISTS `Estadistica` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `jugador` VARCHAR(45),
  `disparos` VARCHAR(45),
  `vida` VARCHAR(45),
  `tiempo` VARCHAR(45)
) ENGINE = InnoDB;

