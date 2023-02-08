create database AMPM
use  AMPM


DROP TABLE products;

CREATE TABLE products (
   code INT PRIMARY KEY ,
   nombre VARCHAR(255),
   stock INT,
   estado VARCHAR(10),
   proveedor VARCHAR(255),
   img image
);

CREATE TABLE users (
   username VARCHAR(255) PRIMARY KEY,
   password VARCHAR(255),
   name VARCHAR(255),
   last_name VARCHAR(255),
   email VARCHAR(255),
   phone VARCHAR(255),
   creation_date DATE
);


CREATE TABLE options (
   id INT PRIMARY KEY IDENTITY(1,1),
   name VARCHAR(255),
   product_code INT,
   status VARCHAR(10),
   FOREIGN KEY (product_code) REFERENCES products(code)
);
select*from options
select*from users
select*from products