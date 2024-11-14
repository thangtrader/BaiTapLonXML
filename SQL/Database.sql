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
    email CHAR(30),
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
    category_name CHAR(50)
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
    floor_name CHAR(50),
    description NVARCHAR(MAX)
);

CREATE TABLE Tables (
    id INT PRIMARY KEY IDENTITY(1,1),
    table_name CHAR(50),
    floor_id INT FOREIGN KEY REFERENCES Floors(id),
    number_of_seat INT,
    description NVARCHAR(MAX),
    status bit
);

CREATE TABLE Orders (
    id INT PRIMARY KEY IDENTITY(1,1),
    staff_id INT FOREIGN KEY REFERENCES Staff(id),
    note VARCHAR(150),
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
