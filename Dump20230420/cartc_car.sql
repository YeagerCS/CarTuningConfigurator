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
-- Table structure for table `car`
--

DROP TABLE IF EXISTS `car`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `car` (
  `id` int NOT NULL AUTO_INCREMENT,
  `topSpeed` int DEFAULT NULL,
  `breakingForce` int DEFAULT NULL,
  `acceleration` decimal(10,2) DEFAULT NULL,
  `nitro` int DEFAULT NULL,
  `hp` int DEFAULT NULL,
  `brand` varchar(60) DEFAULT NULL,
  `model` varchar(60) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `tintedWindows` tinyint DEFAULT NULL,
  `weight` int DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `Exhaust_id` int DEFAULT NULL,
  `Spoiler_id` int DEFAULT NULL,
  `Tyres_id` int DEFAULT NULL,
  `Break_id` int DEFAULT NULL,
  `Nitro_id` int DEFAULT NULL,
  `Rims_id` int DEFAULT NULL,
  `Engine_id` int DEFAULT NULL,
  `isDefaultCar` tinyint DEFAULT '0',
  `path` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Car_Exhaust_idx` (`Exhaust_id`),
  KEY `fk_Car_Spoiler1_idx` (`Spoiler_id`),
  KEY `fk_Car_Tyres1_idx` (`Tyres_id`),
  KEY `fk_Car_Break1_idx` (`Break_id`),
  KEY `fk_Car_Nitro1_idx` (`Nitro_id`),
  KEY `fk_Car_Rims1_idx` (`Rims_id`),
  KEY `fk_Car_Engine1_idx` (`Engine_id`),
  CONSTRAINT `fk_Car_Break1` FOREIGN KEY (`Break_id`) REFERENCES `break` (`break_id`),
  CONSTRAINT `fk_Car_Engine1` FOREIGN KEY (`Engine_id`) REFERENCES `engine` (`engine_id`),
  CONSTRAINT `fk_Car_Exhaust` FOREIGN KEY (`Exhaust_id`) REFERENCES `exhaust` (`exhaust_id`),
  CONSTRAINT `fk_Car_Nitro1` FOREIGN KEY (`Nitro_id`) REFERENCES `nitro` (`nitro_id`),
  CONSTRAINT `fk_Car_Rims1` FOREIGN KEY (`Rims_id`) REFERENCES `rims` (`rims_id`),
  CONSTRAINT `fk_Car_Spoiler1` FOREIGN KEY (`Spoiler_id`) REFERENCES `spoiler` (`spoiler_id`),
  CONSTRAINT `fk_Car_Tyres1` FOREIGN KEY (`Tyres_id`) REFERENCES `tyres` (`tyres_id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `car`
--

LOCK TABLES `car` WRITE;
/*!40000 ALTER TABLE `car` DISABLE KEYS */;
INSERT INTO `car` VALUES (1,210,100,7.00,0,150,'Hyundai','Accent','White',0,1200,14999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'images/car5.jpg'),(2,410,180,2.80,0,987,'Bugatti','Veyron','Red',1,1300,859999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car2.jpg'),(3,260,150,5.00,0,300,'Obren','Burger','Black',1,1600,59999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car3.jpg'),(4,352,180,2.90,0,574,'Mercedes-Benz','AMG ONE','Silver',1,1800,789999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car4.jpg'),(5,325,200,3.00,0,570,'Ferrari','458 Italia','Yellow',1,2000,179999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'images/car1.jpg'),(6,161,100,7.20,0,220,'Ford','Mustang 1970','Blue',0,1300,18999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car6.jpg'),(7,231,130,6.90,0,217,'Subaru','Impreza GT','Brown',0,1200,20999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car7.jpg'),(8,500,190,2.50,0,1280,'Koenigsegg','Jesko','Black',1,1500,1750000.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car8.jpg'),(9,226,200,5.60,0,250,'Range Rover','Evoque','Silver',1,1800,34999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car9.jpg'),(10,220,185,5.50,0,420,'Mercedes-Benz','G550','Gray',0,1750,149999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'/images/car10.jpg'),(13,822,180,0.60,0,2100,'Mercedes-Benz','AMG ONE','Silver',1,1800,2409999.99,NULL,4,NULL,NULL,NULL,NULL,11,0,'/images/car4.jpg'),(14,885,355,0.60,100,2100,'Bugatti','Veyron Eater','Black',1,1300,2689349.99,5,5,5,5,5,5,11,0,'/images/car2.jpg'),(15,502,1075,1.10,100,574,'Mercedes-Benz','AMG ONE','Silver',1,1800,3988999.99,5,6,7,7,5,5,13,0,'/images/car4.jpg'),(16,860,150,0.60,0,2100,'Obren','Burger','Magenta',1,1600,1909999.99,NULL,6,NULL,NULL,NULL,NULL,11,0,'/images/car3.jpg'),(17,761,995,0.60,100,2100,'Ford','Mustang 1970','DimGray',0,1300,4817999.99,5,6,7,7,5,5,11,0,'/images/car6.jpg'),(19,660,100,0.60,0,2100,'Hyundai','Accent','White',0,1200,1614999.99,NULL,NULL,NULL,NULL,NULL,NULL,11,0,'images/car5.jpg'),(20,211,120,6.42,60,450,'Ford','Mustang 1970','Cyan',0,1300,181679.99,NULL,NULL,4,NULL,4,3,7,0,'/images/car6.jpg'),(21,210,100,7.00,0,150,'Hyundai','Accent','White',0,1200,14999.99,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'images/car5.jpg'),(22,1100,890,0.60,100,2100,'Koenigsegg','Jesko','Black',1,1500,4254350.00,5,6,5,7,5,5,11,0,'/images/car8.jpg');
/*!40000 ALTER TABLE `car` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-20 16:10:04
