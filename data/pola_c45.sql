-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 27, 2016 at 09:50 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 7.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pola_c45`
--

-- --------------------------------------------------------

--
-- Table structure for table `nasabah`
--

CREATE TABLE `nasabah` (
  `id` int(11) NOT NULL,
  `nama` varchar(255) DEFAULT NULL,
  `jenis_kelamin` varchar(20) NOT NULL,
  `umur` smallint(6) NOT NULL,
  `pinjaman` bigint(32) NOT NULL,
  `waktu` smallint(6) NOT NULL,
  `anggunan` varchar(25) NOT NULL,
  `angsuran` bigint(32) NOT NULL,
  `target` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nasabah`
--

INSERT INTO `nasabah` (`id`, `nama`, `jenis_kelamin`, `umur`, `pinjaman`, `waktu`, `anggunan`, `angsuran`, `target`) VALUES
(1, 'A', 'Laki-laki', 45, 50000000, 24, 'Perorangan', 2083333, 'Macet'),
(2, 'B', 'Perempuan', 29, 10000000, 24, 'Perorangan', 416666, 'Lancar'),
(3, 'C', 'Laki-laki', 33, 150000000, 36, 'Perusahaan', 4166666, 'Lancar');

-- --------------------------------------------------------

--
-- Table structure for table `nasabah_trans`
--

CREATE TABLE `nasabah_trans` (
  `nasabah_id` int(11) DEFAULT NULL,
  `jenis_kelamin` varchar(20) DEFAULT NULL,
  `umur` varchar(100) DEFAULT NULL,
  `pinjaman` varchar(100) DEFAULT NULL,
  `waktu` varchar(100) DEFAULT NULL,
  `anggunan` varchar(100) DEFAULT NULL,
  `angsuran` varchar(100) DEFAULT NULL,
  `target` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nasabah_trans`
--

INSERT INTO `nasabah_trans` (`nasabah_id`, `jenis_kelamin`, `umur`, `pinjaman`, `waktu`, `anggunan`, `angsuran`, `target`) VALUES
(1, 'Laki-laki', 'Paruh Baya', 'Kecil', 'Lambat', 'Perorangan', 'Besar', 'Macet'),
(2, 'Perempuan', 'Muda', 'Sedang', 'Lambat', 'Perorangan', 'Sedang', 'Lancar'),
(3, 'Laki-laki', 'Muda', 'Besar', 'Lambat', 'Perusahaan', 'Besar', 'Lancar');

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE `settings` (
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `nasabah`
--
ALTER TABLE `nasabah`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nasabah_trans`
--
ALTER TABLE `nasabah_trans`
  ADD KEY `nasaabah_nasabah_trans` (`nasabah_id`);

--
-- Indexes for table `settings`
--
ALTER TABLE `settings`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `nasabah`
--
ALTER TABLE `nasabah`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `settings`
--
ALTER TABLE `settings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
