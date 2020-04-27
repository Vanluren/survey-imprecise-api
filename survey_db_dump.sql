-- MySQL dump 10.13  Distrib 5.7.29, for osx10.15 (x86_64)
--
-- Host: localhost    Database: survey
-- ------------------------------------------------------
-- Server version	5.7.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `CaseParameters`
--

DROP TABLE IF EXISTS `CaseParameters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CaseParameters` (
  `CaseParameterId` int(11) NOT NULL AUTO_INCREMENT,
  `CaseId` int(11) DEFAULT NULL,
  `DescriptionOne` longtext CHARACTER SET utf8mb4,
  `DescriptionTwo` longtext CHARACTER SET utf8mb4,
  `Indicator` int(11) NOT NULL DEFAULT '0',
  `Score` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`CaseParameterId`),
  KEY `IX_CaseParameters_CaseId` (`CaseId`),
  CONSTRAINT `FK_CaseParameters_Cases_CaseId` FOREIGN KEY (`CaseId`) REFERENCES `Cases` (`CaseId`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CaseParameters`
--

LOCK TABLES `CaseParameters` WRITE;
/*!40000 ALTER TABLE `CaseParameters` DISABLE KEYS */;
INSERT INTO `CaseParameters` VALUES (1,14,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(2,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(3,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(4,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(5,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(6,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(7,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(8,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(9,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(10,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(11,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(12,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11),(13,1,'Lavt indtjeningsniveau hæmmer investeringsmuligheder','Dårlig sammenhæng mellem indtjening og afbetaling af gæld',9,11);
/*!40000 ALTER TABLE `CaseParameters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Cases`
--

DROP TABLE IF EXISTS `Cases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Cases` (
  `CaseId` int(11) NOT NULL AUTO_INCREMENT,
  `SupplierId` int(11) DEFAULT NULL,
  PRIMARY KEY (`CaseId`),
  KEY `IX_Cases_SupplierId` (`SupplierId`),
  CONSTRAINT `FK_Cases_Suppliers_SupplierId` FOREIGN KEY (`SupplierId`) REFERENCES `Suppliers` (`SupplierId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cases`
--

LOCK TABLES `Cases` WRITE;
/*!40000 ALTER TABLE `Cases` DISABLE KEYS */;
INSERT INTO `Cases` VALUES (2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,1),(11,1),(12,1),(13,1),(14,1),(1,14);
/*!40000 ALTER TABLE `Cases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Suppliers`
--

DROP TABLE IF EXISTS `Suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Suppliers` (
  `SupplierId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4 NOT NULL,
  `LastName` longtext CHARACTER SET utf8mb4 NOT NULL,
  `Soil` int(11) NOT NULL,
  `Husbandry` int(11) NOT NULL,
  `Nutrients` int(11) NOT NULL,
  `Water` int(11) NOT NULL,
  `Energy` int(11) NOT NULL,
  `Biodiversity` int(11) NOT NULL,
  `Workconditions` int(11) NOT NULL,
  `Lifequality` int(11) NOT NULL,
  `Economy` int(11) NOT NULL,
  `Management` int(11) NOT NULL,
  PRIMARY KEY (`SupplierId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Suppliers`
--

LOCK TABLES `Suppliers` WRITE;
/*!40000 ALTER TABLE `Suppliers` DISABLE KEYS */;
INSERT INTO `Suppliers` VALUES (1,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(2,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(3,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(4,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(5,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(6,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(7,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(8,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(9,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(10,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(11,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(12,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(13,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8),(14,'Lars','Landmand',77,88,80,78,66,58,87,89,80,8);
/*!40000 ALTER TABLE `Suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20200427200443_InitialSetup','3.1.3'),('20200427212033_UpdateCaseParameterCols','3.1.3');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-28  0:57:18
