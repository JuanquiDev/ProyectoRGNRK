-- MySQL dump 10.13  Distrib 8.0.37, for Win64 (x86_64)
--
-- Host: localhost    Database: rgnrk-v2
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `rgnrk-v2`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `rgnrk-v2` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `rgnrk-v2`;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240529100120_init','8.0.4'),('20240529101302_v2','8.0.4'),('20240529152241_videos','8.0.4'),('20240601111603_AddCategoryToExercise','8.0.4'),('20240603142214_workouts','8.0.4'),('20240605134138_workoutandexerciseid','8.0.4'),('20240605134620_description3000','8.0.4'),('20240605135028_useridpersonalcalendar','8.0.4'),('20240606115122_scaffoldingentrenamientos','8.0.4'),('20240607092805_benchmarkSingular','8.0.6'),('20240607094159_changesBenchmark','8.0.6'),('20240607100809_changesBenchmark2','8.0.6'),('20240607102855_changesBenchmark3','8.0.6'),('20240607103047_changesUser','8.0.6'),('20240608103516_personalcalendarreservas','8.0.6'),('20240608110128_add-migration startdateworkout','8.0.6'),('20240608113158_workoutitle','8.0.6'),('20240608133600_reservas','8.0.6'),('20240608135218_personalcalendarworkout','8.0.6'),('20240608135335_reservaspersonalcalendar','8.0.6'),('20240608140456_pcworrkoutreservas','8.0.6'),('20240608144810_pcworkoutyreservas','8.0.6'),('20240608145528_pcworkoutyreservas2','8.0.6'),('20240608162329_UpdateReservaSchema','8.0.6'),('20240608164139_updatepcreserva','8.0.6'),('20240608174018_updatepcreservaentrenadores','8.0.6'),('20240608175512_updatepcreservaentrenadores2','8.0.6');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('3991bfe9-4eba-4626-91e9-fa8be7441d87','Manager','MANAGER',NULL),('4a0116ca-4229-4c37-bdcd-fac84f535bb3','Coach','COACH',NULL),('642776b8-7adf-42a1-88cd-d4f9d1d64e86','Admin','ADMIN',NULL),('fe8082ee-753c-4357-8810-8209c545272f','User','USER',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
INSERT INTO `aspnetuserclaims` VALUES (1,'8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90','http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress','juankycolrub@gmail.com');
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
INSERT INTO `aspnetuserlogins` VALUES ('Google','113076322673267195286','Google','3f6fe96d-7e76-401e-a5bf-2e6aa677e855'),('Microsoft','d7c6bd3e1e609f63','Microsoft','91f8b9e7-3634-4566-8a97-4bf0b9a5cbb7');
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('9ec5c67c-6b85-4c4d-992a-cb2f935c62d0','642776b8-7adf-42a1-88cd-d4f9d1d64e86'),('8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90','fe8082ee-753c-4357-8810-8209c545272f');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FirstName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `LastName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Height` int DEFAULT NULL,
  `Weight` int DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UserCategory` int NOT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('3f6fe96d-7e76-401e-a5bf-2e6aa677e855',NULL,NULL,'j.carlos.colmena.rubio@gmail.com',NULL,NULL,'j.carlos.colmena.rubio@gmail.com',0,'J.CARLOS.COLMENA.RUBIO@GMAIL.COM','J.CARLOS.COLMENA.RUBIO@GMAIL.COM',0,NULL,'7F4BXMHJIIZ5327IYSVQMZ22GKIXKHIU','146a1ac7-30a4-4665-97f8-0d8956381c60',NULL,0,0,NULL,1,0),('8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90','Juanqui',NULL,'juankycolrub@gmail.com',186,84,'juankycolrub@gmail.com',2,'JUANKYCOLRUB@GMAIL.COM','JUANKYCOLRUB@GMAIL.COM',1,'AQAAAAIAAYagAAAAEDXJuC7nc8D7ZSP2AuS6OpX7LlPEtxyKCMabV7s1Gv528BaNoTKBHgfJ2d+PLwyKoA==','MJ3EWKKKQOKA6DEWMFAAXBUT6AQSH6AY','011b4c4f-75da-49e5-ac8a-18d4923bed96',NULL,0,0,NULL,1,0),('91f8b9e7-3634-4566-8a97-4bf0b9a5cbb7',NULL,NULL,'juankycolrub@hotmail.com',NULL,NULL,'juankycolrub@hotmail.com',0,'JUANKYCOLRUB@HOTMAIL.COM','JUANKYCOLRUB@HOTMAIL.COM',0,NULL,'V6S72BP5WEG524MXA7MOZ4EIIV4WNR5I','82bba17d-7110-43ff-b96a-e58e21841ca8',NULL,0,0,NULL,1,0),('9ec5c67c-6b85-4c4d-992a-cb2f935c62d0','admin',NULL,'admin@admin.com',0,0,'admin@admin.com',0,'ADMIN@ADMIN.COM','ADMIN@ADMIN.COM',0,'AQAAAAIAAYagAAAAEPmBD3XOHgFm6dF+WIZmzs8GASUuROMeoAIcQwPbwFzP4gLujnr8kzdCBXd8WRRauQ==','2DTMX5RPEFAPTSHYPUOVIYKAQO7HUAQU','fc7ddfb1-0d6a-4d39-afec-58a2f46a8bcc',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `benchmarks`
--

DROP TABLE IF EXISTS `benchmarks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `benchmarks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PersonalRecords` int NOT NULL,
  `Date` datetime(6) NOT NULL,
  `ExerciseId` int NOT NULL DEFAULT '0',
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_Benchmarks_ExerciseId` (`ExerciseId`),
  KEY `IX_Benchmarks_UserId` (`UserId`),
  CONSTRAINT `FK_Benchmarks_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Benchmarks_Exercises_ExerciseId` FOREIGN KEY (`ExerciseId`) REFERENCES `exercises` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `benchmarks`
--

LOCK TABLES `benchmarks` WRITE;
/*!40000 ALTER TABLE `benchmarks` DISABLE KEYS */;
INSERT INTO `benchmarks` VALUES (1,150,'2024-06-10 00:00:00.000000',2,'8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90'),(2,145,'2024-06-10 00:00:00.000000',3,'8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90'),(4,124,'2024-06-10 00:00:00.000000',4,'8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90'),(5,0,'2024-06-09 00:00:00.000000',2,'9ec5c67c-6b85-4c4d-992a-cb2f935c62d0'),(6,0,'2024-06-09 00:00:00.000000',3,'9ec5c67c-6b85-4c4d-992a-cb2f935c62d0'),(7,0,'2024-06-09 00:00:00.000000',4,'9ec5c67c-6b85-4c4d-992a-cb2f935c62d0'),(8,0,'2024-06-12 00:00:00.000000',11,'8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90');
/*!40000 ALTER TABLE `benchmarks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `category` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Basico'),(2,'Gimnásticos'),(3,'Halterofilia'),(4,'Accesorios');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exercises`
--

DROP TABLE IF EXISTS `exercises`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `exercises` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ExerciseVideoId` int DEFAULT NULL,
  `CategoryId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Exercises_ExerciseVideoId` (`ExerciseVideoId`),
  KEY `IX_Exercises_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_Exercises_Category_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Exercises_Videos_ExerciseVideoId` FOREIGN KEY (`ExerciseVideoId`) REFERENCES `videos` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exercises`
--

LOCK TABLES `exercises` WRITE;
/*!40000 ALTER TABLE `exercises` DISABLE KEYS */;
INSERT INTO `exercises` VALUES (1,'Air Squat','Para hacer una sentadilla al aire, debes comenzar con los pies separados al ancho de los hombros y apuntando hacia adelante. Al ponerte en cuclillas, sus caderas se moverán hacia abajo y hacia atrás. La curva lumbar debe mantenerse y los talones deben permanecer planos en el piso todo el tiempo',1,1),(2,'Front Squat','La sentadilla frontal se basa exactamente en la mecánica de la sentadilla aérea. Todo lo que se agrega es una carga soportada en la posición del rack frontal, donde el peso reposa firmemente en el pecho y los hombros superiores, y los codos apuntan hacia adelante para llevar los brazos superiores paralelos al suelo. Esta posición de rack, fundamental para el levantamiento de pesas, tanto exige como mejora la flexibilidad de las muñecas y los hombros, mientras que la carga, sostenida por el torso, tanto exige como mejora la estabilidad del centro del cuerpo',2,3),(3,'Clean and Jerk','En la variación más común del arranque y envión, el atleta recibe la carga en una sentadilla frontal completa, luego utiliza la posición de estocada en el envión. Para la mayoría de los atletas, estas posiciones permiten levantar las mayores cargas. Durante el arranque, el atleta debe levantar el peso solo hasta donde sea necesario para moverse hacia el fondo de la sentadilla. Durante el envión en estocada, el torso puede permanecer vertical mientras exige menos flexibilidad en los hombros y la región torácica que un arranque o envión de potencia',3,3),(4,'Snatch','Los atletas entrenan levantamientos olímpicos para activar fibras musculares más rápidamente que cualquier otro tipo de entrenamiento. La explosividad que se obtiene de este entrenamiento es esencial para todos los deportes. Practicar el arranque enseña a aplicar la fuerza en cada uno de los grupos musculares en el orden correcto, es decir, desde el centro del cuerpo hacia sus extremidades (de adentro hacia afuera). Aprender esta valiosa técnica beneficia a todos los atletas que necesitan ejercer fuerza sobre otra persona u objeto, lo cual es una necesidad común en casi todos los deportes',4,3),(5,'Db Overhead Squat','La sentadilla con peso por encima de la cabeza es insuperable en el desarrollo del control de la línea media, la estabilidad y el equilibrio. Entrena para la transferencia eficiente de energía de las partes grandes a las pequeñas del cuerpo, exige y desarrolla la flexibilidad funcional, y de manera similar desarrolla la sentadilla amplificando y castigando cruelmente los errores en la postura, el movimiento y la estabilidad de la sentadilla. Equilibrar una sola mancuerna por encima de la cabeza exige aún más demanda en cuanto a flexibilidad, control postural y precisión posicional que su contraparte con barra',5,4),(6,'Overhead Squat','La sentadilla con peso por encima de la cabeza es el ejercicio definitivo para el core y no tiene igual en el desarrollo de un movimiento atlético efectivo. Esta joya funcional entrena para la transferencia eficiente de energía de las partes grandes a las pequeñas del cuerpo y mejora la flexibilidad funcional. De manera similar, desarrolla la sentadilla amplificando y castigando cruelmente los defectos en la postura, el movimiento y la estabilidad. La sentadilla con peso por encima de la cabeza es al control de la línea media, la estabilidad y el equilibrio lo que el clean y el snatch son a la potencia: insuperable',6,4),(7,'Pull-Over','El pull-over es un movimiento básico de gimnasia que lleva al atleta rápidamente y de manera eficiente a la parte superior de la barra. Más allá de la practicidad de colocar al atleta en la parte superior de la barra, el pull-over también desarrolla la coordinación y la conciencia posicional',7,2),(8,'Toes to Bar','El ejercicio “toes to bar” es un movimiento avanzado de entrenamiento funcional que consiste en colgarse de una barra fija y llevar los dedos de los pies hasta tocar la barra, manteniendo las piernas rectas. Este ejercicio es excelente para fortalecer los músculos del core, incluyendo los abdominales y los flexores de la cadera. Además de mejorar la fuerza del agarre, el “toes to bar” también desafía la estabilidad del cuerpo y la coordinación, ya que requiere un control preciso del movimiento y la posición del cuerpo en el aire',8,2),(9,'Bar Muscle Up','El muscle-up es un movimiento que comienza desde la suspensión, pasa por partes de una dominada y un fondo, y termina en una posición soportada con los brazos extendidos',9,2),(10,'Burpee','Simple en su ejecución, pasando de estar tumbado a ponerse de pie verticalmente y saltar, el burpee mueve todo el cuerpo a través de un amplio rango de movimiento, proporcionando una potente respuesta metabólica',10,1),(11,'Back Squat','La sentadilla trasera requiere que las estructuras del cuerpo inferior y el core trabajen de manera sinérgica. Un rendimiento óptimo requiere un rango de movimiento adecuado en los tobillos, caderas y rodillas; una fuerza superior del cuerpo inferior; y una tremenda cantidad de estabilidad del core',11,3),(12,'Push Up','En tiempos anteriores, las flexiones de brazos eran consideradas en gran medida como una medida de la fuerza y la condición física de una persona. En tiempos más modernos, gran parte de esta reputación se ha trasladado al press de banca, pero el abandono de las flexiones de brazos supone perder la gran oportunidad de dominar un movimiento fundamental para una de las progresiones más desarrolladoras en todo el ámbito del fitness',12,1),(13,'Wall Walk','El wall walk es una excelente herramienta para introducir los conceptos básicos de la inversión. Tanto la coordinación como la fuerza del tren superior se ven desafiadas mientras el atleta experimenta y se esfuerza por mantener los elementos fundamentales de la posición de parada de manos. A pesar de los desafíos inherentes a estar invertido, el atleta permanece apoyado por tres puntos de contacto en el suelo, la pared o una combinación de ambos durante todo el movimiento. El wall walk puede ser el primer paso en un viaje hacia el dominio de la parada de manos o una herramienta para el desarrollo de habilidades en atletas de cualquier nivel',13,4);
/*!40000 ALTER TABLE `exercises` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personalcalendarreservas`
--

DROP TABLE IF EXISTS `personalcalendarreservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `personalcalendarreservas` (
  `PersonalCalendarId` int NOT NULL,
  `ReservaId` int NOT NULL,
  `AddedDate` datetime(6) NOT NULL,
  `ReservationDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  PRIMARY KEY (`PersonalCalendarId`,`ReservaId`),
  KEY `IX_PersonalCalendarReservas_ReservaId` (`ReservaId`),
  CONSTRAINT `FK_PersonalCalendarReservas_PersonalCalendars_PersonalCalendarId` FOREIGN KEY (`PersonalCalendarId`) REFERENCES `personalcalendars` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_PersonalCalendarReservas_Reservas_ReservaId` FOREIGN KEY (`ReservaId`) REFERENCES `reservas` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personalcalendarreservas`
--

LOCK TABLES `personalcalendarreservas` WRITE;
/*!40000 ALTER TABLE `personalcalendarreservas` DISABLE KEYS */;
INSERT INTO `personalcalendarreservas` VALUES (1,32,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000'),(1,33,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `personalcalendarreservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personalcalendars`
--

DROP TABLE IF EXISTS `personalcalendars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `personalcalendars` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personalcalendars`
--

LOCK TABLES `personalcalendars` WRITE;
/*!40000 ALTER TABLE `personalcalendars` DISABLE KEYS */;
INSERT INTO `personalcalendars` VALUES (1,'8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90'),(2,'9ec5c67c-6b85-4c4d-992a-cb2f935c62d0'),(3,'3f6fe96d-7e76-401e-a5bf-2e6aa677e855'),(4,'91f8b9e7-3634-4566-8a97-4bf0b9a5cbb7');
/*!40000 ALTER TABLE `personalcalendars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personalcalendarworkouts`
--

DROP TABLE IF EXISTS `personalcalendarworkouts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `personalcalendarworkouts` (
  `PersonalCalendarId` int NOT NULL,
  `WorkoutId` int NOT NULL,
  `AddedDate` datetime(6) NOT NULL,
  PRIMARY KEY (`PersonalCalendarId`,`WorkoutId`),
  KEY `IX_PersonalCalendarWorkouts_WorkoutId` (`WorkoutId`),
  CONSTRAINT `FK_PersonalCalendarWorkouts_PersonalCalendars_PersonalCalendarId` FOREIGN KEY (`PersonalCalendarId`) REFERENCES `personalcalendars` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_PersonalCalendarWorkouts_Workouts_WorkoutId` FOREIGN KEY (`WorkoutId`) REFERENCES `workouts` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personalcalendarworkouts`
--

LOCK TABLES `personalcalendarworkouts` WRITE;
/*!40000 ALTER TABLE `personalcalendarworkouts` DISABLE KEYS */;
INSERT INTO `personalcalendarworkouts` VALUES (1,1,'2024-06-12 15:59:16.770081'),(2,1,'2024-06-08 17:58:12.136690');
/*!40000 ALTER TABLE `personalcalendarworkouts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas`
--

DROP TABLE IF EXISTS `reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `reservas` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime(6) NOT NULL,
  `Entrenador` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Titulo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `StartDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `EndDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `HoraFin` time(6) NOT NULL DEFAULT '00:00:00.000000',
  `HoraInicio` time(6) NOT NULL DEFAULT '00:00:00.000000',
  PRIMARY KEY (`Id`),
  KEY `IX_Reservas_UserId` (`UserId`),
  CONSTRAINT `FK_Reservas_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas`
--

LOCK TABLES `reservas` WRITE;
/*!40000 ALTER TABLE `reservas` DISABLE KEYS */;
INSERT INTO `reservas` VALUES (32,'2024-06-10 20:00:00.000000','Abel','8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90','Reserva de entrenamiento','2024-06-10 20:00:00.000000','2024-06-10 21:00:00.000000','21:00:00.000000','20:00:00.000000'),(33,'2024-06-12 20:00:00.000000','Abel','8d8a52ac-8dc1-4e5a-b610-2a6f3deb7d90','Reserva de entrenamiento','2024-06-12 20:00:00.000000','2024-06-12 21:00:00.000000','21:00:00.000000','20:00:00.000000');
/*!40000 ALTER TABLE `reservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videos`
--

DROP TABLE IF EXISTS `videos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `videos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Url` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Thumbnail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videos`
--

LOCK TABLES `videos` WRITE;
/*!40000 ALTER TABLE `videos` DISABLE KEYS */;
INSERT INTO `videos` VALUES (1,'airsquat','https://www.youtube.com/embed/C_VtOYc6j5c?si=bhA2wWTNVX4rztfg','/img/airsquat-thumbnail.jpg'),(2,'frontsquat','https://www.youtube.com/embed/uYumuL_G_V0?si=B7LaXzLgnb8zM4Pb','/img/airsquat-thumbnail.jpg'),(3,'cleanandjerk','https://www.youtube.com/embed/PjY1rH4_MOA?si=cEMAM9izT0qkBOcZ','/img/airsquat-thumbnail.jpg'),(4,'snatch','https://www.youtube.com/embed/GhxhiehJcQY?si=MA32vUMPuD2dX0MN','/img/airsquat-thumbnail.jpg'),(5,'dbohsquat','https://www.youtube.com/embed/azumEfnk-GI?si=Mt3ru64DpXKx3eto','/img/airsquat-thumbnail.jpg'),(6,'ohsquat','https://www.youtube.com/embed/pn8mqlG0nkE?si=7ZLCMkRTDVGyZ52e','/img/airsquat-thumbnail.jpg'),(7,'pullover','https://www.youtube.com/embed/faJDYEZmueM?si=oLoXWJDZ-AVqBEcM','/img/airsquat-thumbnail.jpg'),(8,'toestobar','https://www.youtube.com/embed/6dHvTlsMvNY?si=CCkiDcz3AhFCJaqA','/img/airsquat-thumbnail.jpg'),(9,'barmuscleup','https://www.youtube.com/embed/OCg3UXgzftc?si=Fo9i53QzWLM2nlnB','/img/airsquat-thumbnail.jpg'),(10,'burpee','https://www.youtube.com/embed/auBLPXO8Fww?si=LySVPyQJ1K9zLuBu','/img/airsquat-thumbnail.jpg'),(11,'backsquat','https://www.youtube.com/embed/QmZAiBqPvZw?si=USzMA5-WaLn91epn','/img/airsquat-thumbnail.jpg'),(12,'pushup','https://www.youtube.com/embed/0pkjOk0EiAk?si=qOxUrBYZS2nbpk7O','/img/airsquat-thumbnail.jpg'),(13,'wallwalk','https://www.youtube.com/embed/NK_OcHEm8yM?si=Zh6RROcEHLRoSFm7','/img/airsquat-thumbnail.jpg');
/*!40000 ALTER TABLE `videos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workouts`
--

DROP TABLE IF EXISTS `workouts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE IF NOT EXISTS `workouts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Description` varchar(3000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Duration` int NOT NULL,
  `ExerciseId` int NOT NULL DEFAULT '0',
  `StartDate` datetime(6) DEFAULT NULL,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Workouts_ExerciseId` (`ExerciseId`),
  CONSTRAINT `FK_Workouts_Exercises_ExerciseId` FOREIGN KEY (`ExerciseId`) REFERENCES `exercises` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workouts`
--

LOCK TABLES `workouts` WRITE;
/*!40000 ALTER TABLE `workouts` DISABLE KEYS */;
INSERT INTO `workouts` VALUES (1,'<p>Tantas rondas y repeticiones como sea posible en 14 minutos de: 7 cleans de potencia desde hang 7 sentadillas frontales</p>\r\n<p>♀ 66 kg ♂ 93 kg</p>\r\n<p>Adaptaci&oacute;n: Mover esta barra con peso moderadamente pesado va a generar m&aacute;s metabolismo del que deseas. Usa un peso que te permita completar los cleans de potencia desde hang en 1-3 series y las sentadillas frontales en 1-2 series durante todo el entrenamiento. Se esperan descansos, sin embargo, el objetivo es seguir avanzando y mantener al menos 1 ronda cada 2 minutos.</p>\r\n<p>Opci&oacute;n intermedia: Tantas rondas y repeticiones como sea posible en 14 minutos de: 7 cleans de potencia desde hang 7 sentadillas frontales</p>\r\n<p>♀ 48 kg ♂ 70 kg</p>\r\n<p>Opci&oacute;n para principiantes: Tantas rondas y repeticiones como sea posible en 14 minutos de: 7 cleans de potencia desde hang 7 sentadillas frontales</p>\r\n<p>♀ 25 kg ♂ 34 kg</p>\r\n<p>&nbsp;</p>\r\n<p>&nbsp;</p>\r\n<div id=\"simple-translate\" class=\"simple-translate-system-theme\">\r\n<div>\r\n<div class=\"simple-translate-button isShow\" style=\"background-image: url(\'moz-extension://1b0252d8-1362-412f-a396-861c6f86090f/icons/512.png\'); height: 22px; width: 22px; top: 71px; left: 2px;\">&nbsp;</div>\r\n<div class=\"simple-translate-panel \" style=\"width: 300px; height: 200px; top: 0px; left: 0px; font-size: 13px;\">\r\n<div class=\"simple-translate-result-wrapper\" style=\"overflow: hidden;\">\r\n<div class=\"simple-translate-move\" draggable=\"true\">&nbsp;</div>\r\n<div class=\"simple-translate-result-contents\">\r\n<p class=\"simple-translate-result\" dir=\"auto\">&nbsp;</p>\r\n<p class=\"simple-translate-candidate\" dir=\"auto\">&nbsp;</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n</div>',60,2,'2024-06-12 15:59:16.770075','WOD'),(2,'<p><span style=\"font-size: 14pt;\">Cada minuto durante 5 minutos completa:</span></p>\r\n<p><span style=\"font-size: 14pt;\">5 clean and jerks (touch and go), descansa 1 minuto y aumenta la carga cada minuto seg&uacute;n tu capacidad.</span></p>\r\n<p><span style=\"font-size: 14pt;\">Luego, cada minuto durante 5 minutos completa:</span></p>\r\n<p><span style=\"font-size: 14pt;\">3 clean and jerks (touch and go), descansa 1 minuto y aumenta la carga cada minuto seg&uacute;n tu capacidad.</span></p>\r\n<p><span style=\"font-size: 14pt;\">Finalmente, cada minuto durante 5 minutos completa:</span></p>\r\n<p><span style=\"font-size: 14pt;\">1 clean and jerk, aumentando la carga cada minuto seg&uacute;n tu capacidad.</span></p>\r\n<p><span style=\"font-size: 14pt;\">El esfuerzo de hoy est&aacute; destinado a desafiar tu ciclo con la barra con una carga m&aacute;s pesada. Aumenta la carga en tantos conjuntos como sea posible, construyendo hasta tus conjuntos m&aacute;s pesados de 5, 3 y 1. Los conjuntos de 5 y 3 son para ser completados sin interrupci&oacute;n (touch and go). Estar&aacute;s limitado en la carga basado en tu competencia t&eacute;cnica con el clean and jerk. Comienza con una carga ligera, perfecciona la t&eacute;cnica y aumenta la carga a medida que desarrollas patrones de movimiento de calidad. Utiliza el tiempo restante de cada minuto para descansar y/o a&ntilde;adir carga a la barra</span></p>',15,3,'2024-06-10 19:22:08.826751','WOD'),(3,'<p>Por tiempo:</p>\r\n<p>75 power snatches</p>\r\n<p>♀ 25 kg ♂ 34 kg</p>\r\n<p>L&iacute;mite de tiempo: 10 minutos</p>\r\n<p>Escalado: Elige un peso que te permita realizar al menos 10 repeticiones seguidas cada vez que levantes la barra.</p>\r\n<p>El peso debe sentirse ligero (muy ligero para algunos). Reduce el peso para que puedas realizar m&uacute;ltiples repeticiones</p>\r\n<p>seguidas y completar el entrenamiento en menos de 8 minutos.</p>\r\n<p>&nbsp;Los atletas menos familiarizados con la halterofilia ol&iacute;mpica deben tomarse un tiempo para practicar la mec&aacute;nica del</p>\r\n<p>power snatch y reducir el peso y las repeticiones.</p>\r\n<p>Opci&oacute;n intermedia:</p>\r\n<p>Por tiempo:</p>\r\n<p>50 power snatches</p>\r\n<p>♀ 20 kg ♂ 25 kg</p>\r\n<p>Opci&oacute;n para principiantes:</p>\r\n<p>Por tiempo:</p>\r\n<p>40 power snatches</p>\r\n<p>♀ 16 kg ♂ 20 kg</p>',20,4,NULL,'WOD'),(4,'<p>10 rondas por tiempo de:</p>\r\n<p>4 deadlifts 3 hang power snatches 2 overhead squats</p>\r\n<p>♀ 48 kg (aproximadamente) ♂ 70 kg (aproximadamente)</p>\r\n<p>Escala: Este es un entrenamiento de sprint que debe ser un desaf&iacute;o equilibrado de fatiga metab&oacute;lica y muscular.</p>\r\n<p>El objetivo es mantenerse en la barra y pasar cada ronda en la menor cantidad de series posible.</p>\r\n<p>Los deadlifts deben sentirse como el movimiento m&aacute;s f&aacute;cil de los tres. Tu capacidad con el hang power snatch y</p>\r\n<p>el overhead squat determinar&aacute; tu carga para el entrenamiento.</p>\r\n<p>Elige un peso que te permita completar cada ronda en menos de 1 minuto y todo el entrenamiento en menos de 10 minutos</p>\r\n<p>Opci&oacute;n intermedia:</p>\r\n<p>10 rondas por tiempo de:</p>\r\n<p>4 deadlifts 3 hang power snatches 2 overhead squats</p>\r\n<p>♀ 34 kg (aproximadamente) ♂ 52 kg (aproximadamente)</p>\r\n<p>Opci&oacute;n para principiantes:</p>\r\n<p>10 rondas por tiempo de:</p>\r\n<p>4 deadlifts 3 hang power snatches 2 overhead squats<br><br>♀ 16 kg (aproximadamente) ♂ 20 kg (aproximadamente)&nbsp;</p>',10,6,NULL,'WOD');
/*!40000 ALTER TABLE `workouts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-13  9:44:17
