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