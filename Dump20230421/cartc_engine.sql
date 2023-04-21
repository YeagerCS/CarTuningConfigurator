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
-- Table structure for table `engine`
--

DROP TABLE IF EXISTS `engine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `engine` (
  `engine_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(60) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `cylinder` varchar(45) DEFAULT NULL,
  `level` int DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `ImpactVelocity` int DEFAULT NULL,
  `ImpactAcceleration` decimal(10,2) DEFAULT NULL,
  `ImpactHorsePower` int DEFAULT NULL,
  PRIMARY KEY (`engine_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `engine`
--

LOCK TABLES `engine` WRITE;
/*!40000 ALTER TABLE `engine` DISABLE KEYS */;
INSERT INTO `engine` VALUES (5,'Eternal Damnation','Uranium','ATOMZ2',1,35000.00,20,0.37,300),(6,'TurboForce 2.0T','Gasoline','2.0L Turbo',1,40000.00,25,0.40,300),(7,'TurboForce 2.5M','Gasoline','2.5L Turbo',2,80000.00,50,0.60,450),(8,'IronCladV8','Diesel','3.0L V8',3,120000.00,75,0.90,650),(9,'EcoVoltage X','Electric','None',4,160000.00,100,1.20,800),(10,'Exterminator','Gasoline','8.0L V16',5,200000.00,125,1.80,1000),(11,'Unreal Engine','Kerosene','CFM56-7B',6,1600000.00,450,7.00,2100),(12,'Slaughterer','Propane Gas','GPS89-X',5,375000.00,180,2.00,1300),(13,'Default',NULL,NULL,0,0.00,0,0.00,0),(14,'Engine of Doom','Ethanol Gas','W16 GX2',5,1000000.00,300,2.80,1700);
/*!40000 ALTER TABLE `engine` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-21 16:58:58
