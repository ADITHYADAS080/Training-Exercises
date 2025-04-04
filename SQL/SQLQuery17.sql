USE [equipment_tracking]
GO
/****** Object:  StoredProcedure [dbo].[SP_ApproveEquipmentRequest]    Script Date: 26-03-2025 18:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_ApproveEquipmentRequest]
    @request_id INT,
    @approved_by INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY


        DECLARE @equipment_id INT, @requested_by INT, @tag_number NVARCHAR(50);

        -- Get Equipment ID and Requested By User ID
        SELECT @equipment_id = equipment_id, @requested_by = requested_by
        FROM EquipmentRequests
        WHERE request_id = @request_id;

        -- Get the tag number from Equipment table
        SELECT @tag_number = tag_number 
        FROM Equipment 
        WHERE equipment_id = @equipment_id;

        -- Approve the request
        UPDATE EquipmentRequests
        SET 
            request_status = 'Approved',
            approved_by = @approved_by,
            approval_date = GETDATE()
        WHERE request_id = @request_id;

        -- Assign the equipment to the requested user
        UPDATE Equipment
        SET assigned_to = @requested_by,
		equipment_status = 'Assigned'
        WHERE equipment_id = @equipment_id;

        -- Insert record into EquipmentHistory with tag_number
        INSERT INTO EquipmentHistory (equipmentId, tagNumber, userId, approvedBy, assignedDate, status)
        VALUES (@equipment_id, @tag_number, @requested_by, @approved_by, GETDATE(), 'Assigned');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

