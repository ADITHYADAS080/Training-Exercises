
--STORED PROCEDURES for users


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

--------------------------------------------------------------------------------------------------------------------------------

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


----------------------------------------------------------------------------------------------------------------------------
--stored procedure for equipments


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

 -----------------------------------------------------------------------------------------------------------------------------------


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
GO8