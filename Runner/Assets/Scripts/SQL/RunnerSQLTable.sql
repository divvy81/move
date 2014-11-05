CREATE DATABASE IF NOT EXISTS Runner;

UsE Runner;

CREATE TABLE IF NOT EXISTS users (
  Username varchar(45) NOT NULL,
  Password varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `score` (
  `Username` varchar(45) NOT NULL,
  `TimeStamp` DATETIME DEFAULT CURRENT_TIMESTAMP,
   leftmove  INT(6),
   rightmove INT(6),
   up INT (6),
   down INT(6),
   Average FLOAT(6),
   Timeplayed FLOAT(6),
   coinscollected INT(6)	
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


ALTER TABLE `users`
 ADD UNIQUE KEY `Username` (`Username`);
