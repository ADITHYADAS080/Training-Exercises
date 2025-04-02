

 --Create table for equipment

 CREATE TABLE Equipment (
 equipment_id INT PRIMARY KEY IDENTITY(1,1),
 tag_number VARCHAR(10) NOT NULL,
 equipment_name VARCHAR(50) NOT NULL,
 category VARCHAR(50) NOT NULL,
 equipment_status VARCHAR(50),
 assigned_to INT NULL,
 purchase_date DATE NOT NULL,
 last_updated DATETIME DEFAULT GETDATE(),
 equipment_image NVARCHAR(MAX) NULL,
 FOREIGN KEY (assigned_to) REFERENCES Users(user_id) ON DELETE SET NULL);

 use equipment_tracking

SELECT * FROM Equipment

ALTER TABLE Equipment
ADD is_deleted BIT DEFAULT 0;


