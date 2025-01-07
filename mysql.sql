DROP DATABASE IF EXISTS proyekpv;
CREATE DATABASE proyekpv;
USE proyekpv;
SET FOREIGN_KEY_CHECKS=0;

-- table cabang
CREATE TABLE cabang(
    id_cabang INT(12)PRIMARY KEY AUTO_INCREMENT,
    nama_daerah VARCHAR(255)NOT NULL,
    jalan_cabang VARCHAR(255)NOT NULL,
    no_telp VARCHAR(30)NOT NULL
);

INSERT INTO cabang(nama_daerah, jalan_cabang, no_telp) VALUES
-- Jakarta Pusat (35 cabang)
('Jakarta Pusat', 'Jl. MH Thamrin No. 28-30, Plaza Indonesia', '(021) 31921524'),
('Jakarta Pusat', 'Jl. Hayam Wuruk No. 108', '(021) 6492949'),
('Jakarta Pusat', 'Jl. Gajah Mada No. 19', '(021) 6334567'),
('Jakarta Pusat', 'Jl. Juanda No. 15, Gedung Kesenian', '(021) 3505678'),
('Jakarta Pusat', 'Jl. Kramat Raya No. 23', '(021) 3154289'),
('Jakarta Pusat', 'Jl. Senen Raya No. 135', '(021) 4208765'),
('Jakarta Pusat', 'Jl. Cideng Barat No. 88', '(021) 6324567'),
('Jakarta Pusat', 'Jl. Tanah Abang II No. 45', '(021) 3456789'),
('Jakarta Pusat', 'Jl. Kebon Sirih No. 17', '(021) 3192345'),
('Jakarta Pusat', 'Jl. Medan Merdeka Selatan No. 9', '(021) 3841234'),
('Jakarta Pusat', 'Jl. Pasar Baru No. 76', '(021) 3852277'),
('Jakarta Pusat', 'Jl. Batu Tulis Raya No. 55', '(021) 3442588'),
('Jakarta Pusat', 'Jl. Pintu Air Raya No. 22', '(021) 3458899'),
('Jakarta Pusat', 'Jl. Wahid Hasyim No. 96', '(021) 31526789'),
('Jakarta Pusat', 'Jl. KH. Mas Mansyur No. 121', '(021) 3927744'),
('Jakarta Pusat', 'Jl. Cikini Raya No. 84', '(021) 31945566'),
('Jakarta Pusat', 'Jl. Percetakan Negara No. 44', '(021) 4247788'),
('Jakarta Pusat', 'Jl. Bendungan Hilir No. 66', '(021) 5704455'),
('Jakarta Pusat', 'Jl. Kwitang Raya No. 33', '(021) 3148899'),
('Jakarta Pusat', 'Jl. Pejompongan Raya No. 45', '(021) 5736677'),
('Jakarta Pusat', 'Jl. Bungur Raya No. 27', '(021) 4248899'),
('Jakarta Pusat', 'Jl. Salemba Raya No. 59', '(021) 3928833'),
('Jakarta Pusat', 'Jl. Gunung Sahari Raya No. 82', '(021) 4205566'),
('Jakarta Pusat', 'Jl. Tongkol No. 40', '(021) 6614455'),
('Jakarta Pusat', 'Jl. Petojo Selatan No. 25', '(021) 6335577'),
('Jakarta Pusat', 'Jl. Suryopranoto No. 68', '(021) 3853366'),
('Jakarta Pusat', 'Jl. Menteng Raya No. 37', '(021) 3152233'),
('Jakarta Pusat', 'Jl. Tambak No. 15', '(021) 6616688'),
('Jakarta Pusat', 'Jl. Veteran No. 11', '(021) 3840011'),
('Jakarta Pusat', 'Jl. Taman Cut Mutiah No. 28', '(021) 3156677'),
('Jakarta Pusat', 'Jl. Jaksa No. 5', '(021) 3192688'),
('Jakarta Pusat', 'Jl. Gereja Theresia No. 22', '(021) 3902233'),
('Jakarta Pusat', 'Jl. Prinsen Park No. 3', '(021) 3441122'),
('Jakarta Pusat', 'Jl. Kenari No. 50', '(021) 3924455'),
('Jakarta Pusat', 'Jl. Pegangsaan Timur No. 17', '(021) 3150099'),

-- Jakarta Selatan (45 cabang)
('Jakarta Selatan', 'Jl. Melawai Raya No. 1, Blok M', '(021) 7206543'),
('Jakarta Selatan', 'Jl. TB Simatupang No. 2, Cilandak', '(021) 75931456'),
('Jakarta Selatan', 'Jl. RS Fatmawati No. 15', '(021) 7501234'),
('Jakarta Selatan', 'Jl. Kemang Raya No. 43', '(021) 7198765'),
('Jakarta Selatan', 'Jl. Cassablanca Raya, Kota Kasablanka', '(021) 29488899'),
('Jakarta Selatan', 'Jl. Prof. Dr. Satrio, Kuningan City', '(021) 52963388'),
('Jakarta Selatan', 'Jl. Gatot Subroto Kav. 18', '(021) 52961177'),
('Jakarta Selatan', 'Jl. Pakubuwono VI No. 70', '(021) 72789012'),
('Jakarta Selatan', 'Jl. Panglima Polim Raya No. 81', '(021) 72555123'),
('Jakarta Selatan', 'Jl. Wolter Monginsidi No. 63', '(021) 72678901'),
('Jakarta Selatan', 'Jl. Wijaya II No. 37', '(021) 7208833'),
('Jakarta Selatan', 'Jl. Hang Lekir No. 12', '(021) 7227744'),
('Jakarta Selatan', 'Jl. Senopati No. 89', '(021) 7208855'),
('Jakarta Selatan', 'Jl. Gunawarman No. 55', '(021) 7207766'),
('Jakarta Selatan', 'Jl. Cipete Raya No. 35', '(021) 7690088'),
('Jakarta Selatan', 'Jl. Antasari Raya No. 22', '(021) 7697799'),
('Jakarta Selatan', 'Jl. Prapanca Raya No. 40', '(021) 7208844'),
('Jakarta Selatan', 'Jl. Brawijaya Raya No. 26', '(021) 7258833'),
('Jakarta Selatan', 'Jl. Gandaria Tengah No. 15', '(021) 7256677'),
('Jakarta Selatan', 'Jl. Tebet Raya No. 77', '(021) 8305566'),
('Jakarta Selatan', 'Jl. Warung Buncit Raya No. 99', '(021) 7940088'),
('Jakarta Selatan', 'Jl. Tendean No. 50', '(021) 5254455'),
('Jakarta Selatan', 'Jl. Mampang Prapatan No. 108', '(021) 7947733'),
('Jakarta Selatan', 'Jl. Pasar Minggu Raya No. 15', '(021) 7970088'),
('Jakarta Selatan', 'Jl. Radio Dalam Raya No. 28', '(021) 7208822'),
('Jakarta Selatan', 'Jl. Ciputat Raya No. 67', '(021) 7660099'),
('Jakarta Selatan', 'Jl. Ciledug Raya No. 85', '(021) 7658833'),
('Jakarta Selatan', 'Jl. Bangka Raya No. 42', '(021) 7208811'),
('Jakarta Selatan', 'Jl. Barito No. 19', '(021) 7207722'),
('Jakarta Selatan', 'Jl. Benda Raya No. 1A', '(021) 7697722'),
('Jakarta Selatan', 'Jl. Mahakam No. 31', '(021) 7208800'),
('Jakarta Selatan', 'Jl. Suryo No. 24', '(021) 7207733'),
('Jakarta Selatan', 'Jl. Iskandarsyah Raya No. 66', '(021) 7208844'),
('Jakarta Selatan', 'Jl. Dharmawangsa No. 52', '(021) 7256688'),
('Jakarta Selatan', 'Jl. Tulodong Bawah No. 18', '(021) 7208855'),
('Jakarta Selatan', 'Jl. Kebayoran Baru No. 33', '(021) 7207744'),
('Jakarta Selatan', 'Jl. Senayan City Mall Lt. 2', '(021) 7278811'),
('Jakarta Selatan', 'Jl. Pacific Place SCBD Lt. 5', '(021) 5154422'),
('Jakarta Selatan', 'Jl. Pondok Indah Mall 1 Lt. 1', '(021) 7506677'),
('Jakarta Selatan', 'Jl. Gandaria City Lt. 3', '(021) 2905544'),
('Jakarta Selatan', 'Jl. Kalibata City Mall Lt. 2', '(021) 7988833'),
('Jakarta Selatan', 'Jl. Cilandak Town Square Lt. 1', '(021) 7505544'),
('Jakarta Selatan', 'Jl. Lippo Mall Kemang Lt. 3', '(021) 7197733'),
('Jakarta Selatan', 'Jl. Plaza Semanggi Lt. 3', '(021) 2554422'),
('Jakarta Selatan', 'Jl. ITC Kuningan Lt. 2', '(021) 5267733'),

-- Jakarta Timur (30 cabang)
('Jakarta Timur', 'Jl. Pemuda No. 2, Rawamangun', '(021) 47862891'),
('Jakarta Timur', 'Jl. I Gusti Ngurah Rai No. 1', '(021) 86612345'),
('Jakarta Timur', 'Jl. Raden Intan No. 55, Kalimalang', '(021) 86507890'),
('Jakarta Timur', 'Jl. Jatinegara Timur No. 44', '(021) 85905678'),
('Jakarta Timur', 'Jl. Buaran Raya No. 88', '(021) 86914567'),
('Jakarta Timur', 'Jl. Cipinang Jaya No. 33', '(021) 85234567'),
('Jakarta Timur', 'Jl. Pondok Kelapa Raya No. 77', '(021) 86445678'),
('Jakarta Timur', 'Jl. Cililitan Besar No. 99', '(021) 80891234'),
('Jakarta Timur', 'Jl. Taman Mini Raya No. 15', '(021) 84561234'),
('Jakarta Timur', 'Jl. Raya Bekasi KM 18', '(021) 46789012'),
('Jakarta Timur', 'Jl. Pahlawan Revolusi No. 12', '(021) 86615544'),
('Jakarta Timur', 'Jl. Raya Bogor KM 19', '(021) 80895544'),
('Jakarta Timur', 'Jl. Klender Raya No. 40', '(021) 86603322'),
('Jakarta Timur', 'Jl. Dewi Sartika No. 75', '(021) 85905544'),
('Jakarta Timur', 'Jl. Matraman Raya No. 50', '(021) 85702233'),
('Jakarta Timur', 'Jl. Tamini Square Lt. 2', '(021) 84562233'),
('Jakarta Timur', 'Jl. Cakung Cilincing No. 33', '(021) 46782233'),
('Jakarta Timur', 'Jl. Kramat Jati No. 68', '(021) 80892233'),
('Jakarta Timur', 'Jl. Duren Sawit Raya No. 25', '(021) 86445544'),
('Jakarta Timur', 'Jl. Pulo Gadung No. 27', '(021) 47865544'),
('Jakarta Timur', 'Jl. Rawamangun Muka Raya No. 10', '(021) 47502233'),
('Jakarta Timur', 'Jl. Cipinang Muara No. 45', '(021) 85232233'),
('Jakarta Timur', 'Jl. Otista Raya No. 64', '(021) 85902233'),
('Jakarta Timur', 'Jl. Penggilingan Raya No. 18', '(021) 46785544'),
('Jakarta Timur', 'Jl. Pondok Bambu Raya No. 55', '(021) 86442233'),
('Jakarta Timur', 'Jl. Halim Perdanakusuma No. 8', '(021) 80895544'),
('Jakarta Timur', 'Jl. Metropolitan Mall Bekasi Lt. 3', '(021) 88605544'),
('Jakarta Timur', 'Jl. Green Terrace AEON Mall Lt. 2', '(021) 29457733'),
('Jakarta Timur', 'Jl. Cijantung Mall Lt. 1', '(021) 87795544'),
('Jakarta Timur', 'Jl. Arion Mall Lt. 2', '(021) 47865544'),

-- Jakarta Barat (25 cabang lengkap)
('Jakarta Barat', 'Jl. S. Parman Kav. 21, Slipi', '(021) 5307890'),
('Jakarta Barat', 'Jl. Puri Indah Raya Blok U1', '(021) 58357123'),
('Jakarta Barat', 'Jl. Daan Mogot No. 47', '(021) 56789012'),
('Jakarta Barat', 'Jl. Tanjung Duren Raya No. 88', '(021) 56123456'),
('Jakarta Barat', 'Jl. Kebon Jeruk Raya No. 66', '(021) 53456789'),
('Jakarta Barat', 'Jl. Mangga Besar Raya No. 55', '(021) 62345678'),
('Jakarta Barat', 'Jl. Kembangan Raya No. 41', '(021) 58901234'),
('Jakarta Barat', 'Jl. Greenvile No. 78', '(021) 56782345'),
('Jakarta Barat', 'Jl. Meruya Ilir Raya No. 29', '(021) 58567890'),
('Jakarta Barat', 'Jl. Pos Pengumben Raya No. 93', '(021) 53234567'),
('Jakarta Barat', 'Jl. Palmerah Barat No. 30', '(021) 5482233'),
('Jakarta Barat', 'Jl. Kedoya Raya No. 52', '(021) 5824455'),
('Jakarta Barat', 'Jl. Tambora Raya No. 15', '(021) 6905544'),
('Jakarta Barat', 'Jl. Central Park Mall Lt. 3', '(021) 5682233'),
('Jakarta Barat', 'Jl. Mall Taman Anggrek Lt. 2', '(021) 5639922'),
('Jakarta Barat', 'Jl. Puri Mall Lt. 1', '(021) 5822233'),
('Jakarta Barat', 'Jl. Seasons City Mall Lt. 2', '(021) 5552233'),
('Jakarta Barat', 'Jl. Mall Ciputra Lt. 3', '(021) 5662233'),
('Jakarta Barat', 'Jl. Green Pramuka Mall Lt. 1', '(021) 5682233'),
('Jakarta Barat', 'Jl. Latumenten Raya No. 33', '(021) 5602233'),
('Jakarta Barat', 'Jl. Jembatan Besi Raya No. 45', '(021) 5612233'),
('Jakarta Barat', 'Jl. Grogol Raya No. 67', '(021) 5622233'),
('Jakarta Barat', 'Jl. Joglo Raya No. 38', '(021) 5852233'),
('Jakarta Barat', 'Jl. Kamal Raya No. 22', '(021) 5542233'),
('Jakarta Barat', 'Jl. Cengkareng Raya No. 50', '(021) 5502233'),

-- Bandung (35 cabang)
('Bandung', 'Jl. Merdeka No. 56', '(022) 4205678'),
('Bandung', 'Jl. Asia Afrika No. 81', '(022) 4238899'),
('Bandung', 'Jl. Gatot Subroto No. 289', '(022) 7308956'),
('Bandung', 'Jl. Pasir Kaliki No. 121', '(022) 6011234'),
('Bandung', 'Jl. Buah Batu No. 157', '(022) 7310123'),
('Bandung', 'Jl. Dipatiukur No. 72', '(022) 2506789'),
('Bandung', 'Jl. Sukajadi No. 131', '(022) 2034567'),
('Bandung', 'Jl. Setiabudi No. 170A', '(022) 2017890'),
('Bandung', 'Jl. Cihampelas No. 160', '(022) 2002233'),
('Bandung', 'Jl. Braga No. 45', '(022) 4208877'),
('Bandung', 'Paris Van Java Mall Lt. 2', '(022) 2103344'),
('Bandung', 'Trans Studio Mall Lt. 3', '(022) 4218899'),
('Bandung', 'Bandung Indah Plaza Lt. 1', '(022) 4205544'),
('Bandung', 'Festival Citylink Lt. 2', '(022) 4236677'),
('Bandung', 'Istana Plaza Lt. 3', '(022) 4239988'),
('Bandung', 'Jl. Kopo No. 222', '(022) 5230011'),
('Bandung', 'Jl. Soekarno Hatta No. 590', '(022) 7565544'),
('Bandung', 'Jl. Jakarta No. 45', '(022) 7318899'),
('Bandung', 'Jl. Riau No. 168', '(022) 2506677'),
('Bandung', 'Metro Indah Mall Lt. 2', '(022) 7318877'),
('Bandung', 'Lucky Square Mall Lt. 1', '(022) 4236688'),
('Bandung', 'Jl. Terusan Jakarta No. 75', '(022) 7102233'),
('Bandung', 'Jl. Ir. H. Juanda No. 180', '(022) 2507788'),
('Bandung', 'Jl. Pajajaran No. 123', '(022) 6039988'),
('Bandung', 'Jl. Lengkong Besar No. 44', '(022) 4236699'),
('Bandung', 'Jl. Pasirkoja No. 89', '(022) 5236677'),
('Bandung', 'Jl. PHH. Mustofa No. 55', '(022) 7208899'),
('Bandung', 'Jl. Cibaduyut No. 122', '(022) 5401122'),
('Bandung', 'Jl. Ciwastra No. 233', '(022) 7561122'),
('Bandung', 'Jl. Antapani Raya No. 54', '(022) 7208877'),
('Bandung', 'Jl. Ujung Berung No. 167', '(022) 7861122'),
('Bandung', 'Jl. Sudirman No. 321', '(022) 4236655'),
('Bandung', 'Jl. BKR No. 112', '(022) 5206677'),
('Bandung', 'Bandung Electronic Center Lt. 3', '(022) 4238866'),
('Bandung', 'Jl. Dago No. 145', '(022) 2506644'),

-- Bogor (20 cabang)
('Bogor', 'Jl. Pajajaran No. 27', '(0251) 8347890'),
('Bogor', 'Jl. Sudirman No. 65', '(0251) 8356677'),
('Bogor', 'Botani Square Lt. 2', '(0251) 8400123'),
('Bogor', 'Bogor Trade Mall Lt. 1', '(0251) 8392233'),
('Bogor', 'Mall Bogor Indah Plaza Lt. 2', '(0251) 8346677'),
('Bogor', 'Jl. Raya Tajur No. 123', '(0251) 8375544'),
('Bogor', 'Jl. Siliwangi No. 88', '(0251) 8378899'),
('Bogor', 'Jl. Raya Padjajaran No. 100', '(0251) 8347788'),
('Bogor', 'Jl. Surya Kencana No. 55', '(0251) 8310011'),
('Bogor', 'Jl. Raya Dramaga No. 77', '(0251) 8622233'),
('Bogor', 'Mall Ekalokasari Lt. 2', '(0251) 8348899'),
('Bogor', 'Lippo Plaza Bogor Lt. 1', '(0251) 8346688'),
('Bogor', 'Jl. Soleh Iskandar No. 44', '(0251) 8722233'),
('Bogor', 'Jl. KH. Sholeh Iskandar No. 120', '(0251) 8723344'),
('Bogor', 'Jl. Raya Cibinong No. 89', '(0251) 8900123'),
('Bogor', 'Jl. Mayor Oking No. 67', '(0251) 8356688'),
('Bogor', 'Cibinong City Mall Lt. 2', '(0251) 8901234'),
('Bogor', 'Jl. Tegar Beriman No. 45', '(0251) 8902233'),
('Bogor', 'Jl. Raya Bogor No. 235', '(0251) 8344455'),
('Bogor', 'Jl. Yasmin No. 78', '(0251) 8346699'),

-- Bekasi (25 cabang)
('Bekasi', 'Jl. Ahmad Yani No. 12', '(021) 88962345'),
('Bekasi', 'Summarecon Mall Bekasi Lt. 2', '(021) 88965544'),
('Bekasi', 'Metropolitan Mall Bekasi Lt. 3', '(021) 88967788'),
('Bekasi', 'Bekasi Cyber Park Lt. 1', '(021) 88964455'),
('Bekasi', 'Grand Metropolitan Mall Lt. 2', '(021) 88968899'),
('Bekasi', 'Jl. Juanda No. 156', '(021) 88963366'),
('Bekasi', 'Jl. Raya Bekasi Timur No. 88', '(021) 88962233'),
('Bekasi', 'Jl. Cut Mutia No. 45', '(021) 88965566'),
('Bekasi', 'Jl. Kalimalang Raya No. 67', '(021) 88967722'),
('Bekasi', 'Jl. Raya Jatibening No. 123', '(021) 88964477'),
('Bekasi', 'Mall Pondok Gede Lt. 2', '(021) 88968833'),
('Bekasi', 'Blu Plaza Bekasi Lt. 1', '(021) 88963344'),
('Bekasi', 'Jl. Raya Industri No. 78', '(021) 88965577'),
('Bekasi', 'Jl. Kemakmuran No. 92', '(021) 88967744'),
('Bekasi', 'Jl. Pramuka No. 134', '(021) 88964466'),
('Bekasi', 'Jl. Raya Tambun No. 55', '(021) 88968844'),
('Bekasi', 'Jl. Siliwangi No. 167', '(021) 88963355'),
('Bekasi', 'Jl. Sultan Hasanuddin No. 89', '(021) 88965588'),
('Bekasi', 'AEON Mall Lt. 2', '(021) 88967755'),
('Bekasi', 'Mall Ciputra Cibubur Lt. 3', '(021) 88964488'),
('Bekasi', 'Jl. Raya Narogong No. 112', '(021) 88968855'),
('Bekasi', 'Jl. Raya Jatiwaringin No. 76', '(021) 88963377'),
('Bekasi', 'Jl. Raya Hankam No. 143', '(021) 88965599'),
('Bekasi', 'Jl. Raya Bekasi Barat No. 90', '(021) 88967766'),
('Bekasi', 'Jl. Raya Cikarang No. 234', '(021) 88964499'),

-- Depok (15 cabang)
('Depok', 'Jl. Margonda Raya No. 1', '(021) 77891234'),
('Depok', 'ITC Depok Lt. 2', '(021) 77895544'),
('Depok', 'Depok Town Square Lt. 3', '(021) 77897788'),
('Depok', 'Mall Cimanggis Lt. 1', '(021) 77894455'),
('Depok', 'Margo City Lt. 2', '(021) 77898899'),
('Depok', 'Jl. Raya Citayam No. 45', '(021) 77893366'),
('Depok', 'Jl. Raya Bojongsari No. 67', '(021) 77892233'),
('Depok', 'Jl. Raya Sawangan No. 89', '(021) 77895566'),
('Depok', 'Jl. Tanah Baru No. 123', '(021) 77897722'),
('Depok', 'Jl. Raya Cinere No. 56', '(021) 77894477'),
('Depok', 'D Mall Depok Lt. 2', '(021) 77898833'),
('Depok', 'Plaza Depok Lt. 1', '(021) 77893344'),
('Depok', 'Jl. Raya Kukusan No. 78', '(021) 77895577'),
('Depok', 'Jl. Meruyung No. 90', '(021) 77897744'),
('Depok', 'Jl. Raya Limo No. 112', '(021) 77894466'),

-- Cirebon (10 cabang)
('Cirebon', 'Jl. Siliwangi No. 117', '(0231) 234567'),
('Cirebon', 'Grage Mall Lt. 2', '(0231) 235544'),
('Cirebon', 'Jl. Kartini No. 55', '(0231) 237788'),
('Cirebon', 'Cirebon Super Block Lt. 1', '(0231) 234455'),
('Cirebon', 'Jl. Cipto Mangunkusumo No. 76', '(0231) 238899'),
('Cirebon', 'Jl. Dr. Cipto No. 45', '(0231) 233366'),
('Cirebon', 'Jl. Pemuda No. 89', '(0231) 232233'),
('Cirebon', 'Jl. Tuparev No. 123', '(0231) 235566'),
('Cirebon', 'Jl. Kesambi No. 67', '(0231) 237722'),
('Cirebon', 'Jl. Wahidin No. 91', '(0231) 234477'),

-- Sukabumi (8 cabang)
('Sukabumi', 'Jl. RE Martadinata No. 56', '(0266) 245678'),
('Sukabumi', 'Sukabumi Square Lt. 1', '(0266) 245544'),
('Sukabumi', 'Jl. Ahmad Yani No. 123', '(0266) 247788'),
('Sukabumi', 'Jl. Bhayangkara No. 45', '(0266) 244455'),
('Sukabumi', 'Jl. Sudirman No. 89', '(0266) 248899'),
('Sukabumi', 'Jl. Siliwangi No. 67', '(0266) 243366'),
('Sukabumi', 'Jl. Otto Iskandardinata No. 78', '(0266) 242233'),
('Sukabumi', 'Jl. Pelabuhan No. 112', '(0266) 245566'),

-- Tasikmalaya (7 cabang)
('Tasikmalaya', 'Jl. HZ Mustofa No. 345', '(0265) 345678'),
('Tasikmalaya', 'Asia Plaza Lt. 2', '(0265) 345544'),
('Tasikmalaya', 'Jl. Sutisna Senjaya No. 67', '(0265) 347788'),
('Tasikmalaya', 'Mayasari Plaza Lt. 1', '(0265) 344455'),
('Tasikmalaya', 'Jl. Yudanegara No. 89', '(0265) 348899'),
('Tasikmalaya', 'Jl. Pancasila No. 123', '(0265) 343366'),
('Tasikmalaya', 'Jl. Pasar Wetan No. 45', '(0265) 342233'),

-- Semarang
('Semarang', 'Jl. Pemuda No. 123', '(024) 8445678'),
('Semarang', 'Paragon Mall Lt. 3', '(024) 8442233'),
('Semarang', 'Jl. Pandanaran No. 45', '(024) 8443344'),
('Semarang', 'Java Mall Lt. 2', '(024) 8441122'),
('Semarang', 'Jl. Gajah Mada No. 67', '(024) 8446677'),

-- Surabaya
('Surabaya', 'Jl. Basuki Rahmat No. 234', '(031) 5678234'),
('Surabaya', 'Tunjungan Plaza Lt. 4', '(031) 5671122'),
('Surabaya', 'Jl. Raya Darmo No. 89', '(031) 5673344'),
('Surabaya', 'Galaxy Mall Lt. 2', '(031) 5675566'),
('Surabaya', 'Jl. HR Muhammad No. 45', '(031) 5674455'),

-- Yogyakarta
('Yogyakarta', 'Jl. Malioboro No. 123', '(0274) 556677'),
('Yogyakarta', 'Ambarrukmo Plaza Lt. 3', '(0274) 554433'),
('Yogyakarta', 'Jl. Kaliurang Km 5 No. 45', '(0274) 557788'),
('Yogyakarta', 'Hartono Mall Lt. 2', '(0274) 552233'),
('Yogyakarta', 'Jl. Sudirman No. 67', '(0274) 559900'),

-- Malang
('Malang', 'Jl. Kawi No. 234', '(0341) 334455'),
('Malang', 'Malang Town Square Lt. 2', '(0341) 336677'),
('Malang', 'Jl. Soekarno Hatta No. 45', '(0341) 338899'),
('Malang', 'Mall Olympic Garden Lt. 3', '(0341) 331122'),
('Malang', 'Jl. Veteran No. 78', '(0341) 333344'),

-- Solo
('Solo', 'Jl. Slamet Riyadi No. 345', '(0271) 567890'),
('Solo', 'Solo Grand Mall Lt. 2', '(0271) 565544'),
('Solo', 'Jl. Dr. Radjiman No. 67', '(0271) 567788'),
('Solo', 'Solo Paragon Lt. 3', '(0271) 564455'),
('Solo', 'Jl. Adi Sucipto No. 89', '(0271) 568899');

CREATE TABLE karyawan (
    id_pegawai INT(11) PRIMARY KEY AUTO_INCREMENT,
    id_cabang INT(12),
    fullName VARCHAR(255) NOT NULL,
    username_karyawan VARCHAR(255) NOT NULL UNIQUE,
    password_karyawan VARCHAR(255) NOT NULL,
    jabatan VARCHAR(20) NOT NULL,
    STATUS ENUM('Aktif', 'Nonaktif') NOT NULL,
    FOREIGN KEY (id_cabang) REFERENCES cabang(id_cabang)
);

INSERT INTO karyawan (id_cabang ,fullName, username_karyawan, password_karyawan, jabatan, STATUS) VALUES
(5,'Tegar Gilang', 'tegar1', '123', 'Admin', 'Aktif'),
(8,'Nicholas Nathanael', 'nicho1', '1234', 'Kasir', 'Aktif'),
(11,'Sebastian Tjandra', 'sebas1', '12345', 'Kasir', 'Aktif'),
(21,'Sean Cornelius', 'sean1', '123456', 'Manager', 'Aktif');

CREATE TABLE menu (
    id_menu INT(12) PRIMARY KEY AUTO_INCREMENT,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    id_kategori INT(12) NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    jenis VARCHAR(50),
    potongan VARCHAR(50),
    jumlah_potongan INT(2),
    include_toy TINYINT(1) DEFAULT 0,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1,
    FOREIGN KEY (id_kategori) REFERENCES kategori(id_kategori)
);

INSERT INTO menu (nama_menu, deskripsi, id_kategori, harga, jenis, potongan, jumlah_potongan, include_toy, STATUS) VALUES
-- Alacarte Chicken
('Chicken Krispy', 'Rasa renyah dan agak pedas', 1, 28000.00, 'Crispy', 'Dada', 1, 0, 1),
('Chicken Krispy', 'Rasa renyah dan agak pedas', 1, 23000.00, 'Crispy', 'Paha', 1, 0, 1),
('Chicken ORI', 'Rasa original authentic', 1, 25000.00, 'Original', 'Dada', 1, 0, 1),
('Chicken ORI', 'Rasa original authentic', 1, 20000.00, 'Original', 'Paha', 1, 0, 1),

-- Bucket
('Bucket 6', '6 CHICKEN', 2, 125000.00, NULL, NULL, 6, 0, 1),
('Bucket 9', '9 CHICKEN', 2, 175000.00, NULL, NULL, 9, 0, 1),
('Bucket 12', '12 CHICKEN', 2, 200000.00, NULL, NULL, 12, 0, 1),

-- Combo
('Super Besar 1', '1pc CHICKEN + 1 NASI + 1 MINUM + 1 SOP', 3, 40000.00, NULL, NULL, 1, 0, 1),
('Super Besar 2', '2pc CHICKEN + 1 NASi + 1 MINUM + 1 SOP', 3, 52000.00, NULL, NULL, 2, 0, 1),
('Super Family', '5pc CHICKEN + 3 NASI + 3 MINUM', 3, 120000.00, NULL, NULL, 5, 0, 1),

-- Breakfast
('Special Porridge', '1 Chicken Porridge + Hot Tea / Hot Coffee', 4, 22000.00, 'Sandwich', NULL, NULL, 0, 1),

-- Coffee
('Coffee', 'Hot Coffee', 5, 12000.00, 'Hot', NULL, NULL, 0, 1),
('Coffee', 'Cold Coffee', 5, 12000.00, 'Cold', NULL, NULL, 0, 1),

-- Kids Meal
('Chaki Kids Meal 1', '1 pc ayam Original + 1 nasi + 1 minuman + mainan', 6, 45000.00, 'Original', NULL, 1, 1, 1),

-- Dessert
('Chocolate Sundae', 'Es krim vanilla dengan sirup coklat', 7, 12000.00, NULL, NULL, NULL, 0, 1),

-- Special
('Jagoan Hemat 1', '1pc CHICKEN + 1 NASI + 1 MINUM', 8, 35000.00, NULL, NULL, 1, 0, 1),
('Jagoan Hemat 2', '2pc CHICKEN + 1 NASI + 1 MINUM', 8, 45000.00, NULL, NULL, 2, 0, 1),
('Jagoan Hemat 3', '1pc CHICKEN + 1 NASI', 8, 25000.00, NULL, NULL, 1, 0, 1),

-- Drinks
('Coca-Cola', 'Minuman bersoda', 9, 12000.00, NULL, NULL, NULL, 0, 1),
('Sprite', 'Minuman bersoda lemon', 9, 12000.00, NULL, NULL, NULL, 0, 1),
('Fanta', 'Minuman bersoda strawberry', 9, 12000.00, NULL, NULL, NULL, 0, 1),
('Air Mineral', 'Air mineral', 9, 8000.00, NULL, NULL, NULL, 0, 1),

-- Sides
('Nasi', 'Nasi putih', 10, 5000.00, NULL, NULL, NULL, 0, 1),
('French Fries', 'Kentang goreng', 10, 15000.00, NULL, NULL, NULL, 0, 1),
('Perkedel', 'Perkedel kentang', 10, 6000.00, NULL, NULL, NULL, 0, 1),
('Soup', 'Sup ayam', 10, 7000.00, NULL, NULL, NULL, 0, 1);

CREATE TABLE diskon (
    id_diskon INT(12) PRIMARY KEY AUTO_INCREMENT,
    nama_diskon VARCHAR(255) NOT NULL,
    nominal DECIMAL(20,2) NOT NULL,
    diskon_type ENUM('Persen', 'Nominal') NOT NULL,
    status_diskon ENUM('Aktif', 'Nonaktif') NOT NULL
);

-- Insert data into diskon table
INSERT INTO diskon (nama_diskon, nominal, diskon_type, status_diskon) VALUES
('Normal', 0.00, 'Nominal', 'Aktif'),
('Monday Special', 10.00, 'Persen', 'Aktif'),
('Super Sunday', 25000.00, 'Nominal', 'Aktif'),
('Birthday Special', 15.00, 'Persen', 'Aktif');

CREATE TABLE kategori(
	id_kategori INT(12)PRIMARY KEY AUTO_INCREMENT,
	nama_kategori VARCHAR(50) NOT NULL
);

INSERT INTO kategori(nama_kategori) VALUES
('Alacarte Chicken'),
('Bucket'),
('Combo'),
('Breakfast'),
('Coffee'),
('Kids Meal'),
('Dessert'),
('Spesial'),
('Drinks'),
('Sides');


CREATE TABLE h_trans (
    id_htrans INT(20) PRIMARY KEY AUTO_INCREMENT,
    tanggal_transaksi DATE NOT NULL,
    id_karyawan INT(11) NOT NULL,
    total_harga DECIMAL(12,2) NOT NULL,
    id_diskon INT(12),
    total_diskon DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (id_karyawan) REFERENCES karyawan(id_pegawai),
    FOREIGN KEY (id_diskon) REFERENCES diskon(id_diskon)
);

-- Insert data into h_trans table
INSERT INTO h_trans (tanggal_transaksi, id_karyawan, total_harga, id_diskon, total_diskon) VALUES
('2024-12-19', 1, 225000.00, 2, 25000.00),
('2024-12-19', 2, 175000.00, 3, 25000.00),
('2024-12-19', 3, 85000.00, 4, 40000.00);

CREATE TABLE stock(
    id_bahan INT(12) PRIMARY KEY AUTO_INCREMENT,
    nama VARCHAR(255) NOT NULL,
    qty INT(12)NOT NULL, 
    satuan_bahan VARCHAR(255) NOT NULL
);

-- Insert data into stock table
INSERT INTO stock (nama , qty , satuan_bahan) VALUES
('Dada Original', 100 , 'Pcs'),
('Paha Original', 100 , 'Pcs'),
('Dada Crispy', 100 , 'Pcs'),
('Paha Crispy', 100 , 'Pcs'),
('Nasi', 100 , 'Pcs'),
('Coca-Cola', 100 , 'Pcs'),
('Fanta', 100 , 'Pcs'),
('Sprite', 100 , 'Pcs'),
('Porridge', 100 , 'Pcs'),
('Coffee', 100 , 'Pcs'),
('Sundae', 100 , 'Pcs');

CREATE TABLE d_trans (
    id_dtrans INT(20) PRIMARY KEY AUTO_INCREMENT,
    id_htrans INT(20) NOT NULL,
    id_menu INT(12) NOT NULL,
    qty INT(5) NOT NULL,
    subtotal DECIMAL(20,2) NOT NULL,
    FOREIGN KEY (id_htrans) REFERENCES h_trans(id_htrans),
    FOREIGN KEY (id_menu) REFERENCES menu(id_menu)
);

-- Insert data into d_trans table
INSERT INTO d_trans (id_htrans, id_menu, qty, subtotal) VALUES
(1, 3, 1,25000.00),
(1, 6, 1,175000.00),
(1, 23, 7,35000.00),
(1, 24, 1,15000.00),
(2, 4, 1,20000.00),
(2, 17, 4,180000.00),
(3, 5, 1,125000.00);

SET FOREIGN_KEY_CHECKS=1;
