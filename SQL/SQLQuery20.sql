USE [equipment_tracking]
GO
/****** Object:  StoredProcedure [dbo].[SP_RejectEquipmentRequest]    Script Date: 26-03-2025 20:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_RejectEquipmentRequest]
    @request_id INT,
    @approved_by INT,
	@equipment_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE EquipmentRequests
    SET 
        request_status = 'Rejected',
        approved_by = @approved_by,
        approval_date = GETDATE()
    WHERE request_id = @request_id;

		UPDATE Equipment
        SET assigned_to = NULL
        WHERE equipment_id = @equipment_id;

END;