/*
Navicat MySQL Data Transfer

Source Server         : hr
Source Server Version : 50018
Source Host           : localhost:3306
Source Database       : baza-grupni

Target Server Type    : MYSQL
Target Server Version : 50018
File Encoding         : 65001

Date: 2022-04-05 22:28:25
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `artikal`
-- ----------------------------
DROP TABLE IF EXISTS `artikal`;
CREATE TABLE `artikal` (
`artikal_id`  int(11) NOT NULL AUTO_INCREMENT ,
`naziv_artikla`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`vrsta_artikla`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`cijena`  double NULL DEFAULT NULL ,
PRIMARY KEY (`artikal_id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=latin1 COLLATE=latin1_swedish_ci
/*!50003 AUTO_INCREMENT=13 */

;

-- ----------------------------
-- Records of artikal
-- ----------------------------
BEGIN;
INSERT INTO `artikal` VALUES ('1', 'Smart Watch', 'Sat', '150'), ('2', 'Punjac', 'Punjac', '15'), ('3', 'Samsung S8', 'Telefon', '250'), ('4', 'Samsung S9', 'Telefon', '350'), ('5', 'Samsung S7', 'Telefon', '200'), ('6', 'Samsung S10', 'Telefon', '550'), ('7', 'Samsung S11', 'Telefon', '750'), ('8', 'Samsung S12', 'Telefon', '1000'), ('9', 'Samsung S13', 'Telefon', '1500'), ('10', 'Iphone 4', 'Telefon', '195'), ('11', 'Iphone 5', 'Telefon', '245'), ('12', 'Iphone 6', 'Telefon', '300');
COMMIT;

-- ----------------------------
-- Table structure for `kupac`
-- ----------------------------
DROP TABLE IF EXISTS `kupac`;
CREATE TABLE `kupac` (
`kupac_id`  int(11) NOT NULL AUTO_INCREMENT ,
`ime`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`prezime`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`grad`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`adresa`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`telefon`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`user`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
`pass`  varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL ,
PRIMARY KEY (`kupac_id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=latin1 COLLATE=latin1_swedish_ci
/*!50003 AUTO_INCREMENT=5 */

;

-- ----------------------------
-- Records of kupac
-- ----------------------------
BEGIN;
INSERT INTO `kupac` VALUES ('1', 'Tarik', 'Kukuljac', 'Sarajevo', 'Branislava Nusica 48', '603114797', 'tarik1', 'tarik123'), ('2', 'Nedim', 'Dugalic', 'Sarajevo', 'Dobrinja 5', '61112313', 'nedim2', 'nedim234'), ('3', 'Edah', 'Cajic', 'Sarajevo', 'Hadzici 5', '62321123', 'edah3', 'edah345'), ('4', 'Mirza', 'Kulovic', 'Sarajevo', 'Grbavica 11', '60232323', 'mirza4', 'mirza456');
COMMIT;

-- ----------------------------
-- Table structure for `narudzbenica`
-- ----------------------------
DROP TABLE IF EXISTS `narudzbenica`;
CREATE TABLE `narudzbenica` (
`narudzbenica_id`  int(11) NOT NULL AUTO_INCREMENT ,
`kupac_id`  int(11) NULL DEFAULT NULL ,
`datum_narudzbe`  date NULL DEFAULT NULL ,
PRIMARY KEY (`narudzbenica_id`),
FOREIGN KEY (`kupac_id`) REFERENCES `kupac` (`kupac_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=latin1 COLLATE=latin1_swedish_ci
COMMENT='InnoDB free: 3072 kB; (`kupac_id`) REFER `baza-grupni/kupac`(`kupac_id`)'
/*!50003 AUTO_INCREMENT=4 */

;

-- ----------------------------
-- Records of narudzbenica
-- ----------------------------
BEGIN;
INSERT INTO `narudzbenica` VALUES ('1', '1', '2022-03-05'), ('2', '2', '2021-02-04');
COMMIT;

-- ----------------------------
-- Table structure for `skladiste`
-- ----------------------------
DROP TABLE IF EXISTS `skladiste`;
CREATE TABLE `skladiste` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`artikal_id`  int(11) NULL DEFAULT NULL ,
`kolicina_stanje`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`id`),
FOREIGN KEY (`artikal_id`) REFERENCES `artikal` (`artikal_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=latin1 COLLATE=latin1_swedish_ci
COMMENT='InnoDB free: 3072 kB; (`artikal_id`) REFER `baza-grupni/artikal`(`artikal_id`)'
/*!50003 AUTO_INCREMENT=13 */

;

-- ----------------------------
-- Records of skladiste
-- ----------------------------
BEGIN;
INSERT INTO `skladiste` VALUES ('1', '1', '10'), ('2', '2', '25'), ('3', '3', '10'), ('4', '4', '5'), ('5', '5', '15'), ('6', '6', '13'), ('7', '7', '21'), ('8', '8', '8'), ('9', '9', '4'), ('10', '10', '10'), ('11', '11', '13'), ('12', '12', '15');
COMMIT;

-- ----------------------------
-- Table structure for `stavka_narudzbenice`
-- ----------------------------
DROP TABLE IF EXISTS `stavka_narudzbenice`;
CREATE TABLE `stavka_narudzbenice` (
`stavka_id`  int(11) NOT NULL AUTO_INCREMENT ,
`narudzbenica_id`  int(11) NULL DEFAULT NULL ,
`artikal_id`  int(11) NULL DEFAULT NULL ,
`kolicina`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`stavka_id`),
FOREIGN KEY (`artikal_id`) REFERENCES `artikal` (`artikal_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`narudzbenica_id`) REFERENCES `narudzbenica` (`narudzbenica_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=latin1 COLLATE=latin1_swedish_ci
COMMENT='InnoDB free: 3072 kB; (`artikal_id`) REFER `baza-grupni/artikal`(`artikal_id`); '
/*!50003 AUTO_INCREMENT=4 */

;

-- ----------------------------
-- Records of stavka_narudzbenice
-- ----------------------------
BEGIN;
INSERT INTO `stavka_narudzbenice` VALUES ('1', '1', '1', '5'), ('2', '2', '2', '10');
COMMIT;

-- ----------------------------
-- Auto increment value for `artikal`
-- ----------------------------
ALTER TABLE `artikal` AUTO_INCREMENT=13;

-- ----------------------------
-- Auto increment value for `kupac`
-- ----------------------------
ALTER TABLE `kupac` AUTO_INCREMENT=5;

-- ----------------------------
-- Indexes structure for table `narudzbenica`
-- ----------------------------
CREATE INDEX `kupac_id` USING BTREE ON `narudzbenica`(`kupac_id`);

-- ----------------------------
-- Auto increment value for `narudzbenica`
-- ----------------------------
ALTER TABLE `narudzbenica` AUTO_INCREMENT=4;

-- ----------------------------
-- Indexes structure for table `skladiste`
-- ----------------------------
CREATE INDEX `artikal_id` USING BTREE ON `skladiste`(`artikal_id`);

-- ----------------------------
-- Auto increment value for `skladiste`
-- ----------------------------
ALTER TABLE `skladiste` AUTO_INCREMENT=13;

-- ----------------------------
-- Indexes structure for table `stavka_narudzbenice`
-- ----------------------------
CREATE INDEX `narudzbenica_id` USING BTREE ON `stavka_narudzbenice`(`narudzbenica_id`);
CREATE INDEX `artikal_id` USING BTREE ON `stavka_narudzbenice`(`artikal_id`);

-- ----------------------------
-- Auto increment value for `stavka_narudzbenice`
-- ----------------------------
ALTER TABLE `stavka_narudzbenice` AUTO_INCREMENT=4;
