CREATE DATABASE Caffe;
GO
USE Caffe;
GO
CREATE TABLE Role (
    id INT PRIMARY KEY IDENTITY(1,1),
    role_name NVARCHAR(10)
);

CREATE TABLE Shift (
    id INT PRIMARY KEY IDENTITY(1,1),
    shift_name NVARCHAR(50),
    start_time TIME,
    end_time TIME
);

CREATE TABLE Staff (
    id INT PRIMARY KEY IDENTITY(1,1),
    fullname NVARCHAR(50) NOT NULL,
    address NVARCHAR(50),
    phone_number CHAR(10),
    email VARCHAR(30),
    role_id INT FOREIGN KEY REFERENCES Role(id),
    date_of_birth DATE,
    cccd CHAR(20),
    password CHAR(100),
    active Bit,
    shift_id INT FOREIGN KEY REFERENCES Shift(id),
	image NVARCHAR(256)
);

CREATE TABLE Category (
    id INT PRIMARY KEY IDENTITY(1,1),
    category_name NVARCHAR(50)
);

CREATE TABLE Product (
    id INT PRIMARY KEY IDENTITY(1,1),
    product_name NVARCHAR(100),
    category_id INT FOREIGN KEY REFERENCES Category(id),
    image NVARCHAR(256),
    price FLOAT,
    description NVARCHAR(MAX),
    status Bit
);

CREATE TABLE Floors (
    id INT PRIMARY KEY IDENTITY(1,1),
    floor_name NVARCHAR(50),
    description NVARCHAR(MAX)
);

CREATE TABLE Tables (
    id INT PRIMARY KEY IDENTITY(1,1),
    table_name NVARCHAR(50),
    floor_id INT FOREIGN KEY REFERENCES Floors(id),
    number_of_seat INT,
    description NVARCHAR(MAX),
    status bit
);

CREATE TABLE Orders (
    id INT PRIMARY KEY IDENTITY(1,1),
    staff_id INT FOREIGN KEY REFERENCES Staff(id),
    note NVARCHAR(150),
    order_date DATE
);

CREATE TABLE Order_Detail (
    id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT FOREIGN KEY REFERENCES Orders(id),
    product_id INT FOREIGN KEY REFERENCES Product(id),
    price FLOAT,
    number_of_product INT,
    total_money FLOAT,
    order_date DATETIME,
    table_id INT FOREIGN KEY REFERENCES Tables(id)
);


INSERT INTO Role (role_name)
VALUES ('Staff'),
       ('Admin');

INSERT INTO Shift (shift_name, start_time, end_time)
VALUES 
    ('Ca 1', '07:00', '12:00'),
    ('Ca 2', '12:00', '17:00'),
    ('Ca 3', '17:00', '22:00');


INSERT INTO Staff (fullname, address, phone_number, email, role_id, date_of_birth, cccd, password, active, shift_id, image)
VALUES ('Nguyễn Đức Thắng', '12 Phan Kế Bính', '0325043590', 'thangkccute@gmail.com', 2, '2004-08-30', '0000000', '123', 1, NULL, NULL);


INSERT INTO Category (category_name)
VALUES ('Nước ép'),
	   ('Nước ngọt'),
       ('Cà phê'),
       ('Đá xay');

INSERT INTO Product (product_name, category_id, image, price, description, status)
VALUES 
    ('Nước ép cam', 1, NULL, 30000, 'Nước ép cam tươi mát', 1),
    ('Coca Cola', 2, NULL, 20000, 'Nước ngọt có ga Coca Cola', 1),
    ('Cà phê đen', 3, NULL, 25000, 'Cà phê đen nguyên chất', 1),
    ('Đá xay chocolate', 4, NULL, 40000, 'Đá xay hương vị chocolate', 1);


INSERT INTO Floors (floor_name, description)
VALUES ('Tầng 1', 'Trong nhà'),
       ('Tầng 2', 'Có bạt kéo thoáng mát');

INSERT INTO Tables (table_name, floor_id, number_of_seat, description, status)
VALUES 
    ('Bàn 1', 1, 4, 'Bàn số 1 tại Tầng 1', 1),
    ('Bàn 2', 1, 4, 'Bàn số 2 tại Tầng 1', 1),
    ('Bàn 3', 1, 4, 'Bàn số 3 tại Tầng 1', 1),
    ('Bàn 4', 1, 4, 'Bàn số 4 tại Tầng 1', 1),
    ('Bàn 5', 1, 4, 'Bàn số 5 tại Tầng 1', 1),
    ('Bàn 6', 1, 4, 'Bàn số 6 tại Tầng 1', 1),
    ('Bàn 7', 1, 4, 'Bàn số 7 tại Tầng 1', 1),
    ('Bàn 8', 2, 4, 'Bàn số 1 tại Tầng 2', 1),
    ('Bàn 9', 2, 4, 'Bàn số 2 tại Tầng 2', 1),
    ('Bàn 10', 2, 4, 'Bàn số 3 tại Tầng 2', 1),
    ('Bàn 11', 2, 4, 'Bàn số 4 tại Tầng 2', 1),
    ('Bàn 12', 2, 4, 'Bàn số 5 tại Tầng 2', 1),
    ('Bàn 13', 2, 4, 'Bàn số 6 tại Tầng 2', 1);

INSERT INTO Orders (staff_id, note, order_date)
VALUES 
    (1, 'Ghi chú đơn hàng 1', '2024-11-10'),
    (1, 'Ghi chú đơn hàng 2', '2024-11-11'),
    (1, 'Ghi chú đơn hàng 3', '2024-11-12');

INSERT INTO Order_Detail (order_id, product_id, price, number_of_product, total_money, order_date, table_id)
VALUES (1, 1, 30000, 2, 30000*2,'2024-11-10 12:30:00', 1);
