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
    shift_id INT FOREIGN KEY REFERENCES Shift(id)
);

CREATE TABLE Category (
    id INT PRIMARY KEY IDENTITY(1,1),
    category_name NVARCHAR(50)
);

CREATE TABLE Product (
    id INT PRIMARY KEY IDENTITY(1,1),
    product_name NVARCHAR(100),
    category_id INT FOREIGN KEY REFERENCES Category(id),
    price FLOAT,
    description NVARCHAR(MAX)
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
    table_id INT FOREIGN KEY REFERENCES Tables(id),
	paid bit default 0 
);


INSERT INTO Role (role_name)
VALUES ('Staff'),
       ('Admin');

INSERT INTO Shift (shift_name, start_time, end_time)
VALUES 
    (N'Ca 1', '07:00', '12:00'),
    (N'Ca 2', '12:00', '17:00'),
    (N'Ca 3', '17:00', '22:00');


INSERT INTO Staff (fullname, address, phone_number, email, role_id, date_of_birth, cccd, password, active, shift_id)
VALUES (N'Nguyễn Đức Thắng', N'12 Phan Kế Bính', '0325043590', 'thangkccute@gmail.com', 2, '2004-08-30', '0000000', '123', 1, NULL);


INSERT INTO Category (category_name)
VALUES (N'Nước ép'),
	   (N'Nước ngọt'),
       (N'Cà phê'),
       (N'Đá xay');

INSERT INTO Product (product_name, category_id, price, description)
VALUES 
    (N'Nước ép cam', 1, 30000, N'Nước ép cam tươi mát'),
    (N'Coca Cola', 2, 20000, N'Nước ngọt có ga Coca Cola'),
    (N'Cà phê đen', 3, 25000, N'Cà phê đen nguyên chất'),
    (N'Đá xay chocolate', 4, 40000, N'Đá xay hương vị chocolate');


INSERT INTO Floors (floor_name, description)
VALUES (N'Tầng 1', N'Trong nhà'),
       (N'Tầng 2', N'Có bạt kéo thoáng mát');

INSERT INTO Tables (table_name, floor_id, number_of_seat, description, status)
VALUES 
    (N'Bàn 1', 1, 4, N'Bàn số 1 tại Tầng 1', 1),
    (N'Bàn 2', 1, 4, N'Bàn số 2 tại Tầng 1', 1),
    (N'Bàn 3', 1, 4, N'Bàn số 3 tại Tầng 1', 1),
    (N'Bàn 4', 1, 4, N'Bàn số 4 tại Tầng 1', 1),
    (N'Bàn 5', 1, 4, N'Bàn số 5 tại Tầng 1', 1),
    (N'Bàn 6', 1, 4, N'Bàn số 6 tại Tầng 1', 1),
    (N'Bàn 7', 1, 4, N'Bàn số 7 tại Tầng 1', 1),
    (N'Bàn 8', 2, 4, N'Bàn số 1 tại Tầng 2', 1),
    (N'Bàn 9', 2, 4, N'Bàn số 2 tại Tầng 2', 1),
    (N'Bàn 10', 2, 4, N'Bàn số 3 tại Tầng 2', 1),
    (N'Bàn 11', 2, 4, N'Bàn số 4 tại Tầng 2', 1),
    (N'Bàn 12', 2, 4, N'Bàn số 5 tại Tầng 2', 1),
    (N'Bàn 13', 2, 4, N'Bàn số 6 tại Tầng 2', 1);

INSERT INTO Orders (staff_id, note, order_date)
VALUES 
    (1, 'Ghi chú đơn hàng 1', '2024-11-10'),
    (1, 'Ghi chú đơn hàng 2', '2024-11-11'),
    (1, 'Ghi chú đơn hàng 3', '2024-11-12');

INSERT INTO Order_Detail (order_id, product_id, price, number_of_product, total_money, order_date, table_id, paid)
VALUES (1, 1, 30000, 2, 30000*2,'2024-11-10 12:30:00', 1, 0);
