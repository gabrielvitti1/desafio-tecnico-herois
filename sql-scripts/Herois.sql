CREATE TABLE `Herois` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(120) NOT NULL,
  `NomeHeroi` varchar(120) NOT NULL,
  `DataNascimento` datetime(6) DEFAULT NULL,
  `Altura` float NOT NULL,
  `Peso` float NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
