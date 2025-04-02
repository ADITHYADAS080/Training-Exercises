CREATE DATABASE equipment_tracking

USE equipment_tracking

--create table for users 

DROP TABLE Users

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



--STORED PROCEDURES


--select all users
GO

ALTER PROCEDURE SPS_User
AS
BEGIN
	SELECT * FROM Users
	WHERE role = 'User'
END;
GO

--select all Admin

CREATE PROCEDURE SPS_Admin
AS
BEGIN
	SELECT * FROM Users
	WHERE role = 'Admin'
END;
GO

--Add new user

ALTER PROCEDURE SPI_User
@first_name NVARCHAR(50),
@last_name NVARCHAR(50),
@date_of_birth DATE,
@gender NVARCHAR(50),
@phone_number NVARCHAR(50),
@email NVARCHAR(50),
@department NVARCHAR(50),
@role NVARCHAR(50) = 'User',
@username NVARCHAR(50),
@password NVARCHAR(50)
AS
BEGIN
	INSERT INTO Users VALUES(
	@first_name,
	@last_name,
	@date_of_birth,
	@gender,
	@phone_number,
	@email,
	@department,
	@role,
	@username,
	@password
	)
END;
GO

--login stored procedure

ALTER PROCEDURE SP_Login
@username NVARCHAR(50),
@password NVARCHAR(50)
AS
BEGIN
	SELECT role FROM Users 
	WHERE username = @username AND password = @password
END;
GO







--EXECUTE STORED PROCEDURED

EXEC SPS_User

EXEC SPI_User 'Sneha','MG','2001-11-08','Female', '1275986523', 'sneha@gmail.com','IT', 'User', 'sneha', 'sneha123'

EXEC SPI_User 
    @first_name = 'Sneha',
    @last_name = 'MG',
    @date_of_birth = '2001-11-08',
    @gender = 'Female',
    @phone_number = '1275986523',
    @email = 'sneha@gmail.com',
    @department = 'IT',
    @username = 'sneha',
    @password = 'sneha123' 

EXEC SP_Login 'adithyadas','password'


 TRUNCATE TABLE Users



 --Create table for equipment

 CREATE TABLE Equipment (equipment_id INT PRIMARY KEY IDENTITY(1,1),
 tag_number VARCHAR(10) NOT NULL,
 equipment_name VARCHAR(50) NOT NULL,
 category VARCHAR(50) NOT NULL,
 equipment_status VARCHAR(50),
 assigned_to INT NULL,
 purchase_date DATE NOT NULL,
 last_updated DATETIME DEFAULT GETDATE(),
 equipment_image NVARCHAR(MAX) NULL,
 FOREIGN KEY (assigned_to) REFERENCES Users(user_id) ON DELETE SET NULL);


ALTER TABLE Equipment 
ADD requested_by INT NULL,
    request_status NVARCHAR(20) CHECK (request_status IN ('Pending', 'Approved', 'Rejected')) DEFAULT 'Pending',
    FOREIGN KEY (requested_by) REFERENCES Users(user_id) ON DELETE NO ACTION;

SELECT * FROM Equipment

TRUNCATE TABLE Equipment

 Use Equipment_tracking
 ALTER TABLE Equipment 
ADD equipment_image VARBINARY(MAX);

SELECT * FROM Equipment

 INSERT INTO Equipment VALUES ('sdsad444','laptop','electronic','active',1,'2025-02-25','2025-02-25');

 INSERT INTO Equipment (tag_number, equipment_name, category, equipment_status, assigned_to, purchase_date)
VALUES ('sdsad444', 'laptop', 'electronic', 'Active', null, '2025-02-25');

 --Stored procedure for select all equipments
 GO
 CREATE PROCEDURE SPS_Equipment
 AS
 BEGIN
	SELECT * FROM Equipment;
 END;
 GO

 EXEC SPS_Equipment;

 --Stored procedure for add equipment
 GO
 ALTER PROCEDURE SPI_Equipment
 @tag_number VARCHAR(10),
 @equipment_name VARCHAR(50),
 @category VARCHAR(50),
 @equipment_status VARCHAR(50),
 @assigned_to INT ,
 @purchase_date DATE,
 @last_update DATETIME,
 @equipment_image NVARCHAR(MAX) NULL,
 @requested_by INT NULL ,
 @request_status NVARCHAR(50)
 AS
 BEGIN
 INSERT INTO Equipment VALUES(@tag_number,@equipment_name,@category,@equipment_status,@assigned_to,@purchase_date,@last_update,@equipment_image,@requested_by,@request_status)
 END;
 GO

 --Stored procedure for requestEquipment
 CREATE PROCEDURE SP_RequestEquipment
    @equipment_id INT,
    @requested_by INT,
    @request_status NVARCHAR(50)
AS
BEGIN
    UPDATE Equipment
    SET requested_by = @requested_by, 
	request_status = @request_status
    WHERE equipment_id = @equipment_id;
END
GO

--stored procedure to get pending request
CREATE PROCEDURE SP_GetPendingRequests
AS
BEGIN
    SELECT equipment_id, tag_number, equipment_name, requested_by, request_status
    FROM Equipment
    WHERE request_status = 'Pending'
END
GO

EXEC SP_GetPendingRequests

CREATE PROCEDURE SP_GetRequestStatus
@requested_by INT
AS
BEGIN
    SELECT equipment_id, tag_number, equipment_name,request_status
    FROM Equipment
    WHERE requested_by = @requested_by
END
GO

EXEC SP_GetRequestStatus 21

use equipment_tracking

--stored procedure for update request astatus
CREATE PROCEDURE SP_UpdateRequestStatus
    @equipment_id INT,
    @request_status NVARCHAR(20)
AS
BEGIN
    UPDATE Equipment
    SET request_status = @request_status
    WHERE equipment_id = @equipment_id
END



CREATE PROCEDURE ApproveEquipmentRequest
 @equipment_id INT
AS
BEGIN
    UPDATE Equipment
    SET assigned_to = requested_by, 
        request_status = 'Approved',
        equipment_status = 'Assigned', 
        last_updated = GETDATE()
    WHERE equipment_id = @equipment_id;
END;

CREATE PROCEDURE RejectEquipmentRequest
 @equipment_id INT
AS
BEGIN
    UPDATE Equipment
    SET request_status = 'Rejected',
        equipment_status = 'Available', 
        last_updated = GETDATE()
    WHERE equipment_id = @equipment_id;
END;

--Create table for equipment history
CREATE TABLE EquipmentHistory (
    historyId INT IDENTITY(1,1) PRIMARY KEY,
    equipmentId INT NOT NULL,
    tagNumber NVARCHAR(50) NOT NULL,
    userId INT NOT NULL,
    approvedBy INT NOT NULL,
    assignedDate DATETIME DEFAULT GETDATE(),
    releasedDate DATETIME NULL,
    status NVARCHAR(50) NOT NULL CHECK (Status IN ('Assigned', 'Released')),
    FOREIGN KEY (EquipmentId) REFERENCES Equipment(equipment_id),
    FOREIGN KEY (UserId) REFERENCES Users(user_id),
    FOREIGN KEY (ApprovedBy) REFERENCES Users(user_id)
);

DROP TABLE EquipmentHistory

SELECT * FROM Equipment


--Stored procedure for release erquipment
ALTER PROCEDURE [dbo].[SP_ReleaseEquipment]
    @equipment_id INT,
    @user_id INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY



        UPDATE EquipmentHistory
        SET 
            ReleasedDate = GETDATE(),
            Status = 'Released'
        WHERE EquipmentId = @equipment_id AND UserId = @user_id AND Status = 'Assigned';


        UPDATE Equipment
        SET assigned_to = NULL
        WHERE equipment_id = @equipment_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

SELECT * FROM EquipmentHistory

--Stored procedure for Assigned Equipment

CREATE PROCEDURE SP_AssignedEquipment
@user_id INT
AS
BEGIN
	SELECT * FROM Equipment
	WHERE assigned_to = @user_id
END;
GO
SELECT * FROM Equipment

TRUNCATE TABLE EquipmentRequests

TRUNCATE TABLE EquipmentRequests


SELECT * FROM EquipmentHistory

TRUNCATE TABLE EquipmentHistory

 SELECT * FROM  EquipmentRequests

--Stored procedure for Equipment history
ALTER PROCEDURE SP_GetEquipmentHistory
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        eh.historyId,
        eh.equipmentId,
        e.tag_number,
        e.equipment_name,
        e.equipment_image, -- Added Equipment Image
        er.request_id,
        er.requested_by,
        eh.userId,
        eh.approvedBy,
        eh.assignedDate,
        eh.releasedDate,
        eh.status
    FROM EquipmentHistory eh
    INNER JOIN Equipment e ON eh.equipmentId = e.equipment_id
    INNER JOIN EquipmentRequests er ON eh.equipmentId = er.equipment_id -- Fetching request details

    INNER JOIN Users rq ON er.requested_by = rq.user_id 
    INNER JOIN Users ass ON eh.userId = ass.user_id 
    LEFT JOIN Users ap ON eh.approvedBy = ap.user_id 

    ORDER BY eh.assignedDate DESC;
END;



SELECT * FROM Equipment
SELECT * FROM EquipmentHistory
SELECT * FROM Users
SELECT * FROM EquipmentRequests

EXEC SP_GetEquipmentHistory
