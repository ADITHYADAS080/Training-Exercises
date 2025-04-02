CREATE DATABASE equipment_tracking

USE equipment_tracking

--create table for users 

CREATE TABLE Users (
user_id INT PRIMARY KEY IDENTITY(1,1),
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
date_of_birth DATE NOT NULL,
gender VARCHAR(50) NOT NULL,
phone_number VARCHAR(50) NOT NULL UNIQUE,
email VARCHAR(50) NOT NULL UNIQUE,
department VARCHAR(50) NOT NULL,
role VARCHAR(50) NOT NULL,
username VARCHAR(50) NOT NULL UNIQUE,
password VARCHAR(50) NOT NULL
);
98
ALTER TABLE Users
ADD  is_deleted BIT  DEFAULT 0;

UPDATE Users
SET is_deleted = 0;
