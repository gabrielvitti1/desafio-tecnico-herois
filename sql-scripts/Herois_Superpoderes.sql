CREATE TABLE `Herois_Superpoderes` (
  `Heroi_id` int NOT NULL,
  `Superpoder_id` int NOT NULL,
  PRIMARY KEY (`Heroi_id`,`Superpoder_id`),
  KEY `Superpoder_id` (`Superpoder_id`),
  CONSTRAINT `Herois_Superpoderes_ibfk_1` FOREIGN KEY (`Heroi_id`) REFERENCES `Herois` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Herois_Superpoderes_ibfk_2` FOREIGN KEY (`Superpoder_id`) REFERENCES `Superpoderes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
