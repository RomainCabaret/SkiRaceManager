-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 10, 2024 at 08:48 PM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `test`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `id` int NOT NULL,
  `login` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `rank` varchar(20) NOT NULL,
  `profilePicture` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`id`, `login`, `password`, `rank`, `profilePicture`) VALUES
(1, 'aa', 'aa', 'admin', '6857659-light-brown-wallpaper.jpg'),
(5, 'bla', 'bla', 'gestionnaire', 'github-removebg-preview.png'),
(7, 'XD', 'XD', 'admin', 'bg.png'),
(9, 'ouba', 'ouba', 'admin', 'default.png'),
(10, 'mama', 'mama', 'user', 'default.png');

-- --------------------------------------------------------

--
-- Table structure for table `color`
--

CREATE TABLE `color` (
  `color` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `color`
--

INSERT INTO `color` (`color`) VALUES
('black'),
('blue'),
('orange'),
('red');

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

CREATE TABLE `manager` (
  `slopeID` int NOT NULL,
  `accountID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`slopeID`, `accountID`) VALUES
(1, 1),
(1, 5),
(1, 7),
(1, 9);

-- --------------------------------------------------------

--
-- Table structure for table `participations`
--

CREATE TABLE `participations` (
  `id` int NOT NULL,
  `slopeid` int NOT NULL,
  `accountid` int NOT NULL,
  `time` time(1) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `participations`
--

INSERT INTO `participations` (`id`, `slopeid`, `accountid`, `time`, `date`) VALUES
(1, 1, 1, '05:28:16.2', '2024-02-18'),
(2, 1, 1, '05:28:16.0', '2024-02-18'),
(3, 1, 5, '05:28:16.2', '2024-02-18'),
(4, 1, 1, '01:28:16.0', '2024-02-18'),
(5, 1, 5, '00:28:16.0', '2024-02-18'),
(6, 3, 1, '00:57:56.2', '2024-02-18'),
(7, 1, 1, '00:01:16.0', '2024-02-18'),
(8, 1, 1, '00:00:16.0', '2024-02-18'),
(9, 1, 1, '00:00:05.0', '2024-02-18'),
(10, 1, 1, '00:00:04.0', '2024-02-18'),
(11, 1, 1, '18:04:03.1', '2024-02-19'),
(13, 1, 10, '00:00:02.0', '2024-02-20');

-- --------------------------------------------------------

--
-- Table structure for table `rank`
--

CREATE TABLE `rank` (
  `rank` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `rank`
--

INSERT INTO `rank` (`rank`) VALUES
('admin'),
('gestionnaire'),
('user');

-- --------------------------------------------------------

--
-- Table structure for table `request`
--

CREATE TABLE `request` (
  `id` int NOT NULL,
  `dateDemande` date NOT NULL,
  `isTraite` tinyint NOT NULL DEFAULT '1',
  `accountID` int NOT NULL,
  `slopeID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `request`
--

INSERT INTO `request` (`id`, `dateDemande`, `isTraite`, `accountID`, `slopeID`) VALUES
(1, '2024-03-09', 1, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `slope`
--

CREATE TABLE `slope` (
  `id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `color` varchar(20) NOT NULL,
  `image` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `slope`
--

INSERT INTO `slope` (`id`, `name`, `color`, `image`) VALUES
(1, 'bb', 'blue', 'aaa.png'),
(2, 'aa', 'red', 'calendrier-de-l-ann-e-de-terminale-2023-2024-157746.jpg'),
(3, 'La valle des morts vivant', 'black', 'image 9.png'),
(4, 'babayaga', 'black', '2023-01-06 22_17_20-Window.png');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rank` (`rank`);

--
-- Indexes for table `color`
--
ALTER TABLE `color`
  ADD PRIMARY KEY (`color`);

--
-- Indexes for table `manager`
--
ALTER TABLE `manager`
  ADD PRIMARY KEY (`slopeID`,`accountID`),
  ADD KEY `slopeID` (`slopeID`,`accountID`),
  ADD KEY `accountID` (`accountID`);

--
-- Indexes for table `participations`
--
ALTER TABLE `participations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `slopeid` (`slopeid`),
  ADD KEY `accountid` (`accountid`);

--
-- Indexes for table `rank`
--
ALTER TABLE `rank`
  ADD PRIMARY KEY (`rank`);

--
-- Indexes for table `request`
--
ALTER TABLE `request`
  ADD PRIMARY KEY (`id`),
  ADD KEY `accountID` (`accountID`),
  ADD KEY `slopeID` (`slopeID`);

--
-- Indexes for table `slope`
--
ALTER TABLE `slope`
  ADD PRIMARY KEY (`id`),
  ADD KEY `color` (`color`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account`
--
ALTER TABLE `account`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `participations`
--
ALTER TABLE `participations`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `request`
--
ALTER TABLE `request`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `slope`
--
ALTER TABLE `slope`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `account_ibfk_1` FOREIGN KEY (`rank`) REFERENCES `rank` (`rank`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `manager`
--
ALTER TABLE `manager`
  ADD CONSTRAINT `manager_ibfk_1` FOREIGN KEY (`slopeID`) REFERENCES `slope` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `manager_ibfk_2` FOREIGN KEY (`accountID`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `participations`
--
ALTER TABLE `participations`
  ADD CONSTRAINT `participations_ibfk_1` FOREIGN KEY (`accountid`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `participations_ibfk_2` FOREIGN KEY (`slopeid`) REFERENCES `slope` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `request`
--
ALTER TABLE `request`
  ADD CONSTRAINT `request_ibfk_1` FOREIGN KEY (`slopeID`) REFERENCES `slope` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `request_ibfk_2` FOREIGN KEY (`accountID`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `slope`
--
ALTER TABLE `slope`
  ADD CONSTRAINT `slope_ibfk_1` FOREIGN KEY (`color`) REFERENCES `color` (`color`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
