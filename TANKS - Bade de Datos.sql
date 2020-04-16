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
  `ip` VARCHAR(15)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Juega` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_jugador` int,
  `id_partida` int,
  `gana` TINYINT,
  CONSTRAINT fk_juega_un_jugador FOREIGN KEY (`id_jugador`) REFERENCES Jugador(`id`),
  CONSTRAINT fk_juega_en_una_partifa FOREIGN KEY (`id_partida`) REFERENCES Partida(`id`)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Estadistica` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_jugador` int,
  `id_juega` int,
  `vida` VARCHAR(255),
  `disparos` int,
  `tiempo` int,
  CONSTRAINT fk_estadistica_un_jugador FOREIGN KEY (`id_jugador`) REFERENCES Jugador(`id`),
  CONSTRAINT fk_estadistica_esta_juego FOREIGN KEY (`id_juega`) REFERENCES Juega(`id`)
) ENGINE = InnoDB;
