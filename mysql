DROP DATABASE IF EXISTS proyekpv;
CREATE DATABASE proyekpv;
USE proyekpv;

-- Core tables
CREATE TABLE customer (
    id_customer INT(12) PRIMARY KEY AUTO_INCREMENT,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50),
    no_telp VARCHAR(30) NOT NULL UNIQUE
);

-- Insert data into customer table
INSERT INTO customer (firstName, lastName, no_telp) VALUES
('Budi', 'Santoso', '081234567890'),
('Siti', 'Rahayu', '081234567891'),
('Dedi', 'Kurniawan', '081234567892');

CREATE TABLE karyawan (
    id_pegawai INT(11) PRIMARY KEY AUTO_INCREMENT,
    fullName VARCHAR(255) NOT NULL,
    username_karyawan VARCHAR(255) NOT NULL UNIQUE,
    password_karyawan VARCHAR(255) NOT NULL,
    jabatan VARCHAR(20) NOT NULL,
    STATUS ENUM('Aktif', 'Nonaktif') NOT NULL
);

-- Insert data into karyawan table
INSERT INTO karyawan (fullName, username_karyawan, password_karyawan, jabatan, STATUS) VALUES
('Tegar Gilang', 'tegar1', '123', 'Admin', 'Aktif'),
('Nicholas Nathanael', 'nicho1', '1234', 'Kasir', 'Aktif'),
('Sebastian Tjandra', 'sebas1', '12345', 'Kasir', 'Aktif'),
('Sean Cornelius', 'sean1', '123456', 'Manager', 'Aktif');

-- Base items tables
CREATE TABLE sides (
    id_sides VARCHAR(12) PRIMARY KEY,
    nama_sides VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    qty INT(12) NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for sides table
INSERT INTO sides (id_sides, nama_sides, deskripsi, qty, harga, STATUS) VALUES
('SID001','Nasi', 'Nasi putih', 1000, 8000.00, 1),
('SID002','French Fries', 'Kentang goreng', 500, 15000.00, 1),
('SID003','Perkedel', 'Perkedel kentang', 200, 6000.00, 1),
('SID004','Soup', 'Sup ayam', 200, 7000.00, 1);

CREATE TABLE drinks (
    id_drinks VARCHAR(12) PRIMARY KEY,
    nama_drinks VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    qty INT(12) NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for drinks
INSERT INTO drinks (id_drinks, nama_drinks, deskripsi, qty, harga, STATUS) VALUES
('DRI001','Coca-Cola', 'Minuman bersoda', 500, 12000.00, 1),
('DRI002','Sprite', 'Minuman bersoda lemon', 500, 12000.00, 1),
('DRI003','Fanta', 'Minuman bersoda strawberry', 500, 12000.00, 1),
('DRI004','Air Mineral', 'Air mineral', 1000, 8000.00, 1);


-- Menu category tables
CREATE TABLE menu_utama(
    id_menu INT(12) PRIMARY KEY AUTO_INCREMENT,
    list_id VARCHAR(12)NOT NULL
);

INSERT INTO menu_utama (list_id) VALUES 
('MBU001'),
('MBU002'),
('MBU003'),
('MBU004'),
('MBR001'),
('MBR002'),
('MBR003');

CREATE TABLE menu_spesial (
    id_spesial VARCHAR(12) PRIMARY KEY,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for special menu
INSERT INTO menu_spesial (id_spesial, nama_menu, deskripsi, harga, STATUS) VALUES
('MSP001','Super Krispy Series', 'Ayam goreng dengan lapisan tepung super krispy', 45000.00, 1),
('MSP002','Zuper Krunch', 'Ayam goreng dengan lapisan krispy ekstra', 42000.00, 1),
('MSP003','Winger Combo Spesial', '5 Sayap ayam dengan saus spesial', 48000.00, 1);

CREATE TABLE menu_combo (
    id_combo VARCHAR(12) PRIMARY KEY,
    nama_combo VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    id_drinks VARCHAR(12),
    id_sides VARCHAR(12),
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1,
    FOREIGN KEY (id_drinks) REFERENCES drinks(id_drinks),
    FOREIGN KEY (id_sides) REFERENCES sides(id_sides)
);

-- Insert data for combo menu
INSERT INTO menu_combo (id_combo, nama_combo, deskripsi, id_drinks, id_sides, harga, STATUS) VALUES
('MCO001','Super Krispy Combo', '1 pc Super Krispy + Nasi + Minuman', 'DRI001', 'SID001', 55000.00, 1),
('MCO002','Zuper Krunch Combo', '1 pc Zuper Krunch + Nasi + Minuman', 'DRI001', 'SID001', 52000.00, 1),
('MCO003','Colonel Burger Combo', 'Colonel Burger + Kentang + Minuman', 'DRI001', 'SID002', 58000.00, 1);

CREATE TABLE menu_bucket (
    id_bucket VARCHAR(12) PRIMARY KEY,
    nama_bucket VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    jumlah_potongan INT(2) NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);


-- Insert data for bucket menu
INSERT INTO menu_bucket (id_bucket, nama_bucket, deskripsi, jumlah_potongan, harga, STATUS) VALUES
('MBU001','Bucket 9', '9 potong ayam', 9, 225000.00, 1),
('MBU002','Bucket 6', '6 potong ayam', 6, 175000.00, 1),
('MBU003','Wings Bucket', '12 pc spicy wings', 12, 125000.00, 1),
('MBU004','Mixed Bucket', '4 potong ayam + 6 sayap', 10, 185000.00, 1);

CREATE TABLE menu_alacarte_chicken (
    id_alacarte VARCHAR(12) PRIMARY KEY,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    jenis ENUM('Original', 'Crispy', 'Spicy') NOT NULL,
    potongan ENUM('Dada', 'Paha', 'Sayap') NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for alacarte chicken
INSERT INTO menu_alacarte_chicken (id_alacarte, nama_menu, deskripsi, jenis, potongan, harga, STATUS) VALUES
('MAC001','OR Dada', 'Original Recipe bagian dada', 'Original', 'Dada', 25000.00, 1),
('MAC002','HC Paha', 'Hot & Crispy bagian paha', 'Crispy', 'Paha', 23000.00, 1),
('MAC003','Spicy Wings', 'Spicy Chicken Wings', 'Spicy', 'Sayap', 18000.00, 1),
('MAC004','OR Sayap', 'Original Recipe bagian sayap', 'Original', 'Sayap', 18000.00, 1);

CREATE TABLE menu_kids_meal (
    id_kids VARCHAR(12) PRIMARY KEY,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    id_drinks VARCHAR(12),
    id_sides VARCHAR(12),
    include_toy TINYINT(1) NOT NULL DEFAULT 1,
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1,
    FOREIGN KEY (id_drinks) REFERENCES drinks(id_drinks),
    FOREIGN KEY (id_sides) REFERENCES sides(id_sides)
);

-- Insert data for kids meal
INSERT INTO menu_kids_meal (id_kids, nama_menu, deskripsi, id_drinks, id_sides, include_toy, harga, STATUS) VALUES
('MKM001','Chaki Meal Original', '1 pc ayam Original + nasi + minuman + mainan', 'DRI001', 'SID001', 1, 45000.00, 1),
('MKM002','Chaki Meal Crispy', '1 pc ayam Crispy + nasi + minuman + mainan', 'DRI001', 'SID001', 1, 45000.00, 1),
('MKM003','Chaki Wings', '3 pc Wings + nasi + minuman + mainan', 'DRI001', 'SID001', 1, 42000.00, 1),
('MKM004','Chaki Burger', 'Junior Burger + kentang + minuman + mainan', 'DRI001', 'SID002', 1, 40000.00, 1);

CREATE TABLE menu_breakfast (
    id_breakfast VARCHAR(12) PRIMARY KEY,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    kategori ENUM('Sandwich', 'Rice Bowl', 'Platter') NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    waktu_mulai TIME NOT NULL,
    waktu_selesai TIME NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for breakfast menu
INSERT INTO menu_breakfast (id_breakfast, nama_menu, deskripsi, kategori, harga, waktu_mulai, waktu_selesai, STATUS) VALUES
('MBR001','Riser Burger', 'Burger dengan telur dan hash brown', 'Sandwich', 28000.00, '04:00:00', '11:00:00', 1),
('MBR002','Scrambled Bowl', 'Nasi dengan telur orak-arik dan ayam', 'Rice Bowl', 32000.00, '04:00:00', '11:00:00', 1),
('MBR003','KFC Breakfast Platter', 'Nasi + telur + ayam + hash brown', 'Platter', 39000.00, '04:00:00', '11:00:00', 1),
('MBR004','Chicken Porridge', 'Bubur ayam spesial', 'Rice Bowl', 25000.00, '04:00:00', '11:00:00', 1),
('MBR005','Breakfast Wrap', 'Tortilla dengan isian ayam dan telur', 'Sandwich', 27000.00, '04:00:00', '11:00:00', 1);

CREATE TABLE menu_coffee (
    id_coffee VARCHAR(12) PRIMARY KEY,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    jenis ENUM('Hot', 'Cold') NOT NULL,
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for coffee menu
INSERT INTO menu_coffee (id_coffee,nama_menu, deskripsi, jenis, harga, STATUS) VALUES
('MCF001','Americano', 'Espresso dengan air panas', 'Hot', 18000.00, 1),
('MCF002','Caffe Latte', 'Espresso dengan steamed milk', 'Hot', 22000.00, 1),
('MCF003','Cappuccino', 'Espresso dengan steamed milk dan foam', 'Hot', 22000.00, 1),
('MCF004','Iced Americano', 'Espresso dengan air dingin dan es', 'Cold', 20000.00, 1),
('MCF005','Iced Latte', 'Espresso dengan susu dingin dan es', 'Cold', 24000.00, 1),
('MCF006','Iced Cappuccino', 'Cappuccino dingin dengan es', 'Cold', 24000.00, 1);

CREATE TABLE menu_dessert (
    id_dessert VARCHAR(12) PRIMARY KEY,
    nama_menu VARCHAR(255) NOT NULL,
    deskripsi TEXT,
    harga DECIMAL(12,2) NOT NULL,
    gambar VARCHAR(255),
    STATUS TINYINT(1) NOT NULL DEFAULT 1
);

-- Insert data for dessert menu
INSERT INTO menu_dessert (id_dessert, nama_menu, deskripsi, harga, STATUS) VALUES
('MDE001','Chocolate Sundae', 'Es krim vanilla dengan sirup coklat', 12000.00, 1),
('MDE002','Strawberry Sundae', 'Es krim vanilla dengan sirup strawberry', 12000.00, 1),
('MDE003','Caramel Sundae', 'Es krim vanilla dengan sirup karamel', 12000.00, 1),
('MDE004','Ice Cream Cone', 'Es krim vanilla dengan cone', 8000.00, 1),
('MDE005','Float Coca-Cola', 'Coca-Cola dengan es krim vanilla', 15000.00, 1),
('MDE006','Float Fanta', 'Fanta dengan es krim vanilla', 15000.00, 1);

-- Transaction related tables
CREATE TABLE diskon (
    id_diskon INT(12) PRIMARY KEY AUTO_INCREMENT,
    nama_diskon VARCHAR(255) NOT NULL,
    nominal DECIMAL(20,2) NOT NULL,
    diskon_type ENUM('Persen', 'Nominal') NOT NULL,
    min_voucher INT(9),
    status_diskon ENUM('Aktif', 'Nonaktif') NOT NULL
);

-- Insert data into diskon table
INSERT INTO diskon (nama_diskon, nominal, diskon_type, min_voucher, status_diskon) VALUES
('Monday Special', 10.00, 'Persen', 1, 'Aktif'),
('Super Sunday', 25000.00, 'Nominal', 2, 'Aktif'),
('Birthday Special', 15.00, 'Persen', 1, 'Aktif');

CREATE TABLE voucher (
    id_voucher VARCHAR(12) PRIMARY KEY,
    diskon_id INT(12) NOT NULL,
    customer_id INT(12) NOT NULL,
    jmlh_voucher INT(12) NOT NULL,
    status_voucher ENUM('Aktif', 'Nonaktif') NOT NULL,
    FOREIGN KEY (diskon_id) REFERENCES diskon(id_diskon),
    FOREIGN KEY (customer_id) REFERENCES customer(id_customer)
);

-- Insert data into voucher table
INSERT INTO voucher (id_voucher, diskon_id, customer_id, jmlh_voucher, status_voucher) VALUES
('VCR001', 1, 1, 2, 'Aktif'),
('VCR002', 2, 2, 3, 'Aktif'),
('VCR003', 3, 3, 1, 'Aktif');

CREATE TABLE h_trans (
    id_htrans INT(20) PRIMARY KEY AUTO_INCREMENT,
    tanggal_transaksi DATE NOT NULL,
    id_karyawan INT(11) NOT NULL,
    total_harga DECIMAL(12,2) NOT NULL,
    id_voucher VARCHAR(12),
    total_diskon DECIMAL(12,2) NOT NULL,
    status_transaksi ENUM('Lunas', 'Belum Lunas', 'Dibatalkan') NOT NULL,
    FOREIGN KEY (id_karyawan) REFERENCES karyawan(id_pegawai),
    FOREIGN KEY (id_voucher) REFERENCES voucher(id_voucher)
);

-- Insert data into h_trans table
INSERT INTO h_trans (tanggal_transaksi, id_karyawan, total_harga, id_voucher, total_diskon, status_transaksi) VALUES
('2024-12-19', 1, 225000.00, 'VCR001', 22500.00, 'Lunas'),
('2024-12-19', 2, 175000.00, 'VCR002', 25000.00, 'Lunas'),
('2024-12-19', 3, 85000.00, 'VCR003', 12750.00, 'Lunas');

CREATE TABLE d_trans (
    id_dtrans INT(20) PRIMARY KEY AUTO_INCREMENT,
    id_htrans INT(20) NOT NULL,
    id_menu INT(12) NOT NULL,
    qty INT(5) NOT NULL,
    subtotal DECIMAL(20,2) NOT NULL,
    FOREIGN KEY (id_htrans) REFERENCES h_trans(id_htrans),
    FOREIGN KEY (id_menu) REFERENCES menu_utama (id_menu)
);

-- Insert data into d_trans table
INSERT INTO d_trans (id_htrans, id_menu, qty, subtotal) VALUES
(1, 3, 1, 225000.00),
(2, 4, 1,175000.00),
(3, 5, 1,85000.00);

CREATE TABLE stock(
    id_bahan INT(12) PRIMARY KEY AUTO_INCREMENT,
    nama VARCHAR(255) NOT NULL,
    qty INT(12)NOT NULL, 
    satuan_bahan VARCHAR(255) NOT NULL
);

-- Insert data into stock table
INSERT INTO stock (nama , qty , satuan_bahan) VALUES
('Ham', 200 , 'Pcs'),
('Selada', 259 , 'Pcs'),
('Tomat', 1167 , 'Pcs'),
('Chicken Wings', 407 , 'Pcs'),
('Upper Chicken Breast', 482 , 'Pcs'),
('Upper Chicken Thigh', 424 , 'Pcs'),
('Lower Chicken Breast', 467 , 'Pcs'),
('Lower Chicken Thigh', 486 , 'Pcs'),
('Chilli', 3245 , 'Pcs'),
('Sesame Seed Bun', 321 , 'Pcs'),
('Egg', 653 , 'Pcs'),
('Potato', 530 , 'Pcs'),
('Rice', 600 , 'Pcs'),
('Noodle', 683 , 'Pcs'),
('Mayonaise', 200 , 'Liter'),
('Nugget', 2500 , 'Pcs'),
('Cheese', 1200 , 'Pcs'),
('Soup', 514 , 'Pcs'),
('Porridge', 1200 , 'Pcs'),
('Water', 6000 , 'Liter'),
('Fanta', 6645 , 'Liter'),
('Coca-Cola', 6063 , 'Liter'),
('Milo', 6016 , 'Liter'),
('Sprite', 6361 , 'Liter');

CREATE TABLE d_menu(
     id_dmenu INT(12) PRIMARY KEY AUTO_INCREMENT, 
     id_menu_utama INT(12)NOT NULL,
     id_bahan INT(12) NOT NULL,
     qty INT(5)NOT NULL,
     FOREIGN KEY (id_menu_utama) REFERENCES menu_utama (id_menu),
     FOREIGN KEY (id_bahan) REFERENCES stock (id_bahan)
);

-- Insert data into d_menu table
INSERT INTO d_menu (id_menu_utama, id_bahan, qty) VALUES
(1, 4, 9),  -- Bucket 9, 9 potong ayam dari 'Upper Chicken Breast'
(2, 5, 6),  -- Bucket 6, 6 potong ayam dari 'Upper Chicken Thigh'
(3, 6, 12), -- Wings Bucket, 12 pc spicy wings dari 'Chicken Wings'
(4, 4, 4),  -- Mixed Bucket, 4 potong ayam dari 'Upper Chicken Breast'
(5, 6, 6);  -- Mixed Bucket, 6 sayap dari 'Chicken Wings'

CREATE TABLE cart(
     id_cart INT(12) PRIMARY KEY AUTO_INCREMENT, 
     id_menu_utama INT(12)NOT NULL,
     qty INT(5)NOT NULL,
     subtotal INT(12)NOT NULL,
     STATUS TINYINT(1) NOT NULL,
     FOREIGN KEY (id_menu_utama) REFERENCES menu_utama (id_menu)
);
