-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: cartc
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `spoiler`
--

DROP TABLE IF EXISTS `spoiler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spoiler` (
  `spoiler_id` int NOT NULL AUTO_INCREMENT,
  `type` varchar(45) DEFAULT NULL,
  `name` varchar(60) DEFAULT NULL,
  `level` int DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `ImpactVelocity` int DEFAULT NULL,
  PRIMARY KEY (`spoiler_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spoiler`
--

LOCK TABLES `spoiler` WRITE;
/*!40000 ALTER TABLE `spoiler` DISABLE KEYS */;
INSERT INTO `spoiler` VALUES (1,'Rear Wing','Rear Eater E3',1,5000.00,5),(2,'Whale Tail Spoiler','VEVOR Whale Tail',2,10000.00,10),(3,'Whale Tail Spoiler','VEVOR Whale V2',3,15000.00,15),(4,'Rear Wing','Wing Sneaker X12',4,20000.00,20),(5,'Lip Spoilers','Lipser Z7',5,25000.00,25),(6,'Rear Wing','Horrifying Spoiler',6,2500000.00,150),(7,NULL,'None',0,0.00,0);
/*!40000 ALTER TABLE `spoiler` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-19 14:34:17
