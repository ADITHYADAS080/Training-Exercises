CREATE DATABASE equipment_tracking

DROP DATABASE equipment_tracking

USE equipment_tracking;

CREATE TABLE [User] (
user_id INT PRIMARY KEY IDENTITY(1,1),
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
date_of_birth DATE NOT NULL,
gender VARCHAR(10) NOT NULL,
phone_number VARCHAR(50) UNIQUE NOT NULL,
email VARCHAR(100) UNIQUE NOT NULL,
department VARCHAR(50) NOT NULL,
role VARCHAR(50) NOT NULL,
username VARCHAR(50) UNIQUE NOT NULL,
password VARCHAR(50) NOT NULL
);
GO

--Stored procedure for select all users

CREATE PROCEDURE SP_SelectAllUser
AS
BEGIN
	SELECT * FROM [User]
END;
GO



--Stored Procedure for Add User

ALTER PROCEDURE SPI_User
@first_name NVARCHAR(50),
@last_name NVARCHAR(50),
@date_of_birth DATE,
@gender NVARCHAR(50),
@phone_number NVARCHAR(11),
@email NVARCHAR(100),
@department NVARCHAR(50),
@role NVARCHAR(50),
@username NVARCHAR(50),
@password NVARCHAR(50)
AS
BEGIN
    INSERT INTO [User]
	(
        first_name, 
        last_name, 
        date_of_birth, 
        gender, 
        phone_number, 
        email, 
        department, 
        role, 
        username, 
        password
    ) 
    VALUES (
	@first_name,
	@last_name,
	@date_of_birth,
	@gender,
	@phone_number, 
	@email, 
	@department,
	@role, 
	@username,
	@password);
END;
GO


--Stored Procedure for GetUserId

CREATE PROCEDURE SP_GetUserById
@user_id INT
AS
BEGIN
SELECT * FROM Users 
WHERE user_id = @user_id
END;
GO


--Stored Procedure for Update User


CREATE PROCEDURE SPU_User
@user_id INT,
@first_name NVARCHAR(50) = NULL,
@last_name NVARCHAR(50)= NULL,
@date_of_birth DATE= NULL,
@gender NVARCHAR(50)= NULL,
@phone_number NVARCHAR(11)= NULL,
@email NVARCHAR(100)= NULL,
@department NVARCHAR(50)= NULL,
@role NVARCHAR(50)= NULL,
@username NVARCHAR(50)= NULL,
@password NVARCHAR(50)= NULL
AS
BEGIN
	UPDATE Users
	SET 
	first_name = COALESCE(@first_name,first_name),
	last_name = COALESCE(@last_name,last_name),
	date_of_birth = COALESCE(@date_of_birth,date_of_birth),
	gender = COALESCE(@phone_number,first_name),
	phone_number = COALESCE(@phone_number,first_name),
	email = COALESCE(@email,first_name),
	department = COALESCE(@department,first_name),
	role = COALESCE(@role,first_name),
	username = COALESCE(@username,first_name),
	password = COALESCE(@password,first_name)
	WHERE user_id = @user_id
END;
GO


--Stored procedure for delete user

CREATE PROCEDURE SPD_User
@user_id INT
AS 
BEGIN
	DELETE FROM Users
	WHERE user_id = @user_id
END;
GO



EXEC SP_SelectAllUser

EXEC SPI_User  'adithyadas', 'KG', '2001-08-08', 'male', '9496519647', 'das@gmail.com', 'IT', 'admin', 'das', 'dasw33234243';


TRUNCATE TABLE [User];

