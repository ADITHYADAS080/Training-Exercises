CREATE DATABASE registration;

USE registration;

CREATE TABLE users
(userId INT PRIMARY KEY IDENTITY(1,1),
userFirstName VARCHAR(50) NOT NULL,
userLastName VARCHAR(50) NOT NULL,
dateOfBirth DATE NOT NULL,
gender VARCHAR(10),
phoneNumber VARCHAR(15) NOT NULL UNIQUE,
emailAddress VARCHAR(50) UNIQUE NOT NULL,
address VARCHAR(50)NOT NULL,
state VARCHAR(50) NOT NULL,
city VARCHAR(50) NOT NULL,
username VARCHAR(50) UNIQUE NOT NULL,
password VARCHAR(50) UNIQUE NOT NULL
);




--Procedure for get all users
GO
CREATE PROCEDURE SP_GetAllUsers
AS
BEGIN
	SELECT * FROM users;
END;
GO





--Procedure for inserting user
CREATE PROCEDURE SP_InsertUser
@userFirstName VARCHAR(50), @userLastName VARCHAR(50), @dateOfBirth VARCHAR(15), @gender VARCHAR(10), @phoneNumber VARCHAR(50),@emailAddress VARCHAR(50), @address VARCHAR(50), @state VARCHAR(50), @city VARCHAR(50), @username VARCHAR(50),@password VARCHAR(50) 
AS BEGIN
	INSERT INTO users VALUES(@userFirstName, @userLastName, @dateOfBirth, @gender, @phoneNumber, @emailAddress, @address, @state, @city, @username, @password);
END;
GO



--Procedure for get user by id
ALTER PROCEDURE SP_GetUserById @userId INT
AS
BEGIN
	SELECT userId,
	[userFirstName],
	[userLastName],
	[dateOfBirth],
	[gender],
	[phoneNumber],
	[emailAddress],
	[address],
	[state],
	[city],
	[username],
	[password]
	FROM users
	WHERE userId = @userId
END;
GO



--Procedure For update user
ALTER PROCEDURE SP_UpdateUser
@userId INT,
@userFirstName NVARCHAR(50) = NULL,
@userLastName NVARCHAR(50) = NULL,
@dateOfBirth NVARCHAR(15) = NULL,
@gender NVARCHAR(10) = NULL,
@phoneNumber NVARCHAR(50) = NULL,
@emailAddress NVARCHAR(50) = NULL,
@address NVARCHAR(50)=NULL,
@state NVARCHAR(50) = NULL,
@city NVARCHAR(50) = NULL,
@username NVARCHAR(50) = NULL,
@password NVARCHAR(50) = NULL
AS 
BEGIN
	UPDATE users SET
	userFirstName = COALESCE(@userFirstName, userFirstName),
	userLastName = COALESCE(@userLastName, userLastName),
	dateOfBirth = COALESCE(@dateOfBirth, dateOfBirth),
	gender = COALESCE(@gender, gender),
	phoneNumber = COALESCE(@phoneNumber, phoneNumber),
	emailAddress = COALESCE(@emailAddress, emailAddress),
	address  = COALESCE (@address, address),
	state = COALESCE(@state, state),
	city = COALESCE(@city, city),
	username = COALESCE(@username, username),
	password = COALESCE(@password, password)
	WHERE userId = @userId
END;
GO



--Procedure for Delete users
CREATE PROCEDURE SP_DeleteUser
@userId INT
AS
BEGIN
	DELETE FROM users
	WHERE userId = @userId
END;
GO




--insert user
INSERT INTO users VALUES('Adithyadas','KG','08-08-2001','male','9496519647','adithyadas@gmail.com','perambra','kerala','thrissur','adithyadaskg','adithyadas123');




--view table data using procedure
EXEC SP_GetAllUsers;


--Using procedure Get User By id
EXEC SP_GetUserById 1

--Using Procedure to delete user
EXEC SP_DeleteUser 2


--Using Procedure to Update User
EXEC SP_UpdateUser
@userId = 1,
@username = 'arjun';



TRUNCATE TABLE users;